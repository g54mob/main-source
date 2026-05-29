using System;
using System.Runtime.CompilerServices;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal sealed class LowLevelButtonEvent : LowLevelEvent
	{
		private const int LVLTNbasRajiqyhcoFTsdxYpUJNJ = 100;

		public float value;

		private static readonly ObjectPool<LowLevelButtonEvent> VQPWRbKOUMcQQSOcpisujDSJyBXH;

		[CompilerGenerated]
		private static Func<LowLevelButtonEvent> autMBJdbnRzwuaphYbdbvPoQqzm;

		private LowLevelButtonEvent()
		{
		}

		static LowLevelButtonEvent()
		{
			VQPWRbKOUMcQQSOcpisujDSJyBXH = new ObjectPool<LowLevelButtonEvent>(100, () => new LowLevelButtonEvent());
		}

		public static LowLevelButtonEvent GetPooled(float timestamp, float value)
		{
			LowLevelButtonEvent lowLevelButtonEvent = VQPWRbKOUMcQQSOcpisujDSJyBXH.Get();
			while (true)
			{
				int num = 1919851006;
				while (true)
				{
					switch (num ^ 0x726E99FF)
					{
					case 0:
						break;
					case 1:
						goto IL_0029;
					default:
						lowLevelButtonEvent.timestamp = timestamp;
						lowLevelButtonEvent.value = value;
						return lowLevelButtonEvent;
					}
					break;
					IL_0029:
					lowLevelButtonEvent.id = LowLevelEvent.GetNextId();
					num = 1919851005;
				}
			}
		}

		public static void ReturnPooled(LowLevelButtonEvent @event)
		{
			if (@event != null)
			{
				VQPWRbKOUMcQQSOcpisujDSJyBXH.Return(@event);
			}
		}

		[CompilerGenerated]
		private static LowLevelButtonEvent xViluIsdmRbyXfNcACpWftHcgjgq()
		{
			return new LowLevelButtonEvent();
		}
	}
}
