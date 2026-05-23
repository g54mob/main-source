using System;
using System.Runtime.CompilerServices;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal sealed class LowLevelButtonEvent : LowLevelEvent
	{
		private const int aNBDEyaYLkDZJEEliUJcJOACtODC = 100;

		public float value;

		private static readonly ObjectPool<LowLevelButtonEvent> oQJBQmusEWAvdHgvPBkmIuGgRYSh;

		[CompilerGenerated]
		private static Func<LowLevelButtonEvent> PkdHFYJlZLMiTCimwpAnCiFWpZz;

		private LowLevelButtonEvent()
		{
		}

		static LowLevelButtonEvent()
		{
			oQJBQmusEWAvdHgvPBkmIuGgRYSh = new ObjectPool<LowLevelButtonEvent>(100, () => new LowLevelButtonEvent());
		}

		public static LowLevelButtonEvent GetPooled(float timestamp, float value)
		{
			LowLevelButtonEvent lowLevelButtonEvent = oQJBQmusEWAvdHgvPBkmIuGgRYSh.Get();
			lowLevelButtonEvent.id = LowLevelEvent.GetNextId();
			lowLevelButtonEvent.timestamp = timestamp;
			lowLevelButtonEvent.value = value;
			return lowLevelButtonEvent;
		}

		public static void ReturnPooled(LowLevelButtonEvent @event)
		{
			if (@event != null)
			{
				oQJBQmusEWAvdHgvPBkmIuGgRYSh.Return(@event);
			}
		}

		[CompilerGenerated]
		private static LowLevelButtonEvent MHcgtBWcyZaVqEtlgCnOTSHqKelQ()
		{
			return new LowLevelButtonEvent();
		}
	}
}
