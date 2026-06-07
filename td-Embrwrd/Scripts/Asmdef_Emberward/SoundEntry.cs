using System;
using UnityEngine;

[Serializable]
public class SoundEntry
{
	public string name;

	public AudioClip[] clips;

	public SoundAssetData.SOUND_TYPE type;

	public bool doLoop;

	public float mod_Volume;

	public float soundLength;

	public bool doRandomClip;

	public int randomClipCount;

	public bool haveCooldown;

	public float cooldownTime;

	public bool doRandomPitch;

	public Vector2 randomPitchRange;
}
