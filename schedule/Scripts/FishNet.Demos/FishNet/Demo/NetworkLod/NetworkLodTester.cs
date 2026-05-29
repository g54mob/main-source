using FishNet.Managing.Observing;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Demo.NetworkLod
{
	public class NetworkLodTester : NetworkBehaviour
	{
		[Header("General")]
		[SerializeField]
		private NetworkObject _prefab;

		[SerializeField]
		private ObserverManager _observerManager;

		[Range(1f, 8f)]
		[SerializeField]
		private byte _lodLevel;

		[Header("Spawning")]
		[SerializeField]
		private int _count;

		[SerializeField]
		private float _xyRange;

		[SerializeField]
		private float _zRange;

		private bool NetworkInitialize___EarlyFishNet_002EDemo_002ENetworkLod_002ENetworkLodTesterFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EDemo_002ENetworkLod_002ENetworkLodTesterFishNet_002EDemos_002Edll_Excuted;

		public virtual void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void Awake_UserLogic_FishNet_002EDemo_002ENetworkLod_002ENetworkLodTester_FishNet_002EDemos_002Edll()
		{
		}
	}
}
