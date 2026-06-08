using System.Collections.Generic;

public class Expression
{
	public ICollection<string> identifiers;

	public List<(string, string)> tableColumnAccessors;

	public Select select;

	public ICollection<Select> subQueries;

	public string aggregateFunction;

	public List<string> aggregatedIdentifiers;

	public List<(string, string)> aggregatedTableColumnAccessors;

	public string stringifiedExpression;

	public bool hasStar;

	public bool hasEquals;

	public bool hasEqualsContinousEquals;

	public Identifiers joinedIdentifiers;

	public Expression(ref Select select)
	{
		hasStar = false;
		hasEquals = false;
		hasEqualsContinousEquals = false;
		identifiers = new List<string>();
		tableColumnAccessors = new List<(string, string)>();
		stringifiedExpression = "";
		this.select = select;
		subQueries = new List<Select>();
		joinedIdentifiers = new Identifiers();
	}

	public void AddIdentifier(string identifier)
	{
		identifiers.Add(identifier);
	}

	public void AddTableColumnAccessor(string table, string column)
	{
		tableColumnAccessors.Add((table, column));
	}

	public void AddAggregateExpression(Expression other)
	{
		foreach (string identifier in other.identifiers)
		{
			AddIdentifier(identifier);
		}
		if (aggregatedIdentifiers == null)
		{
			aggregatedIdentifiers = new List<string>(other.identifiers);
		}
		else
		{
			aggregatedIdentifiers.AddRange(other.identifiers);
		}
		if (aggregatedTableColumnAccessors == null)
		{
			aggregatedTableColumnAccessors = new List<(string, string)>(other.tableColumnAccessors);
		}
		else
		{
			aggregatedTableColumnAccessors.AddRange(other.tableColumnAccessors);
		}
		stringifiedExpression += other.stringifiedExpression;
	}
}
