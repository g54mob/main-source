using System;
using UnityEngine;

namespace Gh.Tk.Story.Requirements
{
	public class ClickedOnTargetRequirementNode : SelectedObjectRequirementBase
	{
		[Serializable]
		public enum TargetModeType
		{
			Anything = 0,
			Prop = 1,
			Actor = 2,
			Room = 3,
			RoomAndContents = 5,
			GoxId = 4
		}

		[Header("Type of Target")]
		public TargetModeType targetMode;

		[Header("Target Config")]
		[DropDownChoice(typeof(StoryHelper), "GetAllPropOptions")]
		public string targetPropType;

		[DropDownChoice(typeof(StoryHelper), "GetActorTypes")]
		public string targetActorType;

		[DropDownChoice(typeof(StoryHelper), "GetAllZones")]
		public string roomZone;

		public int goxId;

		public ItemNarrationAsset wrongItemClickedNarration;

		private bool DoesObjectMatch(ISelectable selectable)
		{
			return false;
		}

		private static bool DoesObjectMatch(ISelectable selectable, TargetModeType targetMode, string roomZone, string targetPropType, string targetActorType, int goxId)
		{
			return false;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}

		protected override void OnSelectedObjectChanged(ISelectable selectable, ActiveStory story)
		{
		}

		private void PlayWrongItemClickedNarration(ISelectable clickedObject, ItemNarrationAsset asset, ActiveStory story)
		{
		}
	}
}
