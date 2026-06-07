using System;
using UnityEngine;

namespace GameCreator.Runtime.Common.Audio
{
	[Serializable]
	public class AudioConfigSoundUI : TAudioConfig
	{
		public static readonly AudioConfigSoundUI Default = new AudioConfigSoundUI();

		[SerializeField]
		private Vector2 m_Pitch = new Vector2(0.95f, 1.05f);

		[SerializeField]
		private TimeMode.UpdateMode m_UpdateMode = TimeMode.UpdateMode.UnscaledTime;

		[SerializeField]
		private SpatialBlending m_SpatialBlend;

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectNone.Create();

		public override float Pitch => UnityEngine.Random.Range(m_Pitch.x, m_Pitch.y);

		public override float SpatialBlend
		{
			get
			{
				if (m_SpatialBlend != SpatialBlending.None)
				{
					return 1f;
				}
				return 0f;
			}
		}

		public override TimeMode.UpdateMode UpdateMode => m_UpdateMode;

		public override GameObject GetTrackTarget(Args args)
		{
			return m_Target.Get(args);
		}

		public static AudioConfigSoundUI Create(float volume, Vector2 pitch)
		{
			return new AudioConfigSoundUI
			{
				m_Volume = volume,
				m_Pitch = pitch,
				m_SpatialBlend = SpatialBlending.None,
				m_Target = GetGameObjectInstance.Create((GameObject)null)
			};
		}
	}
}
