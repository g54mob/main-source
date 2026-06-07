using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Cinemachine/MMCinemachinePriorityListener")]
	public class MMCinemachinePriorityListener : MonoBehaviour
	{
		[HideInInspector]
		public TimescaleModes TimescaleMode;

		[Header("Priority Listener")]
		[Tooltip("the channel to listen to")]
		public int Channel;

		public virtual float GetTime()
		{
			if (TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		public virtual float GetDeltaTime()
		{
			if (TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime;
		}
	}
}
