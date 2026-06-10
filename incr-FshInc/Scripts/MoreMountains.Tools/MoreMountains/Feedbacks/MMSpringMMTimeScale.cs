using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring MMTimeScale")]
	public class MMSpringMMTimeScale : MMSpringFloatComponent<Transform>
	{
		public override float TargetFloat
		{
			get
			{
				return MMSingleton<MMTimeManager>.Instance.CurrentTimeScale;
			}
			set
			{
				MMTimeScaleEvent.Trigger(MMTimeScaleMethods.For, value, 0f, lerp: false, 0f, infinite: true);
			}
		}

		protected override void Initialization()
		{
			base.Initialization();
			FloatSpring.ClampSettings.ClampMin = true;
			FloatSpring.ClampSettings.ClampMinValue = 0f;
			FloatSpring.ClampSettings.ClampMinBounce = true;
		}
	}
}
