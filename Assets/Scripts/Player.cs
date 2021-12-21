using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb; // для хранения RigidBody
    public float speed; // скорость
    public float jumpHeight;    // высота прыжка

    public Transform groundCheck;  // точка, с помощью которой мы будем проверять, находится персонаж
    // на земле или нет

    public float checkRadius;   // радиус вокруг нашей точки groundCheck, который мы будем проверять

    private bool isGrounded;        // переменная сугубо для нашего персонажа, хранит состояние 

    Animator anim;

    // Start is called b efore the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   // присвоили переменной rb объект RigidBody
        anim = GetComponent<Animator>();
    }

    // метод графического движка, срабатывает каждый кадр
    void Update()
    {

        CheckGround();
        if (Input.GetAxis("Horizontal") == 0 && (isGrounded))
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            Flip();
            if (isGrounded)
            {
                anim.SetInteger("State", 2);
            }
        }

        // класс Input отвечает за ввод, двигаем мышкой, нажимает клавиши и т.д. Здесь отвечает
        // за ввод по горизонтали
        // если кнопка "влево", это всё равно будет = -1, если вправо, то = 1
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    // метод обновления физического движка, не зависит от частоты кадров и вызывается сам,по таймеру
    // в этом методе нужно работать с физикой
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        // {
        //     rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        // }
    }

    // метод разворачивает персонажа игрока
    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, checkRadius);
        isGrounded = colliders.Length > 1;
        if (!isGrounded)
        {
            anim.SetInteger("State", 3);
        }
    }
}
