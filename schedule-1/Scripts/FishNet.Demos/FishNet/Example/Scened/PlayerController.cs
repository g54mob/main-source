using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Example.Scened
{
	public class PlayerController : NetworkBehaviour
	{
		[SerializeField]
		private GameObject _camera;

		[SerializeField]
		private float _moveRate;

		[SerializeField]
		private bool _clientAuth;

		private bool NetworkInitialize___EarlyFishNet_002EExample_002EScened_002EPlayerControllerFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EExample_002EScened_002EPlayerControllerFishNet_002EDemos_002Edll_Excuted;

		public override void OnStartClient()
		{
		}

		private void Update()
		{
		}

		[ServerRpc]
		private void ServerMove(float hor, float ver)
		{
		}

		private void Move(float hor, float ver)
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

		private void RpcWriter___Server_ServerMove_1138564871(float hor, float ver)
		{
		}

		private void RpcLogic___ServerMove_1138564871(float hor, float ver)
		{
		}

		private void RpcReader___Server_ServerMove_1138564871(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		public virtual void Awake()
		{
		}
	}
}
