using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Shader Controller")]
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
