using UnityEngine;
using UnityEngine.Audio;

public class AudioItem : MonoBehaviour
{
	public AudioKey key;

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume = 1f;

	[Range(-3f, 3f)]
	public float pitch = 1f;

	[Header("3D")]
	public bool spatial = true;

	[Range(0f, 1f)]
	public float spatialBlend = 1f;

	public float minDistance = 1f;

	public float maxDistance = 20f;

	[Header("Mixer Route Override")]
	public AudioMixerGroup mixerGroupOverride;
}
