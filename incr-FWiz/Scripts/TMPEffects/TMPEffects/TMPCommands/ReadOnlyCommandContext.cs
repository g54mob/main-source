using TMPEffects.Components;
using TMPEffects.Tags;

namespace TMPEffects.TMPCommands
{
	public class ReadOnlyCommandContext : ICommandContext
	{
		private ICommandContext context;

		public TMPWriter Writer => null;

		public TMPEffectTagIndices Indices => default(TMPEffectTagIndices);

		public object CustomData => null;

		public ReadOnlyCommandContext(ICommandContext context)
		{
		}
	}
}
