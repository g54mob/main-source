using System;
using UnityEngine;

[Serializable]
public class SoundPlayer : MonoBehaviour
{
	public SoundEntry soundEntry;

	public AudioSource audioSource;

	public int soundIndex;

	public float fadeIn;

	public float fadeOut;

	public float soundTime;

	private float audioSourceVol;

	private bool isReserved;

	public bool IsReserved => false;

	public float mod_volume
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public void Mute(bool isMute)
	{
	}

	public void ReserveToPlay()
	{
	}

	public void OnSoundPlay()
	{
	}

	public void OnSoundEnd()
	{
	}

	public void SetFadeOut(float fadeOutTime)
	{
	}

	public void SoundUpdate(float deltaTime)
	{
	}
}
