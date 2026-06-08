using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDroneItem : MonoBehaviour, IUIItem, IUIModItem
{
	public Color installedDroneNumberColor = Color.white;

	public Color emptyDroneNumberColor = Color.white;

	public UIDroneNumber droneNumberObject;

	public Text droneHPLabel;

	public Text droneNameLabel;

	public Text modsLabel;

	public Image border;

	private Image backgroundImage;

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public IInventoryItem ParentItem { get; set; }

	public IInventoryItem InventoryItem { get; set; }

	public List<IModification> ModificationList { get; private set; }

	public bool IsHighlighted { get; private set; }

	public bool IsSelected { get; private set; }

	public bool IsActive { get; private set; }

	public IUIItem AffectedItem { get; set; }

	public IDrone Drone { get; private set; }

	private void Awake()
	{
	}

	private void OnDestroy()
	{
		droneHPLabel = null;
		droneNameLabel = null;
		modsLabel = null;
		border = null;
		backgroundImage = null;
	}

	private void Start()
	{
	}

	public void Init()
	{
		backgroundImage = base.gameObject.GetComponent<Image>();
		SetActive();
		if (ModificationList != null)
		{
			ModificationList.Clear();
		}
	}

	public void MarkEmpty(int idx)
	{
		droneNumberObject.droneNumberLabel.color = emptyDroneNumberColor;
		droneHPLabel.text = string.Empty;
		droneNameLabel.text = string.Empty;
		droneNumberObject.droneNumberLabel.text = idx.ToString("0#");
		Drone = null;
		if (ModificationList != null)
		{
			ModificationList.Clear();
		}
	}

	public void FillSlot(IDrone drone)
	{
		if (drone.CurrentHitPoints == 0f)
		{
			droneNumberObject.droneNumberLabel.color = Color.yellow;
			droneHPLabel.color = Color.yellow;
			droneNameLabel.color = Color.yellow;
		}
		else
		{
			droneNumberObject.droneNumberLabel.color = installedDroneNumberColor;
			droneHPLabel.color = Color.white;
			droneNameLabel.color = Color.white;
		}
		droneHPLabel.text = drone.CurrentHitPoints.ToString() + "/" + drone.TotalHitpoints;
		droneNameLabel.text = drone.DroneName;
		droneNumberObject.droneNumberLabel.text = drone.DroneNumber.ToString("0#");
		Drone = drone;
	}

	public void AddModification(IModification mod)
	{
		if (ModificationList == null)
		{
			ModificationList = new List<IModification>();
		}
		ModificationList.Add(mod);
	}

	public void ClearSelection()
	{
		IsSelected = false;
		ClearHighlight();
	}

	public void ClearHighlight()
	{
		IsHighlighted = false;
		if (!IsSelected)
		{
			Color black = Color.black;
			black.a = 0f;
			backgroundImage.color = black;
		}
		else
		{
			backgroundImage.color = ModificationUI.Instance.selectedItemColor;
		}
	}

	public void Select()
	{
		IsSelected = true;
		backgroundImage.color = ModificationUI.Instance.selectedItemColor;
		UpdateToolTip();
	}

	public void Highlight()
	{
		IsHighlighted = true;
		if (IsActive)
		{
			backgroundImage.color = ModificationUI.Instance.highlightedItemColor;
			ModificationUI.Instance.commandHints.SetEnterActive();
		}
		else
		{
			backgroundImage.color = ModificationUI.Instance.highlightedDisabledItemColor;
			ModificationUI.Instance.commandHints.SetEnterInactive();
		}
		UpdateToolTip();
	}

	public void Dim()
	{
		Color white = Color.white;
		white = ((Drone.CurrentHitPoints != 0f) ? Color.white : Color.yellow);
		white.a = 0.5f;
		droneNameLabel.color = white;
		droneHPLabel.color = white;
	}

	public void UnDim()
	{
		Color white = Color.white;
		white = ((Drone.CurrentHitPoints != 0f) ? Color.white : Color.yellow);
		droneNameLabel.color = white;
		droneHPLabel.color = white;
	}

	public void SetActive()
	{
		IsActive = true;
		border.color = ModificationUI.Instance.selectedBorderColor;
		if (IsHighlighted)
		{
			backgroundImage.color = ModificationUI.Instance.highlightedItemColor;
		}
	}

	public void SetInactive()
	{
		IsActive = false;
		border.color = ModificationUI.Instance.deSelectedBorderColor;
		if (IsHighlighted)
		{
			backgroundImage.color = ModificationUI.Instance.highlightedDisabledItemColor;
		}
	}

	private void UpdateToolTip()
	{
		if (Drone != null)
		{
			UITooltips.CurrentTooltip.label.text = string.Format("{0} (Drone #{1})", droneNameLabel.text, droneNumberObject.droneNumberLabel.text);
			UITooltips.CurrentTooltip.enabled = true;
		}
		else
		{
			UITooltips.CurrentTooltip.label.text = string.Empty;
			UITooltips.CurrentTooltip.enabled = false;
		}
	}
}
