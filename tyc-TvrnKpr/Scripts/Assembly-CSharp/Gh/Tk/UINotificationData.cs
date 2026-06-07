using System;
using System.Collections.Generic;
using Gh.Tk.Story;
using LitJson;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class UINotificationData : IPersistable
	{
		public class ChecklistItem : IPersistable
		{
			public bool isChecked;

			[FormerlySerializedAs("label")]
			public string labelKey;

			public float filledProgressPips;

			public int totalProgressPips;

			[PersistenceObjectReference]
			public TooltipData tooltipData;

			public string devCommentaryId;

			public int referenceId;

			public bool isClickable;

			public float GetPercentageAsFactor01()
			{
				return 0f;
			}
		}

		public class PatronCheckListItem : IPersistable
		{
			[JsonIgnore]
			private Func<TooltipData> _lazyTooltipData;

			public bool isTooltipDirty;

			public int tier;

			public string race;

			public bool isChecked;

			public bool isCrossed;

			public bool isHighlighted;

			public float filledProgress;

			public float totalProgress;

			public string progressBarColour;

			public int activePatronId;

			[JsonIgnore]
			public Func<TooltipData> LazyTooltipData
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		public string id;

		public int sourceId;

		[PersistenceObjectReference]
		public ActiveStory SourceStory;

		public string voteId;

		public UIDialogData dialogData;

		public bool syncCheckListWithMainPips;

		public float filledProgressPips;

		public int totalProgressPips;

		public float expireTime;

		public float startedTime;

		public bool invertCountdown;

		public List<PatronCheckListItem> patronCheckList;

		public List<ChecklistItem> checklistItems;

		public bool isTutorialChecklist;

		[FormerlySerializedAs("notificationTitleOverride")]
		public string notificationTitleOverrideKey;

		public string iconOverride;

		public bool autoDestroyAfterCallback;

		public bool canDismiss;

		public bool showInNotificationArea;

		public UINotificationData()
		{
		}

		public UINotificationData(UIDialogData dialogData)
		{
		}

		public UINotificationData(string titleKey, string dialogTextKey, string dialogImage = null)
		{
		}

		public float GetPercentageAsFactor01()
		{
			return 0f;
		}

		public bool IsHidden(UIController.UINotificationVisualData visualData)
		{
			return false;
		}

		private string GetTitleKey(UIController.UINotificationVisualData visualData)
		{
			return null;
		}
	}
}
