using System.Collections.Generic;

public abstract class ScriptablePrimitiveEnum : ScriptableBaseEnum
{
	public abstract List<IScriptableDataEnumEntry> Data { get; }

	public abstract string Type { get; }

	public virtual object Parse(object value)
	{
		return value;
	}
}
