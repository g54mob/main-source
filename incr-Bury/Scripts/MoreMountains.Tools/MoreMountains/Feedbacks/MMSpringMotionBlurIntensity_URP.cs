using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Motion Blur Intensity URP")]
	public class MMSpringMotionBlurIntensity_URP : MMSpringFloatComponent<Volume>
	{
		protected MotionBlur _motionBlur;

		public override float TargetFloat
		{
			get
			{
				return _motionBlur.intensity.value;
			}
			set
			{
				_motionBlur.intensity.Override(value);
			}
		}

		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = base.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet<MotionBlur>(out _motionBlur);
			base.Initialization();
		}
	}
}
