using System;
using System.Collections.Generic;

public class TempBenefits : IBenefitReceiver
{
	public Dictionary<string, float> Benefits;

	[NonSerialized]
	public string TeamBacking;

	public Action OnChange;

	public TempBenefits(Dictionary<string, float> benefits, string teamBacking, Action onChange)
	{
		Benefits = benefits;
		TeamBacking = teamBacking;
		OnChange = onChange;
	}

	public Dictionary<string, float> GetBenefits()
	{
		return Benefits;
	}

	public float GetBenefitValue(string benefit, bool ignoreSelf = false)
	{
		float value;
		if (!ignoreSelf && Benefits.TryGetValue(benefit, out value))
		{
			return value;
		}
		return EmployeeBenefit.GetBenefitValue(null, (TeamBacking != null) ? GameSettings.Instance.sActorManager.Teams.GetOrDefault(TeamBacking) : null, benefit);
	}

	public void CacheBenefits()
	{
	}

	public void ApplyNewBenefits()
	{
		Action onChange = OnChange;
		if (onChange != null)
		{
			onChange();
		}
	}
}
