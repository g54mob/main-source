using TMPro;
using UnityEngine;

public class QuickInventorySlot : QuickInventorySlotBase<CreationView, CreationModel>
{
	private TextMeshProUGUI extendableBarIcon;

	private TextMeshProUGUI hasPropertiesIcon;

	private TextMeshProUGUI isBrainBlockIcon;

	private BlockTooltipTrigger blockTooltip;

	protected override void Awake()
	{
		base.Awake();
		extendableBarIcon = base.transform.FindComponent<TextMeshProUGUI>("ExtendableBarIcon", isRecursively: true);
		hasPropertiesIcon = base.transform.FindComponent<TextMeshProUGUI>("HasPropertiesIcon", isRecursively: true);
		isBrainBlockIcon = base.transform.FindComponent<TextMeshProUGUI>("IsBrainBlockIcon", isRecursively: true);
		blockTooltip = GetComponent<BlockTooltipTrigger>();
	}

	protected override void ActionBeforeRemoveOldItemView()
	{
		base.ItemView.RecycleAllBlocksBeforeDestroying();
	}

	protected override CreationView SetConfigurationHandler(CreationModel itemModel)
	{
		CreationController creationController = CreationControllerBuilder.BuildModelController(itemModel, base.ItemFolder.transform);
		GameObject gameObject = creationController.view.gameObject;
		gameObject.SetLayersRecursively(LayerNames.UI);
		CreationUtil.NormalizeCreationScale(creationController.view, 50f);
		gameObject.transform.localPosition = new Vector3(0f, 0f, -60f);
		if (itemModel.IsOriginatedFromSchematic)
		{
			gameObject.transform.localRotation = Quaternion.Euler(22.5f, 135f, -22.5f);
		}
		else
		{
			gameObject.transform.localRotation = Quaternion.Euler(22.5f, 225f, 22.5f);
		}
		extendableBarIcon.gameObject.SetActive(itemModel.IsTwoPointBlock());
		if (itemModel.IsOriginatedFromSchematic)
		{
			hasPropertiesIcon.gameObject.SetActive(itemModel.GetBlockModel(0).HasUserEditableProperties());
			isBrainBlockIcon.gameObject.SetActive(itemModel.BrainBlockModel != null);
		}
		else
		{
			hasPropertiesIcon.gameObject.SetActive(value: false);
			isBrainBlockIcon.gameObject.SetActive(value: false);
		}
		userIcon.gameObject.SetActive(!itemModel.IsOriginatedFromSchematic);
		blockTooltip.CreationModel = itemModel;
		itemScalableTransform = creationController.view.gameObject.transform;
		itemOriginalScale = creationController.view.transform.localScale;
		return creationController.view;
	}
}
