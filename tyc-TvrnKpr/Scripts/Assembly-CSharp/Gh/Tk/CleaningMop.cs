using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class CleaningMop : GameItemVisual
	{
		public static HashSet<CleaningMop> AllCleaningMops;

		public static event EventHandler<EventArgs<CleaningMop>> CleaningMopAdded
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

		public static event EventHandler<EventArgs<CleaningMop>> CleaningMopRemoved
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

		public override void Start()
		{
		}

		public override void OnDestroy()
		{
		}

		public override bool CanSelect()
		{
			return false;
		}
	}
}
