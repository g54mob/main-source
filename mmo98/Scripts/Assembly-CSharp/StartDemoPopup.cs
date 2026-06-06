using UnityEngine;
using UnityEngine.UI;

public class StartDemoPopup : Popup
{
	private static bool _hasShownPopup;

	[SerializeField]
	private Button confirm;

	[SerializeField]
	private Button store;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(confirm).AddListener(OnSubmit).Context(store)
			.AddListener(ApplicationController.OpenStorePage);
	}

	protected override void Start()
	{
		base.Start();
		if (!_hasShownPopup)
		{
			_hasShownPopup = true;
			ShowContent();
		}
	}
}
