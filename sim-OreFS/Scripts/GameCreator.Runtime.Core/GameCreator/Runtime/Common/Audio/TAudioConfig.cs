using System;
using UnityEngine;

namespace GameCreator.Runtime.Common.Audio
{
	[Serializable]
	public abstract class TAudioConfig : IAudioConfig
	{
		[SerializeField]
		protected float m_Volume = 1f;

		public virtual float Volume => m_Volume;

		public virtual float Pitch => 1f;

		public virtual float TransitionIn => 0f;

		public virtual float SpatialBlend => 0f;

		public virtual TimeMode.UpdateMode UpdateMode => TimeMode.UpdateMode.GameTime;

		public virtual GameObject GetTrackTarget(Args args)
		{
			return null;
		}
	}
}
