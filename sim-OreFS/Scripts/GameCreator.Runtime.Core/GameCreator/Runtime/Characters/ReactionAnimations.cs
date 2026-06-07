using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class ReactionAnimations
	{
		[SerializeField]
		private AnimationClip[] m_Animations = Array.Empty<AnimationClip>();

		[NonSerialized]
		private int m_LastIndex = -1;

		public AnimationClip AnimationClip
		{
			get
			{
				int num = m_Animations.Length;
				if (num > 0)
				{
					if (num == 1)
					{
						return m_Animations[0];
					}
					int num2 = ((m_LastIndex >= 0) ? UnityEngine.Random.Range(0, m_Animations.Length - 1) : UnityEngine.Random.Range(0, m_Animations.Length));
					if (num2 == m_LastIndex)
					{
						num2++;
					}
					m_LastIndex = num2;
					return m_Animations[num2];
				}
				return null;
			}
		}
	}
}
