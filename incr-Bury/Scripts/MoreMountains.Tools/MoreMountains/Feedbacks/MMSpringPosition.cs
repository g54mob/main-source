using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring Position")]
	public class MMSpringPosition : MMSpringVector3Component<Transform>
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
					return Target.position;
				}
				return Target.localPosition;
			}
			set
			{
				if (Space == Spaces.Local)
				{
					Target.localPosition = value;
				}
				else
				{
					Target.position = value;
				}
			}
		}
	}
}
