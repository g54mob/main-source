using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public class SoundGroupOrganizer : MonoBehaviour
	{
		public class CustomEventSelection
		{
			public CustomEvent Event;

			public bool IsSelected;

			public CustomEventSelection(CustomEvent cEvent, bool isSelected)
			{
			}
		}

		public class SoundGroupSelection
		{
			public GameObject Go;

			public bool IsSelected;

			public SoundGroupSelection(GameObject go, bool isSelected)
			{
			}
		}

		public enum MAItemType
		{
			SoundGroups = 0,
			CustomEvents = 1
		}

		public enum TransferMode
		{
			None = 0,
			Import = 1,
			Export = 2
		}

		public GameObject dynGroupTemplate;

		public GameObject dynVariationTemplate;

		public GameObject maGroupTemplate;

		public GameObject maVariationTemplate;

		public MasterAudio.DragGroupMode curDragGroupMode;

		public MasterAudio.AudioLocation bulkVariationMode;

		public SystemLanguage previewLanguage;

		public bool useTextGroupFilter;

		public string textGroupFilter;

		public TransferMode transMode;

		public GameObject sourceObject;

		public List<SoundGroupSelection> selectedSourceSoundGroups;

		public GameObject destObject;

		public List<SoundGroupSelection> selectedDestSoundGroups;

		public MAItemType itemType;

		public List<CustomEventSelection> selectedSourceCustomEvents;

		public List<CustomEventSelection> selectedDestCustomEvents;

		public List<CustomEvent> customEvents;

		public List<CustomEventCategory> customEventCategories;

		public string newEventName;

		public string newCustomEventCategoryName;

		public string addToCustomEventCategoryName;

		private void Awake()
		{
		}
	}
}
