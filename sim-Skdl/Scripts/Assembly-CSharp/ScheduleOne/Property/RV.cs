using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Core;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Property
{
	public class RV : Property
	{
		public Transform ModelContainer;

		public Transform FXContainer;

		public UnityEvent onExplode;

		public UnityEvent onDestroyedState;

		private bool _exploded;

		private bool NetworkInitialize___EarlyScheduleOne_002EProperty_002ERVAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EProperty_002ERVAssembly_002DCSharp_002Edll_Excuted;

		public bool IsDestroyed { get; private set; }

		protected override void Start()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		private void UpdateVariables()
		{
		}

		public override bool ShouldSave()
		{
			return false;
		}

		[Button]
		public void BlowUp()
		{
		}

		[TargetRpc]
		private void SetDestroyed_Client(NetworkConnection conn)
		{
		}

		public void SetDestroyed()
		{
		}

		private void OnSleep()
		{
		}

		public override bool CanDeliverToProperty()
		{
			return false;
		}

		public override bool CanRespawnInsideProperty()
		{
			return false;
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Target_SetDestroyed_Client_328543758(NetworkConnection conn)
		{
		}

		private void RpcLogic___SetDestroyed_Client_328543758(NetworkConnection conn)
		{
		}

		private void RpcReader___Target_SetDestroyed_Client_328543758(PooledReader PooledReader0, Channel channel)
		{
		}

		public override void Awake()
		{
		}
	}
}
