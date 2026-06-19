using UnityEngine;

namespace Aggro.Core.Networking
{
	public abstract class NetworkScriptableObject : ScriptableObject
	{
		[HideInInspector]
		[SerializeField]
		private uint _networkId;

		public uint rawNetworkId => _networkId;

		public bool isNetworkValid => rawNetworkId != 0;

		public NetScrobId networkId => new NetScrobId(_networkId);

		protected virtual void OnValidate()
		{
		}
	}
}
