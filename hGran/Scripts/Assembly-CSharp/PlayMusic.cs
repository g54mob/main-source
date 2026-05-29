using System;
using UnityEngine;

[Serializable]
public class PlayMusic : MonoBehaviour
{
	public AudioClip screenSound;

	public float volume;

	public bool fading;

	public virtual void Start()
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
