using UnityEngine;
using UnityEngine.Timeline;

public class EnemyChase : MonoBehaviour
{
    [Header("Settings")]
    public float chaseRange = 5f;        // 追击开始距离
    public float closeDistance = 2f;     // 打印"接近"的临界距离
    public float moveSpeed = 3f;         // 敌人移动速度

    private Transform player;            // 玩家Transform引用
    private bool isChasing = false;      // 是否正在追击


    void Start()
    {
        // 获取玩家对象（假设玩家有"Player"标签）
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("未找到玩家对象，请确保场景中有带有'Player'标签的对象");
        }
    }
    public GameObject texiao;

    void Update()
    {
        if (player == null) return;

        // 计算与玩家的距离
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // 检查是否在追击范围内
        if (distanceToPlayer <= chaseRange)
        {
            if (!isChasing)
            {
                isChasing = true;
            }

            // 移动向玩家
            MoveTowardsPlayer();

            // 检查是否达到临界距离
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
        // 计算移动方向
        Vector3 direction = (player.position - transform.position).normalized;

        // 移动敌人
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 可选：让敌人面向玩家
        transform.LookAt(player);
    }

    // 可选：在编辑器中可视化追击范围
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeDistance);
    }
}