using System;
using UnityEngine;

namespace GameCreator.Runtime.Common.Audio
{
	[Serializable]
	public class AudioConfigMusic : TAudioConfig
	{
		public static readonly AudioConfigMusic Default = new AudioConfigMusic();

		[SerializeField]
		private float m_TransitionIn;

		[SerializeField]
		private TimeMode.UpdateMode m_UpdateMode;

		public override float TransitionIn => m_TransitionIn;

		public override float SpatialBlend => 0f;

		public override TimeMode.UpdateMode UpdateMode => m_UpdateMode;

		public static AudioConfigMusic Create(float volume, float transition)
		{
			return new AudioConfigMusic
			{
				m_Volume = volume,
				m_TransitionIn = transition
			};
		}
	}
}
