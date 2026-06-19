using UnityEngine;

namespace Aggro.Core.Networking
{
	public class NetworkPrefab : MonoBehaviour
	{
		[HideInInspector]
		[SerializeField]
		private uint _networkId;

		public uint networkId => _networkId;

		public bool isNetworkValid => networkId != 0;

		protected virtual void OnValidate()
		{
		}
	}
}
