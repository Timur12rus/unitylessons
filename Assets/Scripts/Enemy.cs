using UnityEngine;

public class Enemy : MonoBehaviour
{
    // когда объекты сталкиваются
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Произошло столкновение!");
        }
    }

    // когда объекты соприкосаются
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            Debug.Log("Stay");
        }
    }

    // когда объекты прекращают сталкиваться
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Объекты прекратили столкновение!");
        }
    }
}
