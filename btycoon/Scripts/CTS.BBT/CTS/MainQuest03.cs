using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest03 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _tableEntryID;

		[SerializeField]
		[QuestEntryPopup]
		private int _chairEntryID;

		[SerializeField]
		[VariablePopup(false)]
		private string _chairVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _chairMaxVariableName;

		[SerializeField]
		private int _chairMaxVariableNameValue;

		[SerializeField]
		[QuestEntryPopup]
		private int _pumpEntryID;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private GameObject _defaultFurnitures;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_chairVariableName);
		}

		protected override IEnumerator QuestIntroduction()
		{
			BarkFirstWorker(_bark01.GetLocalizedString());
			HighlightButton.Highlight(BBTUI.Instance.ButtonID_FurnitureShop);
			MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.HighTable);
			MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.Pump);
			yield break;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_chairMaxVariableName, _chairMaxVariableNameValue);
			Furniture.FurnitureBought += OnFurnitureBought;
			Furniture.FurnitureSold += OnFurnitureSold;
			SeatCounter.SeatCountChanged += OnSeatCountChanged;
		}

		private void OnSeatCountChanged(int count)
		{
			QuestState questEntryState = QuestLog.GetQuestEntryState(_questName, _chairEntryID);
			if (questEntryState == QuestState.Active || questEntryState == QuestState.Success)
			{
				int asInt = DialogueLua.GetVariable(_chairMaxVariableName).asInt;
				bool num = count >= asInt;
				if (!num && questEntryState == QuestState.Success)
				{
					MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.HighChair);
					QuestEntryCancelSuccess(_chairEntryID);
				}
				SetQuestEntryVariable(_chairEntryID, _chairVariableName, count, _chairMaxVariableName);
				if (num && questEntryState == QuestState.Active)
				{
					MonoSingleton<FurnitureShopPopulator>.Instance.StopHighlight(EFurnitureTags.HighChair);
					QuestEntrySuccess(_chairEntryID);
				}
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (CTSSingleton<LevelParameters>.InstanceExists())
			{
				if (QuestLog.GetQuestEntryState(_questName, _pumpEntryID) == QuestState.Success && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<StationDrink>())
				{
					MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.Pump);
					QuestEntryCancelSuccess(_pumpEntryID);
				}
				if (QuestLog.GetQuestEntryState(_questName, _tableEntryID) == QuestState.Success && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<Table>())
				{
					MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.HighTable);
					QuestEntryCancelSuccess(_tableEntryID);
				}
			}
		}

		private void OnFurnitureBought(Furniture furniture)
		{
			if (QuestLog.GetQuestEntryState(_questName, _pumpEntryID) == QuestState.Active && furniture.Interactor is StationDrink)
			{
				MonoSingleton<FurnitureShopPopulator>.Instance.StopHighlight(EFurnitureTags.Pump);
				QuestEntrySuccess(_pumpEntryID);
			}
			else if (QuestLog.GetQuestEntryState(_questName, _tableEntryID) == QuestState.Active && furniture.Interactor is Table)
			{
				MonoSingleton<FurnitureShopPopulator>.Instance.StopHighlight(EFurnitureTags.HighTable);
				MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.HighChair);
				QuestEntrySuccess(_tableEntryID);
			}
		}

		protected override void StopObservingObjectives()
		{
			Furniture.FurnitureBought -= OnFurnitureBought;
			Furniture.FurnitureSold -= OnFurnitureSold;
			SeatCounter.SeatCountChanged -= OnSeatCountChanged;
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			base.QuestChain.OpenBarButtonDisplayLocker.Unlock();
			MonoSingleton<FurnitureShopPopulator>.Instance.StopHighlight(EFurnitureTags.HighTable);
			MonoSingleton<FurnitureShopPopulator>.Instance.StopHighlight(EFurnitureTags.HighChair);
			MonoSingleton<FurnitureShopPopulator>.Instance.StopHighlight(EFurnitureTags.Pump);
		}

		public override void SkipQuest()
		{
			base.SkipQuest();
			base.QuestChain.OpenBarButtonDisplayLocker.Unlock();
			if ((bool)_defaultFurnitures)
			{
				_defaultFurnitures.SetActive(value: true);
			}
		}

		public override void SuccessConfirmation()
		{
			base.QuestChain.OpenBarButtonDisplayLocker.Unlock();
		}

		protected override void OnResumeQuest()
		{
			base.OnResumeQuest();
			if (!CTSSingleton<BarFurnitures>.Instance.DoesAnyExist<StationDrink>())
			{
				MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.Pump);
			}
			if (!CTSSingleton<BarFurnitures>.Instance.DoesAnyExist<Table>())
			{
				MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.HighTable);
			}
			else
			{
				MonoSingleton<FurnitureShopPopulator>.Instance.Highlight(EFurnitureTags.HighChair);
			}
		}
	}
}
