using System.Collections;
using UnityEngine;

public abstract class LandmarkUnlockable : SceneBehaviour
{
	[SerializeField]
	private CameraControllerCinematicLock _cinematicLock;

	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _animatorLockedParameter = "Locked";

	[SerializeField]
	[ConditionalHide("_animator", true)]
	private string _animatorUnlockParameter = "Unlock";

	[SerializeField]
	[ConditionalHide("_animator", true)]
	[Tooltip("The amount of time the Unlock routine should wait for the animation to complete.")]
	private float _animatorUnlockDuration;

	protected virtual void InitializeLocked()
	{
		_animator.SetBool(_animatorLockedParameter, value: true);
	}

	protected virtual void InitializeUnlocked()
	{
		_animator.SetBool(_animatorLockedParameter, value: false);
	}

	public virtual IEnumerator Unlock()
	{
		if ((bool)_animator)
		{
			yield return _cinematicLock.LockRoutine();
			_animator.ResetTrigger(_animatorUnlockParameter);
			_animator.SetTrigger(_animatorUnlockParameter);
			_animator.SetBool(_animatorLockedParameter, value: false);
			yield return new WaitForSeconds(_animatorUnlockDuration);
			_cinematicLock.Unlock();
		}
	}
}
