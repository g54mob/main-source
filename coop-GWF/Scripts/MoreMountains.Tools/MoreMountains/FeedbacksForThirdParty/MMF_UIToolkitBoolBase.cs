using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	public class MMF_UIToolkitBoolBase : MMF_UIToolkit
	{
		protected bool _initialValue;

		public override float FeedbackDuration => 0f;

		public override bool HasCustomInspectors => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (_visualElements != null && _visualElements.Count != 0)
			{
				_initialValue = GetInitialValue();
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && MMF_UIToolkit.FeedbackTypeAuthorized && _visualElements != null && _visualElements.Count != 0)
			{
				SetValue();
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && MMF_UIToolkit.FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
			}
		}

		protected virtual void SetValue()
		{
		}

		protected virtual void SetValue(bool newValue)
		{
		}

		protected virtual bool GetInitialValue()
		{
			return false;
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && MMF_UIToolkit.FeedbackTypeAuthorized)
			{
				SetValue(_initialValue);
			}
		}
	}
}
