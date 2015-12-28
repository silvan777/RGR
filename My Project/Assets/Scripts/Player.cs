using UnityEngine;
using System.Collections;

//глобальні змінні Player
public class Player : MonoBehaviour {
    public float maxSpeed = 3; //відповідає за макс. швидкість
    public float speed = 50f; //відповідає за швидкість руху
    public float jumpPower = 150f; //відповідає за силу прижка

    public bool grounded; //логічна змінна землі
    public bool canDoubleJump; //логічна змінна стрибка

    public int curHealth; //змінна здоровя
    public int maxHealth = 100; //відповідає за максимальну к-ь здоровя

    private Rigidbody2D rb2d; //змінна фіз. властивостей
    private Animator anim; //змінна анімації

	//відповідає за сцену
	void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth; //змінна приймає з-ння макс. здоровя
	}
	
	//ф-я яка відповідає за події персонаж
	void Update ()
    {
        anim.SetBool("Grounded", grounded); //відовідає за логічну змінну землі
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x)); //вказуємо 
        if (Input.GetAxis("Horizontal") < 0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1); //здійснюєтся переміщення ліворуч
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
			transform.localScale = new Vector3(1, 1, 1); //здійснюєтся переміщення праворуч
        }

        if (Input.GetButtonDown("Jump") ) //якщо натиснути на кнопку стрибку, то
        {
            if(grounded) //якщо знаходится на землі то відбуваєтся стрибок 
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {
                if (canDoubleJump) //якщо не на землі то відбуваєтся ще стрибок
                {
					canDoubleJump = true;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0) ;
                    rb2d.AddForce(Vector2.up / 1.75f);
                }
                
            }
        }



        if(curHealth > maxHealth) //якщо дане здоровя більше ніж макс.
        {
            curHealth = maxHealth; //то к-ь макс. прирівнюєтся до даного
        }

        if(curHealth <= 0) //якщо здоровя <= 0 то 
        {
            Die(); //персонаж помирає
        }


    }

	//ф-я налаштування руху
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); //змінна приймає з-ння х
        if(grounded) //якщо на землі
        rb2d.AddForce((Vector2.right * speed) * h); //здійснюється рух по х з заданаю швидкістю
        //встановлення ліміту макс. швидкості
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
			
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y); 
        }
    }

	//ф-я смерті
    void Die()
    {
        Application.LoadLevel(Application.loadedLevel); //якщо персонаж помер то перезапуск сцени
    }

	//ф-я яка відовідає за дамаг
    public void Damage(int dmg)
    {
        if (curHealth < dmg) { dmg = curHealth; } //якщо дане здоровя менше дамага
        curHealth -= dmg; //він приймає залишок
    }
}
