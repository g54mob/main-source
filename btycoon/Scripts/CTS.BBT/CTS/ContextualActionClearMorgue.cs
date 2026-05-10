using System;
using CTS.BBT;

namespace CTS
{
	[Serializable]
	internal sealed class ContextualActionClearMorgue : MenuContextualAction<StationMorgue>
	{
		public override void Setup()
		{
		}

		protected override bool CanBePerformed()
		{
			if (contextActor.DeadBodyCount == 0)
			{
				return false;
			}
			return true;
		}

		protected override void Execution()
		{
			contextActor.DropBodyBag();
		}
	}
}
