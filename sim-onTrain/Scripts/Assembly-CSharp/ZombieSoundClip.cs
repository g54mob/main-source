using System;
using UnityEngine;

[Serializable]
public class ZombieSoundClip
{
	public AudioClip clip;

	[Tooltip("Ses seviyesi (0-1)")]
	[Range(0f, 1f)]
	public float volume = 0.5f;
}
