using UnityEngine;
using UnityEngine.Timeline;

public class EnemyChase : MonoBehaviour
{
    [Header("Settings")]
    public float chaseRange = 5f;        // ׷����ʼ����
    public float closeDistance = 2f;     // ��ӡ"�ӽ�"���ٽ����
    public float moveSpeed = 3f;         // �����ƶ��ٶ�

    private Transform player;            // ���Transform����
    private bool isChasing = false;      // �Ƿ�����׷��


    void Start()
    {
        // ��ȡ��Ҷ��󣨼��������"Player"��ǩ��
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("δ�ҵ���Ҷ�����ȷ���������д���'Player'��ǩ�Ķ���");
        }
    }
    public GameObject texiao;

    void Update()
    {
        if (player == null) return;

        // ��������ҵľ���
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // ����Ƿ���׷����Χ��
        if (distanceToPlayer <= chaseRange)
        {
            if (!isChasing)
            {
                isChasing = true;
            }

            // �ƶ������
            MoveTowardsPlayer();

            // ����Ƿ�ﵽ�ٽ����
            if (distanceToPlayer <= closeDistance)
            {
                this.gameObject.SetActive(false);
                master.score++;
                Instantiate(texiao, this.gameObject.transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (isChasing)
            {
                isChasing = false;
            }
        }
    }
    public Master master;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "fire")
        {
            this.gameObject.SetActive(false);
            master.score++;
            Instantiate(texiao, this.gameObject.transform.position, Quaternion.identity);
        }
    }


    void MoveTowardsPlayer()
    {
        // �����ƶ�����
        Vector3 direction = (player.position - transform.position).normalized;

        // �ƶ�����
        transform.position += direction * moveSpeed * Time.deltaTime;

        // ��ѡ���õ����������
        transform.LookAt(player);
    }

    // ��ѡ���ڱ༭���п��ӻ�׷����Χ
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeDistance);
    }
}