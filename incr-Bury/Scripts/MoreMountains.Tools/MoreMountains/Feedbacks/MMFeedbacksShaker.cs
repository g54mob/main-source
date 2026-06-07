using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[RequireComponent(typeof(MMFeedbacks))]
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Feedbacks/MM Feedbacks Shaker")]
	public class MMFeedbacksShaker : MMShaker
	{
		protected MMFeedbacks _mmFeedbacks;

		protected override void Initialization()
		{
			base.Initialization();
			_mmFeedbacks = base.gameObject.GetComponent<MMFeedbacks>();
		}

		public virtual void OnMMFeedbacksShakeEvent(MMChannelData channelData = null, bool useRange = false, float eventRange = 0f, Vector3 eventOriginPosition = default(Vector3))
		{
			if (CheckEventAllowed(channelData, useRange, eventRange, eventOriginPosition) && (Interruptible || !Shaking))
			{
				Play();
			}
		}

		protected override void ShakeStarts()
		{
			_mmFeedbacks.PlayFeedbacks();
		}

		protected virtual void Reset()
		{
			ShakeDuration = 0.01f;
		}

		public override void StartListening()
		{
			base.StartListening();
			MMFeedbacksShakeEvent.Register(OnMMFeedbacksShakeEvent);
		}

		public override void StopListening()
		{
			base.StopListening();
			MMFeedbacksShakeEvent.Unregister(OnMMFeedbacksShakeEvent);
		}
	}
}
