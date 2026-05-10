using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using FishNet.Transporting;
using ScheduleOne.Audio;
using ScheduleOne.Growing;
using ScheduleOne.ItemFramework;
using ScheduleOne.Management;
using ScheduleOne.Persistence.Datas;
using ScheduleOne.Tiles;
using ScheduleOne.UI.Management;
using UnityEngine;

namespace ScheduleOne.ObjectScripts
{
	public class MushroomBed : GrowContainer, IConfigurable
	{
		public enum EMushroomBedSoilAppearance
		{
			NoSpores = 0,
			MaskedSpores = 1,
			FullSpores = 2
		}

		[Header("Mushroom Bed")]
		[SerializeField]
		private float _internalSideLength;

		[SerializeField]
		private ConfigurationReplicator _configurationReplicator;

		[SerializeField]
		private Sprite _typeIcon;

		[SerializeField]
		private MushroomBedUIElement _worldspaceUIPrefab;

		[SerializeField]
		private ParticleSystem _poofParticles;

		[SerializeField]
		private AudioSourceController _poofSound;

		[SerializeField]
		private Transform _colonyAlignment;

		[SerializeField]
		private Transform _mixFXContainer;

		[SerializeField]
		private ParticleSystem[] _mixParticles;

		[SerializeField]
		private AudioSourceController _mixSound;

		private Material _soilMaterialInstance;

		private EMushroomBedSoilAppearance _currentSoilAppearance;

		private bool _mushroomBedColdAtLeastOnce;

		public SyncVar<NetworkObject> syncVar____003CCurrentPlayerConfigurer_003Ek__BackingField;

		private bool NetworkInitialize___EarlyScheduleOne_002EObjectScripts_002EMushroomBedAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EObjectScripts_002EMushroomBedAssembly_002DCSharp_002Edll_Excuted;

		public ShroomColony CurrentColony { get; set; }

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

		protected MushroomBedConfiguration _configuration { get; set; }

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

		public override void OnSpawnServer(NetworkConnection connection)
		{
		}

		public void SendConfigurationToClient(NetworkConnection conn)
		{
		}

		public override void InitializeGridItem(ItemInstance instance, Grid grid, Vector2 originCoordinate, int rotation, string GUID)
		{
		}

		public override string GetManagementName()
		{
			return null;
		}

		protected override void Destroy()
		{
		}

		public override bool CanBeDestroyed(out string reason)
		{
			reason = null;
			return false;
		}

		public override bool IsPointAboveGrowSurface(Vector3 point)
		{
			return false;
		}

		public override void SetGrowableVisible(bool visible)
		{
		}

		public override bool CanApplyAdditive(AdditiveDefinition additiveDef, out string invalidReason)
		{
			invalidReason = null;
			return false;
		}

		protected override Vector3 GetRandomPourTargetPosition()
		{
			return default(Vector3);
		}

		public override float GetGrowSurfaceSideLength()
		{
			return 0f;
		}

		protected override Material GetSoilMaterial()
		{
			return null;
		}

		public override void SetSoil(SoilDefinition soil)
		{
		}

		public override void SetMoistureAmount(float amount)
		{
		}

		public void ConfigureSoilAppearance(EMushroomBedSoilAppearance appearance, Texture2D sporeMask = null)
		{
		}

		public bool IsReadyForHarvest(out string reason)
		{
			reason = null;
			return false;
		}

		[ServerRpc(RequireOwnership = false, RunLocally = true)]
		public void SetConfigurer(NetworkObject player)
		{
		}

		protected override AdditiveDefinition ApplyAdditive(string additiveID, bool isInitialApplication)
		{
			return null;
		}

		public void PlayMixFXAtPoint(Vector3 point)
		{
		}

		protected override void OnTileTemperatureChanged(Tile tile, float newTemp)
		{
		}

		public override bool ContainsGrowable()
		{
			return false;
		}

		public override float GetGrowthProgressNormalized()
		{
			return 0f;
		}

		[ServerRpc(RequireOwnership = false)]
		public void CreateAndAssignColony_Server(string shroomSpawnID)
		{
		}

		private void CreateAndAssignColony(ShroomSpawnDefinition shroomSpawn)
		{
		}

		public void AssignColony(ShroomColony colony)
		{
		}

		private void OnColonyFullyHarvested()
		{
		}

		protected override void ClearSoil()
		{
		}

		public void CheckShowTemperatureHint()
		{
		}

		public WorldspaceUIElement CreateWorldspaceUI()
		{
			return null;
		}

		public void DestroyWorldspaceUI()
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

		public virtual void Load(MushroomBedData mushroomBedData)
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

		private void RpcWriter___Server_SetConfigurer_3323014238(NetworkObject player)
		{
		}

		public void RpcLogic___SetConfigurer_3323014238(NetworkObject player)
		{
		}

		private void RpcReader___Server_SetConfigurer_3323014238(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		private void RpcWriter___Server_CreateAndAssignColony_Server_3615296227(string shroomSpawnID)
		{
		}

		public void RpcLogic___CreateAndAssignColony_Server_3615296227(string shroomSpawnID)
		{
		}

		private void RpcReader___Server_CreateAndAssignColony_Server_3615296227(PooledReader PooledReader0, Channel channel, NetworkConnection conn)
		{
		}

		public virtual bool ReadSyncVar___ScheduleOne_002EObjectScripts_002EMushroomBed(PooledReader PooledReader0, uint UInt321, bool Boolean2)
		{
			return false;
		}

		public override void Awake()
		{
		}
	}
}
