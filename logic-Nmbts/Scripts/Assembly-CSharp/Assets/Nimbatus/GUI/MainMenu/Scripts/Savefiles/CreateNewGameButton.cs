using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class CreateNewGameButton : MonoBehaviour
	{
		public SavefileListUI List;

		public StartGameUI DetailUi;

		public Color NormalColor;

		public Color HoverColor;

		public Color SelectedColor;

		public UITexture Background;

		private bool _hover;

		public void Init()
		{
			DetailUi.gameObject.SetActive(false);
		}

		public void OnClick()
		{
			List.SelectedSaveFile = null;
			DetailUi.gameObject.SetActive(true);
			DetailUi.Init();
		}

		public void Update()
		{
			if (!(List != null) || MainMenuNavigator.CurrentPage != EMainMenuPage.CreateGame)
			{
				return;
			}
			if (List.SelectedSaveFile == null)
			{
				Background.color = SelectedColor;
				if (!DetailUi.gameObject.activeInHierarchy)
				{
					DetailUi.gameObject.SetActive(true);
					DetailUi.Init();
				}
			}
			else
			{
				if (DetailUi.gameObject.activeInHierarchy)
				{
					DetailUi.gameObject.SetActive(false);
				}
				Background.color = (_hover ? HoverColor : NormalColor);
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
