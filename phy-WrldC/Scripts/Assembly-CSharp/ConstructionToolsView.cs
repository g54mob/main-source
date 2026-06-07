using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionToolsView : BaseGUIPanelView
{
	public const string UndoButtonEvent = "ConstructionToolsView.UndoButtonEvent";

	public const string RedoButtonEvent = "ConstructionToolsView.RedoButtonEvent";

	public const string GridDecreaseButtonEvent = "ConstructionToolsView.GridDecreaseButtonEvent";

	public const string GridIncreaseButtonEvent = "ConstructionToolsView.GridIncreaseButtonEvent";

	public const string InventoryButtonEvent = "ConstructionToolsView.InventoryButtonEvent";

	public const string BlockViewButtonEvent = "ConstructionToolsView.BlockViewButtonEvent";

	public const string HingeConnectionEvent = "ConstructionToolsView.HingeConnectionEvent";

	public const string MoveButtonEvent = "ConstructionToolsView.MoveButtonEvent";

	public const string GizmosToggleEvent = "ConstructionToolsView.GizmosToggleEvent";

	public const string MassCenterToggleEvent = "ConstructionToolsView.MassCenterToggleEvent";

	public const string AutoFocusToggleEvent = "ConstructionToolsView.AutoFocusToggleEvent";

	public const string AutoConnectionsToggleEvent = "ConstructionToolsView.AutoConnectionsToggleEvent";

	public const string ClearButtonEvent = "ConstructionToolsView.ClearButtonEvent";

	private Button undoButton;

	private Button redoButton;

	private Button gridDecreaseButton;

	private Button gridIncreaseButton;

	private TextMeshProUGUI gridCounterText;

	private Button inventoryButton;

	private Button blockViewButton;

	private Toggle quickKeysToggle;

	private Toggle moveToggle;

	private Toggle hingeConnectionToggle;

	private Toggle gizmosToggle;

	private Toggle massCenterToggle;

	private Toggle autoFocusToggle;

	private Toggle autoConnectionsToggle;

	private Button clearButton;

	private GameObject massCenterObject;

	private QuickKeysView quickKeysView;

	private QuickKeysController quickKeysController;

	public QuickKeysController QuickKeysController => quickKeysController;

	public ConstructionToolsView(TopButtonsView topButtonsView)
	{
		base.MainPanel = topButtonsView.mainPanel.transform.FindChildRecursively("ConstructionToolsPanel").gameObject;
		undoButton = base.MainPanel.transform.FindComponent<Button>("UndoButton", isRecursively: true);
		redoButton = base.MainPanel.transform.FindComponent<Button>("RedoButton", isRecursively: true);
		gridDecreaseButton = base.MainPanel.transform.FindComponent<Button>("GridDecreaseButton", isRecursively: true);
		gridIncreaseButton = base.MainPanel.transform.FindComponent<Button>("GridIncreaseButton", isRecursively: true);
		inventoryButton = base.MainPanel.transform.FindComponent<Button>("InventoryButton", isRecursively: true);
		blockViewButton = base.MainPanel.transform.FindComponent<Button>("BlockViewButton", isRecursively: true);
		quickKeysToggle = base.MainPanel.transform.FindComponent<Toggle>("QuickKeysToggle", isRecursively: true);
		moveToggle = base.MainPanel.transform.FindComponent<Toggle>("MoveToggle", isRecursively: true);
		hingeConnectionToggle = base.MainPanel.transform.FindComponent<Toggle>("HingeConnectionToggle", isRecursively: true);
		gizmosToggle = base.MainPanel.transform.FindComponent<Toggle>("GizmosToggle", isRecursively: true);
		massCenterToggle = base.MainPanel.transform.FindComponent<Toggle>("MassCenterToggle", isRecursively: true);
		autoFocusToggle = base.MainPanel.transform.FindComponent<Toggle>("AutoFocusToggle", isRecursively: true);
		autoConnectionsToggle = base.MainPanel.transform.FindComponent<Toggle>("AutoConnectionsToggle", isRecursively: true);
		clearButton = base.MainPanel.transform.FindComponent<Button>("ClearButton", isRecursively: true);
		gridCounterText = base.MainPanel.transform.FindComponent<TextMeshProUGUI>("Number", isRecursively: true);
		undoButton.onClick.AddListener(delegate
		{
			NotifyChange("ConstructionToolsView.UndoButtonEvent");
		});
		redoButton.onClick.AddListener(delegate
		{
			NotifyChange("ConstructionToolsView.RedoButtonEvent");
		});
		gridDecreaseButton.onClick.AddListener(delegate
		{
			NotifyChange("ConstructionToolsView.GridDecreaseButtonEvent");
		});
		gridIncreaseButton.onClick.AddListener(delegate
		{
			NotifyChange("ConstructionToolsView.GridIncreaseButtonEvent");
		});
		inventoryButton.onClick.AddListener(delegate
		{
			NotifyChange("ConstructionToolsView.InventoryButtonEvent");
		});
		blockViewButton.onClick.AddListener(delegate
		{
			NotifyChange("ConstructionToolsView.BlockViewButtonEvent");
		});
		hingeConnectionToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("ConstructionToolsView.HingeConnectionEvent", isOn);
		});
		moveToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("ConstructionToolsView.MoveButtonEvent", isOn);
		});
		gizmosToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("ConstructionToolsView.GizmosToggleEvent", isOn);
		});
		massCenterToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("ConstructionToolsView.MassCenterToggleEvent", isOn);
		});
		autoFocusToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("ConstructionToolsView.AutoFocusToggleEvent", isOn);
		});
		autoConnectionsToggle.onValueChanged.AddListener(delegate(bool isOn)
		{
			NotifyChange("ConstructionToolsView.AutoConnectionsToggleEvent", isOn);
		});
		clearButton.onClick.AddListener(delegate
		{
			string text = LanguagesManager.Instance.GetText("message.header.top.clear", "Clear Current Contraption");
			string text2 = LanguagesManager.Instance.GetText("message.info.top.clear", "Clear all blocks?");
			GUIManager.Instance.ShowMessageBox(text, text2, delegate
			{
				NotifyChange("ConstructionToolsView.ClearButtonEvent");
			});
		});
		massCenterObject = GameManager.Instance.massCenterObject;
		quickKeysView = new QuickKeysView(topButtonsView, this);
		quickKeysController = new QuickKeysController(quickKeysView, null);
		quickKeysView.SetVisibility(isVisible: false);
		quickKeysToggle.onValueChanged.AddListener(quickKeysView.SetVisibility);
	}

	public override void SetVisibility(bool isVisible)
	{
		base.SetVisibility(isVisible);
		quickKeysView.SetVisibility(isVisible && quickKeysToggle.isOn);
	}

	public void SetUndoRedoInteractivity(bool isUndoEnabled, bool isRedoEnabled)
	{
		undoButton.interactable = isUndoEnabled;
		redoButton.interactable = isRedoEnabled;
	}

	public void SetGridSizeInteractivity(bool isDecreaseEnabled, bool isIncreaseEnabled, int gridCounter)
	{
		gridDecreaseButton.interactable = isDecreaseEnabled;
		gridIncreaseButton.interactable = isIncreaseEnabled;
		gridCounterText.text = gridCounter.ToString();
	}

	public void SetHingeConnectionToggleStatus(bool isSelected)
	{
		if (hingeConnectionToggle.isOn != isSelected)
		{
			hingeConnectionToggle.SetValue(isSelected);
		}
	}

	public void SetQuickKeysToggleStatus(bool isSelected)
	{
		if (quickKeysToggle.isOn != isSelected)
		{
			quickKeysToggle.SetValue(isSelected);
		}
	}

	public void SetMoveToggleStatus(bool isSelected)
	{
		if (moveToggle.isOn != isSelected)
		{
			moveToggle.SetValue(isSelected);
		}
	}

	public void SetGizmosToggleStatus(bool isSelected)
	{
		if (gizmosToggle.isOn != isSelected)
		{
			gizmosToggle.SetValue(isSelected);
		}
	}

	public void SetAutoFocusToggleStatus(bool isSelected)
	{
		if (autoFocusToggle.isOn != isSelected)
		{
			autoFocusToggle.SetValue(isSelected);
		}
	}

	public void SetAutoConnectionsToggleStatus(bool isSelected)
	{
		if (autoConnectionsToggle.isOn != isSelected)
		{
			autoConnectionsToggle.SetValue(isSelected);
		}
	}

	public void SetMassCenterVisibility(bool isVisible)
	{
		GameManager.Instance.massCenterObject.SetActive(isVisible);
		if (massCenterToggle.isOn != isVisible)
		{
			massCenterToggle.SetValue(isVisible);
		}
	}

	public void SetMassCenterPosition(Vector3 position)
	{
		massCenterObject.transform.position = position;
	}

	public void SetMoveToggleInteractivity(bool isInteractable)
	{
		if (moveToggle.interactable != isInteractable)
		{
			moveToggle.interactable = isInteractable;
		}
	}
}
