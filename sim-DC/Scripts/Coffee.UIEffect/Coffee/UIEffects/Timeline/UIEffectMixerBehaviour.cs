using UnityEngine.Playables;

namespace Coffee.UIEffects.Timeline
{
	public abstract class UIEffectMixerBehaviour<T, TBehavior> : PlayableBehaviour where TBehavior : UIEffectBehaviour, IGetValue<T>, new()
	{
		private T _defaultValue;

		protected abstract T currentValue { get; set; }

		protected UIEffect effect { get; private set; }

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
		}

		public override void OnPlayableDestroy(Playable playable)
		{
		}

		private static float GetTotalWeight(Playable playable)
		{
			return 0f;
		}

		private void InitializeIfNeeded(UIEffect newEffect)
		{
		}

		protected abstract T Add(T current, T value, float weight);

		protected abstract T Lerp(T defaultValue, T value, float weight);
	}
}
