using UnityEngine;

public class TweenPlayer : MonoBehaviour
{
	[SerializeField]
	private float tweenDuration = 0.5f;

	[SerializeField]
	private bool flipFlop = true;

	[SerializeField]
	private bool tweenPosition;

	[SerializeField]
	private Vector3 startPosition;

	[SerializeField]
	private Vector3 endPosition;

	[SerializeField]
	private bool tweenRotation;

	[SerializeField]
	public Quaternion startRotation;

	[SerializeField]
	public Quaternion endRotation;

	[SerializeField]
	private Transform target;

	[SerializeField]
	private AnimationCurve curve;

	[SerializeField]
	private string soundOnPlay;

	[SerializeField]
	private string soundOnReverse;

	private bool flipFlopState;

	private bool playerState;

	public bool isPlaying;

	public bool PlayerState()
	{
		return playerState;
	}

	public Transform GetTarget()
	{
		return target;
	}

	public void OnPlay()
	{
		if (flipFlop)
		{
			Tween(flipFlopState);
		}
		else
		{
			Tween(reverse: false);
		}
	}

	public void OnReverse()
	{
		if (flipFlop)
		{
			Tween(flipFlopState);
		}
		else
		{
			Tween(reverse: true);
		}
	}

	private void Tween(bool reverse)
	{
		if (target == null || isPlaying)
		{
			return;
		}
		if (tweenRotation)
		{
			if (reverse)
			{
				playerState = false;
				TweenerManager.TweenRotation("TweenPlayerRotationReverse", target, endRotation, startRotation, tweenDuration, curve, Space.Self, delegate
				{
					isPlaying = false;
				});
				SoundManager.PlaySoundOnce(soundOnReverse);
				isPlaying = true;
			}
			else
			{
				playerState = true;
				TweenerManager.TweenRotation("TweenPlayerRotationForward", target, startRotation, endRotation, tweenDuration, curve, Space.Self, delegate
				{
					isPlaying = false;
				});
				SoundManager.PlaySoundOnce(soundOnPlay);
				isPlaying = true;
			}
		}
		if (flipFlop)
		{
			flipFlopState = !flipFlopState;
		}
	}

	public void QueuedPlay()
	{
		if (!(target == null) && tweenRotation)
		{
			TweenerManager.StopTweenWithContainingKey("TweenPlayerQueuedRotationForward");
			TweenerManager.TweenRotation("TweenPlayerQueuedRotationForward", target, startRotation, endRotation, tweenDuration, curve, Space.Self, delegate
			{
				isPlaying = false;
			});
			SoundManager.PlaySoundOnce(soundOnPlay);
			isPlaying = true;
		}
	}
}
