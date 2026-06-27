using System;
using System.Collections;
using UnityEngine;

namespace Restory.Gameplay.NPCs
{
	public class NpcMovementAnimator : MonoBehaviour
	{
		private static readonly int ArriveFromRightAnimatorHash = Animator.StringToHash("ArriveFromRight");

		private static readonly int ArriveFromLeftAnimatorHash = Animator.StringToHash("ArriveFromLeft");

		private static readonly int ArriveFromAboveAnimatorHash = Animator.StringToHash("ArriveFromAbove");

		private static readonly int LeaveToRightAnimatorHash = Animator.StringToHash("LeaveToRight");

		private static readonly int LeaveToLeftAnimatorHash = Animator.StringToHash("LeaveToLeft");

		private static readonly int LeaveToAboveAnimatorHash = Animator.StringToHash("LeaveToAbove");

		private static readonly int NoNpcPresentAnimatorHash = Animator.StringToHash("NpcAbsent");

		private static readonly int NpcAtWindowAnimatorHash = Animator.StringToHash("NpcAtWindow");

		[SerializeField]
		private Animator animator;

		private NpcMovementOptions currentMovementOption = NpcMovementOptions.RightToLeft;

		private Coroutine animationTrackingCoroutine;

		public bool IsNpcPresent
		{
			get
			{
				if (animationTrackingCoroutine == null)
				{
					if ((bool)animator)
					{
						return animator.GetCurrentAnimatorStateInfo(0).tagHash == NpcAtWindowAnimatorHash;
					}
					return false;
				}
				return true;
			}
		}

		public event Action OnNpcArrivedAtStoreWindow;

		public event Action OnNpcLeft;

		private void OnDisable()
		{
			if (animationTrackingCoroutine != null)
			{
				StopCoroutine(animationTrackingCoroutine);
				animationTrackingCoroutine = null;
			}
		}

		public void StartMovingNpcToStoreWindow(NpcMovementOptions movementDirectionOption, Action onNpcReachedArrivalPointCallback = null)
		{
			ResetAllAnimatorTriggers();
			currentMovementOption = movementDirectionOption;
			int trigger = movementDirectionOption switch
			{
				NpcMovementOptions.LeftToRight => ArriveFromLeftAnimatorHash, 
				NpcMovementOptions.RightToLeft => ArriveFromRightAnimatorHash, 
				NpcMovementOptions.FromAboveAndBackUp => ArriveFromAboveAnimatorHash, 
				_ => throw new NotImplementedException(), 
			};
			animator.SetTrigger(trigger);
			if (animationTrackingCoroutine != null)
			{
				StopCoroutine(animationTrackingCoroutine);
			}
			animationTrackingCoroutine = StartCoroutine(ArrivalAnimationTrackingCoroutine(onNpcReachedArrivalPointCallback));
		}

		public void StartMovingNpcFromStoreWindow(Action onNpcReachedExitPointCallback = null)
		{
			ResetAllAnimatorTriggers();
			int trigger = currentMovementOption switch
			{
				NpcMovementOptions.LeftToRight => LeaveToRightAnimatorHash, 
				NpcMovementOptions.RightToLeft => LeaveToLeftAnimatorHash, 
				NpcMovementOptions.FromAboveAndBackUp => LeaveToAboveAnimatorHash, 
				_ => throw new NotImplementedException(), 
			};
			animator.SetTrigger(trigger);
			if (animationTrackingCoroutine != null)
			{
				StopCoroutine(animationTrackingCoroutine);
			}
			animationTrackingCoroutine = StartCoroutine(DepartureAnimationTrackingCoroutine(onNpcReachedExitPointCallback));
		}

		private IEnumerator ArrivalAnimationTrackingCoroutine(Action callbackOnArrival)
		{
			while (animator.GetCurrentAnimatorStateInfo(0).tagHash == NoNpcPresentAnimatorHash)
			{
				yield return null;
			}
			while (animator.IsInTransition(0) || animator.GetCurrentAnimatorStateInfo(0).tagHash != NpcAtWindowAnimatorHash)
			{
				yield return null;
			}
			animationTrackingCoroutine = null;
			callbackOnArrival?.Invoke();
			this.OnNpcArrivedAtStoreWindow?.Invoke();
		}

		private IEnumerator DepartureAnimationTrackingCoroutine(Action onNpcReachedExitPointCallback)
		{
			while (animator.GetCurrentAnimatorStateInfo(0).tagHash == NpcAtWindowAnimatorHash)
			{
				yield return null;
			}
			while (animator.IsInTransition(0) || animator.GetCurrentAnimatorStateInfo(0).tagHash != NoNpcPresentAnimatorHash)
			{
				yield return null;
			}
			animationTrackingCoroutine = null;
			onNpcReachedExitPointCallback?.Invoke();
			this.OnNpcLeft?.Invoke();
		}

		private void ResetAllAnimatorTriggers()
		{
			AnimatorControllerParameter[] parameters = animator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				if (animatorControllerParameter.type == AnimatorControllerParameterType.Trigger)
				{
					animator.ResetTrigger(animatorControllerParameter.name);
				}
			}
		}
	}
}
