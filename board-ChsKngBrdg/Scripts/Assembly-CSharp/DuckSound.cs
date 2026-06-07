using UnityEngine;

public class DuckSound : MonoBehaviour
{
	public DuckManager duckManager;

	private SoundManager soundManager;

	public void Start()
	{
		soundManager = Object.FindObjectOfType<SoundManager>();
	}

	public void PlayHonkSound()
	{
		if (CheckState())
		{
			SoundManager.LoadSoundEffect(base.transform, soundManager.duck_honk);
		}
	}

	public void PlayWalkSound()
	{
		if (CheckState())
		{
			SoundManager.LoadSoundEffect(base.transform, soundManager.duck_walk);
		}
	}

	public void PlayIdleSound()
	{
		if (CheckState())
		{
			SoundManager.LoadSoundEffect(base.transform, soundManager.duck_idle);
		}
	}

	public void PlayFlapSound()
	{
		if (CheckState())
		{
			SoundManager.LoadSoundEffect(base.transform, soundManager.duck_flap);
		}
	}

	private bool CheckState()
	{
		if (duckManager.duckState == DuckManager.DuckState.Inactive)
		{
			return false;
		}
		return true;
	}
}
