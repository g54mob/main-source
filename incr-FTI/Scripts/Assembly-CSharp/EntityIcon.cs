using UnityEngine.UI;

public class EntityIcon : SelectableButton
{
	public delegate void OnSelected(EntityId selectedEntity);

	private EntityId displayedEntity;

	public Image iconImage;

	public Image overlayImage;

	public void LoadEntity(EntityId id)
	{
		displayedEntity = id.GetCopy();
		selectionHandle = id;
		iconImage.sprite = IconManager.SpriteForEntity(id);
		AddPointerDownTrigger(OnButtonPressed);
	}

	public void OnButtonPressed()
	{
		PerformSelection();
	}
}
