using System;
using UnityEngine;

[Serializable]
public class FadeNightSound : MonoBehaviour
{
	public AudioClip nightSound;

	public float volume;

	public bool fading;

	public bool soundLow;

	public bool soundHigh;

	public bool gameStart;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void fadeUp()
	{
	}

	public virtual void fadeDown()
	{
	}

	public virtual void stopAudio()
	{
	}
}
