using System;
using UnityEngine;

namespace GameCreator.Runtime.Common.Audio
{
	[Serializable]
	public class AudioConfigSoundEffect : TAudioConfig
	{
		public static readonly AudioConfigSoundEffect Default = new AudioConfigSoundEffect();

		[SerializeField]
		private Vector2 m_Pitch = Vector2.one;

		[SerializeField]
		private float m_TransitionIn;

		[SerializeField]
		private TimeMode.UpdateMode m_UpdateMode;

		[SerializeField]
		private SpatialBlending m_SpatialBlend;

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectNone.Create();

		public override float Pitch => UnityEngine.Random.Range(m_Pitch.x, m_Pitch.y);

		public override float TransitionIn => m_TransitionIn;

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

		public static AudioConfigSoundEffect Create(float volume, Vector2 pitch, float transition, TimeMode.UpdateMode time, SpatialBlending spatialBlending, GameObject target)
		{
			return new AudioConfigSoundEffect
			{
				m_Volume = volume,
				m_Pitch = pitch,
				m_TransitionIn = transition,
				m_SpatialBlend = spatialBlending,
				m_Target = GetGameObjectInstance.Create(target)
			};
		}
	}
}
