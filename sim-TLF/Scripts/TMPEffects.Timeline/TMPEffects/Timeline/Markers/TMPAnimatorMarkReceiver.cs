using TMPEffects.Components;
using UnityEngine;
using UnityEngine.Playables;

namespace TMPEffects.Timeline.Markers
{
	[RequireComponent(typeof(TMPAnimator))]
	public class TMPAnimatorMarkReceiver : MonoBehaviour, INotificationReceiver
	{
		private TMPAnimator animator;

		public void OnNotify(Playable origin, INotification notification, object context)
		{
			if (animator == null)
			{
				animator = GetComponent<TMPAnimator>();
				if (animator == null)
				{
					return;
				}
			}
			if (!(notification is TMPStartAnimatingMarker))
			{
				if (!(notification is TMPStopAnimatingMarker))
				{
					if (!(notification is TMPUpdateAnimationsMarker { DeltaTime: var num }))
					{
						if (!(notification is TMPSetUpdateFromMarker tMPSetUpdateFromMarker))
						{
							if (!(notification is TMPResetAnimationsMarker))
							{
								if (notification is TMPResetTimeMarker tMPResetTimeMarker)
								{
									animator.ResetTime(tMPResetTimeMarker.Time);
								}
							}
							else
							{
								animator.ResetAnimations();
							}
						}
						else
						{
							animator.SetUpdateFrom(tMPSetUpdateFromMarker.UpdateFrom);
						}
					}
					else
					{
						if (num < 0f)
						{
							num = ((num == -1f) ? Time.deltaTime : ((num != -2f) ? 0f : Time.fixedDeltaTime));
						}
						animator.UpdateAnimations(num);
					}
				}
				else
				{
					animator.StopAnimating();
				}
			}
			else
			{
				animator.StartAnimating();
			}
		}
	}
}
