using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringColorAdjustmentsSaturation_URP")]
	public class MMSpringColorAdjustmentsSaturation_URP : MMSpringFloatComponent<Volume>
	{
		protected ColorAdjustments _colorAdjustments;

		public override float TargetFloat
		{
			get
			{
				return _colorAdjustments.saturation.value;
			}
			set
			{
				_colorAdjustments.saturation.Override(value);
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
