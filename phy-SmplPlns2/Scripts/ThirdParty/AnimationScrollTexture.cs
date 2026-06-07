using System;
using UnityEngine;

[Serializable]
public class AnimationScrollTexture : MonoBehaviour
{
	public float Speed;

	public virtual void FixedUpdate()
	{
		float y = Time.time * (0f - Speed);
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0f, y);
	}

	public AnimationScrollTexture()
	{
		Speed = 0.25f;
	}
}
