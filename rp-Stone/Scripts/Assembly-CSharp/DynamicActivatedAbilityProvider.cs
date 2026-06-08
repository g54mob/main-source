using System;
using System.Collections.Generic;
using UnityEngine;

public class DynamicActivatedAbilityProvider : MonoBehaviour
{
	[NonSerialized]
	public List<IAbilityActivationProvider> activatedAbilities = new List<IAbilityActivationProvider>();

	public void Clear()
	{
		activatedAbilities.Clear();
	}

	public void Add(IAbilityActivationProvider ability)
	{
		for (int i = 0; i < activatedAbilities.Count; i++)
		{
			if (activatedAbilities[i] == null)
			{
				activatedAbilities[i] = ability;
				return;
			}
		}
		activatedAbilities.Add(ability);
	}

	public bool Remove(IAbilityActivationProvider ability)
	{
		for (int i = 0; i < activatedAbilities.Count; i++)
		{
			if (activatedAbilities[i] == ability)
			{
				activatedAbilities[i] = null;
				return true;
			}
		}
		return false;
	}
}
