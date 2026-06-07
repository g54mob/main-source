using System;
using Febucci.Parsing;
using Febucci.TextAnimatorCore;

namespace Febucci.TextAnimatorForUnity.Effects.Core
{
	[Serializable]
	public abstract class ManagedEffectScriptableBase : EffectScriptableBase, IEffectManaged, IEffect, ITagProvider, INotifyValueChanged
	{
		public abstract EffectPresetSettings Settings { get; }

		public abstract IEffectContent Appearance { get; }

		public abstract IEffectContent Disappearance { get; }

		public abstract IEffectContent Persistent { get; }

		public event Action OnValueChanged;

		protected void NotifyValueChanged()
		{
			this.OnValueChanged?.Invoke();
		}
	}
}
