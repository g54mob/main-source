using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringLightColor")]
	public class MMSpringLightColor : MMSpringColorComponent<Light>
	{
		public override Color TargetColor
		{
			get
			{
				return Target.color;
			}
			set
			{
				Target.color = value;
			}
		}
	}
}
