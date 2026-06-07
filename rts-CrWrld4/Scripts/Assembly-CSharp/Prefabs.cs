using UnityEngine;

public class Prefabs : MonoBehaviour
{
	public static Prefabs instance;

	public GameObject MVerseUnitPrefab;

	public GameObject MVerseBeamPrefab;

	public GameObject BeamMVBPrefab;

	public GameObject MVerseEventIndicatorPrefab;

	public Material[] mverseUnitMaterial;

	public Material[] mverseUnitIsBuildingMaterial;

	public GameObject MVerseDefaultBuildGhost;

	public GameObject MVerseMouseIndicatorPrefab;

	public Material beamMat_black;

	public Material beamMat_red;

	public Material beamMat_orange;

	public Material beamMat_yellow;

	public Material beamMat_green;

	public Material beamMat_blue;

	public Material beamMat_purple;

	public Material beamMat_white;

	public Texture2D ada_placeholder;

	public Texture2D ada_divider1;

	public Texture2D ada_divider2;

	public Texture2D ada_divider3;

	public Texture2D ada_divider4;

	public Texture2D ada_divider5;

	public Texture2D ada_divider6;

	public Texture2D ada_farmer;

	public Sprite ada_panel1;

	public Sprite ada_panel1_opaque;

	public Sprite ada_panel2;

	public Sprite ada_panel2_opaque;

	public Sprite ada_panel3;

	public Sprite ada_panel3_opaque;

	public Sprite ada_panel4;

	public Sprite ada_panel4_opaque;

	public Sprite ada_icon_assessment;

	public Sprite ada_icon_analysis;

	public Sprite ada_icon_artifact;

	public Sprite ada_icon_transmission;

	public Sprite ada_icon_data;

	public Texture2D airSacBubbleWrathRecorderTexture;

	public Texture2D sporeRecorderTexture;

	public Texture2D blobRecorderTexture;

	public Texture2D airSacRecorderTexture;

	public Texture2D unitDestroyedRecorderTexture;

	public Texture2D enemyUnitDestroyedRecorderTexture;

	public Texture2D riftRecorderTexture;

	public Texture2D minerEnergyRecorderTexture;

	public Texture2D minerBluiteRecorderTexture;

	public Texture2D wallRecorderTexture;

	public Texture2D crazoniumRecorderTexture;

	public Texture2D factoryImage;

	public Texture2D ernPortalImage;

	public Texture2D ultracImage;

	public GameObject model_commandBase;

	public GameObject model_factory;

	public GameObject model_ernInterfacae;

	public GameObject model_ern;

	public GameObject model_resourceBlue;

	public GameObject model_resourceRed;

	public GameObject model_greenarMother;

	public GameObject model_tower;

	public GameObject model_transformer;

	public GameObject model_pylon;

	public GameObject model_reactor;

	public GameObject model_greenarRefinery;

	public GameObject model_greenarDrone;

	public GameObject model_terp;

	public GameObject model_terpDrone;

	public GameObject model_porter;

	public GameObject model_porterDrone;

	public GameObject model_pod;

	public GameObject model_cannon;

	public GameObject model_mortar;

	public GameObject model_sprayer;

	public GameObject model_sniper;

	public GameObject model_missileLauncher;

	public GameObject model_nullifier;

	public GameObject model_runway;

	public GameObject model_bomberPad;

	public GameObject model_bomber;

	public GameObject model_rocketPad;

	public GameObject model_rocket;

	public GameObject model_powerZone;

	public GameObject model_monolith;

	public GameObject model_microrift;

	public GameObject model_damper;

	public GameObject model_singularity;

	public GameObject model_rain;

	public GameObject model_conversion;

	public GameObject model_totem;

	public GameObject model_crystal;

	public GameObject model_emitter;

	public GameObject model_stash;

	public GameObject model_sporeLauncher;

	public GameObject model_blobNest;

	public GameObject model_skimmerFactory;

	public GameObject model_airSacCauldron;

	public GameObject model_spore;

	public GameObject model_blob;

	public GameObject model_skimmer;

	public GameObject model_airSac;

	public GameObject model_ultrac;

	public GameObject model_cytocreepLauncher;

	public GameObject model_shield;

	public GameObject model_denier;

	public GameObject model_acbomberpad;

	public GameObject model_acbomber;

	public GameObject model_collectorpanel5;

	public GameObject model_collectorpanel3;

	public GameObject model_infocache;

	public GameObject model_activationantenna;

	public GameObject model_chronat;

