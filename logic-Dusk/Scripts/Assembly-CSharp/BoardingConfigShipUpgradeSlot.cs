using UnityEngine;
using UnityEngine.UI;

public class BoardingConfigShipUpgradeSlot : MonoBehaviour
{
	public Text slotNumberLabel;

	private Text _description;

	private Image _cursorBorder;

	private Image slotBorder;

	private BaseShipUpgrade _upgrade;

	private bool _initialized;

	private Color itemShipUpgradeBroken = new Color(1f, 0.5f, 0.5f);

	public bool IsCursorHere
	{
		get
		{
			return _cursorBorder.gameObject.activeInHierarchy;
		}
	}

	public bool IsVisible
	{
		get
		{
			return base.gameObject.activeInHierarchy;
		}
		set
		{
			base.gameObject.SetActive(value);
		}
	}

	public bool IsFixed
	{
		get
		{
			if (_upgrade != null)
			{
				return _upgrade.IsPermanentUpgrade;
			}
			return false;
		}
	}

	public BaseShipUpgrade Upgrade
	{
		get
		{
			return _upgrade;
		}
	}

	private void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
	}

	private void OnDestroy()
	{
		slotNumberLabel = null;
		_description = null;
		_cursorBorder = null;
		slotBorder = null;
	}

	private void Initialize()
	{
		Transform transform = base.transform.FindChild("slotText");
		if (transform != null)
		{
			_description = transform.gameObject.GetComponent<Text>();
		}
		Transform transform2 = base.transform.FindChild("cursorBorder");
		if (transform2 != null)
		{
			_cursorBorder = transform2.gameObject.GetComponent<Image>();
			_cursorBorder.gameObject.SetActive(false);
		}
		transform2 = base.transform.FindChild("Image");
		if (transform2 != null)
		{
			slotBorder = transform2.gameObject.GetComponent<Image>();
		}
		_initialized = true;
	}

	public void SetUpgrade(BaseShipUpgrade upgrade)
	{
		_upgrade = upgrade;
		string text = "------";
		if (upgrade != null)
		{
			text = DroneManager.GetShipUpgradeText(upgrade);
			_description.color = DroneManager.GetUpgradeStatus(Upgrade, !IsCursorHere);
		}
		else
		{
			_description.color = Color.white;
		}
		_description.text = text;
		if (IsFixed)
		{
			slotNumberLabel.gameObject.SetActive(false);
			slotBorder.enabled = false;
		}
	}

	public void SetCursorHere(bool cursorIsHere)
	{
		if (!_initialized)
		{
			Initialize();
		}
		_cursorBorder.gameObject.SetActive(cursorIsHere);
		if (BoardingConfigShipUpgradeUi.Instance != null)
		{
			if (_upgrade != null)
			{
				string text = BoardingConfigUi.Instance.helper.FindHelpText(_upgrade.CommandValue);
				if (text == string.Empty)
				{
					text = _upgrade.Description;
				}
				if (!Upgrade.IsPermanentUpgrade)
				{
					BoardingConfigShipUpgradeUi.Instance.tooltips.label.text = text;
				}
				else
				{
					BoardingConfigShipUpgradeUi.Instance.tooltips.label.text = "Permanent: " + text;
				}
				_description.color = DroneManager.GetUpgradeStatus(Upgrade, !IsCursorHere);
			}
			else
			{
				BoardingConfigShipUpgradeUi.Instance.tooltips.label.text = string.Empty;
			}
		}
		RefreshBreakStats();
	}

	public void SetDeficient()
	{
		slotBorder.color = Color.yellow;
	}

	public void SetCritical()
	{
		slotBorder.color = GlobalSettings.Constants.ORANGE;
	}

	public void SetBroken()
	{
		slotBorder.color = Color.red;
	}

	public void SetWorking()
	{
		slotBorder.color = Color.gray;
	}

	private void RefreshBreakStats()
	{
		if (Upgrade != null && !Upgrade.IsPermanentUpgrade)
		{
			BoardingConfigShipUpgradeUi.Instance.breakStats.gameObject.SetActive(true);
			BoardingConfigShipUpgradeUi.Instance.breakStats.MissionCountLabel.text = Upgrade.NumMissions.ToString();
			BoardingConfigShipUpgradeUi.Instance.breakStats.BreakProbabilityLabel.text = Upgrade.BreakProbability.ToString("0.00") + "%";
			Color upgradeStatus = DroneManager.GetUpgradeStatus(Upgrade, !IsCursorHere);
			BoardingConfigShipUpgradeUi.Instance.breakStats.Border.color = upgradeStatus;
			BoardingConfigShipUpgradeUi.Instance.breakStats.DescriptionLabel.color = upgradeStatus;
			BoardingConfigShipUpgradeUi.Instance.breakStats.MissionCountLabel.color = upgradeStatus;
			BoardingConfigShipUpgradeUi.Instance.breakStats.BreakProbabilityLabel.color = upgradeStatus;
		}
		else
		{
			BoardingConfigShipUpgradeUi.Instance.breakStats.gameObject.SetActive(false);
		}
	}
}
