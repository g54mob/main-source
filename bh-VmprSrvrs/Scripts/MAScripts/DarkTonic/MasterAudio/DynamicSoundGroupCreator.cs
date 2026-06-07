using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	[AudioScriptOrder(-35)]
	public class DynamicSoundGroupCreator : MonoBehaviour
	{
		public enum CreateItemsWhen
		{
			FirstEnableOnly = 0,
			EveryEnable = 1
		}

		public const int ExtraHardCodedBusOptions = 1;

		public SystemLanguage previewLanguage;

		public MasterAudio.DragGroupMode curDragGroupMode;

		public GameObject groupTemplate;

		public GameObject variationTemplate;

		public bool errorOnDuplicates;

		public bool createOnAwake;

		public bool soundGroupsAreExpanded;

		public bool removeGroupsOnSceneChange;

		public CreateItemsWhen reUseMode;

		public bool showCustomEvents;

		public MasterAudio.AudioLocation bulkVariationMode;

		public List<CustomEvent> customEventsToCreate;

		public List<CustomEventCategory> customEventCategories;

		public string newEventName;

		public string newCustomEventCategoryName;

		public string addToCustomEventCategoryName;

		public bool showMusicDucking;

		public List<DuckGroupInfo> musicDuckingSounds;

		public List<GroupBus> groupBuses;

		public bool playListExpanded;

		public bool playlistEditorExp;

		public List<MasterAudio.Playlist> musicPlaylists;

		public List<GameObject> audioSourceTemplates;

		public string audioSourceTemplateName;

		public bool groupByBus;

		public bool itemsCreatedEventExpanded;

		public string itemsCreatedCustomEvent;

		public bool showUnityMixerGroupAssignment;

		private bool _hasCreated;

		private readonly List<Transform> _groupsToRemove;

		private Transform _trans;

		private int _instanceId;

		private readonly List<DynamicSoundGroup> _groupsToCreate;

		public static int HardCodedBusOptions => 0;

		public List<DynamicSoundGroup> GroupsToCreate => null;

		public int InstanceId => 0;

		public bool ShouldShowUnityAudioMixerGroupAssignments => false;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void CreateItemsIfReady()
		{
		}

		public void RemoveItems()
		{
		}

		public void CreateItems()
		{
		}

		private void FireEvents()
		{
		}

		public void PopulateGroupData()
		{
		}
	}
}
