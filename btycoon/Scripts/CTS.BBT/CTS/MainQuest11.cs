using System.Collections;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest11 : Level01Quest
	{
		[SerializeField]
		private UIGifsListSO _constructionVideos;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[QuestEntryPopup]
		private int _roomUIEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _newRoomEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _doorEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _biggerRoomEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		private int _roomAmount;

		protected override IEnumerator QuestIntroduction()
		{
			_constructionVideos.Show();
			yield break;
		}

		protected override void QuestSetup()
		{
			base.QuestChain.ConstructionInteriorLocker.Unlock();
			base.QuestChain.ConstructionDestructionLocker.Unlock();
			base.QuestChain.ConstructionZoneLocker.Unlock();
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_InteriorTool);
		}

		protected override void StopObservingObjectives()
		{
			UI_ConstructionSystem.OnInteriorMode -= OnInteriorMode;
			ConstructionSystem.OnConstructionGenerated -= OnConstructionGenerated;
			BuildablePlacementSystem.OnBuildablePlaced -= OnBuildablePlaced;
		}

		protected override void StartObservingObjectives()
		{
			UI_ConstructionSystem.OnInteriorMode += OnInteriorMode;
			ConstructionSystem.OnConstructionGenerated += OnConstructionGenerated;
			BuildablePlacementSystem.OnBuildablePlaced += OnBuildablePlaced;
			_roomAmount = MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentContainer.GeneratedRooms.Count;
		}

		private void OnConstructionGenerated(int roomID, int cellsAmount, int roomCellAmount)
		{
			if (cellsAmount != 0 && roomCellAmount > 0)
			{
				if (_roomAmount < MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentContainer.GeneratedRooms.Count)
				{
					_roomAmount = MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentContainer.GeneratedRooms.Count;
					QuestEntrySuccess(_newRoomEntry);
				}
				else
				{
					QuestEntrySuccess(_biggerRoomEntry);
				}
			}
		}

		private void OnInteriorMode()
		{
			UI_ConstructionSystem.OnInteriorMode -= OnInteriorMode;
			QuestEntrySuccess(_roomUIEntry);
		}

		private void OnBuildablePlaced(BuildableElement element)
		{
			if ((element.BuildableType == BuildableElementSO.EBuildableType.Door || element.BuildableType == BuildableElementSO.EBuildableType.Arch) && MonoSingleton<BuildingRoomsContainerManager>.Instance.AllRoomHaveExteriorAccess == EAccess.Accessible)
			{
				BuildablePlacementSystem.OnBuildablePlaced -= OnBuildablePlaced;
				QuestEntrySuccess(_doorEntry);
			}
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			base.QuestChain.ConstructionDestructionLocker.Unlock();
			base.QuestChain.ConstructionInteriorLocker.Unlock();
			base.QuestChain.ConstructionZoneLocker.Unlock();
		}

		public override void SuccessConfirmation()
		{
			base.QuestChain.ConstructionInteriorLocker.Unlock();
			base.QuestChain.ConstructionDestructionLocker.Unlock();
			base.QuestChain.ConstructionZoneLocker.Unlock();
		}
	}
}
