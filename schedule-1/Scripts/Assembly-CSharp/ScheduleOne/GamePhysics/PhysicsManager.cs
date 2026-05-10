using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.DevUtilities;

namespace ScheduleOne.GamePhysics
{
	public class PhysicsManager : NetworkSingleton<PhysicsManager>
	{
		public const bool AUTO_SYNC_TRANSFORMS = true;

		private bool NetworkInitialize___EarlyScheduleOne_002EGamePhysics_002EPhysicsManagerAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EGamePhysics_002EPhysicsManagerAssembly_002DCSharp_002Edll_Excuted;

		public float GravityMultiplier { get; private set; }

		public override void Awake()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		[TargetRpc]
		[ObserversRpc(RunLocally = true)]
		public void SetGravityMultiplier(NetworkConnection conn, float gravity)
		{
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

		private void RpcWriter___Observers_SetGravityMultiplier_530160725(NetworkConnection conn, float gravity)
		{
		}

		public void RpcLogic___SetGravityMultiplier_530160725(NetworkConnection conn, float gravity)
		{
		}

		private void RpcReader___Observers_SetGravityMultiplier_530160725(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Target_SetGravityMultiplier_530160725(NetworkConnection conn, float gravity)
		{
		}

		private void RpcReader___Target_SetGravityMultiplier_530160725(PooledReader PooledReader0, Channel channel)
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EGamePhysics_002EPhysicsManager_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
