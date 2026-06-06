using System.Collections.Generic;

public class Quirks : SceneBehaviour
{
	private Agent _agent;

	private List<VitalQuirkBase> _vitalQuirks;

	public void Initialize(Agent agent)
	{
		_agent = agent;
	}

	public int OnInitializeVital(VitalType vital, int amount)
	{
		if (_vitalQuirks.IsNullOrEmpty())
		{
			return amount;
		}
		foreach (VitalQuirkBase vitalQuirk in _vitalQuirks)
		{
			amount = vitalQuirk.OnInitializeVital(vital, amount);
		}
		return amount;
	}

	public int OnIncreaseVital(VitalType vital, int amount = 1)
	{
		if (_vitalQuirks.IsNullOrEmpty())
		{
			return amount;
		}
		foreach (VitalQuirkBase vitalQuirk in _vitalQuirks)
		{
			amount = vitalQuirk.OnIncreaseVital(vital, amount);
		}
		return amount;
	}

	public void AddVitalQuirk(VitalQuirkBase quirk)
	{
		if (_vitalQuirks == null)
		{
			_vitalQuirks = new List<VitalQuirkBase>();
		}
		_vitalQuirks.Add(quirk);
	}

	public void RemoveVitalQuirk(VitalQuirkBase quirk)
	{
		_vitalQuirks?.Remove(quirk);
	}

	public bool HasQuirk<T>() where T : QuirkBase
	{
		return HasQuirk<VitalQuirkBase, T>(_vitalQuirks);
	}

	private bool HasQuirk<LT, QT>(List<LT> quirks) where LT : QuirkBase where QT : QuirkBase
	{
		if (quirks.IsNullOrEmpty())
		{
			return false;
		}
		foreach (LT quirk in quirks)
		{
			if (quirk is QT)
			{
				return true;
			}
		}
		return false;
	}
}
