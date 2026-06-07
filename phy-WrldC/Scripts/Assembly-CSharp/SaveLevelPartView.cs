using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveLevelPartView : BaseGUIView
{
	public const string SaveButtonEvent = "SaveLevelPartView.SaveButtonEvent";

	public const string CloseButtonEvent = "SaveLevelPartView.CloseButtonEvent";

	private GameObject referenceBlockObject;

	private TMP_InputField partNameInput;

	private TMP_InputField descriptionInput;

	private Button saveButton;

	private Button closeButton;

	private GameObject partModelPanel;

	private GameObject levelObjectsParent;

	private CustomLevelObjectsModel toSaveCustomLevelObjectsModel;

	public override void Initialize()
	{
		referenceBlockObject = mainPanel.transform.FindChildRecursively("BigBlockReference").gameObject;
		partModelPanel = mainPanel.transform.FindChildRecursively("PartModelPanel").gameObject;
		partNameInput = mainPanel.transform.FindComponent<TMP_InputField>("PartNameInput", isRecursively: true);
		descriptionInput = mainPanel.transform.FindComponent<TMP_InputField>("DescriptionInput", isRecursively: true);
		saveButton = mainPanel.transform.FindComponent<Button>("SaveButton", isRecursively: true);
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton", isRecursively: true);
		saveButton.onClick.AddListener(SaveButtonHandler);
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("SaveLevelPartView.CloseButtonEvent");
		});
		referenceBlockObject.SetActive(value: false);
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		if (levelObjectsParent != null && levelObjectsParent.activeSelf != isVisible)
		{
			levelObjectsParent.SetActive(isVisible);
		}
	}

	public void DrawCreationToSave(CustomLevelObjectsModel customLevelObjectsModel)
	{
		if (levelObjectsParent != null)
		{
			Object.Destroy(levelObjectsParent);
		}
		partNameInput.SetTextWithoutNotify(customLevelObjectsModel.Name);
		descriptionInput.SetTextWithoutNotify(customLevelObjectsModel.Description);
		levelObjectsParent = LevelEditorUtil.InstantiateLevelObjectsForUI(customLevelObjectsModel, partModelPanel.transform, referenceBlockObject);
		toSaveCustomLevelObjectsModel = customLevelObjectsModel;
	}

	public void ClearFields()
	{
		partNameInput.SetTextWithoutNotify(string.Empty);
		descriptionInput.SetTextWithoutNotify(string.Empty);
	}

	private void SaveButtonHandler()
	{
		string text = partNameInput.text;
		string text2 = descriptionInput.text;
		NotifyChange("SaveLevelPartView.SaveButtonEvent", toSaveCustomLevelObjectsModel, text, text2);
	}
}