	public GameObject model_platform;

	public GameObject model_holdBase;

	public Texture2DArray terrainTextureArray256;

	public Texture2DArray terrainTextureNormalArray256;

	public GameObject pterosaurPrefab;

	public Material shieldMaterial;

	public Material shieldFlatMaterial;

	public Material stockObjectPreviewMaterial;

	public Material wallBeamMaterial;

	public Material wallCrazoniumBeamMaterial;

	public GameObject unitBuildGhostCostText;

	public GameObject unitBuildButtonPrefab;

	public GameObject cubeBarPrefab;

	public GameObject worldLinePrefab;

	public GameObject indicatorTextPrefab;

	public GameObject waypointLinePrefab;

	public GameObject mistPrefab;

	public GameObject barPrefab;

	public GameObject losIndicator;

	public GameObject placementIndicator;

	public GameObject selectionIndicatorPrefab;

	public GameObject editTerrainRangeIndicator;

	public GameObject terrainDecalPrefab;

	public GameObject colorPickerPrefab;

	public GameObject unitPopupInfoPanePrefab;

	public GameObject cmodPopup;

	public GameObject debugTextPrefab;

	public GameObject unitTextPrefab;

	public Material rematerializingMaterial;

	public Material unitMaterial;

	public Material unitBuildingMaterial;

	public Material unitDisabledMaterial;

	public Material unitBuildGhostMaterial;

	public Material unitMoveGhostMaterial;

	public Material unitCModMaterial;

	public Texture2D defaultCPackTexture;

	public Material rocketMaterial;

	public Material rocketBuildingMaterial;

	public Material animusMaterial;

	public Material animusEnemyMaterial;

	public Texture[] planetTextures;

	public Texture[] planetNormalTextures;

	public Material[] decalMaterials;

	public Texture decalEmptyTexture;

	public GameObject unitERNIndicatorPrefab;

	public GameObject beamPrefab;

	public GameObject ammoTypeIndicatorPrefab;

	public GameObject volumetricLightBeamPrefab;

	public GameObject cmodUnitTextPrefab;

	public Material airSacBubbleMaterial;

	public Material airSacBubbleWrathMaterial;

	public Material sporeLauncherMaterial;

	public Material sporeLauncherAlternateMaterial;

	public Material sporeLauncherAlternate2Material;

	public GameObject uiIndicatorPrefab;

	public GameObject moveIndicator;

	public GameObject cmodInstancePrefab;

	public GameObject commandBasePrefab;

	public GameObject emitterPrefab;

	public GameObject sporeLauncherPrefab;

	public GameObject blobNestPrefab;

	public GameObject vineRootPrefab;

	public GameObject skimmerFactoryPrefab;

	public GameObject denierPrefab;

	public GameObject airSacCauldronPrefab;

	public GameObject crystalPrefab;

	public GameObject striderPrefab;

	public GameObject forbPrefab;

	public GameObject blobPrefab;

	public GameObject sporePrefab;

	public GameObject airSacPrefab;

	public GameObject airSacBubblePrefab;

	public GameObject chronatPrefab;

	public GameObject towerPrefab;

	public GameObject transformerPrefab;

	public GameObject collectorPrefab;

	public GameObject superTowerPrefab;

	public GameObject towerBridgePrefab;

	public GameObject microriftPrefab;

	public GameObject monolithPrefab;

	public GameObject collectorPanel5Prefab;

	public GameObject collectorPanel3Prefab;

	public GameObject nullifierPrefab;

	public GameObject cannonPrefab;

	public GameObject mortarPrefab;

	public GameObject sprayerPrefab;

	public GameObject packetPrefab;

	public GameObject wallPrefab;

	public GameObject crazoniumPrefab;

	public GameObject workallPrefab;

	public GameObject storagePadPrefab;

	public GameObject fabricatorPrefab;

	public GameObject fabricator2Prefab;

	public GameObject blueFabPrefab;

	public GameObject redFabPrefab;

	public GameObject grayFabPrefab;

	public GameObject fatManPrefab;

	public GameObject driverPrefab;

	public GameObject sparkerPrefab;

	public GameObject missileLauncherPrefab;

	public GameObject sniperPrefab;

	public GameObject podPrefab;

	public GameObject deliveryPadPrefab;

	public GameObject deliveryDronePrefab;

	public GameObject shrapnelPrefab;

	public GameObject totemPrefab;

	public GameObject factoryPrefab;

	public GameObject ernInterfacePrefab;

	public GameObject ernPrefab;

