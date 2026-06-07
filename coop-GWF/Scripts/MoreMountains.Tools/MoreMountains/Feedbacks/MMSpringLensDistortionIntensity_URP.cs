using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringLensDistortionIntensity_URP")]
	public class MMSpringLensDistortionIntensity_URP : MMSpringFloatComponent<Volume>
	{
		protected LensDistortion _lensDistortion;

		public override float TargetFloat
		{
			get
			{
				return _lensDistortion.intensity.value;
			}
			set
			{
				_lensDistortion.intensity.Override(value);
			}
		}

		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = base.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet<LensDistortion>(out _lensDistortion);
			base.Initialization();
		}
	}
}
