using UnityEngine;

public class ScrollingUV : MonoBehaviour
{
	public float ScrollX = 0.5f;

	public float ScrollY = 0.5f;

	private void FixedUpdate()
	{
		float x = Time.time * ScrollX;
		float y = Time.time * ScrollY;
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(x, y);
	}
}
