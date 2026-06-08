using UnityEngine;
using UnityEngine.UI;

public class BoardingConfigShipPanel : MonoBehaviour
{
	private const int UPGRADE_SLOT_COUNT = 6;

	private LocalPlayer _player;

	private bool _initialized;

	private int _currentUpgradeSlot;

	private Text _shipName;

	private Text _shipActualName;

	private RawImage _shipImage;

	private BoardingConfigShipUpgradeSlot[] _upgradeSlots = new BoardingConfigShipUpgradeSlot[6];

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

	public LocalPlayer ThePlayer
	{
		get
		{
			return _player;
		}
	}

	public BaseShipUpgrade SelectedUpgrade
	{
		get
		{
			return _upgradeSlots[_currentUpgradeSlot].Upgrade;
		}
	}

	public int CurrentSlotIndex
	{
		get
		{
			return _currentUpgradeSlot;
		}
	}

	public bool HasPermUpgrade { get; private set; }

	private void Awake()
	{
		if (!_initialized)
		{
			Initialize();
		}
	}

	private void OnDestroy()
	{
		_shipName = null;
		_shipImage = null;
	}

	private void Initialize()
	{
		if (_initialized)
		{
			return;
		}
		Transform transform = base.transform.FindChild("shipName");
		if (transform != null)
		{
			_shipName = transform.gameObject.GetComponent<Text>();
		}
		transform = base.transform.FindChild("shipActualName");
		if (transform != null)
		{
			_shipActualName = transform.gameObject.GetComponent<Text>();
		}
		transform = base.transform.FindChild("shipImage");
		if (transform != null)
		{
			_shipImage = transform.gameObject.GetComponent<RawImage>();
			RefreshShipImage();
		}
		bool flag = true;
		Transform transform2 = base.transform.FindChild("Grid");
		if (transform2 != null)
		{
			for (int i = 0; i < 6; i++)
			{
				transform = transform2.FindChild("shipSlot" + (i + 1));
				if (transform != null)
				{
					_upgradeSlots[i] = transform.gameObject.GetComponent<BoardingConfigShipUpgradeSlot>();
					_upgradeSlots[i].slotNumberLabel.text = i + 1 + ".";
				}
				if (_upgradeSlots[i] == null)
				{
					flag = false;
				}
			}
		}
		if (_shipName == null || _shipImage == null || !flag)
		{
			Debug.LogError("BoardingConfigShipPanel did not resolve all fields properly");
		}
		_initialized = true;
	}

	private void RefreshShipImage()
	{
		if (!(_shipImage != null))
		{
			return;
		}
		string empty = string.Empty;
		empty = ((GlobalSettings.GameState.ThePlayer.MyShip.Definition.Value == null) ? GlobalSettings.GameState.ThePlayer.MyShip.Definition.Key.imageFileName : GlobalSettings.GameState.ThePlayer.MyShip.Definition.Value.imageFileName);
		if (!string.IsNullOrEmpty(empty))
		{
			Texture2D texture2D = ResourceManager.LoadAsset<Texture2D>("UI/shipProfiles/" + empty);
			if (texture2D != null)
			{
				_shipImage.texture = texture2D;
			}
		}
	}

