using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common.Audio
{
	[Serializable]
	public class AudioConfigSpeech : TAudioConfig
	{
		public static readonly AudioConfigSpeech Default = new AudioConfigSpeech();

		[SerializeField]
		private TimeMode.UpdateMode m_UpdateMode;

		[SerializeField]
		private SpatialBlending m_SpatialBlend = SpatialBlending.Spatial;

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectPlayer.Create();

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
			return GetSpeechSource(m_Target.Get(args));
		}

		public static GameObject GetSpeechSource(GameObject target)
		{
			if (!(target == null))
			{
				return target;
			}
			return null;
		}

		public static AudioConfigSpeech Create(float volume, SpatialBlending spatialBlending, GameObject target)
		{
			return new AudioConfigSpeech
			{
				m_Volume = volume,
				m_SpatialBlend = spatialBlending,
				m_Target = GetGameObjectInstance.Create(target)
			};
		}
	}
}
