using FishNet.Object;
using UnityEngine;

namespace FishNet.Demo.HashGrid
{
	public class MoveRandomly : NetworkBehaviour
	{
		[SerializeField]
		private Renderer _renderer;

		private float _moveRate;

		public const float Range = 25f;

		private Vector3 _goal;

		private Vector3 _start;

		private bool NetworkInitialize___EarlyFishNet_002EDemo_002EHashGrid_002EMoveRandomlyFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EDemo_002EHashGrid_002EMoveRandomlyFishNet_002EDemos_002Edll_Excuted;

		private void Update()
		{
		}

		public override void OnStartNetwork()
		{
		}

		public override void OnStopNetwork()
		{
		}

		private void RandomizeGoal()
		{
		}

		private Vector3 RandomInsideRange()
		{
			return default(Vector3);
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
