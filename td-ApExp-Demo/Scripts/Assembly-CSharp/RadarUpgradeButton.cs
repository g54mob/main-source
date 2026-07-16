using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadarUpgradeButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IMoveHandler
{
	public enum State
	{
		PurchasedActive = 0,
		PurchasedInactive = 1,
		Unavailable = 2,
		UnpurchasedNoMoney = 3,
		UnpurchasedHaveMoney = 4
	}

	[NonSerialized]
	public State _currentState = State.Unavailable;

	[SerializeField]
	private Sprite hiddenSprite;

	[SerializeField]
	private Button button;

	public Image iconImage;

	public Image background;

	[SerializeField]
	private Image toggleImage;

	[SerializeField]
	private Sprite backgroundUnurchasedSprite;

	[SerializeField]
	private Sprite backgroundPurchasedSprite;

	[SerializeField]
	private Sprite toggleSpriteOn;

	[SerializeField]
	private Sprite toggleSpriteOff;

	private bool isSelected;

	public float interactTimer;

	public EnhancementRadar Upgrade { get; private set; }

	public int Index { get; private set; }

	public RadarWindow RadarWindow { get; private set; }

	public bool IsRevealed { get; private set; }

	public event Action onPointerEnter;

	public event Action onPointerExit;

	public event Action<int> onNavigate;

	public void OnPointerEnter(PointerEventData eventData)
	{
		this.onPointerEnter?.Invoke();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		this.onPointerExit?.Invoke();
	}

	public void OnNavigate(int index)
	{
		this.onNavigate?.Invoke(index);
	}

	private void Update()
	{
		interactTimer -= Time.unscaledDeltaTime;
	}

	public void Init(RadarWindow radarWindow, int index, EnhancementRadar upgrade)
	{
		RadarWindow = radarWindow;
		Index = index;
		Upgrade = upgrade;
		ResourceManager.Instance.Cores.OnValueChangedTo.AddListener(delegate
		{
			RefreshCostState();
		});
	}

	public void CheckBought()
	{
		if (UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].isBought)
		{
			OnBought();
		}
	}

	public void OnClick()
	{
		TrySelectUpgrade();
	}

	public void TrySelectUpgrade()
	{
		if (!(interactTimer > 0f))
		{
			interactTimer = 0.1f;
			if (!UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].isBought)
			{
				TryBuy();
			}
			else if (Upgrade.IsToggleable)
			{
				UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].IsApplied = !UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].IsApplied;
				Debug.Log(Upgrade.ID + " " + UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].IsApplied);
				UpdateToggleImage();
			}
		}
	}

	private void TryBuy()
	{
		Debug.Log(Upgrade.CoresCost + "  " + Upgrade.ID);
		if (!UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].isBought && IsRevealed && ResourceManager.Instance.Cores.TrySpend(Upgrade.CoresCost))
		{
			Debug.Log("spent");
			OnBought();
			UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].IsApplied = true;
		}
	}

	public void OnResetState()
	{
		UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].isBought = false;
		UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].IsApplied = false;
		IsRevealed = false;
		background.sprite = backgroundUnurchasedSprite;
		ChangeState(State.Unavailable);
	}

	public void OnBought()
	{
		Debug.Log("Bought upgrade id " + Upgrade.ID + " " + Index);
		iconImage.sprite = Upgrade.Icon;
		iconImage.color = RadarWindow.PurchasedActiveColor;
		background.sprite = backgroundPurchasedSprite;
		if (UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].isBought)
		{
			if (UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].IsApplied)
			{
				RadarWindow.tempButtonState = State.PurchasedActive;
			}
			else
			{
				RadarWindow.tempButtonState = State.PurchasedInactive;
			}
		}
		UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].isBought = true;
		IsRevealed = true;
		if (Upgrade.IsToggleable)
		{
			toggleImage.gameObject.SetActive(value: true);
		}
		RadarWindow.RevealAdjacent(Index);
	}

	public void TryReveal()
	{
		if (!IsRevealed)
		{
			IsRevealed = true;
			iconImage.sprite = Upgrade.Icon;
			RefreshCostState();
		}
	}

	public void RefreshCostState()
	{
		if (!UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].isBought && IsRevealed)
		{
			if (ResourceManager.Instance.Cores.Value >= (float)Upgrade.CoresCost)
			{
				ChangeState(State.UnpurchasedHaveMoney);
			}
			else
			{
				ChangeState(State.UnpurchasedNoMoney);
			}
		}
	}

	public void RefreshHoverCostState()
	{
		if (!UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].isBought && IsRevealed)
		{
			if (ResourceManager.Instance.Cores.Value >= (float)Upgrade.CoresCost)
			{
				RadarWindow.tempButtonState = State.UnpurchasedHaveMoney;
			}
			else
			{
				RadarWindow.tempButtonState = State.UnpurchasedNoMoney;
			}
		}
	}

	public void UpdateToggleImage()
	{
		if ((bool)Upgrade)
		{
			Debug.Log("Changing state for id " + Upgrade.ID + " " + Index);
			if (UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].IsApplied)
			{
				RadarWindow.tempButtonState = State.PurchasedActive;
				ChangeState(State.PurchasedActive);
			}
			else if (!UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].IsApplied && UpgradeManager.Instance.RadarUpgradeSaves[Upgrade.ID].isBought)
			{
				RadarWindow.tempButtonState = State.PurchasedInactive;
				ChangeState(State.PurchasedInactive);
			}
		}
	}

	private void OnEnable()
	{
		UpdateToggleImage();
	}

	public void UpgradeAppliedHandler(bool applied)
	{
		UpdateToggleImage();
	}

	internal State GetState()
	{
		return _currentState;
	}

	public void ChangeSelect()
	{
	}

	public void ChangeState(State state)
	{
		switch (state)
		{
		case State.PurchasedActive:
			toggleImage.sprite = toggleSpriteOn;
			iconImage.color = RadarWindow.PurchasedActiveColor;
			background.sprite = RadarWindow.PurchasedUpgradeActiveSprite;
			break;
		case State.PurchasedInactive:
			toggleImage.sprite = toggleSpriteOff;
			if (iconImage != null)
			{
				iconImage.color = RadarWindow.PurchasedInactiveColor;
			}
			else
			{
				Debug.LogError("mby wrong");
			}
			background.sprite = RadarWindow.PurchasedUpgradeInactiveSprite;
			break;
		case State.UnpurchasedHaveMoney:
			iconImage.color = RadarWindow.UnpurchasedHaveMoneyColor;
			break;
		case State.UnpurchasedNoMoney:
			iconImage.color = RadarWindow.UnpurchasedNoMoneyColor;
			break;
		case State.Unavailable:
			iconImage.sprite = hiddenSprite;
			iconImage.color = RadarWindow.UnavailableColor;
			toggleImage.enabled = false;
			background.sprite = backgroundUnurchasedSprite;
			break;
		}
		_currentState = state;
	}

	public void OnMove(AxisEventData eventData)
	{
		Selectable component = GetComponent<Selectable>();
		Selectable selectable = null;
		switch (eventData.moveDir)
		{
		case MoveDirection.Up:
			selectable = component.FindSelectableOnUp();
			break;
		case MoveDirection.Down:
			selectable = component.FindSelectableOnDown();
			break;
		case MoveDirection.Left:
			selectable = component.FindSelectableOnLeft();
			break;
		case MoveDirection.Right:
			selectable = component.FindSelectableOnRight();
			break;
		}
		if (selectable != null)
		{
			RadarUpgradeButton component2 = selectable.gameObject.GetComponent<RadarUpgradeButton>();
			component2?.onNavigate?.Invoke(component2.Index);
		}
	}
}
