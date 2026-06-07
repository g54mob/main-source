using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/TechTree/Research Unlockable Group")]
public class ResearchUnlockableGroup : ResearchUnlockable
{
	[SerializeField]
	private LocalizedString _name = null;

	[SerializeField]
	private LocalizedString _description = null;

	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private ResearchUnlockable[] _unlockables;

	public override Types Type => Types.UnlockableGroup;

	public ResearchUnlockable[] Unlockables => _unlockables;

	public override string GetName()
	{
		return _name;
	}

	public override string GetDescription()
	{
		using ListPool<ILocalizationParamsManager>.List list = ListPool<ILocalizationParamsManager>.Get();
		ResearchUnlockable[] unlockables = _unlockables;
		for (int i = 0; i < unlockables.Length; i++)
		{
			if (unlockables[i] is ILocalizationParamsManager item)
			{
				LocalizationManager.ParamManagers.Add(item);
				list.Add(item);
			}
		}
		string result = _description;
		LocalizationManager.ParamManagers.RemoveRange(list);
		return result;
	}

	public override Sprite GetIcon()
	{
		return _icon;
	}

	public override string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		Debug.LogError("TODO: Implement UnlockableGroup.GetTooltip");
		return string.Empty;
	}

	public override void Unlock()
	{
		ResearchUnlockable[] unlockables = _unlockables;
		for (int i = 0; i < unlockables.Length; i++)
		{
			unlockables[i].Unlock();
		}
	}

	public override bool IsUnlocked()
	{
		return _unlockables.Find((ResearchUnlockable unlockable) => !unlockable.IsUnlocked()) == null;
	}

	public override bool Contains(Unlockable unlockable)
	{
		ResearchUnlockable[] unlockables = _unlockables;
		for (int i = 0; i < unlockables.Length; i++)
		{
			if (unlockables[i] == unlockable)
			{
				return true;
			}
		}
		return false;
	}
}
