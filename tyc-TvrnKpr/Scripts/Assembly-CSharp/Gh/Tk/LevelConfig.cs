using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class LevelConfig : MonoBehaviour
	{
		[HideInInspector]
		public string defaultTavernName;

		[HideInInspector]
		public string levelName;

		[HideInInspector]
		public string gazetteName;

		[HideInInspector]
		public List<string> startingMapPOIs;

		[Header("Offset in Hours")]
		[Tooltip("The time (in hours) it takes a patron to reach the tavern sign from the spawn points - used to schedule spawning for bards and story characters so they arrive when they should")]
		public float spawnTimeOffset;

		public int startingHour;

		[Header("Merchants")]
		public string emergencyMerchantId;

		public string travellingMerchantId;

		[Tooltip("If set this prefab will be used for the merchant instead of default (swamp)")]
		public GameObject merchantPrefabOverride;

		public Texture sunCookie;

		public EventPositionConfiner weatherAmbience;

		[DropDownChoice(typeof(AudioSwitch.FootstepMaterial), "GetAllMaterials")]
		public string outsideFloorSoundMaterial;

		public Transform evacuationPoint;

		public Vector3 evacuationPointRadius;

		public List<Vector3Int> outerWallSplitPoints;

		public EnvironmentLighting tavernLightingOverride;

		public Sun sunlightOverride;

		public Sun uiSunlightOverride;

		public CameraLevelConfig cameraConfig;

		public GameObject cameraVisualOcclusionChecker;

		public Vector3 merchantEventCameraRotation;

		public List<Vector3Int> SuppressWallPostsOnPositions;

		private GameObject _occlusionCheckInstance;

		private EnvironmentLighting _tavernLightingOverrideInstance;

		public GameObjectX[] Exits { get; private set; }

		public GameObject[] DeliveryGuyEntries { get; private set; }

		public GameObject[] TavernSignLocations { get; private set; }

		public bool IsInitialized { get; private set; }

		public DevCommentaryMarkerMonoBehaviour[] DevCommentaryMarkers { get; private set; }

		public void Init(bool isNewGame)
		{
		}

		private void OnDestroy()
		{
		}

		private void SetupTravellingMerchant()
		{
		}
	}
}
