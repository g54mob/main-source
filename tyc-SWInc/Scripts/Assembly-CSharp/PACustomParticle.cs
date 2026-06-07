using System;
using UnityEngine;

[Serializable]
public class PACustomParticle
{
	public Vector3 originDirection;

	public float size = 1f;

	public Color color = Color.white;

	public float speed;

	public float spinSpeed;

	public Rect uv = new Rect(0f, 0f, 1f, 1f);

	public void SetDefaultValuesIfUninitialized()
	{
		if (originDirection == default(Vector3) && size == 0f && color == default(Color) && speed == 0f && spinSpeed == 0f && uv == default(Rect))
		{
			originDirection = Vector3.zero;
			size = 1f;
			color = Color.white;
			speed = 0f;
			spinSpeed = 0f;
			uv = new Rect(0f, 0f, 1f, 1f);
		}
	}

	public PACustomParticle()
	{
		originDirection = new Vector3(0.5f, 0.5f, 0.5f);
		size = 1f;
		color = Color.white;
		speed = 0f;
		spinSpeed = 0f;
		uv = new Rect(0f, 0f, 1f, 1f);
	}

	public PACustomParticle(Vector3 originDirection, Color color, float size, float speed, float spinSpeed, Rect uv)
	{
		this.originDirection = originDirection;
		this.size = size;
		this.speed = speed;
		this.spinSpeed = spinSpeed;
		this.color = color;
		this.uv = uv;
	}

	public PACustomParticle(Vector3 originDirection, Color color, float size = 1f, float speed = 0f, float spinSpeed = 0f)
	{
		this.originDirection = originDirection;
		this.size = size;
		this.speed = speed;
		this.spinSpeed = spinSpeed;
		this.color = color;
		uv = new Rect(0f, 0f, 1f, 1f);
	}

	public PACustomParticle(Vector3 originDirection)
	{
		this.originDirection = originDirection;
		size = 1f;
		speed = 0f;
		spinSpeed = 0f;
		color = Color.white;
		uv = new Rect(0f, 0f, 1f, 1f);
	}
}
