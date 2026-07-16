using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RadarWindow : Menu
{
	[SerializeField]
	private RadarTooltip tooltip;

	[SerializeField]
	[Tooltip("Index of the first upgrades to be revealed in the grid, e.g. 0 = top left.")]
	private int[] startIndices;

	public Sprite PurchasedUpgradeActiveSprite;

	public Sprite PurchasedUpgradeInactiveSprite;

	public Sprite HoverUpgradeSprite;

	public Sprite UnpurchasedUpgradeSprite;

	private Dictionary<int, RadarUpgradeButton> radarButtons;

	private EnhancementRadar[] radarUpgrades;

	private int size = 6;

	[NonSerialized]
	public RadarUpgradeButton.State tempButtonState;

	private int lastNavigationIndex = -1;

	private bool isCursorInButton;

	private bool isChangingToKeyboard;

	private ControllerType _currentControllerType;

	[field: SerializeField]
	public Color PurchasedActiveColor { get; private set; }

	[field: SerializeField]
	public Color PurchasedActiveHoverColor { get; private set; }

	[field: SerializeField]
	public Color PurchasedInactiveColor { get; private set; }

	[field: SerializeField]
	public Color PurchasedInactiveHoverColor { get; private set; }

	[field: SerializeField]
	public Color UnpurchasedHaveMoneyColor { get; private set; }

	[field: SerializeField]
	public Color UnpurchasedHaveMoneyHoverColor { get; private set; }

	[field: SerializeField]
	public Color UnpurchasedNoMoneyColor { get; private set; }

	[field: SerializeField]
	public Color UnpurchasedNoMoneyHoverColor { get; private set; }

	[field: SerializeField]
	public Color UnavailableColor { get; private set; }

	[field: SerializeField]
	public Color UnavailableHoverColor { get; private set; }

	[field: SerializeField]
	public Color UnpurchasedColor { get; private set; }

	[field: SerializeField]
	public Color UnpurchasedHoverColor { get; private set; }

	[field: SerializeField]
	public Color PurchasedColor { get; private set; }

	[field: SerializeField]
	public Color PurchasedHoverColor { get; private set; }

	public override void Init()
	{
		base.Init();
		radarButtons = new Dictionary<int, RadarUpgradeButton>();
		Transform transform = base.transform.Find("Contents");
		for (int i = 0; i < transform.childCount; i++)
		{
			if (transform.GetChild(i).TryGetComponent<RadarUpgradeButton>(out var component))
			{
				radarButtons.Add(i, component);
			}
		}
		radarUpgrades = UpgradeManager.Instance.RadarUpgrades;
		tooltip.Init();
		foreach (KeyValuePair<int, RadarUpgradeButton> radarButton in radarButtons)
		{
			int i2 = radarButton.Key;
			radarButton.Value.Init(this, i2, radarUpgrades[i2]);
			radarButton.Value.onPointerEnter += delegate
			{
				HandleRadarButtonPointerEnter(i2);
			};
			radarButton.Value.onPointerExit += delegate
			{
				HandleRadarButtonPointerExit(i2);
			};
			radarButton.Value.onNavigate += delegate(int nextIndex)
			{
				HandleRadarButtonNavigate(nextIndex);
			};
		}
	}

	private void Start()
	{
		foreach (RadarUpgradeButton value in radarButtons.Values)
		{
			value.CheckBought();
		}
		RevealStart();
	}

	private void Update()
	{
		if (MouseCursor.Instance.IsVisible && !isCursorInButton)
		{
			tooltip.gameObject.SetActive(value: false);
		}
	}

	protected override void OnOpen()
	{
		base.OnOpen();
		foreach (KeyValuePair<int, RadarUpgradeButton> radarButton in radarButtons)
		{
			radarButton.Value.UpdateToggleImage();
		}
		InputManager.Instance.OnEnter += HandleEnterInput;
		InputHandler.OnAnyInputDetected = (Action<int, ControllerType>)Delegate.Combine(InputHandler.OnAnyInputDetected, new Action<int, ControllerType>(HandleDeviceChanged));
		if (InputManager.Instance.LastControllerTypeUsed == ControllerType.KeyboardMouse)
		{
			StartCoroutine(DeselectAfterDelay());
		}
		static IEnumerator DeselectAfterDelay()
		{
			yield return new WaitForSeconds(0.1f);
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	protected override void OnClose()
	{
		if (lastNavigationIndex >= 0)
		{
			HandleRadarButtonPointerExit(lastNavigationIndex);
		}
		tooltip.gameObject.SetActive(value: false);
		InputManager.Instance.OnEnter -= HandleEnterInput;
		InputHandler.OnAnyInputDetected = (Action<int, ControllerType>)Delegate.Remove(InputHandler.OnAnyInputDetected, new Action<int, ControllerType>(HandleDeviceChanged));
		SaveManager.Instance.Save();
	}

	private void HandleDeviceChanged(int playerIndex, ControllerType controllerType)
	{
		if (_currentControllerType != controllerType)
		{
			Debug.LogWarning("controller changed");
			if (lastNavigationIndex >= 0)
			{
				Debug.Log("devis chng");
				HandleRadarButtonPointerExit(lastNavigationIndex);
			}
			tooltip.gameObject.SetActive(value: false);
			if (controllerType == ControllerType.KeyboardMouse)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
			else if (EventSystem.current.currentSelectedGameObject == null)
			{
				EventSystem.current.SetSelectedGameObject(defaultSelectedGo);
				HandleRadarButtonPointerEnter(defaultSelectedGo.GetComponent<RadarUpgradeButton>().Index);
			}
			_currentControllerType = controllerType;
			SetUpForControllerType(controllerType);
		}
	}

	private void SetUpForControllerType(ControllerType controllerType)
	{
	}

	public void ChangeNavigationIndex(int i)
	{
		_ = lastNavigationIndex;
		_ = 0;
		lastNavigationIndex = i;
		if (i >= 0)
		{
			tooltip.SetUpgrade(radarButtons[i].Upgrade);
			isCursorInButton = true;
			EventSystem.current.SetSelectedGameObject(radarButtons[i].gameObject);
			tempButtonState = radarButtons[i].GetState();
			if (tempButtonState != RadarUpgradeButton.State.Unavailable)
			{
				tooltip.gameObject.SetActive(value: true);
			}
			else
			{
				tooltip.gameObject.SetActive(value: false);
			}
		}
		else
		{
			tooltip.gameObject.SetActive(value: false);
			isCursorInButton = false;
		}
	}

	private void HandleRadarButtonPointerEnter(int i)
	{
		ChangeNavigationIndex(i);
		if (radarButtons[i].IsRevealed)
		{
			tooltip.gameObject.SetActive(value: true);
		}
	}

	private void HandleRadarButtonPointerExit(int i)
	{
		if (isChangingToKeyboard)
		{
			isChangingToKeyboard = false;
		}
		else
		{
			ChangeNavigationIndex(-1);
		}
	}

	private void HandleRadarButtonNavigate(int i)
	{
		Debug.Log("SWIIITCHHHH");
		if (lastNavigationIndex >= 0)
		{
			Debug.Log("exit " + lastNavigationIndex);
			HandleRadarButtonPointerExit(lastNavigationIndex);
		}
		Debug.Log("go " + i);
		isChangingToKeyboard = true;
		tooltip.SetIsTooltipOnMouse(isToMouse: false);
		HandleRadarButtonPointerEnter(i);
	}

	private void HandleEnterInput(int playerIndex, InputAction.CallbackContext context)
	{
		if (lastNavigationIndex >= 0)
		{
			radarButtons[lastNavigationIndex].TrySelectUpgrade();
		}
	}

	public int GetLastNavigationIndex()
	{
		return lastNavigationIndex;
	}

	private void RevealStart()
	{
		for (int i = 0; i < startIndices.Length; i++)
		{
			radarButtons[startIndices[i]].TryReveal();
		}
	}

	public void RevealAdjacent(int i)
	{
		RadarUpgradeButton radarUpgradeButton = radarButtons[i];
		List<RadarUpgradeButton> adjacentButtons = GetAdjacentButtons(i);
		bool isBought = UpgradeManager.Instance.RadarUpgradeSaves[radarUpgradeButton.Upgrade.ID].isBought;
		foreach (RadarUpgradeButton item in adjacentButtons)
		{
			if (isBought)
			{
				item.TryReveal();
			}
		}
	}

	public List<RadarUpgradeButton> GetAdjacentButtons(int i)
	{
		List<RadarUpgradeButton> list = new List<RadarUpgradeButton>();
		if (radarButtons.ContainsKey(i - 1) && i % size != 0)
		{
			list.Add(radarButtons[i - 1]);
		}
		if (radarButtons.ContainsKey(i + 1) && (i + 1) % size != 0)
		{
			list.Add(radarButtons[i + 1]);
		}
		if (radarButtons.ContainsKey(i - size))
		{
			list.Add(radarButtons[i - size]);
		}
		if (radarButtons.ContainsKey(i + size))
		{
			list.Add(radarButtons[i + size]);
		}
		return list;
	}

	public void DebugBuyAllUpgrades()
	{
		ResourceManager.Instance.Cores.AddValue(100f);
		foreach (RadarUpgradeButton value in radarButtons.Values)
		{
			value.OnBought();
			UpgradeManager.Instance.RadarUpgradeSaves[value.Upgrade.ID].IsApplied = true;
		}
	}

	public void DebugResetAllUpgrades()
	{
		foreach (RadarUpgradeButton value in radarButtons.Values)
		{
			value.OnResetState();
			UpgradeManager.Instance.RadarUpgradeSaves[value.Upgrade.ID].isBought = false;
			UpgradeManager.Instance.RadarUpgradeSaves[value.Upgrade.ID].IsApplied = false;
		}
		RevealStart();
	}
}
