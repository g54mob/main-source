using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest20 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _assignationUIEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _vampireRoomEntry;

		[SerializeField]
		[NavArea(false)]
		private int _vampireArea;

		[SerializeField]
		private UIMessageBase _vampireAreaGift;

		private bool _gifted;

		[SerializeField]
		[QuestEntryPopup]
		private int _tableEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _chairsEntry;

		private List<Furniture> _chairs = new List<Furniture>();

		[SerializeField]
		[VariablePopup(false)]
		private string _currentChairsVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetChairsVariableName;

		[SerializeField]
		private int _targetChairsVariableNameValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_currentChairsVariableName);
		}

		protected override void StopObservingObjectives()
		{
			UI_ConstructionSystem.OnAssignationActived -= OnAssignationActived;
			RoomAssingationMenu.OnRoomAssignationChanged -= OnRoomAssignationChanged;
			Furniture.FurniturePlaced -= OnFurniturePlaced;
			Furniture.FurnitureSold -= OnFurnitureSold;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetChairsVariableName, _targetChairsVariableNameValue);
			UI_ConstructionSystem.OnAssignationActived += OnAssignationActived;
			RoomAssingationMenu.OnRoomAssignationChanged += OnRoomAssignationChanged;
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_RoomTypeTool);
			Furniture.FurniturePlaced += OnFurniturePlaced;
			Furniture.FurnitureSold += OnFurnitureSold;
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (furniture.Interactor is Seat)
			{
				_chairs.Remove(furniture);
				if (SetQuestEntryVariable(_chairsEntry, _currentChairsVariableName, _chairs.Count, _targetChairsVariableName))
				{
					QuestEntryCancelSuccess(_chairsEntry);
				}
			}
		}

		private void OnFurniturePlaced(Furniture furniture)
		{
			if (furniture.Interactor is Table && furniture.RoomObject.CurrentRoom.NavArea == _vampireArea && CTSSingleton<LevelParameters>.Instance.Furnitures.GetCount<Table>() > 0)
			{
				QuestEntrySuccess(_tableEntry);
			}
			else
			{
				if (!(furniture.Interactor is Seat))
				{
					return;
				}
				if ((bool)furniture.Controller.CurrentSlot)
				{
					if (furniture.RoomObject.CurrentRoom.NavArea == _vampireArea)
					{
						if (!_chairs.Contains(furniture))
						{
							_chairs.Add(furniture);
						}
						if (SetQuestEntryVariable(_chairsEntry, _currentChairsVariableName, _chairs.Count, _targetChairsVariableName))
						{
							QuestEntrySuccess(_chairsEntry);
						}
					}
				}
				else
				{
					_chairs.Remove(furniture);
					if (SetQuestEntryVariable(_chairsEntry, _currentChairsVariableName, _chairs.Count, _targetChairsVariableName))
					{
						QuestEntryCancelSuccess(_chairsEntry);
					}
				}
			}
		}

		private void OnRoomAssignationChanged(RoomBuilding room)
		{
			if (room.NavArea == _vampireArea)
			{
				QuestEntrySuccess(_vampireRoomEntry);
				foreach (Table item in CTSSingleton<LevelParameters>.Instance.Furnitures.Enumerate<Table>())
				{
					if (item.Furniture.RoomObject.CurrentRoom == room)
					{
						QuestEntrySuccess(_tableEntry);
						if (SetQuestEntryVariable(_chairsEntry, _currentChairsVariableName, item.Furniture.SlotsUsedAmount, _targetChairsVariableName))
						{
							QuestEntrySuccess(_chairsEntry);
						}
					}
				}
				if (!_gifted)
				{
					CTSSingleton<UIMessage>.Instance.ShowMessage(_vampireAreaGift);
					UnlockingManager.AddUnlockKey(EUnlockKey.VampireBarPackage);
					HighlightButton.Highlight(BBTUI.Instance.ButtonID_Theme);
					_gifted = true;
				}
				return;
			}
			bool flag = false;
			foreach (KeyValuePair<int, RoomBuilding> generatedRoom in MonoSingleton<BuildingRoomsContainerManager>.Instance.CurrentContainer.GeneratedRooms)
			{
				if (generatedRoom.Value.NavArea.Area == _vampireArea)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				QuestEntryCancelSuccess(_vampireRoomEntry);
			}
		}

		private void OnAssignationActived(bool activated)
		{
			if (activated)
			{
				UI_ConstructionSystem.OnAssignationActived -= OnAssignationActived;
				QuestEntrySuccess(_assignationUIEntry);
			}
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			UnlockingManager.AddUnlockKey(EUnlockKey.VampireBarPackage);
		}

		public override void SuccessConfirmation()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.VampireBarPackage);
		}
	}
}
