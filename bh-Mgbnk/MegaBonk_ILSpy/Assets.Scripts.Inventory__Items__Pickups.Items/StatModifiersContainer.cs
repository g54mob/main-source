using System;
using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public class StatModifiersContainer
{
	private Dictionary<EStatModifyType, StatModifier> statContainers;

	public void SetModifier(StatModifier statModifier)
	{
		((Dictionary<System.Int32Enum, object>)(object)statContainers).set_Item((System.Int32Enum)statModifier.modifyType, (object)statModifier);
	}

	public IEnumerable<StatModifier> GetModifiers()
	{
		if (statContainers != null)
		{
			return statContainers.Values;
		}
		return (IEnumerable<StatModifier>)new NullReferenceException();
	}

	public StatModifiersContainer()
	{
		Dictionary<EStatModifyType, StatModifier> dictionary = new Dictionary<EStatModifyType, StatModifier>();
		statContainers = dictionary;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
