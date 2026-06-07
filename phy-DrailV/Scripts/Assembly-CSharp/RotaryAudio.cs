using DV.CabControls;
using DV.Utils;
using UnityEngine;

public class RotaryAudio : MonoBehaviour
{
	public AudioClip notchClip;

	private SteppedJoint steppedJoint;

	private AudioSource notchSound;

	private void Start()
	{
		if ((bool)notchClip)
		{
			if (!SingletonBehaviour<AudioManager>.Instance)
			{
				Debug.LogWarning("RotaryAudio couldn't find an AudioManager instance, removing itself", base.gameObject);
				Object.Destroy(this);
			}
			else
			{
				notchSound = NAudio.CreateSource(base.transform, notchClip, 1f, 1f, loop: false).source;
				steppedJoint = GetComponent<SteppedJoint>();
				steppedJoint.PositionChanged += PlaySound;
			}
		}
	}

	private void OnDestroy()
	{
		if ((bool)steppedJoint)
		{
			steppedJoint.PositionChanged -= PlaySound;
		}
	}

	private void PlaySound(ValueChangedEventArgs _)
	{
		if ((bool)notchSound)
		{
			notchSound.Play();
		}
	}
}