	public GameObject flopePrefab;

	public GameObject stashPrefab;

	public GameObject vinePrefab;

	public GameObject terpPrefab;

	public GameObject terpDronePrefab;

	public GameObject straferPadPrefab;

	public GameObject straferDronePrefab;

	public GameObject bomberPadPrefab;

	public GameObject bomberPrefab;

	public GameObject acBomberPadPrefab;

	public GameObject acBomberPrefab;

	public GameObject runwayPrefab;

	public GameObject reactorPrefab;

	public GameObject powerZonePrefab;

	public GameObject rocketPadPrefab;

	public GameObject rocketPrefab;

	public GameObject payloadPadPrefab;

	public GameObject payloadPrefab;

	public GameObject damperPrefab;

	public GameObject singularityPrefab;

	public GameObject rainPrefab;

	public GameObject conversionPrefab;

	public GameObject rainDropPrefab;

	public GameObject greenarRefineryPrefab;

	public GameObject greenarDronePrefab;

	public GameObject ultracPrefab;

	public GameObject cytocreeperLauncherPrefab;

	public GameObject pterosaurNestPrefab;

	public GameObject shieldPrefab;

	public GameObject platformPrefab;

	public GameObject maxPrefab;

	public GameObject infoCachePrefab;

	public GameObject activationAntennaPrefab;

	public GameObject surviveBasePrefab;

	public GameObject shotPrefab;

	public GameObject acShotPrefab;

	public GameObject mortarShotPrefab;

	public GameObject missilePrefab;

	public GameObject straferMissilePrefab;

	public GameObject bombPrefab;

	public GameObject acBombPrefab;

	public GameObject sniperShotPrefab;

	public GameObject resourceBluePrefab;

	public GameObject resourceRedPrefab;

	public GameObject greenarMotherPrefab;

	public GameObject fabricatorWarePrefab;

	public Mesh payloadDampMesh;

	public Mesh payloadSingularityMesh;

	public Mesh payloadRainMesh;

	public GameObject chronatBuildGhostPrefab;

	public GameObject towerBuildGhostPrefab;

	public GameObject transformerBuildGhostPrefab;

	public GameObject collectorBuildGhostPrefab;

	public GameObject superTowerBuildGhostPrefab;

	public GameObject towerBridgeBuildGhostPrefab;

	public GameObject microriftBuildGhostPrefab;

	public GameObject monolithBuildGhostPrefab;

	public GameObject collectorPanel5BuildGhostPrefab;

	public GameObject collectorPanel3BuildGhostPrefab;

	public GameObject nullifierBuildGhostPrefab;

	public GameObject cannonBuildGhostPrefab;

	public GameObject mortarBuildGhostPrefab;

	public GameObject sprayerBuildGhostPrefab;

	public GameObject wallBuildGhostPrefab;

	public GameObject crazoniumBuildGhostPrefab;

	public GameObject commandBaseBuildGhostPrefab;

	public GameObject emitterBuildGhostPrefab;

	public GameObject sporeLauncherBuildGhostPrefab;

	public GameObject blobNestBuildGhostPrefab;

	public GameObject vineRootBuildGhostPrefab;

	public GameObject skimmerFactoryBuildGhostPrefab;

	public GameObject denierBuildGhostPrefab;

	public GameObject airSacCauldronBuildGhostPrefab;

	public GameObject crystalBuildGhostPrefab;

	public GameObject resourceBlueBuildGhostPrefab;

	public GameObject resourceRedBuildGhostPrefab;

	public GameObject greenarMotherBuildGhostPrefab;

	public GameObject workallBuildGhostPrefab;

	public GameObject storagePadBuildGhostPrefab;

	public GameObject fabricatorBuildGhostPrefab;

	public GameObject fabricator2BuildGhostPrefab;

	public GameObject blueFabBuildGhostPrefab;

	public GameObject redFabBuildGhostPrefab;

	public GameObject grayFabBuildGhostPrefab;

	public GameObject fatManBuildGhostPrefab;

	public GameObject driverBuildGhostPrefab;

	public GameObject sparkerBuildGhostPrefab;

	public GameObject missileLauncherBuildGhostPrefab;

	public GameObject sniperBuildGhostPrefab;

	public GameObject blobBuildGhostPrefab;

	public GameObject striderBuildGhostPrefab;

	public GameObject forbBuildGhostPrefab;

	public GameObject podBuildGhostPrefab;

	public GameObject deliveryPadBuildGhostPrefab;

	public GameObject deliveryDroneBuildGhostPrefab;

