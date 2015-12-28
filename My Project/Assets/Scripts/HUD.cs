using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites; //відображення здоровя

	public Image HeartUI; //відображення комірок здоровя

    private Player player;

	//пошук персонажа
    void Start()
    {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();


    }

	//ф-я відображення даного здоровя на сцені
    void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];

    }


}

