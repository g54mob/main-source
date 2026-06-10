using TMPro;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Springs/MM Spring TMP Word Spacing")]
	public class MMSpringTMPWordSpacing : MMSpringFloatComponent<TMP_Text>
	{
		public override float TargetFloat
		{
			get
			{
				return Target.wordSpacing;
			}
			set
			{
				Target.wordSpacing = value;
			}
		}
	}
}
