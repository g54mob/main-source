using Febucci.Parsing;

namespace Febucci.TextAnimatorCore
{
	public interface IEffectManaged : IEffect, ITagProvider, INotifyValueChanged
	{
		EffectPresetSettings Settings { get; }

		IEffectContent Appearance { get; }

		IEffectContent Disappearance { get; }

		IEffectContent Persistent { get; }
	}
}
