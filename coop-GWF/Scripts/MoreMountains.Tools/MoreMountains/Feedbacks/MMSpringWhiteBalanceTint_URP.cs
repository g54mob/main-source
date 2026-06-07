using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringWhiteBalanceTint_URP")]
	public class MMSpringWhiteBalanceTint_URP : MMSpringFloatComponent<Volume>
	{
		protected WhiteBalance _whiteBalance;

		public override float TargetFloat
		{
			get
			{
				return _whiteBalance.tint.value;
			}
			set
			{
				_whiteBalance.tint.Override(value);
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
