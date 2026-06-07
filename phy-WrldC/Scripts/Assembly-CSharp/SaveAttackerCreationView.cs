using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveAttackerCreationView : BaseGUIView
{
	public const string SaveButtonEvent = "SaveAttackerCreationView.SaveButtonEvent";

	public const string CloseButtonEvent = "SaveAttackerCreationView.CloseButtonEvent";

	private GameObject blockReference;

	private TextMeshProUGUI infoText;

	private TMP_InputField creationNameInput;

	private TMP_InputField descriptionInput;

	private TextMeshProUGUI characterCounterText;

	private Button saveButton;

	private Button closeButton;

	private Toggle savePartToggle;

	private GameObject creationModelPanel;

	private GameObject creationViewObject;

	private GameObject DEV_Panel;

	private Toggle DEV_DevPartToggle;

	public override void Initialize()
	{
		blockReference = mainPanel.transform.FindChildRecursively("BigBlockReference").gameObject;
		creationModelPanel = mainPanel.transform.FindChildRecursively("CreationModelPanel").gameObject;
		infoText = mainPanel.transform.FindComponent<TextMeshProUGUI>("InfoText", isRecursively: true);
		creationNameInput = mainPanel.transform.FindComponent<TMP_InputField>("CreationNameInput", isRecursively: true);
		descriptionInput = mainPanel.transform.FindComponent<TMP_InputField>("DescriptionInput", isRecursively: true);
		characterCounterText = mainPanel.transform.FindComponent<TextMeshProUGUI>("CharacterCounterText", isRecursively: true);
		saveButton = mainPanel.transform.FindComponent<Button>("SaveButton", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		savePartToggle = mainPanel.transform.FindComponent<Toggle>("SavePartToggle", isRecursively: true);
		descriptionInput.onValueChanged.AddListener(delegate(string text)
		{
			CharacterCounterHandler(text);
		});
		saveButton.onClick.AddListener(SaveButtonHandler);
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("SaveAttackerCreationView.CloseButtonEvent");
		});
		savePartToggle.onValueChanged.AddListener(SavePartToggleHandler);
		blockReference.SetActive(value: false);
		DEV_Panel = mainPanel.transform.FindChildRecursively("DEV_Panel").gameObject;
		DEV_DevPartToggle = DEV_Panel.transform.FindComponent<Toggle>("DevPartToggle", isRecursively: true);
		DEV_Panel.SetActive(value: false);
	}

	private void CharacterCounterHandler(string text)
	{
		characterCounterText.SetText(text.Length + "/" + descriptionInput.characterLimit);
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		if (creationViewObject != null && creationViewObject.activeSelf != isVisible)
		{
			creationViewObject.SetActive(isVisible);
		}
	}

	public void DrawCreationToSave(CreationModel creationModel)
	{
		if (creationViewObject != null)
		{
			creationViewObject.GetComponent<CreationView>().RecycleAllBlocksBeforeDestroying();
			Object.Destroy(creationViewObject);
		}
		CreationController creationController = CreationControllerBuilder.BuildModelController(creationModel, creationModelPanel.transform);
		creationViewObject = creationController.view.gameObject;
		creationViewObject.SetLayersRecursively(LayerNames.UI);
		CreationUtil.NormalizeCreationScale(creationController.view, blockReference.transform.localScale.x);
		creationViewObject.transform.position = blockReference.transform.position;
		creationViewObject.transform.rotation = blockReference.transform.rotation;
		if (creationModel.IsOriginatedFromSchematic)
		{
			creationViewObject.transform.localRotation = Quaternion.Euler(22.5f, 135f, -22.5f);
		}
		int blockModelCount = creationModel.BlockModelCount;
		float num = creationModel.TotalCost();
		float num2 = creationModel.TotalWeight();
		infoText.text = "<#FFFFFFFF>\uf1b3 " + blockModelCount + "   <#F7EC3DFF>\uf0eb " + num.ToString("0.##") + "   <#8998DFFF>\ue908 " + num2.ToString("0.##");
		creationNameInput.text = creationModel.Name;
		descriptionInput.text = creationModel.Description;
	}

	public void ClearToggles()
	{
		DEV_DevPartToggle.isOn = false;
		savePartToggle.isOn = false;
	}

	public void ClearFields()
	{
		DEV_DevPartToggle.isOn = false;
		savePartToggle.isOn = false;
		creationNameInput.text = string.Empty;
		descriptionInput.text = string.Empty;
	}

	private void SaveButtonHandler()
	{
		string text = creationNameInput.text;
		string text2 = descriptionInput.text;
		NotifyChange("SaveAttackerCreationView.SaveButtonEvent", text, text2, savePartToggle.isOn, DEV_DevPartToggle.isOn);
	}

	private void SavePartToggleHandler(bool isOn)
	{
		if (Debug.isDebugBuild)
		{
			DEV_Panel.SetActive(isOn);
		}
	}
}
