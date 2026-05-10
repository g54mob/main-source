using FishNet.Object;
using UnityEngine;

namespace FishNet.Example.ColliderRollbacks
{
	public class Aim : NetworkBehaviour
	{
		private readonly Vector3 _offset;

		private bool NetworkInitialize___EarlyFishNet_002EExample_002EColliderRollbacks_002EAimFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EExample_002EColliderRollbacks_002EAimFishNet_002EDemos_002Edll_Excuted;

		public PlayerCamera PlayerCamera { get; private set; }

		public override void OnStartClient()
		{
		}

		private void Update()
		{
		}

		private void MoveAim()
		{
		}

		private void MoveCamera()
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
