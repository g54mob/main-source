using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class BackToMainMenu : MonoBehaviour
	{
		public TweenPosition CheckTween;

		public void OnClick()
		{
			MainMenuNavigator.Instance.NavigateTowards(EMainMenuPage.Main);
		}

		public void Update()
		{
			if (CheckTween != null && Input.GetKeyDown(KeyCode.Escape) && (CheckTween.value - CheckTween.to).magnitude < 0.1f)
			{
				OnClick();
			}
		}
	}
}
