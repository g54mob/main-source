using UnityEngine;

namespace Dorfromantik
{
	public class SaveGameScreenToolbar : MonoBehaviour
	{
		[SerializeField]
		private GameObject loadTooltip;

		[SerializeField]
		private GameObject saveTooltip;

		[SerializeField]
		private GameObject deleteTooltip;

		[SerializeField]
		private GameObject newGameTooltip;

		public void SetInfoState(TooltipBarInfoState infoState)
		{
			loadTooltip.SetActive(infoState == TooltipBarInfoState.AutoSaveGameUi || infoState == TooltipBarInfoState.SaveGameUi);
			saveTooltip.SetActive(infoState == TooltipBarInfoState.AutoSaveGameUi);
			deleteTooltip.SetActive(infoState == TooltipBarInfoState.AutoSaveGameUi || infoState == TooltipBarInfoState.SaveGameUi);
			newGameTooltip.SetActive(infoState == TooltipBarInfoState.NewSaveGameButton);
		}
	}
}
