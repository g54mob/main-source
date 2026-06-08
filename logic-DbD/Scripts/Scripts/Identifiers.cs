using System.Collections.Generic;

public class Identifiers
{
	public List<string> identifiers;

	public List<(string, string)> tableColumnAccessors;

	public bool hasValue;

	public Identifiers()
	{
		identifiers = new List<string>();
		tableColumnAccessors = new List<(string, string)>();
		hasValue = false;
	}

	public void AddIdentifiers(Identifiers other)
	{
		identifiers.AddRange(other.identifiers);
		tableColumnAccessors.AddRange(other.tableColumnAccessors);
	}

	public void AddTableColumnAccessor(string table, string column)
	{
		tableColumnAccessors.Add((table, column));
	}

	public void AddIdentifier(string identifier)
	{
		identifiers.Add(identifier);
	}

	public void SetHasValue()
	{
		hasValue = true;
	}
}
