using UnityEngine;

public class UserLevelWorkshopView : BaseWorkshopView<LevelModel>
{
	public override void Initialize()
	{
		base.Initialize();
		uploadTextId = "label.text.workshop.le.upload";
		upgradeTextId = "label.text.workshop.le.upgrade";
		unsubscribeTextId = "label.text.workshop.le.unsubscribe";
	}

	public override void SetConfiguration(LevelModel levelModel)
	{
		base.SetConfiguration(levelModel);
		if (levelModel != null)
		{
			itemNameText.SetText(levelModel.Name);
			descriptionText.SetText(levelModel.Description);
			Sprite sprite = GameManager.Instance.UserAndWorkshopLevelThumbnailCollection.GetSprite("lvl_" + levelModel.Id);
			if (sprite != null)
			{
				itemImage.enabled = true;
				itemImage.sprite = sprite;
				noImageText.gameObject.SetActive(value: false);
			}
			else
			{
				itemImage.enabled = false;
				noImageText.gameObject.SetActive(value: true);
			}
			NotifyChange("BaseWorkshopView.ModelConfiguratedEvent", selectedModel);
		}
	}
}
