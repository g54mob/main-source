using System;
using Dissonance.Extensions;
using Mirror;

namespace Dissonance.Integrations.MirrorIgnorance
{
	internal struct DissonanceNetworkMessage : NetworkMessage, IDisposable
	{
		public ArraySegment<byte> Data;

		public DissonanceNetworkMessage(ArraySegment<byte> packet)
		{
			Data = ArraySegmentExtensions.CopyTo(packet, DissonanceNetworkMessageExtensions.SerializationBuffers.Get());
		}

		public void Dispose()
		{
			byte[] array = Data.Array;
			if (array != null && array.Length == 1024)
			{
				DissonanceNetworkMessageExtensions.SerializationBuffers.Put(array);
				Data = new ArraySegment<byte>(Array.Empty<byte>(), 0, 0);
			}
		}
	}
}
