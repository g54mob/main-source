using System;
using UnityEngine;

[Serializable]
public class fadeMusic : MonoBehaviour
{
	public AudioClip Music;

	public AudioClip BookMusic;

	public float volume;

	public bool fading;

	public bool playMusic;

	public bool musicOn;

	public bool momHunting;

	public bool stopFade;

	public virtual void Update()
	{
	}
}
