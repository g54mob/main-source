using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelStatisticsSlot : MonoBehaviour
{
	private GameObject creationFolder;

	private GameObject referenceBlock;

	private TextMeshProUGUI slotText;

	private TextMeshProUGUI nameText;

	private Button loadButton;

	public CreationView CreationView { get; private set; }

	public CreationModel CreationModel { get; private set; }

	public event Action<CreationModel> OnLoadButtonEvent;

	public event Action<GameObject, Quaternion, bool> OnMouseOverEvent;

	private void Awake()
	{
		creationFolder = base.transform.Find("CreationFolder").gameObject;
		referenceBlock = base.transform.FindChildRecursively("BlockReference").gameObject;
		referenceBlock.SetActive(value: false);
		slotText = base.transform.FindComponent<TextMeshProUGUI>("SlotText", isRecursively: true);
		nameText = base.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
		loadButton = base.transform.FindComponent<Button>("LoadButton", isRecursively: true);
		loadButton.onClick.AddListener(delegate
		{
			this.OnLoadButtonEvent?.Invoke(CreationModel);
		});
		AddMouseOverEvents(base.gameObject, creationFolder);
	}

	public void SetCreationVisibility(bool isVisible)
	{
		creationFolder.SetActive(isVisible);
	}

	public void SetSlotText(string text)
	{
		slotText.SetText(text);
	}

	public void SetCreationModel(CreationModel creationModel)
	{
		if (CreationView != null)
		{
			CreationView.RecycleAllBlocksBeforeDestroying();
			UnityEngine.Object.Destroy(CreationView.gameObject);
		}
		if (creationModel == null)
		{
			nameText.gameObject.SetActive(value: false);
			loadButton.gameObject.SetActive(value: false);
			CreationModel = null;
			return;
		}
		creationFolder.transform.localPosition = Vector3.zero;
		creationFolder.transform.localRotation = Quaternion.Euler(Vector3.zero);
		CreationController creationController = CreationControllerBuilder.BuildModelController(creationModel, creationFolder.transform);
		GameObject obj = creationController.view.gameObject;
		CreationView = creationController.view;
		obj.transform.localPosition = new Vector3(0f, 0f, 0f);
		obj.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		CreationUtil.NormalizeCreationScale(creationController.view, referenceBlock.transform.localScale.x);
		creationFolder.transform.localPosition = referenceBlock.transform.localPosition;
		creationFolder.transform.localRotation = referenceBlock.transform.localRotation;
		creationFolder.transform.localScale = Vector3.one;
		creationFolder.SetLayersRecursively(LayerNames.UI);
		nameText.gameObject.SetActive(value: true);
		nameText.SetText(creationModel.Name);
		loadButton.gameObject.SetActive(value: true);
		CreationModel = creationModel;
	}

	private void AddMouseOverEvents(GameObject buttonGameObject, GameObject creationFolder)
	{
		Util.AddMouseUIEvent(buttonGameObject, EventTriggerType.PointerEnter, delegate
		{
			this.OnMouseOverEvent?.Invoke(creationFolder, referenceBlock.transform.rotation, arg3: true);
		});
		Util.AddMouseUIEvent(buttonGameObject, EventTriggerType.PointerExit, delegate
		{
			this.OnMouseOverEvent?.Invoke(creationFolder, referenceBlock.transform.rotation, arg3: false);
		});
	}
}
