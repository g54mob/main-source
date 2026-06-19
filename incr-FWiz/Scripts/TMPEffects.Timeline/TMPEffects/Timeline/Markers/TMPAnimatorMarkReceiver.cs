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
		}
	}
}
