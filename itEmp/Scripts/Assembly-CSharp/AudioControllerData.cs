using System;
using UnityEngine;

[Serializable]
public class AudioControllerData
{
	public AudioControllerProfil type;

	public AudioSource audio;

	[HideInInspector]
	public float volume;
}
