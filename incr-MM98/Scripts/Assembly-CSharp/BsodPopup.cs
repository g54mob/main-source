using UnityEngine;
using UnityEngine.UI;

public class BsodPopup : Popup
{
	[SerializeField]
	private Button mainMenuButton;

	[SerializeField]
	private Button wishlistButton;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(mainMenuButton).AddListener(ApplicationController.LoadMainMenu).Context(wishlistButton)
			.AddListener(ApplicationController.OpenStorePage);
	}
}
