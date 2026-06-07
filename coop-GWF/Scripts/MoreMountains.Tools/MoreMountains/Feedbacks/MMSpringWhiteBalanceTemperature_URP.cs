using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringWhiteBalanceTemperature_URP")]
	public class MMSpringWhiteBalanceTemperature_URP : MMSpringFloatComponent<Volume>
	{
		protected WhiteBalance _whiteBalance;

		public override float TargetFloat
		{
			get
			{
				return _whiteBalance.temperature.value;
			}
			set
			{
				_whiteBalance.temperature.Override(value);
			}
		}

		protected override void Initialization()
		{
			if (Target == null)
			{
				Target = base.gameObject.GetComponent<Volume>();
			}
			Target.profile.TryGet<WhiteBalance>(out _whiteBalance);
			base.Initialization();
		}
	}
}
