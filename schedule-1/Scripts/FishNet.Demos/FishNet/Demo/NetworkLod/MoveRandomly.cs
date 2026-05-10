using FishNet.Object;
using UnityEngine;

namespace FishNet.Demo.NetworkLod
{
	public class MoveRandomly : NetworkBehaviour
	{
		[SerializeField]
		private float _moveRate;

		[SerializeField]
		private Renderer _renderer;

		[SerializeField]
		private bool _updateRotation;

		private const float _range = 10f;

		private Vector3 _goalPosition;

		private Quaternion _goalRotation;

		private Vector3 _startPosition;

		private bool NetworkInitialize___EarlyFishNet_002EDemo_002ENetworkLod_002EMoveRandomlyFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EDemo_002ENetworkLod_002EMoveRandomlyFishNet_002EDemos_002Edll_Excuted;

		private void Update()
		{
		}

		public override void OnStartNetwork()
		{
		}

		private void RandomizeGoal()
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
