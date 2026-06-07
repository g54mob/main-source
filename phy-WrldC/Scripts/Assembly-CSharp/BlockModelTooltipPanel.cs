using System.Collections;
using UnityEngine;

public class BlockModelTooltipPanel : TooltipPanelBase
{
	private CreationView creationView;

	private GameObject creationFolder;

	private GameObject referenceBlock;

	private readonly WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

	protected override void Awake()
	{
		base.Awake();
		creationFolder = base.transform.Find("CreationFolder").gameObject;
		referenceBlock = base.transform.FindChildRecursively("BlockReference").gameObject;
		referenceBlock.SetActive(value: false);
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		if (isVisible)
		{
			StartCoroutine(WaitOneFrameToEnable());
		}
		else
		{
			creationFolder.SetActive(value: false);
		}
		IEnumerator WaitOneFrameToEnable()
		{
			yield return waitForEndOfFrame;
			creationFolder.SetActive(value: true);
		}
	}

	public void SetCreationModel(CreationModel creationModel)
	{
		if (creationView != null)
		{
			creationView.RecycleAllBlocksBeforeDestroying();
			Object.Destroy(creationView.gameObject);
			creationFolder.transform.localPosition = new Vector3(0f, 0f, 0f);
			creationFolder.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
			creationFolder.transform.localScale = Vector3.one;
		}
		CreationController creationController = CreationControllerBuilder.BuildModelController(creationModel, creationFolder.transform);
		GameObject obj = creationController.view.gameObject;
		creationView = creationController.view;
		obj.transform.localPosition = new Vector3(0f, 0f, 0f);
		obj.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		CreationUtil.NormalizeCreationScale(creationController.view, referenceBlock.transform.localScale.x);
		creationFolder.transform.localPosition = referenceBlock.transform.localPosition;
		creationFolder.transform.localRotation = referenceBlock.transform.localRotation;
		creationFolder.transform.localScale = Vector3.one;
		creationFolder.SetLayersRecursively(LayerNames.UI);
	}
}
