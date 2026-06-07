using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class EntryAnimationClip
	{
		[SerializeField]
		private AnimationClip m_EntryClip;

		[SerializeField]
		private AvatarMask m_EntryMask;

		[SerializeField]
		private bool m_RootMotion;

		public AnimationClip EntryClip => m_EntryClip;

		public AvatarMask EntryMask => m_EntryMask;

		public bool RootMotion => m_RootMotion;
	}
}
