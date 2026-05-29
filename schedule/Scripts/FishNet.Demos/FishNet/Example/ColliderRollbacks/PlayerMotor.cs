using FishNet.Object;
using UnityEngine;

namespace FishNet.Example.ColliderRollbacks
{
	public class PlayerMotor : NetworkBehaviour
	{
		[SerializeField]
		private float _moveRate;

		private CharacterController _characterController;

		private bool NetworkInitialize___EarlyFishNet_002EExample_002EColliderRollbacks_002EPlayerMotorFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EExample_002EColliderRollbacks_002EPlayerMotorFishNet_002EDemos_002Edll_Excuted;

		public override void OnStartClient()
		{
		}

		private void Update()
		{
		}

		private void Move()
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
