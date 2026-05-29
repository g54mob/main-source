using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.EntityFramework;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Storage;
using ScheduleOne.Tiles;
using ScheduleOne.UI.Management;
using UnityEngine;

namespace ScheduleOne.ObjectScripts
{
	[RequireComponent(typeof(ConfigurationReplicator))]
	public class PlaceableStorageEntity : GridItem, ITransitEntity, IUsable, IConfigurable
	{
		[Header("References")]
		public StorageEntity StorageEntity;

		public Transform[] accessPoints;

		[SerializeField]
		private Transform _linkOrigin;

		private EntityConfiguration _configuration;

		private ConfigurationReplicator _configReplicator;

		public SyncVar<NetworkObject> syncVar____003CNPCUserObject_003Ek__BackingField;

		public SyncVar<NetworkObject> syncVar____003CPlayerUserObject_003Ek__BackingField;

		public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;

		private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EPlaceableStorageEntityAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EPlaceableStorageEntityAssembly_002DCSharp_002Edll_Excuted;

		public string Name => null;

		public List<ItemSlot> InputSlots { get; set; }

		public List<ItemSlot> OutputSlots { get; set; }

		public Transform LinkOrigin => null;

		public NetworkObject NPCUserObject
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public NetworkObject PlayerUserObject
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public Transform[] AccessPoints => null;

		public bool Selectable { get; }

		public bool IsAcceptingItems { get; set; }

		public EntityConfiguration Configuration => null;

		public ConfigurationReplicator ConfigReplicator => null;

		public EConfigurableType ConfigurableType => default(EConfigurableType);

		public WorldspaceUIElement WorldspaceUI { get; set; }

		public NetworkObject CurrentPlayerConfigurer
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			set
			{
			}
		}

		public Sprite TypeIcon => null;

		public Transform Transform => null;

		public Transform UIPoint => null;

		public bool CanBeSelected => false;

		public NetworkObject SyncAccessor__003CNPCUserObject_003Ek__BackingField
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NetworkObject SyncAccessor__003CPlayerUserObject_003Ek__BackingField
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NetworkObject SyncAccessor__003CCurrentPlayerConfigurer_003Ek__BackingField
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override void Awake()
		{
		}

		protected override void Start()
		{
		}

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID)
		{
		}

		public override string GetManagementName()
		{
			return null;
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		public void SetPlayerUser(NetworkObject playerObject)
		{
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		public void SetNPCUser(NetworkObject npcObject)
		{
		}

		public override bool CanBeDestroyed(out string reason)
		{
			reason = null;
			return false;
		}

		protected override void Destroy()
		{
		}

		public override BuildableItemData GetBaseData()
		{
			return null;
		}

		public override DynamicSaveData GetSaveData()
		{
			return null;
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		public void SetConfigurer(NetworkObject player)
		{
		}

		public void SendConfigurationToClient(NetworkConnection conn)
		{
		}

		public WorldspaceUIElement CreateWorldspaceUI()
		{
			return null;
		}

		public void DestroyWorldspaceUI()
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

		private void RpcWriter___Server_SetPlayerUser_3323014238(NetworkObject playerObject)
		{
		}

		public void RpcLogic___SetPlayerUser_3323014238(NetworkObject playerObject)
		{
		}

		private void RpcReader___Server_SetPlayerUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Server_SetNPCUser_3323014238(NetworkObject npcObject)
		{
		}

		public void RpcLogic___SetNPCUser_3323014238(NetworkObject npcObject)
		{
		}

		private void RpcReader___Server_SetNPCUser_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Server_SetConfigurer_3323014238(NetworkObject player)
		{
		}

		public void RpcLogic___SetConfigurer_3323014238(NetworkObject player)
		{
		}

		private void RpcReader___Server_SetConfigurer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		public virtual bool ReadSyncVar___ScheduleOne_002EObjectScripts_002EPlaceableStorageEntity(PooledReader PooledReader0, uint UInt321, bool Boolean2)
		{
			return false;
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EObjectScripts_002EPlaceableStorageEntity_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
