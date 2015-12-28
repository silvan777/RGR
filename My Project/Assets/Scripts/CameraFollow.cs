using UnityEngine;
using System.Collections;

//створення змінних
public class CameraFollow : MonoBehaviour {
    private Vector2 velocity;

    public float smoothTimeY; //швидкість руху камери по у
	public float smoothTimeX; //швидкість руху камери по х

    public GameObject player;

    public bool bounds; //відповідає за межі камери

    public Vector3 minCameraPos; //мін. позицію камери
    public Vector3 maxCameraPos; //макс. позиція камери

	//пошук персонажа
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
	}
	//ф-я фокусування камери на персонажа
	void Update () {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
		//встановлення межі камери відносно сцени
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
                
        }
    }
	//ф-я задання мін.позиції камери
   public void SetMinPosition()
    {
        minCameraPos = gameObject.transform.position;

    }
	//ф-я задання макс.позиції камери
   public void SetMaxPosition()
    {
        maxCameraPos = gameObject.transform.position;
    }
}
