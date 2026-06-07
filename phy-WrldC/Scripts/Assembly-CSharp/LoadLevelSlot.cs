using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelSlot : MonoBehaviour
{
	private Toggle toggle;

	private TextMeshProUGUI nameText;

	private TextMeshProUGUI completedText;

	private Button deleteButton;

	private Image background;

	private Image borderIsOn;

	private bool isLevelCompleted;

	public LevelModel SelectedLevelModel { get; private set; }

	public bool IsSelected => toggle.isOn;

	public event Action<LevelModel> OnSlotSelectedEvent;

	public event Action<LevelModel> OnDeleteLevelEvent;

	protected virtual void Awake()
	{
		toggle = GetComponent<Toggle>();
		nameText = base.transform.FindComponent<TextMeshProUGUI>("NameText", isRecursively: true);
		completedText = base.transform.FindComponent<TextMeshProUGUI>("CompletedText", isRecursively: true);
		deleteButton = base.transform.FindComponent<Button>("DeleteButton", isRecursively: true);
		background = base.transform.FindComponent<Image>("Background", isRecursively: true);
		borderIsOn = base.transform.FindComponent<Image>("BorderIsOn", isRecursively: true);
	}

	public virtual void SetConfiguration(LevelModel levelModel, ToggleGroup toggleGroup)
	{
		toggle.isOn = false;
		toggle.group = toggleGroup;
		toggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			SetToggleStyles(isOn);
			if (isOn)
			{
				this.OnSlotSelectedEvent?.Invoke(levelModel);
			}
		});
		deleteButton.onClick.AddListener(delegate
		{
			this.OnDeleteLevelEvent?.Invoke(levelModel);
		});
		if (levelModel.Place == LevelModel.LevelPlace.Workshop || levelModel.Place == LevelModel.LevelPlace.New)
		{
			deleteButton.gameObject.SetActive(value: false);
		}
		nameText.SetText(levelModel.Name);
		if (levelModel.Place == LevelModel.LevelPlace.New)
		{
			SetTemplateLevelName();
			LanguagesManager.Instance.OnLanguageChangedEvent += SetTemplateLevelName;
		}
		SetLevelCompleteness(levelModel.IsLevelCompleted);
		SelectedLevelModel = levelModel;
		SelectedLevelModel.NotifyChangeEvent += LevelModelNotifyChangeHandler;
		SetToggleValue(isSelected: false);
		void SetTemplateLevelName()
		{
			string id = "leveleditor.template.name." + levelModel.Id;
			string text = LanguagesManager.Instance.GetText(id);
			nameText.SetText(text);
		}
	}

	private void LevelModelNotifyChangeHandler(string eventName, params object[] data)
	{
		if (eventName == "LevelModel.BestTimeChangedEvent")
		{
			SetLevelCompleteness(isLevelCompleted: true);
		}
	}

	public void SetLevelCompleteness(bool isLevelCompleted)
	{
		this.isLevelCompleted = isLevelCompleted;
		completedText.SetText(isLevelCompleted ? "\uf046" : "\uf096");
		completedText.color = (toggle.isOn ? Util.HexToColor("#212224FF") : (isLevelCompleted ? Util.HexToColor("#F7EC3DFF") : Util.HexToColor("#787878FF")));
	}

	public void SetToggleValue(bool isSelected)
	{
		if (toggle.isOn != isSelected)
		{
			toggle.SetValue(isSelected);
		}
		SetToggleStyles(isSelected);
	}

	protected virtual void SetToggleStyles(bool isOn)
	{
		borderIsOn.gameObject.SetActive(isOn);
		nameText.color = (isOn ? Util.HexToColor("#212224FF") : Util.HexToColor("#FFFFFFFF"));
		completedText.color = (isOn ? Util.HexToColor("#212224FF") : (isLevelCompleted ? Util.HexToColor("#F7EC3DFF") : Util.HexToColor("#787878FF")));
		background.color = (isOn ? Util.HexToColor("#F7EC3DFF") : Util.HexToColor("#2B2C2EFF"));
	}
}
