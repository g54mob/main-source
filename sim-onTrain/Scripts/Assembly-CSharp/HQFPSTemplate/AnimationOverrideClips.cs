using System;
using UnityEngine;

namespace HQFPSTemplate
{
	[Serializable]
	public class AnimationOverrideClips : ICloneable
	{
		[Serializable]
		public struct AnimationClipPair
		{
			public AnimationClip Original;

			public AnimationClip Override;
		}

		[SerializeField]
		private RuntimeAnimatorController m_Controller;

		[SerializeField]
		private AnimationClipPair[] m_Clips;

		public RuntimeAnimatorController Controller => m_Controller;

		public AnimationClipPair[] Clips => m_Clips;

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}
