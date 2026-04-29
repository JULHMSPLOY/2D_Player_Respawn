using UnityEngine;
public class RespawnController : MonoBehaviour
{
    // ตัวแปรที่ปรับได ้ใน Inspector
    public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่
    private Rigidbody2D rb; // ตัวแปรอ ้างอิง Rigidbody2D
    // 1. ตัวแปรสำ หรับ Player และ Respawn Point
    public GameObject player;
    public Transform respawnPoint;

    void Start()
    {
        // รับคอมโพเนนต์ Rigidbody2D เมื่อเริ่มต ้น
        rb = GetComponent<Rigidbody2D>();
    } 
    void Update()
    {
        // 1. รับค่า Input ในแนวนอน (Horizontal)
        // จะมีค่าเป็น -1 (ซ ้าย), 0 (ไม่มีการกด), หรือ 1 (ขวา)
        float moveInput = Input.GetAxisRaw("Horizontal");

        // 2. สร ้าง Vector2 สำ หรับการเคลื่อนที่
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // 3. กำ หนดความเร็วใหม่ให ้กับ Rigidbody2D
        rb.velocity = moveVelocity;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player ชนกับ Hazard! กำ ลัง Respawn...");
        if (other.CompareTag("Hazard"))
        {
            // Debug.Log() เพื่อดูค่าตำ แหน่ง (Vector3) ของจุดเกิดใหม่
            Debug.Log("Respawn ที่ตำ แหน่ง: " + respawnPoint.position);
            player.transform.position = respawnPoint.position;
        }
    }
}