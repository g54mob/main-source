using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[HelpURL("https://docs.gamecreator.io/gamecreator/characters/animation/states")]
	public class StateAnimation : StateOverrideAnimator
	{
		[SerializeField]
		private AnimationClip m_StateClip;

		protected sealed override void BeforeSerialize()
		{
			if (!(m_Controller == null))
			{
				m_Controller["Human@Action"] = m_StateClip;
			}
		}

		protected sealed override void AfterSerialize()
		{
		}
	}
}
