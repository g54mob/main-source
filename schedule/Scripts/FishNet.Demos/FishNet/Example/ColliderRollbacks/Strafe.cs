using FishNet.Object;

namespace FishNet.Example.ColliderRollbacks
{
	public class Strafe : NetworkBehaviour
	{
		public float MoveRate;

		public float MoveDistance;

		private bool _movingRight;

		private float _startX;

		private bool NetworkInitialize___EarlyFishNet_002EExample_002EColliderRollbacks_002EStrafeFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EExample_002EColliderRollbacks_002EStrafeFishNet_002EDemos_002Edll_Excuted;

		public override void OnStartServer()
		{
		}

		private void Update()
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
