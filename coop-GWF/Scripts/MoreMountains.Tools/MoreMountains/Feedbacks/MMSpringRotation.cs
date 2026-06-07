using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringRotation")]
	public class MMSpringRotation : MMSpringVector3Component<Transform>
	{
		public enum Spaces
		{
			Local = 0,
			World = 1
		}

		[MMInspectorGroup("Target", true, 17, false)]
		public Spaces Space = Spaces.World;

		public override Vector3 TargetVector3
		{
			get
			{
				if (Space != Spaces.Local)
				{
					return Target.rotation.eulerAngles;
				}
				return Target.localRotation.eulerAngles;
			}
			set
			{
				if (Space == Spaces.Local)
				{
					Target.localRotation = Quaternion.Euler(value);
				}
				else
				{
					Target.rotation = Quaternion.Euler(value);
				}
			}
		}
	}
}
