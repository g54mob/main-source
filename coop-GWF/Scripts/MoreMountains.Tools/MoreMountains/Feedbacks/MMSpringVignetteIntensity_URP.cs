using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringVignetteIntensity_URP")]
	public class MMSpringVignetteIntensity_URP : MMSpringFloatComponent<Volume>
	{
		protected Vignette _vignette;

		public override float TargetFloat
		{
			get
			{
				return _vignette.intensity.value;
			}
			set
			{
				_vignette.intensity.Override(value);
			}
		}

		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = base.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet<Vignette>(out _vignette);
			base.Initialization();
		}
	}
}
