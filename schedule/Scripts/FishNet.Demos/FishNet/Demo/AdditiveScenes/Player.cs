using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Demo.AdditiveScenes
{
	public class Player : NetworkBehaviour
	{
		[SerializeField]
		private Transform _ownerObjects;

		[SerializeField]
		private float _moveRate;

		private List<Waypoint> _wayPoints;

		private int _goalIndex;

		private Vector3 _goalOffset;

		private bool NetworkInitialize___EarlyFishNet_002EDemo_002EAdditiveScenes_002EPlayerFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EDemo_002EAdditiveScenes_002EPlayerFishNet_002EDemos_002Edll_Excuted;

		public override void OnStartServer()
		{
		}

		public override void OnOwnershipClient(NetworkConnection prevOwner)
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
