using System;
using UnityEngine;

[Serializable]
public class AnimationSpriteSheet : MonoBehaviour
{
	public int uvX;

	public int uvY;

	public float fps;

	public virtual void Update()
	{
		int num = (int)(Time.time * fps) % (uvX * uvY);
		Vector2 value = new Vector2(1f / (float)uvX, 1f / (float)uvY);
		int num2 = num % uvX;
		int num3 = num / uvX;
		Vector2 value2 = new Vector2((float)num2 * value.x, 1f - value.y - (float)num3 * value.y);
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", value2);
		GetComponent<Renderer>().material.SetTextureScale("_MainTex", value);
	}

	public AnimationSpriteSheet()
	{
		uvX = 4;
		uvY = 2;
		fps = 24f;
	}
}
