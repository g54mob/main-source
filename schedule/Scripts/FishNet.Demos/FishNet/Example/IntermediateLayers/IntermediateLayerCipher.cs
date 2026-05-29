using System;
using FishNet.Managing.Transporting;

namespace FishNet.Example.IntermediateLayers
{
	public class IntermediateLayerCipher : IntermediateLayer
	{
		private const byte CIPHER_KEY = 5;

		public override ArraySegment<byte> HandleIncoming(ArraySegment<byte> src, bool fromServer)
		{
			return default(ArraySegment<byte>);
		}

		public override ArraySegment<byte> HandleOutgoing(ArraySegment<byte> src, bool toServer)
		{
			return default(ArraySegment<byte>);
		}
	}
}
