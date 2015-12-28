using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour
{

    private Player player;

	//ф-я пошуку персонажа
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

	//якщо персонаж потрапляє на колайдер шипів то
	//персонаж отримує дамаг
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(2);
        }
    }
}
