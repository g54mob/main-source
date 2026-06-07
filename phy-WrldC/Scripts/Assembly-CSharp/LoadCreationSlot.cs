using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadCreationSlot : MonoBehaviour
{
	private GameObject creationFolder;

	private GameObject referenceBlock;

	private TextMeshProUGUI creationName;

	private TextMeshProUGUI creationInfos;

	private Button slotButton;

	private Button deleteButton;

	private Button workshopButton;

	private DescriptionTooltipTrigger descriptionTooltipTrigger;

	public CreationView CreationView { get; private set; }

	public CreationModel CreationModel { get; private set; }

	public event Action OnLoadButtonEvent;

	public event Action OnDeleteButtonEvent;

	public event Action OnWorkshopButtonEvent;

	public event Action<GameObject, bool> OnMouseOverEvent;

	protected virtual void Awake()
	{
		creationFolder = base.transform.Find("CreationFolder").gameObject;
		referenceBlock = base.transform.FindChildRecursively("BlockReference").gameObject;
		referenceBlock.SetActive(value: false);
		creationName = base.transform.FindComponent<TextMeshProUGUI>("CreationNameText", isRecursively: true);
		creationInfos = base.transform.FindComponent<TextMeshProUGUI>("CreationInfosText", isRecursively: true);
		slotButton = base.transform.FindComponent<Button>(base.name, isRecursively: true);
		deleteButton = base.transform.FindComponent<Button>("DeleteButton", isRecursively: true);
		workshopButton = base.transform.FindComponent<Button>("WorkshopButton", isRecursively: true);
		descriptionTooltipTrigger = GetComponent<DescriptionTooltipTrigger>();
		slotButton.onClick.AddListener(delegate
		{
			this.OnLoadButtonEvent?.Invoke();
		});
		deleteButton.onClick.AddListener(delegate
		{
			this.OnDeleteButtonEvent?.Invoke();
		});
		workshopButton.onClick.AddListener(delegate
		{
			this.OnWorkshopButtonEvent?.Invoke();
		});
		AddMouseOverEvents(base.gameObject, creationFolder);
	}

	public virtual void SetCreationModel(CreationModel creationModel)
	{
		if (CreationView != null)
		{
			CreationView.RecycleAllBlocksBeforeDestroying();
			UnityEngine.Object.Destroy(CreationView.gameObject);
			this.OnLoadButtonEvent = null;
			this.OnDeleteButtonEvent = null;
			this.OnMouseOverEvent = null;
		}
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
		creationName.text = creationModel.Name;
		creationInfos.text = "<#FFFFFFFF>\uf1b3 " + creationModel.BlockModelCount + "   <#F7EC3DFF>\uf0eb " + creationModel.TotalCost().ToString("0.##") + "   <#8998DFFF>\ue908 " + creationModel.TotalWeight().ToString("0.##");
		descriptionTooltipTrigger.Description = creationModel.Description;
		descriptionTooltipTrigger.IsActivated = !string.IsNullOrEmpty(creationModel.Description);
		if (creationModel.Place == CreationModel.CreationPlace.Workshop)
		{
			deleteButton.gameObject.SetActive(value: false);
		}
		if (!SteamManager.Initialized)
		{
			workshopButton.interactable = false;
		}
		CreationModel = creationModel;
	}

	private void AddMouseOverEvents(GameObject buttonGameObject, GameObject creationFolder)
	{
		Util.AddMouseUIEvent(buttonGameObject, EventTriggerType.PointerEnter, delegate
		{
			this.OnMouseOverEvent?.Invoke(creationFolder, arg2: true);
		});
		Util.AddMouseUIEvent(buttonGameObject, EventTriggerType.PointerExit, delegate
		{
			this.OnMouseOverEvent?.Invoke(creationFolder, arg2: false);
		});
	}
}
