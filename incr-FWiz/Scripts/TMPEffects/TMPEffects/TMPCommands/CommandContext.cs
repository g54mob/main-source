using TMPEffects.Components;
using TMPEffects.Tags;

namespace TMPEffects.TMPCommands
{
	public class CommandContext : ICommandContext
	{
		public TMPWriter Writer { get; set; }

		public TMPEffectTagIndices Indices { get; set; }

		public object CustomData { get; set; }

		public CommandContext(TMPWriter writer, TMPEffectTagIndices indices)
		{
		}
	}
}
