using UnityEngine;
using UnityEngine.PostProcessing;

namespace Gh.Tk
{
	public class MotionBlurAnimEvent : MonoBehaviour
	{
		public PostProcessingProfile postProcessProfile;

		private BasicAnimationEventObserver _animationEventObserver;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnDisable()
		{
		}

		private void MotionBlurEvent(object sender, AnimationEventArgs e)
		{
		}

		private void EnablePostProcessMotionBlur()
		{
		}

		private void DisablePostProcessMotionBlur()
		{
		}

		private void EnableFrameBlending()
		{
		}

		private void DisableFrameBlending()
		{
		}
	}
}
