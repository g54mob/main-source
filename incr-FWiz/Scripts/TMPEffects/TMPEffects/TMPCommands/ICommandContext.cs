using TMPEffects.Components;
using TMPEffects.Tags;

namespace TMPEffects.TMPCommands
{
	public interface ICommandContext
	{
		TMPWriter Writer { get; }

		TMPEffectTagIndices Indices { get; }

		object CustomData { get; }
	}
}
