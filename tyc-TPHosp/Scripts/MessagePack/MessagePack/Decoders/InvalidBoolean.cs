using System;

namespace MessagePack.Decoders
{
	internal sealed class InvalidBoolean : IBooleanDecoder
	{
		internal static IBooleanDecoder Instance = new InvalidBoolean();

		private InvalidBoolean()
		{
		}

		public bool Read()
		{
			throw new InvalidOperationException("code is invalid.");
		}
	}
}
