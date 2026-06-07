using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Random Animation Clip")]
	[Category("Random/Random Animation Clip")]
	[Image(typeof(IconDice), ColorTheme.Type.Yellow)]
	[Description("A random Animation Clip asset from a list")]
	[HideLabelsInEditor(true)]
	public class GetAnimationRandom : PropertyTypeGetAnimation
	{
		[SerializeField]
		protected AnimationClip[] m_Values = Array.Empty<AnimationClip>();

		public static PropertyGetAnimation Create => new PropertyGetAnimation(new GetAnimationRandom());

		public override string String => "Random Clip";

		public override AnimationClip Get(Args args)
		{
			AnimationClip[] values = m_Values;
			if (values == null || values.Length == 0)
			{
				return null;
			}
			int num = UnityEngine.Random.Range(0, m_Values.Length);
			return m_Values[num];
		}
	}
}
