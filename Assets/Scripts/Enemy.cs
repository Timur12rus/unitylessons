using UnityEngine;

public class Enemy : MonoBehaviour
{
    // когда объекты сталкиваются
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Произошло столкновение!");
        }
    }

    // когда объекты соприкосаются
    private void onCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            print("Stay");
        }
    }

    // когда объекты прекращают сталкиваться
    private void onCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("Объекты прекратили столкновение!");
        }
    }
}
