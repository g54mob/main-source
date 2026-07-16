using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class SoundContainer
{
	public string name;

	public AudioClip[] audioClip;

	public bool selectRandomClip;

	public AudioMixerGroup group;

	public bool loop;

	[Range(0f, 2f)]
	public float volume = 1f;

	[Range(0f, 2f)]
	public float pitch = 1f;

	[Header("2D - 3D")]
	[Range(0f, 1f)]
	public float spatialBlend = 1f;
}
