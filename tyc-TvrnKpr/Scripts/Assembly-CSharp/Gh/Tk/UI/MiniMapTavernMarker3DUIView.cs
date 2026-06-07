using Gh.Tk.Story;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class MiniMapTavernMarker3DUIView : BaseInteractable3DUIView
	{
		[DropDownChoice(typeof(StoryHelper), "GetTavernLevelIds")]
		public string tavernLevelId;

		public string regionName;

		[SerializeField]
		private GameObject _scenarioUnlockedVisual;

		[SerializeField]
		private GameObject _scenarioCompletedVisual;

		[SerializeField]
		private GameObject _newScenarioVisual;

		public override bool IsBlocked => false;

		public override void CheckState()
		{
		}

		protected override void TriggerUnlocking()
		{
		}

		protected override void Awake()
		{
		}

		private bool IsNew()
		{
			return false;
		}

		private bool IsValidForFreeplay()
		{
			return false;
		}

		private bool HasProfileUnlockedTavern()
		{
			return false;
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		private string GetNameKey()
		{
			return null;
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		protected override void OnClickedInternal()
		{
		}
	}
}
