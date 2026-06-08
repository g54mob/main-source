using UnityEngine;
using UnityEngine.UI;

public class SchematicViewShipPanel : MonoBehaviour
{
	private const int UPGRADE_SLOT_COUNT = 6;

	public static SchematicViewShipPanel Instance;

	private Text[] _upgradeSlotText = new Text[6];

	private Image[] upgradeSlotBorder = new Image[6];

	private GameObject[] _upgradeSlotObject = new GameObject[6];

	private GameObject[] _upgradeSlotNumberObject = new GameObject[6];

	private bool _initialized;

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

	private void Awake()
	{
		if (!_initialized)
		{
			Initialize();
			Instance = this;
		}
	}

	private void Initialize()
	{
		bool flag = true;
		bool flag2 = true;
		Transform transform = base.transform.FindChild("Grid");
		if (transform != null)
		{
			for (int i = 0; i < 6; i++)
			{
				string arg = (i + 1).ToString();
				Transform transform2 = transform.FindChild(string.Format("shipSlot{0}", arg));
				if (!(transform2 != null))
				{
					continue;
				}
				Transform transform3 = transform2.FindChild(string.Format("shipSlot{0}Frame", arg));
				if (transform3 != null)
				{
					_upgradeSlotObject[i] = transform3.gameObject;
					upgradeSlotBorder[i] = transform3.gameObject.GetComponent<Image>();
					transform3 = transform3.FindChild("upgradeText");
					if (transform3 != null)
					{
						_upgradeSlotText[i] = transform3.gameObject.GetComponent<Text>();
					}
					else
					{
						flag = false;
					}
				}
				else
				{
					flag = false;
				}
				transform3 = transform2.FindChild(string.Format("shipSlot{0}Number", arg));
				if (transform3 != null)
				{
					_upgradeSlotNumberObject[i] = transform3.gameObject;
				}
				else
				{
					flag2 = false;
				}
			}
		}
		if (!flag || !flag2)
		{
			Debug.LogError("SchematicViewShipPanel did not resolve all fields properly");
		}
		_initialized = true;
	}

	public void SetData()
	{
		if (!_initialized)
		{
			Initialize();
		}
		int num = 0;
		BaseShipUpgrade baseShipUpgrade = null;
		int num2 = 0;
		if (GlobalSettings.GameState.ThePlayer.MyShip.slotList != null)
		{
			int count = GlobalSettings.GameState.ThePlayer.MyShip.slotList.Count;
			for (int i = 0; i < count; i++)
			{
				SlotInfo slotInfo = GlobalSettings.GameState.ThePlayer.MyShip.slotList[i];
				if (slotInfo.BrokenState == BrokenStateEnum.Broken)
				{
					upgradeSlotBorder[slotInfo.SlotNumber].color = Color.red;
				}
				else if (slotInfo.BreakProbability > 25f)
				{
					upgradeSlotBorder[slotInfo.SlotNumber].color = GlobalSettings.Constants.ORANGE;
				}
				else if (slotInfo.BreakProbability > 15f)
				{
					upgradeSlotBorder[slotInfo.SlotNumber].color = Color.yellow;
				}
			}
		}
		int num3 = 0;
		int num4 = 0;
		for (int j = 0; j < 6; j++)
		{
			if (j < GlobalSettings.GameState.ThePlayer.MyShip.ShipUpgradeSlots + num2)
			{
				SlotInfo slotInfo2 = null;
				if (GlobalSettings.GameState.ThePlayer.MyShip.slotList != null && num4 < GlobalSettings.GameState.ThePlayer.MyShip.slotList.Count)
				{
					slotInfo2 = GlobalSettings.GameState.ThePlayer.MyShip.slotList[num4];
				}
				_upgradeSlotObject[j].gameObject.SetActive(true);
				_upgradeSlotNumberObject[j].gameObject.SetActive(true);
				BaseShipUpgrade baseShipUpgrade2 = null;
				if (num3 < GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.InventoryCount)
				{
					baseShipUpgrade2 = (BaseShipUpgrade)GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy[num3];
				}
				if (baseShipUpgrade2 != null && baseShipUpgrade2.IsPermanentUpgrade)
				{
					baseShipUpgrade = baseShipUpgrade2;
					num3++;
					continue;
				}
				num4++;
				if (baseShipUpgrade2 != null && slotInfo2 != null && slotInfo2.BrokenState != BrokenStateEnum.Broken)
				{
					_upgradeSlotText[num].text = DroneManager.GetShipUpgradeText(baseShipUpgrade2);
					_upgradeSlotText[num].color = DroneManager.GetUpgradeStatus(baseShipUpgrade2, false);
					num3++;
				}
				else
				{
					_upgradeSlotText[num].text = "-------------";
				}
				num++;
			}
			else
			{
				_upgradeSlotObject[j].gameObject.SetActive(false);
				_upgradeSlotNumberObject[j].gameObject.SetActive(false);
			}
		}
		if (baseShipUpgrade != null)
		{
			_upgradeSlotText[num].gameObject.SetActive(true);
			_upgradeSlotText[num].text = DroneManager.GetShipUpgradeText(baseShipUpgrade);
			_upgradeSlotText[num].color = DroneManager.GetUpgradeStatus(baseShipUpgrade, false);
			_upgradeSlotText[num].transform.parent.GetComponent<Image>().enabled = false;
			_upgradeSlotNumberObject[num].gameObject.SetActive(false);
		}
	}
}
