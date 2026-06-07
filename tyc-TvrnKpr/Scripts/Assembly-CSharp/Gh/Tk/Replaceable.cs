using System;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	[GhTypeHintingAlias("Gh.Tk.Replacable")]
	public class Replaceable : AttachedBehaviour
	{
		public Replace_Job CurrentReplaceJob => null;

		public event EventHandler UpdateVisualEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public Job CreateReplaceJob(GameItemTemplate template)
		{
			return null;
		}

		public override void OnDestroy()
		{
		}

		internal void InvalidateVisual()
		{
		}
	}
}
