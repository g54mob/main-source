using System;
using UnityEngine;

namespace TMPEffects.Components.Animator
{
	[Serializable]
	internal class AnimationUpdater
	{
		[SerializeField]
		private uint maxUpdatesPerSecond;

		[SerializeField]
		private float additionalTimeScaling;

		private float delta;

		private float updateTiming;

		private float over;

		private Action<float> updateAction;

		public uint MaxUpdatesPerSecond => 0u;

		public float AdditionalTimeScaling
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationUpdater(Action<float> updateAction, uint maxUpdatesPerSecond, float timeScale)
		{
		}

		public void SetMaxUpdatesPerSecond(uint maxUpdatesPerSecond)
		{
		}

		public bool Update(float deltaTime)
		{
			return false;
		}

		public void Reset()
		{
		}
	}
}
