using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringVignetteColor_URP")]
	public class MMSpringVignetteColor_URP : MMSpringColorComponent<Volume>
	{
		protected Vignette _vignette;

		public override Color TargetColor
		{
			get
			{
				return _vignette.color.value;
			}
			set
			{
				_vignette.color.Override(value);
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
