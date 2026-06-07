using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Law;
using ScheduleOne.NPCs.Behaviour;
using ScheduleOne.NPCs.Other;
using ScheduleOne.PlayerScripts;

namespace ScheduleOne.NPCs.Actions
{
	public class NPCActions : NetworkBehaviour
	{
		private NPC npc;

		private bool _canUseUmbrella;

		private UseUmbrella _umbrellaAction;

		private bool NetworkInitialize___EarlyScheduleOne_002ENPCs_002EActions_002ENPCActionsAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002ENPCs_002EActions_002ENPCActionsAssembly_002DCSharp_002Edll_Excuted;

		protected NPCBehaviour behaviour => null;

		public virtual void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void Cower()
		{
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		public void CallPolice_Networked(NetworkObject playerObj)
		{
		}

		public void SetCallPoliceBehaviourCrime(Crime crime)
		{
		}

		public void FacePlayer(Player player)
		{
		}

		public void SetCanUseUmbrella(bool canUseUmbrella)
		{
		}

		private void UpdateUmbrellaUse()
		{
		}

		private float GetRainAmount()
		{
			return 0f;
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

		private void RpcWriter___Server_CallPolice_Networked_3323014238(NetworkObject playerObj)
		{
		}

		public void RpcLogic___CallPolice_Networked_3323014238(NetworkObject playerObj)
		{
		}

		private void RpcReader___Server_CallPolice_Networked_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002ENPCs_002EActions_002ENPCActions_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
