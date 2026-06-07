using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MMSpringTMPFontSize")]
	public class MMSpringTMPFontSize : MMSpringFloatComponent<TMP_Text>
	{
		public override float TargetFloat
		{
			get
			{
				return Target.fontSize;
			}
			set
			{
				Target.fontSize = (int)value;
			}
		}
	}
}
