using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class EntityButton : SelectableButton
{
	public Image iconImage;

	public TextMeshProUGUI primaryLabel;

	public UnityAction<EntityButton> onClickedDelegate;

	public EntityId loadedEntity;

	public void LoadEntity(EntityId id)
	{
		loadedEntity = id;
		iconImage.sprite = IconManager.SpriteForEntity(id);
		primaryLabel.text = TextDisplay.LabelForEntity(id);
		selectionHandle = loadedEntity;
	}

	public void Initialize()
	{
		AddPointerClickTrigger(OnClicked);
		base.buttonState = CustomButtonState.Background;
	}

	private void OnClicked()
	{
		PerformSelection();
		onClickedDelegate?.Invoke(this);
	}
}
