using System;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public class SlotMachine : Prop
	{
		public bool isWin;

		public bool isJackpot;

		public static float WinChance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static int TotalProfit
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static int CurrentJackpot
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static event EventHandler<SlotsGameEventArgs> SlotsGamePlayed
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

		public static void FireSlotsGamePlayed(Actor actor, bool didWin)
		{
		}

		protected override void ChargeForUse(Patron patron, string usageKey)
		{
		}

		public void RecordProfitLoss(int adjustment)
		{
		}

		public override Job UseService(Actor actor, ActorBehaviour behaviour, string usageKeyOverride = null, GameItem item = null, float duration = -1f)
		{
			return null;
		}
	}
}
