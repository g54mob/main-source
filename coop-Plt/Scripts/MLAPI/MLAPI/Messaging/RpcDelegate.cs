using System.IO;

namespace MLAPI.Messaging
{
	public delegate void RpcDelegate(ulong clientId, Stream stream);
}
