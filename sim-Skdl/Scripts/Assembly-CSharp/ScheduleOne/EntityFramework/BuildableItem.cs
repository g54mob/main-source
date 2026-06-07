using System;
using System.Collections.Generic;
using EPOOutline;
using FishNet.Component.Ownership;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.ItemFramework;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Persistence.Loaders;
using ScheduleOne.Property;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.EntityFramework
{
	[RequireComponent(typeof(PredictedSpawn))]
	public abstract class BuildableItem : NetworkBehaviour, IGUIDRegisterable, ISaveable
	{
		public enum EOutlineColor
		{
			White = 0,
			Blue = 1,
			LightBlue = 2
		}

		[HideInInspector]
		public bool isGhost;

		[Header("Build Settings")]
		[SerializeField]
		protected GameObject buildHandler;

		public float HoldDistance;

		public Transform BuildPoint;

		public Transform MidAirCenterPoint;

		public BoxCollider BoundingCollider;

		[SerializeField]
		[Header("Outline settings")]
		protected List<GameObject> OutlineRenderers;

		[SerializeField]
		protected bool IncludeOutlineRendererChildren;

		protected Outlinable OutlineEffect;

		[Header("Culling Settings")]
		public GameObject[] GameObjectsToCull;

		public List<MeshRenderer> MeshesToCull;

		[Header("Buildable Events")]
		public UnityEvent onGhostModel;

		public UnityEvent onInitialized;

		public UnityEvent onDestroyed;

		public Action<BuildableItem> onDestroyedWithParameter;

		private bool NetworkInitialize___EarlyScheduleOne_002EEntityFramework_002EBuildableItemAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EEntityFramework_002EBuildableItemAssembly_002DCSharp_002Edll_Excuted;

		public ItemInstance ItemInstance { get; protected set; }

		public ScheduleOne.Property.Property ParentProperty { get; protected set; }

		public bool IsDestroyed { get; protected set; }

		public bool Initialized { get; protected set; }

		public Guid GUID { get; protected set; }

		public bool IsCulled { get; protected set; }

		public GameObject BuildHandler => null;

		protected bool _locallyBuilt { get; set; }

		public string SaveFolderName => null;

		public string SaveFileName => null;

		public Loader Loader => null;

		public bool ShouldSaveUnderFolder => false;

		public List<string> LocalExtraFiles { get; set; }

		public List<string> LocalExtraFolders { get; set; }

		public bool HasChanged { get; set; }

		public void SetLocallyBuilt()
		{
		}

		public virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual ScheduleOne.Property.Property GetProperty(Transform searchTransform = null)
		{
			return null;
		}

		public virtual string GetManagementName()
		{
			return null;
		}

		public virtual string GetDefaultManagementName()
		{
			return null;
		}

		public virtual void InitializeSaveable()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public override void OnStartClient()
		{
		}

		protected abstract void SendInitializationToClient(NetworkConnection conn);

		protected abstract void SendInitializationToServer();

		protected void InitializeBuildableItem(ItemInstance instance, string GUID, string parentPropertyCode)
		{
		}

		public bool CanBePickedUp(out string reason)
		{
			reason = null;
			return false;
		}

		public virtual bool CanBeDestroyed(out string reason)
		{
			reason = null;
			return false;
		}

		public void PickupItem()
		{
		}

		protected virtual void Destroy()
		{
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		private void Destroy_Server()
		{
		}

		[ObserversRpc(RunLocally = true)]
		private void Destroy_Client()
		{
		}

		public void SetGUID(Guid guid)
		{
		}

		private static Color32 GetColorFromOutlineColorEnum(EOutlineColor col)
		{
			return default(Color32);
		}

		public virtual void ShowOutline(Color color)
		{
		}

		public void ShowOutline(EOutlineColor color)
		{
		}

		public virtual void HideOutline()
		{
		}

		public bool GetPenetration(out float x, out float z, out float y)
		{
			x = default(float);
			z = default(float);
			y = default(float);
			return false;
		}

		private bool HasLoS_IgnoreBuildables(Vector3 point)
		{
			return false;
		}

		public virtual void SetCulled(bool culled)
		{
		}

		public virtual DynamicSaveData GetSaveData()
		{
			return null;
		}

		public virtual BuildableItemData GetBaseData()
		{
			return null;
		}

		public string GetSaveString()
		{
			return null;
		}

		public virtual List<string> WriteData(string parentFolderPath)
		{
			return null;
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

		private void RpcWriter___Server_Destroy_Server_2166136261()
		{
		}

		private void RpcLogic___Destroy_Server_2166136261()
		{
		}

		private void RpcReader___Server_Destroy_Server_2166136261(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Observers_Destroy_Client_2166136261()
		{
		}

		private void RpcLogic___Destroy_Client_2166136261()
		{
		}

		private void RpcReader___Observers_Destroy_Client_2166136261(PooledReader PooledReader0, Channel channel)
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EEntityFramework_002EBuildableItem_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
