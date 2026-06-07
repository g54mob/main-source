using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring TMP Alpha")]
	public class MMSpringTMPAlpha : MMSpringFloatComponent<TMP_Text>
	{
		public override float TargetFloat
		{
			get
			{
				return Target.alpha;
			}
			set
			{
				Target.alpha = value;
			}
		}
	}
}
