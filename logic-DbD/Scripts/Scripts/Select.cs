using System;
using System.Collections.Generic;

public class Select
{
	public enum CoreKeywords
	{
		SELECT = 0,
		FROM = 1,
		WHERE = 2,
		GROUP_BY = 3,
		HAVING = 4,
		ORDER_BY = 5
	}

	public Dictionary<string, Expression> selectAliases;

	public Dictionary<Expression, string> selectExpressionAliases;

	public Dictionary<string, string> tableAliases;

	public Dictionary<string, Select> subQueryAliases;

	public ICollection<string> identifiers;

	public List<string> fromTables;

	public List<Select> fromSubQueries;

	public List<(string, string)> tableColumnAccessors;

	public Expression whereExpression;

	public Expression havingExpression;

	public List<Expression> selectExpressions;

	public List<Expression> groupExpressions;

	public List<Expression> orderExpressions;

	public HashSet<CoreKeywords> keywordsSeen;

	public HashSet<string> selectColumnNames;

	public Dictionary<string, Expression> parentSelectAliases;

	public string stringifiedSelect;

	public int selectCount;

	public List<Identifiers> joinedIdentifiers;

	public List<string> joinedUsingColumns;

	public bool finishedJoining;

	public Select()
	{
		stringifiedSelect = "";
		selectAliases = new Dictionary<string, Expression>(StringComparer.OrdinalIgnoreCase);
		selectExpressionAliases = new Dictionary<Expression, string>();
		identifiers = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
		tableAliases = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		fromTables = new List<string>();
		tableColumnAccessors = new List<(string, string)>();
		keywordsSeen = new HashSet<CoreKeywords>();
		fromSubQueries = new List<Select>();
		selectColumnNames = new HashSet<string>();
		subQueryAliases = new Dictionary<string, Select>();
		parentSelectAliases = new Dictionary<string, Expression>();
		joinedIdentifiers = new List<Identifiers>();
		joinedUsingColumns = new List<string>();
	}

	public Select(Select select, bool populateSelectAliases)
		: this()
	{
		if (populateSelectAliases)
		{
			parentSelectAliases = new Dictionary<string, Expression>(select.selectAliases, StringComparer.OrdinalIgnoreCase);
			selectAliases = new Dictionary<string, Expression>(select.selectAliases, StringComparer.OrdinalIgnoreCase);
		}
		tableAliases = new Dictionary<string, string>(select.tableAliases, StringComparer.OrdinalIgnoreCase);
		fromTables = new List<string>(select.fromTables);
	}

	public void AddTableReferences(Select select)
	{
		foreach (string key in select.tableAliases.Keys)
		{
			tableAliases.Add(key, select.tableAliases[key]);
		}
		fromTables.AddRange(select.fromTables);
	}

	public void RemoveTableReferences(Select select)
	{
		foreach (string key in select.tableAliases.Keys)
		{
			tableAliases.Remove(key);
		}
		foreach (string fromTable in select.fromTables)
		{
			fromTables.Remove(fromTable);
		}
	}
}
