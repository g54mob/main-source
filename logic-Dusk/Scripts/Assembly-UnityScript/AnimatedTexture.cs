using System;
using UnityEngine;

[Serializable]
public class AnimatedTexture : MonoBehaviour
{
	public int uvAnimationTileX;

	public int uvAnimationTileY;

	public float framesPerSecond;

	public AnimatedTexture()
	{
		uvAnimationTileX = 24;
		uvAnimationTileY = 1;
		framesPerSecond = 10f;
	}

	public virtual void Update()
	{
		int num = (int)(Time.time * framesPerSecond);
		num %= uvAnimationTileX * uvAnimationTileY;
		Vector2 scale = new Vector2(1f / (float)uvAnimationTileX, 1f / (float)uvAnimationTileY);
		int num2 = num % uvAnimationTileX;
		int num3 = num / uvAnimationTileX;
		Vector2 offset = new Vector2((float)num2 * scale.x, 1f - scale.y - (float)num3 * scale.y);
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
		GetComponent<Renderer>().material.SetTextureScale("_MainTex", scale);
	}

	public virtual void Main()
	{
	}
}
