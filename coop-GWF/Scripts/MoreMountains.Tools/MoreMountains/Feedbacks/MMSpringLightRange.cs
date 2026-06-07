using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringLightRange")]
	public class MMSpringLightRange : MMSpringFloatComponent<Light>
	{
		public override float TargetFloat
		{
			get
			{
				return Target.range;
			}
			set
			{
				Target.range = value;
			}
		}
	}
}
