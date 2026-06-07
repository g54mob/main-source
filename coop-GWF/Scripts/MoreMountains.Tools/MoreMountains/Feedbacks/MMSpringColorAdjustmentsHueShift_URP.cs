using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringColorAdjustmentsHueShift_URP")]
	public class MMSpringColorAdjustmentsHueShift_URP : MMSpringFloatComponent<Volume>
	{
		protected ColorAdjustments _colorAdjustments;

		public override float TargetFloat
		{
			get
			{
				return _colorAdjustments.hueShift.value;
			}
			set
			{
				_colorAdjustments.hueShift.Override(value);
			}
		}

		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = base.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet<ColorAdjustments>(out _colorAdjustments);
			base.Initialization();
		}
	}
}
