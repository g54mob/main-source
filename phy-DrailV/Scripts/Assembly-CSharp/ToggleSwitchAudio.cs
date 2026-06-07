using DV.CabControls;
using UnityEngine;

public class ToggleSwitchAudio : MonoBehaviour
{
	public AudioClip switchClip;

	private ToggleSwitchBase toggleSwitch;

	private AudioSource switchSource;

	private float autoOffSoundThreshold = 0.1f;

	private void Start()
	{
		if ((bool)switchClip)
		{
			switchSource = NAudio.CreateSource(base.transform, switchClip, 1f, 1f, loop: false).source;
		}
		toggleSwitch = GetComponent<ToggleSwitchBase>();
		toggleSwitch.ValueChanged += PlaySound;
	}

	private void OnDestroy()
	{
		toggleSwitch.ValueChanged -= PlaySound;
	}

	private void PlaySound(ValueChangedEventArgs e)
	{
		if (CanPlaySound())
		{
			switchSource.Play();
		}
	}

	private bool CanPlaySound()
	{
		if (switchSource == null)
		{
			return false;
		}
		if (!toggleSwitch.IsOn || toggleSwitch.autoOffTimer == 0f)
		{
			return true;
		}
		if (toggleSwitch.autoOffTimer > autoOffSoundThreshold)
		{
			return true;
		}
		return false;
	}
}
