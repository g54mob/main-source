using UnityEngine;
using UnityEngine.UI;

public class CustomizationPopup : Popup
{
	[SerializeField]
	private Button confirm;

	[SerializeField]
	private Button cancel;

	[SerializeField]
	private ButtonWrapper backgroundButton;

	[SerializeField]
	private BackgroundCustomization backgroundCustomization;

	[SerializeField]
	private ButtonWrapper cursorButton;

	[SerializeField]
	private CursorCustomization cursorCustomization;

	[SerializeField]
	private ButtonWrapper gnormanButton;

	[SerializeField]
	private GnormanCustomization gnormanCustomization;

	private ButtonWrapper _activeButton;

	private ICustomization _activeCustomization;

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		backgroundButton.onClick.AddListener(delegate
		{
			ShowCustomization(backgroundButton, backgroundCustomization);
		});
		backgroundCustomization.Initialize();
		cursorButton.onClick.AddListener(delegate
		{
			ShowCustomization(cursorButton, cursorCustomization);
		});
		cursorCustomization.Initialize();
		gnormanButton.onClick.AddListener(delegate
		{
			ShowCustomization(gnormanButton, gnormanCustomization);
		});
		gnormanCustomization.Initialize();
		confirm.onClick.AddListener(OnSubmit);
		cancel.onClick.AddListener(OnCancel);
		ShowCustomization(backgroundButton, backgroundCustomization);
	}

	private void ShowCustomization(ButtonWrapper button, ICustomization customization)
	{
		_activeButton?.Clear();
		_activeButton = button;
		_activeButton.ForceSelected();
		_activeCustomization?.Hide();
		_activeCustomization = customization;
		_activeCustomization.Show();
	}

	protected override void OnSubmit()
	{
		_activeCustomization.Apply();
	}
}
