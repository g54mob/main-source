using UnityEngine.UI;

public class SaveDefenderCreationView : BaseGUIView
{
	public const string SaveEvent = "SaveDefenderCreationView.SaveEvent";

	public const string SaveAsNewEvent = "SaveDefenderCreationView.SaveAsNewEvent";

	public const string CloseEvent = "SaveDefenderCreationView.CloseEvent";

	private InputField nameInput;

	private InputField descriptionInput;

	private Button saveButton;

	private Button saveAsNewButton;

	private Button closeButton;

	public override void Initialize()
	{
		nameInput = mainPanel.transform.FindComponent<InputField>("NameInput");
		descriptionInput = mainPanel.transform.FindComponent<InputField>("DescriptionInput");
		saveButton = mainPanel.transform.FindComponent<Button>("SaveButton");
		saveAsNewButton = mainPanel.transform.FindComponent<Button>("SaveAsNewButton");
		closeButton = mainPanel.transform.FindComponent<Button>("CloseButton");
		saveButton.onClick.AddListener(delegate
		{
			SaveHandler("SaveDefenderCreationView.SaveEvent");
		});
		saveAsNewButton.onClick.AddListener(delegate
		{
			SaveHandler("SaveDefenderCreationView.SaveAsNewEvent");
		});
		closeButton.onClick.AddListener(delegate
		{
			NotifyChange("SaveDefenderCreationView.CloseEvent");
		});
	}

	private void SaveHandler(string eventName)
	{
		if (!string.IsNullOrEmpty(nameInput.text))
		{
			NotifyChange(eventName, nameInput.text, descriptionInput.text);
		}
	}

	public void SetNameText(string name)
	{
		nameInput.text = name;
	}

	public void SetDescriptionText(string description)
	{
		descriptionInput.text = description;
	}
}
