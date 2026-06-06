using UnityEngine;
using UnityEngine.UI;

public class NotInDemoPopup : Popup
{
	[SerializeField]
	private Button confirm;

	[SerializeField]
	private Button wishlistButton;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(confirm).AddListener(OnSubmit).Context(wishlistButton)
			.AddListener(ApplicationController.OpenStorePage);
	}
}
