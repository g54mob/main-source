public class ItemFilter
{
	public ItemType itemType;

	public FilterPackageSetting filterPackageSetting;

	public FilterLogicSetting filterLogicSetting;

	public const int filterFlag_onlyAllowPacked = 1;

	public const int filterFlag_onlyAllowUnpacked = 2;

	public const int filterFlag_required = 4;

	public const int filterFlag_exclude = 8;

	public const int filterFlag_max = 16;

	public ItemFilter(ItemType requiredType)
	{
		filterLogicSetting = FilterLogicSetting.Include;
		itemType = requiredType;
	}

	public override string ToString()
	{
		int dataFlags = GetDataFlags();
		if (dataFlags == 0)
		{
			return itemType.ToString();
		}
		return $"{itemType} flags:{dataFlags}";
	}

	public ItemFilter GetCopy()
	{
		ItemFilter itemFilter = new ItemFilter(itemType);
		itemFilter.CopyFrom(this);
		return itemFilter;
	}

	public void CopyFrom(ItemFilter other)
	{
		itemType = other.itemType;
		filterLogicSetting = other.filterLogicSetting;
		filterPackageSetting = other.filterPackageSetting;
	}

	public int GetDataFlags()
	{
		return GetFlags(filterPackageSetting, filterLogicSetting);
	}

	public static int GetFlags(FilterPackageSetting packageSetting, FilterLogicSetting logicSetting)
	{
		int summaryValue = 0;
		switch (packageSetting)
		{
		case FilterPackageSetting.OnlyAllowPacked:
			GameUtility.SetShiftedFlag(ref summaryValue, 1, nextState: true);
			break;
		case FilterPackageSetting.OnlyAllowUnpacked:
			GameUtility.SetShiftedFlag(ref summaryValue, 2, nextState: true);
			break;
		}
		switch (logicSetting)
		{
		case FilterLogicSetting.Require:
			GameUtility.SetShiftedFlag(ref summaryValue, 4, nextState: true);
			break;
		case FilterLogicSetting.Exclude:
			GameUtility.SetShiftedFlag(ref summaryValue, 8, nextState: true);
			break;
		}
		return summaryValue;
	}

	public void LoadFlags(int flags)
	{
		if (GameUtility.IsShiftedFlagSet(flags, 1))
		{
			filterPackageSetting = FilterPackageSetting.OnlyAllowPacked;
		}
		else if (GameUtility.IsShiftedFlagSet(flags, 2))
		{
			filterPackageSetting = FilterPackageSetting.OnlyAllowUnpacked;
		}
		else
		{
			filterPackageSetting = FilterPackageSetting.None;
		}
		if (GameUtility.IsShiftedFlagSet(flags, 8))
		{
			filterLogicSetting = FilterLogicSetting.Exclude;
		}
		else if (GameUtility.IsShiftedFlagSet(flags, 4))
		{
			filterLogicSetting = FilterLogicSetting.Require;
		}
		else
		{
			filterLogicSetting = FilterLogicSetting.Include;
		}
	}
}
