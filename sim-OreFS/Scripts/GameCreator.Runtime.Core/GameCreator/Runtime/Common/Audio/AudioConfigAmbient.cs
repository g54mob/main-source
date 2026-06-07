using System;
using UnityEngine;

namespace GameCreator.Runtime.Common.Audio
{
	[Serializable]
	public class AudioConfigAmbient : TAudioConfig
	{
		public static readonly AudioConfigAmbient Default = new AudioConfigAmbient();

		[SerializeField]
		private float m_TransitionIn;

		[SerializeField]
		private TimeMode.UpdateMode m_UpdateMode;

		[SerializeField]
		private SpatialBlending m_SpatialBlend;

		[SerializeField]
		private PropertyGetGameObject m_Target = GetGameObjectNone.Create();

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

		public static AudioConfigAmbient Create(float volume, float transition, SpatialBlending spatialBlending, GameObject target = null)
		{
			return new AudioConfigAmbient
			{
				m_Volume = volume,
				m_TransitionIn = transition,
				m_SpatialBlend = spatialBlending,
				m_Target = GetGameObjectInstance.Create(target)
			};
		}
	}
}
