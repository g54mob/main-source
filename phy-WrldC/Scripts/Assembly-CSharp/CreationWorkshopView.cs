using UnityEngine;

public class CreationWorkshopView : BaseWorkshopView<CreationModel>
{
	public override void Initialize()
	{
		base.Initialize();
		uploadTextId = "label.text.workshop.cp.upload";
		upgradeTextId = "label.text.workshop.cp.upgrade";
		unsubscribeTextId = "label.text.workshop.cp.unsubscribe";
	}

	public override void SetConfiguration(CreationModel creationModel)
	{
		base.SetConfiguration(creationModel);
		if (creationModel != null)
		{
			itemNameText.SetText(creationModel.Name);
			descriptionText.SetText(creationModel.Description);
			string filePathToSave = PathNames.UserCreations + creationModel.Id + ".png";
			Sprite sprite = GameManager.Instance.creationThumbnailGenerator.GenerateThumbnailImage(creationModel, filePathToSave);
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
