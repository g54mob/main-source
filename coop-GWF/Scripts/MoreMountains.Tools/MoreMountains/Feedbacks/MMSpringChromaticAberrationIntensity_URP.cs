using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringChromaticAberrationIntensity_URP")]
	public class MMSpringChromaticAberrationIntensity_URP : MMSpringFloatComponent<Volume>
	{
		protected ChromaticAberration _chromaticAberration;

		public override float TargetFloat
		{
			get
			{
				return _chromaticAberration.intensity.value;
			}
			set
			{
				_chromaticAberration.intensity.Override(value);
			}
		}

		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = base.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet<ChromaticAberration>(out _chromaticAberration);
			base.Initialization();
		}
	}
}
