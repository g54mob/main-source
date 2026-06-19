using System;
using UnityEngine;

namespace TMPEffects.Components.Animator
{
	[Serializable]
	internal class AnimationUpdater
	{
		[SerializeField]
		private uint maxUpdatesPerSecond = 60u;

		[SerializeField]
		private float additionalTimeScaling = 1f;

		private float delta;

		private float updateTiming;

		private float over;

		private Action<float> updateAction;

		public uint MaxUpdatesPerSecond => maxUpdatesPerSecond;

		public float AdditionalTimeScaling
		{
			get
			{
				return additionalTimeScaling;
			}
			set
			{
				additionalTimeScaling = value;
			}
		}

		public AnimationUpdater(Action<float> updateAction, uint maxUpdatesPerSecond, float timeScale)
		{
			this.updateAction = updateAction;
			this.maxUpdatesPerSecond = maxUpdatesPerSecond;
			additionalTimeScaling = timeScale;
			updateTiming = 1f / (float)maxUpdatesPerSecond;
			delta = 0f;
			over = 0f;
		}

		public void SetMaxUpdatesPerSecond(uint maxUpdatesPerSecond)
		{
			this.maxUpdatesPerSecond = maxUpdatesPerSecond;
			updateTiming = 1f / (float)maxUpdatesPerSecond;
			delta = 0f;
			over = 0f;
		}

		public bool Update(float deltaTime)
		{
			delta += deltaTime;
			if (delta + over >= updateTiming)
			{
				over = (delta + over) % updateTiming;
				updateAction(delta * additionalTimeScaling);
				delta = 0f;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			delta = 0f;
			over = 0f;
		}
	}
}
