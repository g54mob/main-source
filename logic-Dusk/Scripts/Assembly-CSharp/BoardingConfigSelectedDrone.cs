using UnityEngine;
using UnityEngine.UI;

public class BoardingConfigSelectedDrone : MonoBehaviour
{
	public Image droneImage;

	public Text droneName;

	public Text droneHP;

	public Text droneNumber;

	public Text modsText;

	public BoardingConfigUpgradeSlot[] upgradeSlots;

	private bool _initialized;

	private int _currentUpgradeSlot;

	private Image[] _droneDetailImage = new Image[4];

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

	public IDrone ThisDrone { get; private set; }

	public BaseDroneUpgrade SelectedUpgrade
	{
		get
		{
			return upgradeSlots[_currentUpgradeSlot].Upgrade;
		}
	}

	public int CurrentSlotIndex
	{
		get
		{
			return _currentUpgradeSlot;
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
		droneImage = null;
		droneName = null;
		droneHP = null;
		droneNumber = null;
		modsText = null;
		int num = _droneDetailImage.Length;
		for (int i = 0; i < num; i++)
		{
			_droneDetailImage[i] = null;
		}
		_droneDetailImage = null;
	}

	private void Initialize()
	{
		if (_initialized)
		{
			return;
		}
		Transform transform = base.transform.FindChild("droneNumberFrame");
		transform = base.transform.FindChild("Image");
		if (transform != null)
		{
			droneImage = transform.gameObject.GetComponent<Image>();
		}
		bool flag = true;
		bool flag2 = true;
		for (int i = 0; i < 4; i++)
		{
			transform = base.transform.FindChild("detailImage" + (i + 1));
			if (transform != null)
			{
				_droneDetailImage[i] = transform.gameObject.GetComponent<Image>();
			}
			if (_droneDetailImage[i] == null)
			{
				flag = false;
			}
		}
		int num = upgradeSlots.Length;
		for (int j = 0; j < num; j++)
		{
			if (upgradeSlots[j] != null)
			{
				upgradeSlots[j].address.text = j + 1 + ".";
			}
		}
		if (!flag || !flag2 || droneImage == null)
		{
			Debug.LogError("BoardingConfigSelectedDrone did not resolve all fields properly");
		}
		_initialized = true;
	}

	public void SetDrone(IDrone drone)
	{
		ThisDrone = drone;
		if (drone != null)
		{
			IsVisible = true;
			droneName.text = drone.DroneName;
			droneNumber.text = drone.DroneNumber.ToString("00");
			droneHP.text = string.Format("{0}/{1}", drone.CurrentHitPoints, drone.TotalHitpoints);
			modsText.text = ModificationsHelper.GetUpgradeIndicators(drone.AppliedModifications);
			int num = 4;
			for (int i = 0; i < num; i++)
			{
				upgradeSlots[i].gameObject.SetActive(false);
			}
			for (int j = 0; j < Mathf.Min(drone.NumberOfUpgradeSlots, num); j++)
			{
				_droneDetailImage[j].gameObject.SetActive(true);
				upgradeSlots[j].gameObject.SetActive(true);
				upgradeSlots[j].SetUpgrade(drone.Upgrades[j]);
				upgradeSlots[j].SetIsSelected(false);
				upgradeSlots[j].SetCursorHere(false);
			}
			SetCursorAtSlot(0);
		}
		else
		{
			droneName.text = "<empty>";
			droneHP.text = string.Empty;
			droneNumber.text = string.Empty;
			modsText.text = string.Empty;
			for (int k = 0; k < 4; k++)
			{
				_droneDetailImage[k].gameObject.SetActive(false);
				upgradeSlots[k].SetUpgrade(null);
				upgradeSlots[k].gameObject.SetActive(false);
			}
			IsVisible = false;
		}
	}

	public BaseDroneUpgrade RemoveSelectedUpgrade()
	{
		if (ThisDrone == null)
		{
			Debug.LogWarning("ThisDrone is null, can't continue!");
			return null;
		}
		BaseDroneUpgrade upgrade = upgradeSlots[_currentUpgradeSlot].Upgrade;
		if (upgrade != null)
		{
			ThisDrone.RemoveDroneUpgrade(upgrade);
			upgradeSlots[_currentUpgradeSlot].SetUpgrade(null);
		}
		RefreshBreakStats(_currentUpgradeSlot);
		return upgrade;
	}

	public void InstallUpgradeAnySlot(BaseDroneUpgrade upgrade)
	{
		if (ThisDrone == null)
		{
			Debug.LogWarning("ThisDrone is null, can't continue!");
		}
		else
		{
			ThisDrone.AddDroneUpgrade(upgrade);
		}
	}

	public void InstallUpgrade(int slot, BaseDroneUpgrade upgrade)
	{
		if (ThisDrone == null)
		{
			Debug.LogWarning("ThisDrone is null, can't continue!");
		}
		else
		{
			ThisDrone.AddDroneUpgrade(slot, upgrade);
		}
	}

	public void SetCursorAtSlot(int slot)
	{
		_currentUpgradeSlot = slot;
		for (int i = 0; i < 4; i++)
		{
			upgradeSlots[i].SetIsSelected(false);
			upgradeSlots[i].SetCursorHere(false);
		}
		upgradeSlots[slot].SetCursorHere(true);
		BoardingConfigUi.Instance.ClearHintText();
		if (upgradeSlots[slot].label.text != string.Empty)
		{
			string text = BoardingConfigUi.Instance.helper.FindHelpText(upgradeSlots[slot].upgradeName);
			if (text != string.Empty)
			{
				BoardingConfigUi.Instance.SetHintText(text);
			}
		}
		RefreshBreakStats(slot);
	}

	public void ArrowUp()
	{
		ArrowUp(false);
	}

	public void ArrowUp(bool forceUp)
	{
		if (ThisDrone == null)
		{
			return;
		}
		if (forceUp)
		{
			_currentUpgradeSlot = 0;
		}
		if (_currentUpgradeSlot == 0)
		{
			for (int num = 3; num >= 0; num--)
			{
				if (num < ThisDrone.NumberOfUpgradeSlots)
				{
					_currentUpgradeSlot = num;
					break;
				}
			}
		}
		else
		{
			_currentUpgradeSlot--;
			GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
		}
		SetCursorAtSlot(_currentUpgradeSlot);
	}

	public void ArrowDown()
	{
		if (ThisDrone != null)
		{
			if (_currentUpgradeSlot != ThisDrone.NumberOfUpgradeSlots - 1)
			{
				_currentUpgradeSlot++;
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
			SetCursorAtSlot(_currentUpgradeSlot);
		}
	}

	public void ShowCursor(bool show)
	{
		upgradeSlots[_currentUpgradeSlot].SetCursorHere(show);
	}

	private void RefreshBreakStats(int slot)
	{
		if (upgradeSlots[slot].Upgrade != null)
		{
			BoardingConfigUi.Instance.breakStats.gameObject.SetActive(true);
			BoardingConfigUi.Instance.breakStats.MissionCountLabel.text = upgradeSlots[slot].Upgrade.NumMissions.ToString();
			BoardingConfigUi.Instance.breakStats.BreakProbabilityLabel.text = upgradeSlots[slot].Upgrade.BreakProbability.ToString("0.00") + "%";
			Color upgradeStatus = DroneManager.GetUpgradeStatus(upgradeSlots[slot].Upgrade, !upgradeSlots[slot].IsCursorHere);
			BoardingConfigUi.Instance.breakStats.Border.color = upgradeStatus;
			BoardingConfigUi.Instance.breakStats.DescriptionLabel.color = upgradeStatus;
			BoardingConfigUi.Instance.breakStats.MissionCountLabel.color = upgradeStatus;
			BoardingConfigUi.Instance.breakStats.BreakProbabilityLabel.color = upgradeStatus;
		}
		else
		{
			BoardingConfigUi.Instance.breakStats.gameObject.SetActive(false);
		}
	}
}