	public void UpdateData()
	{
		_player = GlobalSettings.GameState.ThePlayer;
		for (int i = 0; i < 6; i++)
		{
			_upgradeSlots[i].SetUpgrade(null);
			_upgradeSlots[i].SetWorking();
			_upgradeSlots[i].gameObject.SetActive(false);
		}
		RefreshShipImage();
		if (_player.MyShip.slotList != null)
		{
			foreach (SlotInfo slot in _player.MyShip.slotList)
			{
				if (slot.BrokenState == BrokenStateEnum.Broken)
				{
					_upgradeSlots[slot.SlotNumber].SetBroken();
				}
				else if (slot.BreakProbability > 25f)
				{
					_upgradeSlots[slot.SlotNumber].SetCritical();
				}
				else if (slot.BreakProbability > 15f)
				{
					_upgradeSlots[slot.SlotNumber].SetDeficient();
				}
			}
		}
		if (_player != null)
		{
			IsVisible = true;
			_shipName.text = _player.MyShip.DisplayName;
			_shipActualName.text = _player.MyShip.Name;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			BaseShipUpgrade baseShipUpgrade = null;
			for (int j = 0; j < Mathf.Min(_player.MyShip.ShipUpgradeSlots, 6); j++)
			{
				SlotInfo slotInfo = null;
				if (_player.MyShip.slotList != null && num3 < _player.MyShip.slotList.Count)
				{
					slotInfo = _player.MyShip.slotList[num3];
				}
				BaseShipUpgrade baseShipUpgrade2 = null;
				if (num2 < _player.MyShip.InstalledInventory.InventoryCount)
				{
					baseShipUpgrade2 = (BaseShipUpgrade)_player.MyShip.InstalledInventory.ItemsCopy[num2];
				}
				if (baseShipUpgrade2 != null && baseShipUpgrade2.IsPermanentUpgrade)
				{
					baseShipUpgrade = baseShipUpgrade2;
					num2++;
					continue;
				}
				num3++;
				_upgradeSlots[num].gameObject.SetActive(true);
				if (slotInfo == null || slotInfo.BrokenState != BrokenStateEnum.Broken)
				{
					_upgradeSlots[num].SetUpgrade(baseShipUpgrade2);
					num2++;
				}
				_upgradeSlots[num].SetCursorHere(false);
				num++;
			}
			if (baseShipUpgrade != null)
			{
				_upgradeSlots[num].gameObject.SetActive(true);
				_upgradeSlots[num].SetUpgrade(baseShipUpgrade);
				_upgradeSlots[num].SetCursorHere(false);
				num++;
				HasPermUpgrade = true;
			}
			_currentUpgradeSlot = 0;
		}
		else
		{
			_shipName.text = "<empty>";
			_shipActualName.text = "<empty>";
			IsVisible = false;
		}
	}

	public BaseShipUpgrade RemoveSelectedUpgrade()
	{
		if (_player == null)
		{
			Debug.LogWarning("_player is null, can't continue!");
			return null;
		}
		BaseShipUpgrade upgrade = _upgradeSlots[_currentUpgradeSlot].Upgrade;
		if (upgrade != null)
		{
			_player.UninstallShipUpgrade(upgrade);
			UpdateData();
		}
		return upgrade;
	}

	public bool InstallUpgradeAnySlot(BaseShipUpgrade upgrade)
	{
		if (_player == null)
		{
			Debug.LogWarning("_player is null, can't continue!");
			return false;
		}
		return _player.InstallShipUpgrade(upgrade);
	}

	public void SetCursorAtSlot(int slot)
	{
		_currentUpgradeSlot = slot;
		for (int i = 0; i < 6; i++)
		{
			_upgradeSlots[i].SetCursorHere(false);
		}
		_upgradeSlots[slot].SetCursorHere(true);
	}

	public void ArrowUp()
	{
		if (_player != null)
		{
			if (_currentUpgradeSlot != 0)
			{
				_currentUpgradeSlot--;
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
			SetCursorAtSlot(_currentUpgradeSlot);
		}
	}

	public void ArrowDown()
	{
		if (_player != null)
		{
			int num = _player.MyShip.ShipUpgradeSlots - 1;
			if (_currentUpgradeSlot != num)
			{
				_currentUpgradeSlot++;
				GameAudio.Play2DSFX(GameAudio.SoundEnum.UISelectLow);
			}
			SetCursorAtSlot(_currentUpgradeSlot);
		}
	}

	public void ShowCursor(bool show)
	{
		_upgradeSlots[_currentUpgradeSlot].SetCursorHere(show);
	}
}
