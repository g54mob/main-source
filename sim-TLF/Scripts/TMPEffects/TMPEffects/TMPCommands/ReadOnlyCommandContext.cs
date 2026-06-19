using TMPEffects.Components;
using TMPEffects.Tags;

namespace TMPEffects.TMPCommands
{
	public class ReadOnlyCommandContext : ICommandContext
	{
		private ICommandContext context;

		public TMPWriter Writer => context.Writer;

		public TMPEffectTagIndices Indices => context.Indices;

		public object CustomData => context.CustomData;

		public ReadOnlyCommandContext(ICommandContext context)
		{
			this.context = context;
		}
	}
}
