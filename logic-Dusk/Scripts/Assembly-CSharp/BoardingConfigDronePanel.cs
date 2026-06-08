using UnityEngine;
using UnityEngine.UI;

public class BoardingConfigDronePanel : MonoBehaviour
{
	public const int UPGRADE_SLOT_COUNT = 4;

	public DronePanelUI dronePanel;

	private bool _initialized;

	private Image _downArrow;

	private Image _leftArrow;

	private Image _rightArrow;

	private Color HIGHLIGHT_COLOR = new Color(0.56f, 0.56f, 0.56f);

	private Color _originalColor;

	public bool IsVisible
	{
		get
		{
			return dronePanel.gameObject.activeInHierarchy;
		}
		set
		{
			dronePanel.gameObject.SetActive(value);
		}
	}

	public bool CursorIsHere
	{
		get
		{
			return cursorObject.activeInHierarchy;
		}
	}

	public IDrone ThisDrone { get; private set; }

	public GameObject cursorObject { get; private set; }

	public Image droneSlotImage { get; set; }

	public Image borderImage { get; private set; }

	private void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
	}

	private void Start()
	{
		cursorObject.GetComponent<Image>().color = BoardingConfigUi.Instance.selectedDroneBorderColor;
	}

	private void OnDestroy()
	{
		cursorObject = null;
		_downArrow = null;
		_leftArrow = null;
		_rightArrow = null;
		droneSlotImage = null;
		borderImage = null;
	}

	private void Initialize()
	{
		if (!_initialized)
		{
			Transform transform = base.transform.FindChild("ImageBorder");
			if (transform != null)
			{
				borderImage = transform.gameObject.GetComponent<Image>();
			}
			if (dronePanel != null)
			{
			}
			transform = base.transform.FindChild("focusSelector");
			if (transform != null)
			{
				cursorObject = transform.gameObject;
			}
			transform = base.transform.FindChild("downArrow");
			if (transform != null)
			{
				_downArrow = transform.gameObject.GetComponent<Image>();
			}
			if (dronePanel.gameObject == null || cursorObject == null || dronePanel.droneImage == null || _downArrow == null)
			{
				Debug.LogError("BoardingConfigDronePanel did not resolve all fields properly");
			}
			else
			{
				cursorObject.SetActive(false);
				dronePanel.gameObject.SetActive(false);
				_originalColor = dronePanel.droneImage.color;
				_downArrow.gameObject.SetActive(false);
			}
			_initialized = true;
		}
	}

	public void SetDrone(IDrone drone)
	{
		ThisDrone = drone;
		if (drone != null)
		{
			dronePanel.gameObject.SetActive(true);
			dronePanel.droneName.text = drone.DroneName;
			dronePanel.droneHP.text = string.Format("{0}/{1}", drone.CurrentHitPoints, drone.TotalHitpoints);
			dronePanel.modsText.text = ModificationsHelper.GetUpgradeIndicators(drone.AppliedModifications);
			for (int i = 0; i < 4; i++)
			{
				if (i < drone.NumberOfUpgradeSlots && drone.Upgrades[i] != null)
				{
					dronePanel.upgradeSlots[i].label.text = DroneManager.GetDroneUpgradeText(drone.Upgrades[i]);
					dronePanel.upgradeSlots[i].label.color = DroneManager.GetUpgradeStatus(drone.Upgrades[i], false);
				}
				else
				{
					dronePanel.upgradeSlots[i].label.text = "-------";
					dronePanel.upgradeSlots[i].label.color = Color.white;
				}
				if (i > drone.NumberOfUpgradeSlots - 1)
				{
					dronePanel.upgradeSlots[i].gameObject.SetActive(false);
				}
				else
				{
					dronePanel.upgradeSlots[i].gameObject.SetActive(true);
				}
			}
			switch (((NonVisualDrone)ThisDrone).DroneVisualIndex)
			{
			case 0:
				dronePanel.droneImage.material = new Material(BoardingConfigUi.Instance.drone1Mat);
				break;
			case 1:
				dronePanel.droneImage.material = new Material(BoardingConfigUi.Instance.drone2Mat);
				break;
			case 2:
				dronePanel.droneImage.material = new Material(BoardingConfigUi.Instance.drone3Mat);
				break;
			case 3:
				dronePanel.droneImage.material = new Material(BoardingConfigUi.Instance.drone4Mat);
				break;
			case 4:
				dronePanel.droneImage.material = new Material(BoardingConfigUi.Instance.drone5Mat);
				break;
			case 5:
				dronePanel.droneImage.material = new Material(BoardingConfigUi.Instance.drone6Mat);
				break;
			}
			if (drone.CurrentHitPoints == 0f)
			{
				dronePanel.droneImage.material.color = BoardingConfigUi.Instance.DisabledDrone;
			}
			else
			{
				dronePanel.droneImage.material.color = Color.white;
			}
		}
		else
		{
			dronePanel.droneName.text = string.Empty;
			dronePanel.droneHP.text = string.Empty;
			dronePanel.modsText.text = string.Empty;
			for (int j = 0; j < 4; j++)
			{
				dronePanel.upgradeSlots[j].label.text = string.Empty;
			}
			dronePanel.gameObject.SetActive(false);
		}
	}

	public void SetCursorHere(bool showCursor)
	{
		cursorObject.SetActive(showCursor);
	}

	public void SetDownArrow(bool show)
	{
		_downArrow.gameObject.SetActive(show);
	}

	public void SetHighlighted(bool highlight)
	{
		if (highlight)
		{
			if (ThisDrone != null && ThisDrone.CurrentHitPoints == 0f)
			{
				dronePanel.droneImage.material.color = BoardingConfigUi.Instance.DisabledHighlightedDrone;
			}
			else
			{
				dronePanel.droneImage.material.color = HIGHLIGHT_COLOR;
			}
		}
		else if (ThisDrone != null && ThisDrone.CurrentHitPoints == 0f)
		{
			dronePanel.droneImage.material.color = BoardingConfigUi.Instance.DisabledDrone;
		}
		else
		{
			dronePanel.droneImage.material.color = _originalColor;
		}
	}

	public void SetLeftRightArrows(Image leftArrow, Image rightArrow)
	{
		_leftArrow = leftArrow;
		_rightArrow = rightArrow;
	}

	public void ShowLeftRightArrows(bool show)
	{
		_leftArrow.gameObject.SetActive(show);
		_rightArrow.gameObject.SetActive(show);
	}
}
