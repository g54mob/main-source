using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Building;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Property;
using UnityEngine;

namespace ScheduleOne.EntityFramework
{
	public class SurfaceItem : BuildableItem
	{
		[Header("Settings")]
		public List<Surface.ESurfaceType> ValidSurfaceTypes;

		public bool AllowRotation;

		protected Vector3 RelativePosition;

		protected Quaternion RelativeRotation;

		private bool NetworkInitialize___EarlyScheduleOne_002EEntityFramework_002ESurfaceItemAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EEntityFramework_002ESurfaceItemAssembly_002DCSharp_002Edll_Excuted;

		public Surface ParentSurface { get; protected set; }

		public float RotationIncrement { get; }

		public override void Awake()
		{
		}

		protected override void SendInitializationToServer()
		{
		}

		protected override void SendInitializationToClient(NetworkConnection conn)
		{
		}

		[ServerRpc(RequireOwnership = false)]
		private void InitializeSurfaceItem_Server(ItemInstance instance, string GUID, string parentSurfaceGUID, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		[ObserversRpc(RunLocally = true)]
		[TargetRpc]
		private void InitializeSurfaceItem_Client(NetworkConnection conn, ItemInstance instance, string GUID, string parentSurfaceGUID, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		public virtual void InitializeSurfaceItem(ItemInstance instance, string GUID, string parentSurfaceGUID, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		private void SetTransformData(string parentSurfaceGUID, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		protected override ScheduleOne.Property.Property GetProperty(Transform searchTransform = null)
		{
			return null;
		}

		public override BuildableItemData GetBaseData()
		{
			return null;
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

		private void RpcWriter___Server_InitializeSurfaceItem_Server_2652836379(ItemInstance instance, string GUID, string parentSurfaceGUID, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		private void RpcLogic___InitializeSurfaceItem_Server_2652836379(ItemInstance instance, string GUID, string parentSurfaceGUID, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		private void RpcReader___Server_InitializeSurfaceItem_Server_2652836379(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Target_InitializeSurfaceItem_Client_2932264618(NetworkConnection conn, ItemInstance instance, string GUID, string parentSurfaceGUID, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		private void RpcLogic___InitializeSurfaceItem_Client_2932264618(NetworkConnection conn, ItemInstance instance, string GUID, string parentSurfaceGUID, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		private void RpcReader___Target_InitializeSurfaceItem_Client_2932264618(PooledReader PooledReader0, Channel channel)
		{
		}

		private void RpcWriter___Observers_InitializeSurfaceItem_Client_2932264618(NetworkConnection conn, ItemInstance instance, string GUID, string parentSurfaceGUID, Vector3 relativePosition, Quaternion relativeRotation)
		{
		}

		private void RpcReader___Observers_InitializeSurfaceItem_Client_2932264618(PooledReader PooledReader0, Channel channel)
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EEntityFramework_002ESurfaceItem_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
