using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.GameDifficulty;
using NSMedieval.StatsSystem;
using UnityEngine;

namespace NSMedieval.UI
{
	public class GameOptionDifficultyView : UIView
	{
		[SerializeField]
		private GameOptionsView gameOptionsView;

		[SerializeField]
		private GameParametersLayoutItemView gameParametersView;

		[SerializeField]
		private SoundButton backButton;

		private bool isInitialized;

		private GameParametersInstance oldGameParameters;

		public override void Show()
		{
			base.Show();
			if (!isInitialized)
			{
				isInitialized = true;
				backButton.onClick.AddListener(Hide);
				gameParametersView.Initialize(GlobalSaveController.CurrentVillageData.GameParametersCurrent);
			}
			oldGameParameters = new GameParametersInstance(GlobalSaveController.CurrentVillageData.GameParametersCurrent);
		}

		public override void Hide()
		{
			base.Hide();
			MonoSingleton<GlobalSaveController>.Instance.Serialize();
			MonoSingleton<StatsUpdateManager>.Instance.DifficultyChanged(oldGameParameters, GlobalSaveController.CurrentVillageData.GameParametersCurrent);
			gameOptionsView.Show();
		}
	}
}
