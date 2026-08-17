using System;

namespace VampireSurvivors.Tools.CheatCommand;

public class CheatAttribute : Attribute
{
	private readonly string _003CAlias_003Ek__BackingField;

	public string Alias => _003CAlias_003Ek__BackingField;

	public CheatAttribute(string alias = null)
	{
		_003CAlias_003Ek__BackingField = alias;
	}
}
