public class AssignableState
{
	public AssignableState parentSettings;

	public readonly PropertyItem<OverrideState> pause = new PropertyItem<OverrideState>();

	public readonly PropertyItem<StatePriority> priority = new PropertyItem<StatePriority>();

	public readonly PropertyItem<OverrideState> autoAssign = new PropertyItem<OverrideState>();

	public readonly PropertyItem<TradeMode> tradingConfig = new PropertyItem<TradeMode>();

	public readonly PropertyItem<OverrideState> autoClaim = new PropertyItem<OverrideState>();

	public readonly ProductionConfig productionLimit = new ProductionConfig();

	public StatePriority craftingGroupPriority => priority.value;

	public void TogglePause()
	{
		bool isParentSpecified = InheritedPause() == OverrideState.On;
		pause.ChangeValue(GameUtility.CycledOverride(pause.value, isParentSpecified));
		GameManager.Instance.OnBuildingStatePauseChanged(this);
	}

	public bool HasValues()
	{
		if (pause.value == OverrideState.None && priority.value == StatePriority.None && autoAssign.value == OverrideState.None && autoClaim.value == OverrideState.None && craftingGroupPriority == StatePriority.None)
		{
			return tradingConfig.value != TradeMode.None;
		}
		return true;
	}

	public void Reset()
	{
		pause.InitializeValue(OverrideState.None);
		priority.InitializeValue(StatePriority.None);
		autoAssign.InitializeValue(OverrideState.None);
		autoClaim.InitializeValue(OverrideState.None);
		tradingConfig.InitializeValue(TradeMode.None);
		productionLimit.Reset();
	}

	public void CyclePriority()
	{
		bool isParentSpecified = InheritedPriority() != StatePriority.None;
		priority.ChangeValue(GameUtility.CycledPriority(craftingGroupPriority, isParentSpecified));
	}

	public void CycleAutoAssign()
	{
		bool isParentSpecified = InheritedAutoAssign() == OverrideState.On;
		autoAssign.ChangeValue(GameUtility.CycledOverride(autoAssign.value, isParentSpecified));
	}

	public void CycleAutoClaim()
	{
		bool isParentSpecified = InheritedAutoClaim() == OverrideState.On;
		autoClaim.ChangeValue(GameUtility.CycledOverride(autoClaim.value, isParentSpecified));
	}

	public OverrideState DerivedAutoClaim()
	{
		if (autoClaim.value == OverrideState.None && parentSettings != null)
		{
			return parentSettings.DerivedAutoClaim();
		}
		return autoClaim.value;
	}

	public OverrideState DerivedAutoAssign()
	{
		if (autoAssign.value == OverrideState.None && parentSettings != null)
		{
			return parentSettings.DerivedAutoAssign();
		}
		return autoAssign.value;
	}

	public OverrideState InheritedAutoClaim()
	{
		if (parentSettings != null)
		{
			return parentSettings.DerivedAutoClaim();
		}
		return OverrideState.None;
	}

	public OverrideState InheritedAutoAssign()
	{
		if (parentSettings != null)
		{
			return parentSettings.DerivedAutoAssign();
		}
		return OverrideState.None;
	}

	public OverrideState DerivedPause()
	{
		if (pause.value == OverrideState.None && parentSettings != null)
		{
			return parentSettings.DerivedPause();
		}
		return pause.value;
	}

	public OverrideState InheritedPause()
	{
		if (parentSettings != null)
		{
			return parentSettings.DerivedPause();
		}
		return OverrideState.None;
	}

	public StatePriority DerivedPriority()
	{
		if (priority.value == StatePriority.None && parentSettings != null)
		{
			return parentSettings.DerivedPriority();
		}
		return priority.value;
	}

	public StatePriority InheritedPriority()
	{
		if (parentSettings != null)
		{
			return parentSettings.DerivedPriority();
		}
		return StatePriority.None;
	}

	public TradeMode DerivedTradeMode()
	{
		if (tradingConfig.value == TradeMode.None && parentSettings != null)
		{
			return parentSettings.DerivedTradeMode();
		}
		return tradingConfig.value;
	}

	public TradeMode InheritedTradeMode()
	{
		if (parentSettings != null)
		{
			return parentSettings.DerivedTradeMode();
		}
		return TradeMode.None;
	}

	public ProductionConfig DerivedProductionConfig()
	{
		if (productionLimit.type == ProductionLimitType.DefaultNone && parentSettings != null)
		{
			return parentSettings.DerivedProductionConfig();
		}
		return productionLimit;
	}

	public ProductionConfig InheritedProductionConfig()
	{
		return parentSettings?.DerivedProductionConfig();
	}
}
