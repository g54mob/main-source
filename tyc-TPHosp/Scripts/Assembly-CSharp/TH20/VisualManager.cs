using FullInspector;
using JetBrains.Annotations;
using TH20.ExtContent;
using UnityEngine;

namespace TH20
{
	public class VisualManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public SharedInstance<BlobShadowManager.Config> BlobShadowManagerConfig;

			public RoomLightingManagerConfig RoomLightingManagerConfig;

			public RetroVisualManagerConfig RetroVisualManagerConfig;

			public ElectricBoltManagerConfig ElectricBoltManagerConfig;

			public UGCWallMeshOverridesConfig UGCWallMeshOverridesConfig;

			public CausticsEffectManagerConfig CausticsEffectManagerConfig;

			[InspectorMargin(8)]
			[InspectorHeader("Shared Character Visual Assets")]
			public CharacterShockEffectConfig CharacterShockEffectConfig;

			public SharedInstance<CharModule.Mask> CharacterXRaySkeletonMask;
		}

		private readonly Config _config;

		[DontSave]
		private static float _elapsedTime = 0f;

		[DontSave]
		private BlobShadowManager _blobShadowManager;

		[DontSave]
		private RoomLightingManager _roomLightingManager;

		[DontSave]
		private RetroVisualManager _retroVisualManager;

		[DontSave]
		private ElectricBoltManager _electricBoltManager;

		[DontSave]
		private Level _level;

		[DontSave]
		private CausticsEffectManager _causticsEffectManager;

		private static readonly int GameTimeUnscaledParameter = Shader.PropertyToID("_GameTimeUnscaled");

		public static float ElapsedTime => _elapsedTime;

		public Config VisualManagerConfig => _config;

		public BlobShadowManager BlobShadowManager => _blobShadowManager;

		public RoomLightingManager RoomLightingManager => _roomLightingManager;

		public RetroVisualManager RetroVisualManager => _retroVisualManager;

		public ElectricBoltManager ElectricBoltManager => _electricBoltManager;

		public VisualManager(Config config, BuildEvents buildEvents, Level level)
		{
			_elapsedTime = 0f;
			_config = config;
			_level = level;
			ExtContentSourceLocalMods contentSourceLocalMods = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
			contentSourceLocalMods.OnGameItemDeleted += OnLocalModGameItemDeleted;
			contentSourceLocalMods.OnGameItemUpdated += OnLocalModGameItemUpdated;
			_blobShadowManager = new BlobShadowManager(_config.BlobShadowManagerConfig.Instance);
			_roomLightingManager = new RoomLightingManager(_config.RoomLightingManagerConfig, buildEvents, level);
			_retroVisualManager = new RetroVisualManager(level, _config.RetroVisualManagerConfig);
			_electricBoltManager = new ElectricBoltManager(level, _config.ElectricBoltManagerConfig);
			_causticsEffectManager = new CausticsEffectManager(level, _config.CausticsEffectManagerConfig);
		}

		public void RestoreFromSave(BuildEvents buildEvents, Level level)
		{
			_elapsedTime = 0f;
			_level = level;
			ExtContentSourceLocalMods contentSourceLocalMods = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
			contentSourceLocalMods.OnGameItemDeleted += OnLocalModGameItemDeleted;
			contentSourceLocalMods.OnGameItemUpdated += OnLocalModGameItemUpdated;
			_blobShadowManager = new BlobShadowManager(_config.BlobShadowManagerConfig.Instance);
			_roomLightingManager = new RoomLightingManager(_config.RoomLightingManagerConfig, buildEvents, level);
			_retroVisualManager = new RetroVisualManager(level, _config.RetroVisualManagerConfig);
			_electricBoltManager = new ElectricBoltManager(level, _config.ElectricBoltManagerConfig);
			_causticsEffectManager = new CausticsEffectManager(level, _config.CausticsEffectManagerConfig);
		}

		private void OnLocalModGameItemDeleted(GameItemBase gameItem)
		{
			if (gameItem.ContentType != EContentType.Wall && gameItem.ContentType != EContentType.Floor)
			{
				return;
			}
			if (gameItem.ContentType == EContentType.Floor)
			{
				foreach (Room allRoom in _level.WorldState.AllRooms)
				{
					if (allRoom.FloorPlanVisual.FloorVisualOverride is FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC && floorVisualOverrideDefinitionUGC.ContentID == gameItem.ContentID)
					{
						allRoom.FloorPlanVisual.FloorVisualOverride = null;
					}
				}
			}
			if (gameItem.ContentType != EContentType.Wall)
			{
				return;
			}
			foreach (Room allRoom2 in _level.WorldState.AllRooms)
			{
				if (allRoom2.FloorPlanVisual.WallVisualOverride is WallVisualOverrideDefinitionUGC wallVisualOverrideDefinitionUGC && wallVisualOverrideDefinitionUGC.ContentID == gameItem.ContentID)
				{
					allRoom2.FloorPlanVisual.WallVisualOverride = null;
				}
			}
		}

		private void OnLocalModGameItemUpdated(GameItemBase gameItem)
		{
			if (gameItem.ContentType != EContentType.Wall && gameItem.ContentType != EContentType.Floor)
			{
				return;
			}
			if (gameItem.ContentType == EContentType.Floor)
			{
				FloorVisualOverrideDefinitionUGC floorVisualOverride = null;
				foreach (FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC2 in _level.FloorVisualOverrideDefinitionUGCs)
				{
					if (floorVisualOverrideDefinitionUGC2.ContentID == gameItem.ContentID)
					{
						floorVisualOverride = floorVisualOverrideDefinitionUGC2;
						break;
					}
				}
				foreach (Room allRoom in _level.WorldState.AllRooms)
				{
					if (allRoom.FloorPlanVisual.FloorVisualOverride is FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC && floorVisualOverrideDefinitionUGC.ContentID == gameItem.ContentID)
					{
						allRoom.FloorPlanVisual.FloorVisualOverride = null;
						allRoom.FloorPlanVisual.FloorVisualOverride = floorVisualOverride;
					}
				}
			}
			if (gameItem.ContentType != EContentType.Wall)
			{
				return;
			}
			WallVisualOverrideDefinitionUGC wallVisualOverride = null;
			foreach (WallVisualOverrideDefinitionUGC wallVisualOverrideDefinitionUGC2 in _level.WallVisualOverrideDefinitionUGCs)
			{
				if (wallVisualOverrideDefinitionUGC2.ContentID == gameItem.ContentID)
				{
					wallVisualOverride = wallVisualOverrideDefinitionUGC2;
					break;
				}
			}
			foreach (Room allRoom2 in _level.WorldState.AllRooms)
			{
				if (allRoom2.FloorPlanVisual.WallVisualOverride is WallVisualOverrideDefinitionUGC wallVisualOverrideDefinitionUGC && wallVisualOverrideDefinitionUGC.ContentID == gameItem.ContentID)
				{
					allRoom2.FloorPlanVisual.WallVisualOverride = null;
					allRoom2.FloorPlanVisual.WallVisualOverride = wallVisualOverride;
				}
			}
		}

		public void Update()
		{
			_elapsedTime += Time.unscaledDeltaTime;
			Shader.SetGlobalFloat(GameTimeUnscaledParameter, _elapsedTime);
			_roomLightingManager.Update();
			_retroVisualManager.Update();
			_electricBoltManager.Update();
			_causticsEffectManager.Update();
		}

		public override void Destroy()
		{
			ExtContentSourceLocalMods contentSourceLocalMods = ExtContentUtils.ExtContentManager.ContentSourceLocalMods;
			contentSourceLocalMods.OnGameItemDeleted -= OnLocalModGameItemDeleted;
			contentSourceLocalMods.OnGameItemUpdated -= OnLocalModGameItemUpdated;
			_blobShadowManager.Destroy();
			_roomLightingManager.Destroy();
			_retroVisualManager.Destroy();
			_electricBoltManager.Destroy();
			_causticsEffectManager.Destroy();
			base.Destroy();
		}
	}
}
