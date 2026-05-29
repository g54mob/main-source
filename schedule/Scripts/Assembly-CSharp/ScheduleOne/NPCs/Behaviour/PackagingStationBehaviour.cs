using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.ObjectScripts;
using UnityEngine;

namespace ScheduleOne.NPCs.Behaviour
{
	public class PackagingStationBehaviour : Behaviour
	{
		public const float BASE_PACKAGING_TIME = 5f;

		private Coroutine packagingRoutine;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EBehaviour_002EPackagingStationBehaviourAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EBehaviour_002EPackagingStationBehaviourAssembly_002DCSharp_002Edll_Excuted;

		public PackagingStation Station { get; protected set; }

		public bool PackagingInProgress { get; protected set; }

		public override void Activate()
		{
		}

		public override void Resume()
		{
		}

		public override void Pause()
		{
		}

		public override void Disable()
		{
		}

		public override void Deactivate()
		{
		}

		public override void OnActiveTick()
		{
		}

		private void StartPackaging()
		{
		}

		public void AssignStation(PackagingStation station)
		{
		}

		public bool IsAtStation()
		{
			return false;
		}

		public void GoToStation()
		{
		}

		[ObserversRpc(RunLocally = true)]
		public void BeginPackaging()
		{
		}

		private void StopPackaging()
		{
		}

		public bool IsStationReady(PackagingStation station)
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

		private void RpcWriter___Observers_BeginPackaging_2166136261()
		{
		}

		public void RpcLogic___BeginPackaging_2166136261()
		{
		}

		private void RpcReader___Observers_BeginPackaging_2166136261(PooledReader PooledReader0, Channel channel)
		{
		}

		public override void Awake()
		{
		}
	}
}
