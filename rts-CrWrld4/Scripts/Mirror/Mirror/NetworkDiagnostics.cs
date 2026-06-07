using System;
using System.Runtime.CompilerServices;

namespace Mirror
{
	public static class NetworkDiagnostics
	{
		public readonly struct MessageInfo
		{
			public readonly NetworkMessage message;

			public readonly int channel;

			public readonly int bytes;

			public readonly int count;

			internal MessageInfo(NetworkMessage message, int channel, int bytes, int count)
			{
				this.message = null;
				this.channel = 0;
				this.bytes = 0;
				this.count = 0;
			}
		}

		public static event Action<MessageInfo> OutMessageEvent
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

		public static event Action<MessageInfo> InMessageEvent
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

		internal static void OnSend<T>(T message, int channel, int bytes, int count) where T : struct, NetworkMessage
		{
		}

		internal static void OnReceive<T>(T message, int channel, int bytes) where T : struct, NetworkMessage
		{
		}
	}
}
