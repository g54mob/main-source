using System;
using UnityEngine;

[Serializable]
public class ChillEffect
{
	[SerializeField]
	private float timer;

	public float Timer => 0f;

	public bool IsFinished => false;

	public ChillEffect(float duration)
	{
	}

	public void Renew(float duration)
	{
	}

	public void Update(float deltaTime)
	{
	}
}