	public GameObject totemBuildGhostPrefab;

	public GameObject factoryBuildGhostPrefab;

	public GameObject ernInterfaceBuildGhostPrefab;

	public GameObject ernBuildGhostPrefab;

	public GameObject flopeBuildGhostPrefab;

	public GameObject stashBuildGhostPrefab;

	public GameObject terpBuildGhostPrefab;

	public GameObject terpDroneBuildGhostPrefab;

	public GameObject straferPadBuildGhostPrefab;

	public GameObject bomberPadBuildGhostPrefab;

	public GameObject bomberBuildGhostPrefab;

	public GameObject acBomberPadBuildGhostPrefab;

	public GameObject acbomberBuildGhostPrefab;

	public GameObject runwayBuildGhostPrefab;

	public GameObject reactorBuildGhostPrefab;

	public GameObject powerZoneBuildGhostPrefab;

	public GameObject rocketPadBuildGhostPrefab;

	public GameObject rocketBuildGhostPrefab;

	public GameObject payloadPadBuildGhostPrefab;

	public GameObject damperBuildGhostPrefab;

	public GameObject singularityBuildGhostPrefab;

	public GameObject rainBuildGhostPrefab;

	public GameObject rainDropBuildGhostPrefab;

	public GameObject conversionBuildGhostPrefab;

	public GameObject greenarRefineryBuildGhostPrefab;

	public GameObject greenarDroneBuildGhostPrefab;

	public GameObject ultracBuildGhostPrefab;

	public GameObject cytocreeperLauncherBuildGhostPrefab;

	public GameObject pterosaurNestBuildGhostPrefab;

	public GameObject pterosaurBuildGhostPrefab;

	public GameObject shieldBuildGhostPrefab;

	public GameObject platformBuildGhostPrefab;

	public GameObject maxBuildGhostPrefab;

	public GameObject infoCacheBuildGhostPrefab;

	public GameObject activationAntennaBuildGhostPrefab;

	public GameObject surviveBaseBuildGhostPrefab;

	public GameObject commandBaseMoveGhostPrefab;

	public GameObject chronatMoveGhostPrefab;

	public GameObject cannonMoveGhostPrefab;

	public GameObject mortarMoveGhostPrefab;

	public GameObject sprayerMoveGhostPrefab;

	public GameObject workallMoveGhostPrefab;

	public GameObject fatManMoveGhostPrefab;

	public GameObject missileLauncherMoveGhostPrefab;

	public GameObject sniperMoveGhostPrefab;

	public GameObject deliveryDroneMoveGhostPrefab;

	public GameObject terpMoveGhostPrefab;

	public GameObject shieldMoveGhostPrefab;

	public GameObject activationAntennaMoveGhostPrefab;

	public GameObject genericMoveGhostPrefab;

	public GameObject deliveryPadTargetIndicatorPrefab;

	public GameObject aircraftMoveTargetIndicatorPrefab;

	public GameObject standardTargetIndicatorPrefab;

	public GameObject nullifierTargetIndicatorPrefab;

	public GameObject pathPrefab;

	public GameObject particleTrail;

	public GameObject particleTrailSmoke;

	public GameObject sparks;

	public GameObject materializeEffect;

	public GameObject unitExplosion;

	public GameObject mortarShotExplosion;

	public GameObject enemyExplosion;

	public GameObject smallExplosion;

	public GameObject debrisExplosion;

	public GameObject orangeBeam;

	public GameObject orangeBeamStart;

	public GameObject orangeBeamEnd;

	public GameObject stormBeam;

	public GameObject stormBeamStart;

	public GameObject stormBeamEnd;

	public GameObject stunned;

	public GameObject stunExplosion;

	public GameObject totemRift;

	public GameObject totemRiftOpen;

	public GameObject inspectorIntPrefab;

	public GameObject inspectorFloatPrefab;

	public GameObject inspectorStringPrefab;

	public GameObject inspectorBoolPrefab;

	public GameObject inspectorChoicePrefab;

	public GameObject inspectorTimePrefab;

	public GameObject inspectorEmitterSecondaryEditorPrefab;

	public GameObject inspectorButtonPrefab;

	public GameObject inspectorVector3Prefab;

	public GameObject inspectorVector2Prefab;

	public GameObject scriptSettingsInspectorIntPrefab;

	public GameObject scriptSettingsInspectorFloatPrefab;

	public GameObject scriptSettingsInspectorStringPrefab;

	private void Awake()
	{
	}
}
