using System.Collections.Generic;
using NSEipix;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Almanac;
using NSMedieval.GameDifficulty;

namespace NSMedieval.UI
{
	public class GameParametersLayoutItemView : LayoutGroupItemView
	{
		private int resetButtonIndex;

		private readonly List<DifficultySettingItemView> difficultySettingsViews = new List<DifficultySettingItemView>();

		private SoundButton resetButton;

		private GameParametersInstance gameParametersInstance;

		public void Initialize(GameParametersInstance gameParametersInstance)
		{
			if (!resetButton)
			{
				resetButton = base.GroupItems[resetButtonIndex].GetComponent<SoundButton>();
			}
			resetButton.AddCleanListener(OnResetButtonClicked);
			this.gameParametersInstance = gameParametersInstance;
			UpdateView();
		}

		private void UpdateView()
		{
			difficultySettingsViews.SetAllActive(active: false);
			LayoutGroupView component = GetComponent<LayoutGroupView>();
			int num = 0;
			foreach (DifficultyOption allItem in Repository<DifficultyOptionsRepository, DifficultyOption>.Instance.GetAllItems())
			{
				DifficultySettingItemView next = difficultySettingsViews.GetNext(component);
				next.SetData(allItem, gameParametersInstance.GetById(allItem.GetID()), gameParametersInstance.SetById);
				next.Background.enabled = (num & 1) == 0;
				num++;
			}
		}

		private void OnResetButtonClicked()
		{
			gameParametersInstance.ResetToDefaults();
			UpdateView();
		}
	}
}
