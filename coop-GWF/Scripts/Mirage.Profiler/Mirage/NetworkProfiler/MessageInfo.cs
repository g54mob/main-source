using System;
using Mirror;
using UnityEngine;

namespace Mirage.NetworkProfiler
{
	[Serializable]
	public class MessageInfo
	{
		[SerializeField]
		private int _order;

		[SerializeField]
		private int _bytes;

		[SerializeField]
		private int _count;

		[SerializeField]
		private string _messageName;

		[SerializeField]
		private bool _hasNetId;

		[SerializeField]
		private uint _netId;

		[SerializeField]
		private string _objectName;

		[SerializeField]
		private string _rpcName;

		public int Order => _order;

		public string Name => _messageName;

		public int Bytes => _bytes;

		public int Count => _count;

		public int TotalBytes => Bytes * Count;

		public uint? NetId => _hasNetId ? _netId : 0u;

		public string ObjectName => _objectName;

		public string RpcName => _rpcName;

		public MessageInfo(NetworkDiagnostics.MessageInfo msg, INetworkInfoProvider provider, int order)
		{
			_order = order;
			_bytes = msg.bytes;
			_count = msg.count;
			_messageName = msg.message.GetType().FullName;
			uint? netId = provider.GetNetId(msg);
			_hasNetId = netId.HasValue;
			_netId = netId.GetValueOrDefault();
			NetworkIdentity networkIdentity = provider.GetNetworkIdentity(netId);
			_objectName = ((networkIdentity != null) ? networkIdentity.name : null);
			_rpcName = provider.GetRpcName(msg);
		}
	}
}
