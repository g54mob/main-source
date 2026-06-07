using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New SoundEffect", menuName = "SoundEffects")]
public class SoundEffect : ScriptableObject
{
	public AudioClip[] audioClips;

	public AudioMixerGroup mixerGroup;

	public bool doLoopClip;

	[Range(0f, 1f)]
	public float volume;

	public bool doRandomizePitch;

	[Range(0f, 1f)]
	public float pitchRange;
}
