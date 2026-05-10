using FishNet.Object;
using UnityEngine;

namespace FishNet.Demo.HashGrid
{
	public class GridSpawner : NetworkBehaviour
	{
		[SerializeField]
		private NetworkObject _staticPrefab;

		[SerializeField]
		private NetworkObject _movingPrefab;

		[SerializeField]
		private int _movingCount;

		[SerializeField]
		private byte _spacing;

		private bool NetworkInitialize___EarlyFishNet_002EDemo_002EHashGrid_002EGridSpawnerFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EDemo_002EHashGrid_002EGridSpawnerFishNet_002EDemos_002Edll_Excuted;

		private float _range => 0f;

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

		public virtual void Awake()
		{
		}
	}
}
