using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.NPCs;
using UnityEngine;

namespace ScheduleOne.Vision
{
	public class EntityVisibility : NetworkBehaviour
	{
		public const float MAX_VISIBLITY = 100f;

		public List<VisibilityAttribute> ActiveAttributes;

		[Header("Settings")]
		public LayerMask VisibilityCheckMask;

		[Header("References")]
		public Transform CentralVisibilityPoint;

		public List<Transform> VisibilityPoints;

		private VisibilityAttribute environmentalVisibility;

		private Dictionary<string, Coroutine> removalRoutinesDict;

		private Dictionary<string, float> maxPointsChangesByUniquenessCode;

		private List<RaycastHit> hits;

		private bool NetworkInitialize___EarlyScheduleOne_002EVision_002EEntityVisibilityAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EVision_002EEntityVisibilityAssembly_002DCSharp_002Edll_Excuted;

		public virtual float CurrentVisibility => 0f;

		public virtual float Suspiciousness => 0f;

		public List<EntityVisualState> VisualStates { get; protected set; }

		public Vector3 CenterPoint => default(Vector3);

		public virtual void Awake()
		{
		}

		public override void OnStartClient()
		{
		}

		private float CalculateVisibility()
		{
			return 0f;
		}

		public VisibilityAttribute GetAttribute(string name)
		{
			return null;
		}

		private void UpdateEnvironmentalVisibilityAttribute()
		{
		}

		public float CalculateExposureToPoint(Vector3 point, float checkRange = 50f, NPC checkingNPC = null)
		{
			return 0f;
		}

		[ServerRpc(RunLocally = true)]
		public void ApplyState(string label, EVisualState state, float autoRemoveAfter = 0f)
		{
		}

		[ServerRpc(RunLocally = true)]
		public void RemoveState(string label, float delay = 0f)
		{
		}

		public EntityVisualState GetState(string label)
		{
			return null;
		}

		public void ClearStates()
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

		private void RpcWriter___Server_ApplyState_2910447583(string label, EVisualState state, float autoRemoveAfter = 0f)
		{
		}

		public void RpcLogic___ApplyState_2910447583(string label, EVisualState state, float autoRemoveAfter = 0f)
		{
		}

		private void RpcReader___Server_ApplyState_2910447583(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Server_RemoveState_606697822(string label, float delay = 0f)
		{
		}

		public void RpcLogic___RemoveState_606697822(string label, float delay = 0f)
		{
		}

		private void RpcReader___Server_RemoveState_606697822(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EVision_002EEntityVisibility_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
