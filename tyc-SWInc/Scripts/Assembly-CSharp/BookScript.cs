using UnityEngine;

public class BookScript : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2((float)Random.Range(0, 2) * 0.5f, (float)Random.Range(0, 2) * 0.5f);
	}
}
