using TMPro;
using UnityEngine.Events;

public class OptionListItemDropDown : MenuButton
{
	public TextMeshProUGUI keyLabel;

	public TextMeshProUGUI valueLabel;

	public MenuButton valueButton;

	public object loadedObject;

	public UnityAction<OptionListItemDropDown> onButtonClickedDelegate;

	protected override void Awake()
	{
		base.Awake();
		valueButton.AddPointerClickTrigger(OnValueClicked);
	}

	private void OnValueClicked()
	{
		onButtonClickedDelegate?.Invoke(this);
	}
}
