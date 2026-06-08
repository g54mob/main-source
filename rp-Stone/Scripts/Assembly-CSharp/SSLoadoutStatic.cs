using System.Collections.Generic;

public class SSLoadoutStatic : StonescriptObject
{
	public SSLoadoutStatic()
		: base("loadout")
	{
		DeclareFunction(Equip);
		DeclareFunction(FindItem);
	}

	private object Equip(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0 || !(parameters[0] is int))
		{
			throw new StonescriptRuntimeException("loadout.Equip requires an integer index.");
		}
		int bindingIndex = (int)parameters[0];
		UtilityBeltKeyShortcuts.singleton.RecallLoadout(bindingIndex);
		return null;
	}

	private object FindItem(List<object> parameters, InvocationContext ctx)
	{
		if (parameters.Count == 0)
		{
			throw new StonescriptRuntimeException("loadout.FindItem requires a string parameter.");
		}
		string value = parameters[0].ToString();
		foreach (UtilityBeltKeyShortcuts.Loadout loadout in UtilityBeltKeyShortcuts.singleton.Loadouts)
		{
			if (loadout.leftHand.Contains(value) || loadout.rightHand.Contains(value))
			{
				return loadout.index;
			}
		}
		return -1;
	}
}
