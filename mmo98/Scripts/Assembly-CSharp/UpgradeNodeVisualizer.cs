using System;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.UI;

public class UpgradeNodeVisualizer : MonoBehaviour, ITooltip, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Tooltip tooltipHidden;

	[SerializeField]
	private Tooltip tooltipLocked;

	[SerializeField]
	private Tooltip tooltipBought;

	[SerializeField]
	private AudioDataType unlockedAudio;

	[SerializeField]
	private Button button;

	[SerializeField]
	private Image image;

	private UpgradeNodeData _data;

	private UpgradeNodeGameFeel _gameFeel;

	private UpgradeState _previousState;

	private DoubleVariable _costVariable;

	private IDisposable _moneyRefreshSubscription;

	public Tooltip Tooltip
	{
		get
		{
			if (Database.State.Upgrades.IsUnlocked(_data))
			{
				return tooltipBought;
			}
			if (Database.State.Upgrades.IsUnlocked(_data.prerequisite))
			{
				return tooltipLocked;
			}
			return tooltipHidden;
		}
	}

	private void OnDestroy()
	{
		_moneyRefreshSubscription?.Dispose();
	}

	public void Setup(UpgradeNodeData data)
	{
		_data = data;
		_gameFeel = GetComponent<UpgradeNodeGameFeel>();
		button.onClick.AddListener(UpgradeClicked);
		image.sprite = data.sprite;
		Database.State.Upgrades.ObserveUnlockedOrVisited(_data).Prepend(Unit.Default).Subscribe(delegate
		{
			HandleState();
		})
			.AddTo(this);
		Database.State.Research.Unlocked.ObserveContains(data.research).Subscribe(delegate
		{
			HandleState();
		}).AddTo(this);
		InitializeTooltip();
	}

	private void UpgradeClicked()
	{
		Database.Commands.Upgrades.Unlock(_data);
		if (Database.State.Upgrades.IsUnlocked(_data))
		{
			Audio.PlaySfx(unlockedAudio.Value());
			_gameFeel.PlayUnlockAnimation();
			((IPointerEnterHandler)this).OnPointerEnter((PointerEventData)null);
		}
		else
		{
			_gameFeel.PlayDeniedAnimation();
		}
	}

	private void HandleState()
	{
		UpgradeState state = Database.Commands.Upgrades.GetState(_data);
		base.gameObject.SetActive(state != UpgradeState.Hidden);
		button.interactable = state == UpgradeState.Available || state == UpgradeState.Purchaseable;
		image.color = state.Value();
		if (_previousState == UpgradeState.Hidden && state != UpgradeState.Hidden)
		{
			_gameFeel.PlayAppearAnimation();
		}
		_previousState = state;
		UpdateMoneySubscription(state);
	}

	private void UpdateMoneySubscription(UpgradeState state)
	{
		if (state != UpgradeState.Available && state != UpgradeState.Purchaseable)
		{
			_moneyRefreshSubscription?.Dispose();
			_moneyRefreshSubscription = null;
		}
		else if (_moneyRefreshSubscription == null)
		{
			_moneyRefreshSubscription = Database.State.Resources.MoneyRefresh.Subscribe(delegate
			{
				HandleState();
			}).AddTo(this);
		}
	}

	private void InitializeTooltip()
	{
		if (_costVariable == null)
		{
			_costVariable = new DoubleVariable();
		}
		(string, IVariable)[] variables = new(string, IVariable)[3]
		{
			("upgrade_title", _data.TitleLocalized),
			("upgrade_description", _data.DescriptionLocalized),
			("upgrade_cost", _costVariable)
		};
		tooltipHidden.SetVariables(variables);
		tooltipLocked.SetVariables(variables);
		tooltipLocked.SetVariable("upgrade_modifiers", new LocalizedModifierList(_data, preview: true));
		tooltipBought.SetVariables(variables);
		tooltipBought.SetVariable("upgrade_modifiers", new LocalizedModifierList(_data, preview: false));
	}

	public void RefreshTooltip()
	{
		_costVariable.Value = Database.Commands.Upgrades.CalculateCost(_data);
	}
}
