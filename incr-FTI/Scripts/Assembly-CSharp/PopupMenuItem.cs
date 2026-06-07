using TMPro;
using UnityEngine.Events;

public class PopupMenuItem : MenuButton
{
	public TextMeshProUGUI label;

	public object loadedObject;

	public UnityAction<PopupMenuItem> onClickedDelegate;

	protected override void Awake()
	{
		base.Awake();
		AddPointerClickTrigger(OnPointerClick);
	}

	private void OnPointerClick()
	{
		onClickedDelegate?.Invoke(this);
	}
}
