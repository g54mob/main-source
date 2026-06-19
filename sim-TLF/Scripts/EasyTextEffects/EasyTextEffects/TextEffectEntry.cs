using System;
using EasyTextEffects.Effects;
using UnityEngine.Events;

namespace EasyTextEffects
{
	[Serializable]
	public class TextEffectEntry
	{
		public enum TriggerWhen
		{
			OnStart = 0,
			Manual = 1
		}

		public TriggerWhen triggerWhen;

		public TextEffectInstance effect;

		public UnityEvent onEffectCompleted = new UnityEvent();

		public TextEffectEntry GetCopy(int startCharIndex, int charLength)
		{
			TextEffectEntry textEffectEntry = new TextEffectEntry();
			textEffectEntry.effect = effect.Instantiate();
			textEffectEntry.effect.startCharIndex = startCharIndex;
			textEffectEntry.effect.charLength = charLength;
			textEffectEntry.triggerWhen = triggerWhen;
			textEffectEntry.onEffectCompleted = onEffectCompleted;
			return textEffectEntry;
		}

		public void StartEffect()
		{
			effect.StartEffect(this);
		}

		internal void InvokeCompleted()
		{
			onEffectCompleted?.Invoke();
		}
	}
}
