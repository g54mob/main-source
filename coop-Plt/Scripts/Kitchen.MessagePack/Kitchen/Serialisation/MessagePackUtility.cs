using MessagePack;

namespace Kitchen.Serialisation
{
	public static class MessagePackUtility
	{
		public static MessagePackSerializerOptions DefaultOptions;

		public static MessagePackSerializerOptions ObsoleteOptionsWithoutAOT;

		public static byte[] Serialize<T>(T data, bool force_compression = false)
		{
			return Serialize(data, DefaultOptions, force_compression);
		}

		public static T Deserialize<T>(byte[] data, bool force_compression = false)
		{
			try
			{
				return Deserialize<T>(data, DefaultOptions, force_compression);
			}
			catch (MessagePackSerializationException ex)
			{
				try
				{
					return Deserialize<T>(data, ObsoleteOptionsWithoutAOT, force_compression);
				}
				catch (MessagePackSerializationException)
				{
					throw ex;
				}
			}
		}

		private static byte[] Serialize<T>(T data, MessagePackSerializerOptions opts, bool force_compression = false)
		{
			if (force_compression)
			{
				opts = opts.WithCompression(MessagePackCompression.Lz4Block);
			}
			return MessagePackSerializer.Serialize(data, opts);
		}

		private static T Deserialize<T>(byte[] data, MessagePackSerializerOptions opts, bool force_compression = false)
		{
			if (force_compression)
			{
				opts = opts.WithCompression(MessagePackCompression.Lz4Block);
			}
			return MessagePackSerializer.Deserialize<T>(data, opts);
		}
	}
}
