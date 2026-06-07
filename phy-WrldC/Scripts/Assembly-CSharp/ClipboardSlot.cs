using UnityEngine;

public class ClipboardSlot : ClipboardSlotBase<CreationView, CreationModel>
{
	protected override void ActionBeforeRemoveOldItemView()
	{
		base.ItemView.RecycleAllBlocksBeforeDestroying();
	}

	protected override CreationView SetConfigurationHandler(CreationModel itemModel)
	{
		CreationController creationController = CreationControllerBuilder.BuildModelController(itemModel, base.ItemFolder.transform);
		GameObject gameObject = creationController.view.gameObject;
		gameObject.SetLayersRecursively(LayerNames.UI);
		gameObject.transform.SetParent(base.ItemFolder.transform);
		CreationUtil.NormalizeCreationScale(creationController.view, referenceBlockObject.transform.localScale.x);
		gameObject.transform.localPosition = referenceBlockObject.transform.localPosition;
		gameObject.transform.localRotation = referenceBlockObject.transform.localRotation;
		if (itemModel.IsOriginatedFromSchematic)
		{
			gameObject.transform.localRotation = Quaternion.Euler(22.5f, 135f, -22.5f);
		}
		itemScalableTransform = creationController.view.gameObject.transform;
		itemOriginalScale = creationController.view.transform.localScale;
		return creationController.view;
	}
}
