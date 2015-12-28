using UnityEngine;
using System.Collections;

public class Groundcheck : MonoBehaviour {
    private Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>(); //здійснює пошук персонажа
    }

    void OnTriggerEnter2D(Collider2D col) //перевірка зіткнення двох колайдерів
    {
        player.grounded = true;
    }

    void OnTriggerStay2d(Collider2D col) //перевірка продовження стану зіткнення
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col) //перевірка моменту виходу зі стану зіткнення
    {
        player.grounded = false;
    }







}
