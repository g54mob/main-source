using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringShaderController")]
	public class MMSpringShaderController : MMSpringFloatComponent<ShaderController>
	{
		public override float TargetFloat
		{
			get
			{
				return Target.DrivenLevel;
			}
			set
			{
				Target.DrivenLevel = value;
			}
		}
	}
}
