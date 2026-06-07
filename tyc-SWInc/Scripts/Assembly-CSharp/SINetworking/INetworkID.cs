using UnityEngine;

namespace SINetworking
{
	public interface INetworkID
	{
		uint NetworkID { get; set; }

		GameObject GO { get; }
	}
}
