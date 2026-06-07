using System;

namespace Muna.Beta.OpenAI
{
	public sealed class BinaryData
	{
		private readonly byte[] data;

		public bool IsEmpty => data.Length == 0;

		public int Length => data.Length;

		public string? MediaType { get; private set; }

		public byte[] ToArray()
		{
			return data;
		}

		public ReadOnlyMemory<byte> ToMemory()
		{
			return new ReadOnlyMemory<byte>(data);
		}

		public BinaryData(byte[] data, string? mediaType = null)
		{
			this.data = data;
			MediaType = mediaType;
		}
	}
}
