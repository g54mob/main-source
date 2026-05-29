using System;
using UnityEngine;

[Serializable]
public class LastPlayerSighting : MonoBehaviour
{
	public Vector3 position;

	public Vector3 resetPosition;

	public float lightHighIntensity;

	public float lightLowIntensity;

	public float fadeSpeed;

	public float musicFadeSpeed;

	private Light mainLight;

	private AudioSource panicAudio;

	private AudioSource[] sirens;

	public virtual void Awake()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void SwitchAlarms()
	{
	}

	public virtual void MusicFading()
	{
	}
}
