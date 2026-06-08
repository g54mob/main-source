using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Parser
{
	public class ParserException : Exception
	{
		public ParserException(string message)
			: base(message)
		{
		}
	}

	public class UnsupportedException : Exception
	{
		public UnsupportedException(string message)
			: base(message)
		{
		}
	}

	public class WarningException : Exception
	{
		public WarningException(string message)
			: base(message)
		{
		}
	}

	private Tokenizer tokenizer;

	private Token current;

	private Token previous;

	private IParserDBAccessor dbAccessor;

	private Dictionary<string, HashSet<string>> tableColumnNamesCache;

	private List<Select> subQuerySelects;

	public Parser(string query, IDbConnection connection)
		: this(query, new ParserDBAccessor(connection))
	{
	}

	public Parser(string query, IParserDBAccessor dbAccessor)
	{
		tokenizer = new Tokenizer(query);
		this.dbAccessor = dbAccessor;
		subQuerySelects = new List<Select>();
	}

	public void ParseQuery()
	{
		Select obj = new Select();
		ParseSelect(obj);
		CheckRemaining(obj);
	}

	private void ParseSelect(Select select)
	{
		GetNextToken(select);
		ParseSelectCore(select);
		AssertValidSelectSubQueryReferences(select);
		AssertValidReferences(select, select, isSubQuery: false);
		Debug.Log("Finished parsing");
	}

	private void ParseSelectCore(Select select)
	{
		LogFunction("ParseSelectCore");
		if (current == null || !current.Equals("SELECT"))
		{
			throw new ParserException("All queries must start with SELECT");
		}
		select.keywordsSeen.Add(Select.CoreKeywords.SELECT);
		GetNextToken("You must specify something to SELECT.", select);
		if (current.Equals("DISTINCT"))
		{
			GetNextToken("You must specify something to SELECT.", select);
		}
		LogFunction("ParseColumns");
		ParseColumns(select);
		EnforceCoreKeyword("SELECT");
		LogFunction("ParseFrom");
		ParseFrom(select);
		EnforceCoreKeyword("FROM");
		LogFunction("ParseWhere");
		ParseWhere(select);
		EnforceCoreKeyword("WHERE");
		select.finishedJoining = true;
		LogFunction("ParseGroupBy");
		ParseGroupBy(select);
		EnforceCoreKeyword("GROUP BY");
		LogFunction("ParseHaving");
		ParseHaving(select);
		EnforceCoreKeyword("HAVING");
		LogFunction("ParseCompoundOperator");
		ParseCompoundOperator(select);
		LogFunction("ParseOrderBy");
		ParseOrderBy(select);
		EnforceCoreKeyword("ORDER BY");
		Debug.Log("SELECT STRING= " + select.stringifiedSelect);
	}

	private void ParseCompoundOperator(Select baseSelect)
	{
		if (current != null && IsCompoundOperator(current))
		{
			string text = current.GetString();
			Debug.Log("Seen keywords: " + string.Join(",", baseSelect.keywordsSeen));
			if (baseSelect.keywordsSeen.Contains(Select.CoreKeywords.ORDER_BY))
			{
				throw new ParserException("ORDER BY statements cannot appear in the SELECT statement <b>before</b> the " + text + " operator.");
			}
			GetNextToken(ErrorMessage(text), baseSelect);
			if (text.Equals("UNION") && current.Equals("ALL"))
			{
				GetNextToken(ErrorMessage("UNION ALL"), baseSelect);
			}
			if (!current.Equals("SELECT"))
			{
				throw new ParserException(ErrorMessage(text));
			}
			Select obj = new Select();
			ParseSelectCore(obj);
			AssertValidReferences(obj, baseSelect, isSubQuery: false);
			baseSelect.stringifiedSelect += obj.stringifiedSelect;
			int num = baseSelect.selectCount;
			var (flag, text2) = IsSelectStar(baseSelect);
			if (flag)
			{
				num--;
				num += ((text2 != null) ? GetTableColumnNames(text2).Count : GetAllTableColumns(baseSelect));
			}
			int num2 = obj.selectCount;
			var (flag2, text3) = IsSelectStar(obj);
			if (flag2)
			{
				num2--;
				num2 += ((text3 != null) ? GetTableColumnNames(text3).Count : GetAllTableColumns(obj));
			}
			if (num != num2)
			{
				throw new ParserException("The SELECT queries between the " + text + " operator must have the same number of columns selected.");
			}
			EnforceCoreKeyword(text);
		}
		static string ErrorMessage(string compoundOperator)
		{
			return "There must be a SELECT statement after the " + compoundOperator + " keyword.";
		}
		static bool IsCompoundOperator(Token token)
		{
			if (!token.Equals("UNION") && !token.Equals("INTERSECT"))
			{
				return token.Equals("EXCEPT");
			}
			return true;
		}
	}

	private int GetAllTableColumns(Select select)
	{
		int num = 0;
		foreach (string fromTable in select.fromTables)
		{
			num += GetTableColumnNames(fromTable).Count;
		}
		return num;
	}

	private void ParseColumns(Select select)
	{
		List<Expression> list = new List<Expression>();
		Expression resultColumn = GetResultColumn(select);
		list.Add(resultColumn);
		while (current != null && current.Equals(","))
		{
			GetNextToken("The list of columns in the query cannot end with a comma.", select);
			resultColumn = GetResultColumn(select);
			list.Add(resultColumn);
		}
		select.selectExpressions = list;
	}

	private Expression GetResultColumn(Select select)
	{
		select.selectCount++;
		if (current.Equals(","))
		{
			throw new ParserException(GetCommaErrorMessage("SELECT"));
		}
		if (current.Equals("*"))
		{
			GetNextToken(select);
			if (current == null)
			{
				throw new ParserException("When using the special character '*' to select everything from a table, you must specify the table names using the FROM keyword.");
			}
			if (current.Equals("AS"))
			{
				throw new ParserException("The special character: \"*\" cannot be given an alias.");
			}
			switch (current.GetTokenType())
			{
			case Token.TYPE.KEYWORD:
				if (!current.Equals("FROM"))
				{
					throw new ParserException("When using the special character '*' to select everything from a table, you must specify the table names using the FROM keyword directly after the SELECT statement.");
				}
				break;
			case Token.TYPE.SPECIAL:
				if (current.Equals(","))
				{
					break;
				}
				goto default;
			default:
				throw new ParserException($"<b>{current}</b> cannot be placed right next to the special character '*'. " + $"If you would like to add <b>{current}</b> as a seperate column, add a comma after '*'.");
			}
			return null;
		}
		Expression expression = new Expression(ref select);
		ParseExpression(expression, isSelectExpression: true);
		subQuerySelects.AddRange(expression.subQueries);
		select.stringifiedSelect += expression.stringifiedExpression;
		if (current == null)
		{
			return expression;
		}
		if (current.Equals("AS"))
		{
			GetNextToken("An alias must be given after the AS keyword.", select);
		}
		switch (current.GetTokenType())
		{
		case Token.TYPE.NAME:
		case Token.TYPE.QUOTED_IDENTIFIER:
		case Token.TYPE.NON_QUOTED_IDENTIFER:
		{
			string text = current.GetString();
			if (select.selectAliases.ContainsKey(text))
			{
				throw new ParserException("Column alias " + text + " already exists. There cannot be two conflicting alias names.");
			}
			select.selectAliases.Add(text, expression);
			select.selectExpressionAliases.Add(expression, text);
			GetNextToken(select);
			break;
		}
		case Token.TYPE.KEYWORD:
			if (!previous.Equals("AS"))
			{
				break;
			}
			goto default;
		case Token.TYPE.SPECIAL:
			if (!previous.Equals("AS") && (current.Equals(",") || current.Equals(")")))
			{
				break;
			}
			goto default;
		default:
			throw new ParserException($"'{current}' cannot be placed right next to a column name. " + "Column aliases cannot start with numbers or special characters.");
		}
		return expression;
	}

	private void ParseFrom(Select select)
	{
		if (current == null || !current.Equals("FROM"))
		{
			if (select.identifiers.Count > 0 && ContainsColumn(select.identifiers))
			{
				throw new ParserException("All queries that are selecting columns must have the FROM statement directly after the SELECT statement containing the tables to select from.");
			}
			return;
		}
		select.keywordsSeen.Add(Select.CoreKeywords.FROM);
		GetNextToken("The FROM statement cannot be empty.", select);
		if (current.Equals(","))
		{
			throw new ParserException(GetCommaErrorMessage("FROM"));
		}
		string currentKeyword = "FROM";
		GetTables(select, ref currentKeyword);
		static bool ContainsColumn(ICollection<string> identifiers)
		{
			foreach (string identifier in identifiers)
			{
				if (!IsString(identifier))
				{
					return true;
				}
			}
			return false;
		}
		static bool IsString(string text)
		{
			string text2 = text.Trim();
			if (text2.StartsWith("\""))
			{
				return text2.EndsWith("\"");
			}
			return false;
		}
	}

	private void ParseWhere(Select select)
	{
		if (current != null && current.Equals("WHERE"))
		{
			select.keywordsSeen.Add(Select.CoreKeywords.WHERE);
			GetNextToken("The WHERE statement cannot be empty.", select);
			if (current.Equals("*"))
			{
				throw new ParserException(GetStarErrorMessage("WHERE"));
			}
			if (current.Equals(","))
			{
				throw new ParserException("There should not be a comma in the beginning of the WHERE statement");
			}
			Expression expression = new Expression(ref select);
			ParseExpression(expression);
			if (current != null && current.Equals(","))
			{
				throw new ParserException("The WHERE statement should not contain commas. If you want to combine multiple conditions, use the AND or OR operators instead.");
			}
			select.stringifiedSelect += expression.stringifiedExpression;
			select.whereExpression = expression;
			if (expression.aggregateFunction != null)
			{
				throw new ParserException("Aggregate functions such as " + expression.aggregateFunction + " cannot appear in the WHERE statement. Aggregate functions should only appear in the SELECT and HAVING statements.");
			}
		}
	}

	private void ParseGroupBy(Select select)
	{
		if (current == null || !current.Equals("GROUP"))
		{
			return;
		}
		GetNextToken("The GROUP keyword must be followed by the BY keyword", select);
		GetNextToken("The GROUP BY statement cannot be empty.", select);
		if (current.Equals("*"))
		{
			throw new ParserException(GetStarErrorMessage("GROUP BY"));
		}
		if (current.Equals(","))
		{
			throw new ParserException(GetCommaErrorMessage("GROUP BY"));
		}
		select.keywordsSeen.Add(Select.CoreKeywords.GROUP_BY);
		List<Expression> list = new List<Expression> { ParseGroupByExpression() };
		while (current != null && current.Equals(","))
		{
			GetNextToken("The list of values in the GROUP BY cannot end with a comma.", select);
			if (current.Equals(","))
			{
				throw new ParserException("A comma cannot directly follow another comma in the GROUP BY statement.");
			}
			list.Add(ParseGroupByExpression());
		}
		foreach (Expression item in list)
		{
			if (item.hasStar)
			{
				throw new ParserException(GetStarErrorMessage("GROUP BY"));
			}
		}
		select.groupExpressions = list;
		Debug.Log("ADDING GROUP BY");
		Expression ParseGroupByExpression()
		{
			Expression expression = new Expression(ref select);
			ParseExpression(expression);
			select.stringifiedSelect += expression.stringifiedExpression;
			if (expression.aggregateFunction != null)
			{
				throw new ParserException("Aggregate functions such as " + expression.aggregateFunction + " are not allowed in the GROUP BY.");
			}
			return expression;
		}
	}

	private void ParseHaving(Select select)
	{
		if (current != null && current.Equals("HAVING"))
		{
			if (!select.keywordsSeen.Contains(Select.CoreKeywords.GROUP_BY))
			{
				throw new ParserException("HAVING statements require a GROUP BY statement beforehand.");
			}
			select.keywordsSeen.Add(Select.CoreKeywords.HAVING);
			GetNextToken("The HAVING statement cannot be empty.", select);
			if (current.Equals("*"))
			{
				throw new ParserException(GetStarErrorMessage("HAVING"));
			}
			if (current.Equals(","))
			{
				throw new ParserException("There should not be a comma in the beginning of the HAVING statement");
			}
			Expression expression = new Expression(ref select);
			ParseExpression(expression);
			if (current != null && current.Equals(","))
			{
				throw new ParserException("The HAVING statement should not contain commas. If you want to combine multiple conditions, use the AND or OR operators instead.");
			}
			if (expression.hasStar)
			{
				throw new ParserException(GetStarErrorMessage("HAVING"));
			}
			select.stringifiedSelect += expression.stringifiedExpression;
			select.havingExpression = expression;
		}
	}

	private void ParseOrderBy(Select select)
	{
		if (current == null || !current.Equals("ORDER"))
		{
			return;
		}
		GetNextToken("The ORDER keyword must be followed by the BY keyword", select);
		GetNextToken("The ORDER BY statement cannot be empty.", select);
		if (current.Equals("*"))
		{
			throw new ParserException(GetStarErrorMessage("ORDER BY"));
		}
		if (current.Equals(","))
		{
			throw new ParserException(GetCommaErrorMessage("ORDER BY"));
		}
		select.keywordsSeen.Add(Select.CoreKeywords.ORDER_BY);
		List<Expression> list = new List<Expression>();
		Expression expression = ParseOrderingTerm(select);
		if (expression.hasStar)
		{
			throw new ParserException(GetStarErrorMessage("ORDER BY"));
		}
		list.Add(expression);
		while (current != null && current.Equals(","))
		{
			GetNextToken("The list of values in the ORDER BY cannot end with a comma.", select);
			if (current.Equals(","))
			{
				throw new ParserException("There must be a value specified before each comma in the ORDER BY statement.");
			}
			expression = ParseOrderingTerm(select);
			list.Add(expression);
		}
		select.orderExpressions = list;
		ParseCompoundOperator(select);
		Expression ParseOrderingTerm(Select select2)
		{
			Expression expression2 = new Expression(ref select2);
			ParseExpression(expression2);
			select2.stringifiedSelect += expression2.stringifiedExpression;
			if (current != null && (current.Equals("ASC") || current.Equals("DESC")))
			{
				GetNextToken(select2);
			}
			return expression2;
		}
	}

	private bool IsJoinOperator(Select select, ref string currentKeyword)
	{
		if (current == null)
		{
			return false;
		}
		if (current.Equals(","))
		{
			GetNextToken("The list of tables in the " + currentKeyword + " statement cannot end with a comma.", select);
			if (current.Equals(","))
			{
				throw new ParserException("A comma cannot directly follow another comma in the " + currentKeyword + " statement.");
			}
			return true;
		}
		bool flag = false;
		if (current.Equals("NATURAL") || current.Equals("CROSS"))
		{
			flag = true;
			GetNextToken(ErrorMessage(current.GetString()), select);
		}
		if (!previous.Equals("CROSS"))
		{
			if (current.Equals("FULL") || current.Equals("OUTER"))
			{
				throw new ParserException("FULL OUTER JOINS are not supported in CopOS.");
			}
			if (current.Equals("LEFT") || current.Equals("RIGHT"))
			{
				flag = true;
				GetNextToken(ErrorMessage(current.GetString()), select);
				if (current.Equals("OUTER"))
				{
					GetNextToken(ErrorMessage("LEFT OUTER"), select);
				}
			}
			else if (current.Equals("INNER"))
			{
				flag = true;
				GetNextToken(ErrorMessage(current.GetString()), select);
			}
		}
		if (current.Equals("JOIN"))
		{
			currentKeyword = "JOIN";
			GetNextToken("A table must be specified after the JOIN keyword.", select);
			if (current.Equals(","))
			{
				throw new ParserException(GetCommaErrorMessage("JOIN"));
			}
			if (current.Equals("ON"))
			{
				throw new ParserException("A table name must be provided in the JOIN statement before the ON keyword.");
			}
			return true;
		}
		if (flag)
		{
			throw new ParserException($"The keyword JOIN must be written after {previous}!");
		}
		return false;
		static string ErrorMessage(string keyword)
		{
			return "Join conditions cannot end with " + keyword + ".";
		}
	}

	private HashSet<string> GetJoinConstraint(Select select, HashSet<string> leftTableColumns, HashSet<string> rightTableColumns)
	{
		LogFunction("GetJoinConstraint");
		if (current == null || (!current.Equals("ON") && !current.Equals("USING")))
		{
			return GetAllColumnNames();
		}
		if (current.Equals("ON"))
		{
			GetNextToken("A JOIN condition must be provided after the ON keyword.", select);
			if (current.Equals(","))
			{
				throw new ParserException("There should not be a comma in the beginning of the JOIN ON statement");
			}
			Expression expression = new Expression(ref select);
			ParseExpression(expression);
			select.stringifiedSelect += expression.stringifiedExpression;
			return GetAllColumnNames();
		}
		if (leftTableColumns == null || rightTableColumns == null)
		{
			throw new ParserException("At least one of the tables joined through the USING condition cannot be found.");
		}
		GetNextToken("Column names must be specified after USING", select);
		if (!current.Equals("("))
		{
			throw new ParserException("Column names must be enclosed by parentheses in USING.");
		}
		GetNextToken("There is an unclosed parentheses within the USING statement.", select);
		if (current.Equals(")"))
		{
			throw new ParserException("The USING clause cannot be empty.");
		}
		List<string> list = ParseColumnList();
		if (!current.Equals(")"))
		{
			throw new ParserException($"An unexpected value of \"{current}\" was found inside the USING statement.");
		}
		GetNextToken(select);
		HashSet<string> source = new HashSet<string>(leftTableColumns);
		HashSet<string> source2 = new HashSet<string>(rightTableColumns);
		HashSet<string> destination = new HashSet<string>();
		foreach (string item2 in list)
		{
			if (!leftTableColumns.Contains(item2, StringComparer.OrdinalIgnoreCase) || !rightTableColumns.Contains(item2, StringComparer.OrdinalIgnoreCase))
			{
				throw new ParserException("Tables in the FROM statement cannot be joined with USING as they do not share the column: " + item2);
			}
			destination.Add(item2);
			source.Remove(item2);
			source2.Remove(item2);
		}
		select.joinedUsingColumns.AddRange(list);
		AddAll(ref destination, ref source);
		AddAll(ref destination, ref source2);
		return destination;
		void AddAll(ref HashSet<string> columnNames, ref HashSet<string> reference)
		{
			foreach (string item3 in reference)
			{
				AddColumnSelectName(ref columnNames, item3);
			}
		}
		HashSet<string> GetAllColumnNames()
		{
			HashSet<string> destination2 = new HashSet<string>();
			if (leftTableColumns != null)
			{
				AddAll(ref destination2, ref leftTableColumns);
			}
			if (rightTableColumns != null)
			{
				AddAll(ref destination2, ref rightTableColumns);
			}
			return destination2;
		}
		List<string> ParseColumnList()
		{
			List<string> list2 = new List<string>();
			do
			{
				Token.TYPE tokenType = current.GetTokenType();
				if (tokenType != Token.TYPE.NAME && (uint)(tokenType - 3) > 2u)
				{
					throw new ParserException("The USING clause can only contain column names.");
				}
				string item = current.GetString();
				list2.Add(item);
				GetNextToken("There is an unclosed parentheses within the USING statement.", select);
				if (!current.Equals(","))
				{
					return list2;
				}
				GetNextToken("There is a trailing comma in the USING statement.", select);
			}
			while (current != null);
			return list2;
		}
	}

	private HashSet<string> GetTables(Select select, ref string currentKeyword)
	{
		LogFunction("GetTables");
		HashSet<string> hashSet = GetFromResult(select, ref currentKeyword);
		while (current != null && IsJoinOperator(select, ref currentKeyword))
		{
			HashSet<string> fromResult = GetFromResult(select, ref currentKeyword);
			hashSet = GetJoinConstraint(select, hashSet, fromResult);
		}
		select.selectColumnNames = hashSet;
		Debug.Log("select.selectColumnNames -> " + string.Join(',', select.selectColumnNames));
		return hashSet;
	}

	private HashSet<string> GetFromResult(Select select, ref string currentKeyword)
	{
		LogFunction("GetFromResult");
		if (current == null)
		{
			return null;
		}
		if (current.Equals("("))
		{
			string text = "All expressions that start with an opening parenthesis must be closed with a closing parenthesis.";
			GetNextToken(text, select);
			if (current.Equals(")"))
			{
				throw new ParserException("Empty parentheses are not allowed.");
			}
			HashSet<string> result;
			if (current.Equals("SELECT"))
			{
				Select obj = new Select();
				ParseSelectCore(obj);
				AssertValidReferences(obj, select, isSubQuery: true);
				select.stringifiedSelect += obj.stringifiedSelect;
				select.fromSubQueries.Add(obj);
				result = (obj.selectColumnNames = GetSelectedColumnNames(obj));
				if (current == null || !current.Equals(")"))
				{
					throw new ParserException(text);
				}
				GetNextToken(select);
				string alias = GetAlias(select, ref select.tableAliases, ref select.subQueryAliases);
				if (alias != null)
				{
					select.subQueryAliases.Add(alias, obj);
				}
			}
			else
			{
				result = GetTables(select, ref currentKeyword);
				if (current == null || !current.Equals(")"))
				{
					throw new ParserException(text);
				}
				GetNextToken(select);
			}
			return result;
		}
		string table = GetTable(select);
		return GetTableColumnNames(table);
	}

	private string GetTable(Select select)
	{
		LogFunction("GetTable");
		string text;
		switch (current.GetTokenType())
		{
		case Token.TYPE.NAME:
			text = current.GetString();
			select.fromTables.Add(text);
			GetNextToken(select);
			break;
		case Token.TYPE.STRING:
		case Token.TYPE.QUOTED_IDENTIFIER:
		case Token.TYPE.NON_QUOTED_IDENTIFER:
			text = current.GetString();
			text = current.GetString().Substring(1, text.Length - 2);
			select.fromTables.Add(text);
			GetNextToken(select);
			break;
		default:
			throw new ParserException(current.GetString() + " cannot be selected. Table names cannot start with numbers or special characters.");
		}
		if (current == null)
		{
			return text;
		}
		string alias = GetAlias(select, ref select.tableAliases, ref select.subQueryAliases);
		if (alias != null)
		{
			select.tableAliases.Add(alias, text);
		}
		return text;
	}

	private string GetAlias(Select select, ref Dictionary<string, string> tableAliases, ref Dictionary<string, Select> subQueryAliases)
	{
		if (current == null)
		{
			return null;
		}
		if (current.Equals("AS"))
		{
			GetNextToken("An alias must be given after the AS keyword.", select);
		}
		switch (current.GetTokenType())
		{
		case Token.TYPE.NAME:
		case Token.TYPE.STRING:
		case Token.TYPE.QUOTED_IDENTIFIER:
		case Token.TYPE.NON_QUOTED_IDENTIFER:
		{
			string text = current.GetString();
			if (tableAliases.ContainsKey(text) || subQueryAliases.ContainsKey(text))
			{
				throw new ParserException("Table alias " + text + " already exists. There cannot be two conflicting alias names.");
			}
			GetNextToken(select);
			return text;
		}
		case Token.TYPE.KEYWORD:
			if (!previous.Equals("AS"))
			{
				break;
			}
			goto default;
		case Token.TYPE.SPECIAL:
			if (!previous.Equals("AS") && (current.Equals(",") || current.Equals(")")))
			{
				break;
			}
			goto default;
		default:
			throw new ParserException($"'{current}' cannot be placed right next to a table name. " + "Table aliases cannot start with numbers or special characters.");
		}
		return null;
	}

	private void ParseExpression(Expression exp, bool isSelectExpression = false)
	{
		LogFunction("ParseExpression");
		if (current == null)
		{
			return;
		}
		if (IsUnaryOperator(current))
		{
			GetNextToken(exp);
			ParseExpression(exp, isSelectExpression);
			return;
		}
		if (IsBinaryOperator(current))
		{
			if (IsBinaryOperator(previous))
			{
				throw new ParserException($"The binary operators: <b>{previous}</b> and <b>{current}</b> cannot be used next to each other.");
			}
			throw new ParserException($"Cannot use the binary operator: <b>{current}</b> on <b>{previous}</b>");
		}
		if (current.Equals("CASE"))
		{
			throw new UnsupportedException("The CASE keyword is not supported.");
		}
		if (current.Equals("NOT") || current.Equals("EXISTS"))
		{
			string text = "The NOT keyword must be followed by the EXISTS keyword";
			bool num = current.Equals("NOT");
			if (num)
			{
				GetNextToken(text, exp);
			}
			if (!current.Equals("EXISTS"))
			{
				throw new ParserException(text);
			}
			string text2 = (num ? "NOT " : "") + "EXISTS";
			GetNextToken("The " + text2 + " condition must be followed by a SELECT subquery.", exp);
			ParseSubQuery(text2);
			GetNextToken(exp);
		}
		else
		{
			if (current.Equals("CAST"))
			{
				throw new UnsupportedException("The CAST keyword is not supported.");
			}
			if (current.Equals("("))
			{
				string text3 = "All expressions that start with an opening parenthesis must be closed with a closing parenthesis.";
				GetNextToken(text3, exp);
				if (current.Equals(")"))
				{
					throw new ParserException("Empty parentheses are not allowed.");
				}
				if (current.Equals("SELECT"))
				{
					Select obj = new Select(exp.select, !isSelectExpression);
					ParseSelectCore(obj);
					if (!isSelectExpression)
					{
						AssertValidReferences(obj, exp.select, isSubQuery: true);
					}
					EnforceSingleSelection(obj);
					exp.subQueries.Add(obj);
					exp.stringifiedExpression += obj.stringifiedSelect;
				}
				else
				{
					ParseExpression(exp, isSelectExpression);
				}
				if (current == null)
				{
					throw new ParserException(text3);
				}
				if (!current.Equals(")"))
				{
					if (current.Equals(","))
					{
						throw new ParserException("Commas are not allowed within parenthesis in statements.");
					}
					throw new ParserException($"\"{current}\" should not be inside the parenthesis in your query.");
				}
				GetNextToken(exp);
			}
			else
			{
				if (current.Equals("RAISE"))
				{
					throw new UnsupportedException("The RAISE keyword is not supported.");
				}
				if (IsAggregateFunction(current))
				{
					Token token = current;
					GetNextToken(exp);
					if (current == null || !current.Equals("("))
					{
						throw new ParserException("Aggregate functions must be followed by parentheses.");
					}
					string text4 = token.Upper();
					exp.aggregateFunction = text4;
					string text5 = "You must provide a column name or value for the aggregate function: " + text4 + ".";
					string text6 = "The aggregate function: " + text4 + " does not have a closing parenthesis.";
					GetNextToken(text5, exp);
					if (current.Equals("DISTINCT"))
					{
						GetNextToken(text5, exp);
					}
					if (current.Equals(")"))
					{
						throw new ParserException(text5);
					}
					if (current.Equals("*"))
					{
						if (!token.Equals("COUNT"))
						{
							throw new ParserException("The special character: * cannot be given to the aggregate function: " + text4 + ".");
						}
						Expression expression = new Expression(ref exp.select);
						expression.hasStar = true;
						exp.AddAggregateExpression(expression);
						GetNextToken(text6, exp);
					}
					else
					{
						Expression expression2 = new Expression(ref exp.select);
						ParseExpression(expression2, isSelectExpression);
						if (expression2.aggregateFunction != null)
						{
							throw new ParserException("Aggregate functions cannot contain other aggregate functions inside their parentheses.");
						}
						exp.AddAggregateExpression(expression2);
					}
					if (current == null || !current.Equals(")"))
					{
						if (current != null && current.Equals(","))
						{
							throw new ParserException("Aggregate functions such as " + text4 + " cannot include commas inside their parentheses.");
						}
						throw new ParserException(text6);
					}
					GetNextToken(exp);
				}
				else if (IsSQLiteFunction(current))
				{
					Token token2 = current;
					GetNextToken(exp);
					if (current == null || !current.Equals("("))
					{
						throw new ParserException("SQL functions must be followed by parentheses.");
					}
					string text7 = token2.Upper();
					string text8 = "You must provide a column name or value for the function: " + text7 + ".";
					string message = "The function: " + text7 + " does  not have a closing parenthesis.";
					GetNextToken(text8, exp);
					if (current.Equals("DISTINCT"))
					{
						throw new ParserException("DISTINCT cannot be used in non-aggregate functions.");
					}
					if (current.Equals(")"))
					{
						throw new ParserException(text8);
					}
					if (current.Equals("*"))
					{
						throw new ParserException("The special character: * cannot be given to the function: " + text7 + ".");
					}
					ParseExpression(exp, isSelectExpression);
					if (text7.Equals("CONCAT"))
					{
						while (current != null && current.Equals(","))
						{
							GetNextToken("The " + text7 + " function cannot end with a comma.", exp);
							if (current.Equals(")"))
							{
								throw new ParserException("The " + text7 + " function cannot end with a comma.");
							}
							ParseExpression(exp, isSelectExpression);
						}
					}
					else if (text7.Equals("POW"))
					{
						if (current == null || !current.Equals(","))
						{
							throw new ParserException("The POW function must be given 2 arguments. For example, POW(2, 3) corresponds to 2^3.");
						}
						GetNextToken("The " + text7 + " function cannot end with a comma.", exp);
						if (current.Equals(")"))
						{
							throw new ParserException("The " + text7 + " function cannot end with a comma.");
						}
						ParseExpression(exp, isSelectExpression);
						if (current != null && current.Equals(","))
						{
							throw new ParserException("The POW function must be have exactly 2 arguments.");
						}
					}
					else if (current == null || !current.Equals(")"))
					{
						if (current != null && current.Equals(","))
						{
							throw new ParserException("The SQRT function can only be given one argument.");
						}
						throw new ParserException(message);
					}
					if (current == null || !current.Equals(")"))
					{
						throw new ParserException(message);
					}
					GetNextToken(exp);
				}
				else
				{
					switch (current.GetTokenType())
					{
					case Token.TYPE.NUMBER:
					case Token.TYPE.STRING:
						exp.joinedIdentifiers.SetHasValue();
						GetNextToken(exp);
						break;
					case Token.TYPE.NAME:
					case Token.TYPE.QUOTED_IDENTIFIER:
					case Token.TYPE.NON_QUOTED_IDENTIFER:
						GetNextToken(exp);
						if (current != null && current.Equals("."))
						{
							string text9 = previous.GetString();
							GetNextToken("Queries cannot end with a period (\".\") character.", exp);
							string text10 = current.GetString();
							if (text10.Trim().Equals("*"))
							{
								exp.hasStar = true;
							}
							exp.select.tableColumnAccessors.Add((text9, text10));
							exp.AddTableColumnAccessor(text9, text10);
							exp.joinedIdentifiers.AddTableColumnAccessor(text9, text10);
							GetNextToken(exp);
							if (text10.Trim().Equals("*") && current != null && current.Equals("AS"))
							{
								throw new ParserException("The special character: \"*\" cannot be given an alias.");
							}
						}
						else
						{
							string text11 = previous.GetString();
							exp.select.identifiers.Add(text11);
							exp.AddIdentifier(text11);
							exp.joinedIdentifiers.AddIdentifier(text11);
						}
						break;
					case Token.TYPE.KEYWORD:
						throw new ParserException("The keyword: " + current.Upper() + " cannot be placed directly after " + GetDescriptiveName(previous));
					}
				}
			}
		}
		if (current != null && current.Equals("NOT"))
		{
			GetNextToken("The NOT keyword must be followed by the IN or LIKE keywords.", exp);
			if (current != null && !current.Equals("IN") && !current.Equals("LIKE") && !current.Equals("NULL"))
			{
				throw new ParserException($"The value: \"{current}\" cannot come after the NOT keyword.");
			}
		}
		if (current != null && current.Equals("IN"))
		{
			string text12 = (previous.Equals("NOT") ? "NOT " : "") + "IN";
			GetNextToken("The " + text12.ToUpperInvariant() + " condition must be followed by a SELECT subquery.", exp);
			ParseSubQuery(text12, enforceSingleSelection: true);
			GetNextToken(exp);
		}
		Debug.Log("Current expression finished, checking if part of larger expression");
		if (current != null && IsBinaryOperator(current))
		{
			if (current.Equals("==") || current.ToString().Contains("=") || current.Equals(">") || current.Equals("<") || current.Equals("LIKE"))
			{
				if (exp.hasEqualsContinousEquals)
				{
					throw new ParserException("To set more than two columns equal to each other, use the AND keyword. For example, if you wanted to join on a column named <i>col</i> across three tables, you should do this instead: <i>t1.col = t2.col AND t2.col = t3.col</i>");
				}
				exp.hasEquals = true;
				exp.hasEqualsContinousEquals = true;
			}
			else if (current.Equals("OR"))
			{
				exp.joinedIdentifiers = new Identifiers();
				exp.hasEqualsContinousEquals = false;
			}
			else if (current.Equals("AND"))
			{
				if (exp.hasEquals && !exp.select.finishedJoining)
				{
					exp.select.joinedIdentifiers.Add(exp.joinedIdentifiers);
				}
				exp.joinedIdentifiers = new Identifiers();
				exp.hasEquals = false;
				exp.hasEqualsContinousEquals = false;
			}
			Debug.Log($"Current token is a binary operator: {current}");
			GetNextToken($"The operator: {current} must be followed by a value.", exp);
			if (previous.Equals("IS") && current.Equals("NOT"))
			{
				GetNextToken("The IS NOT operator must be followed by a value.", exp);
			}
			if (current.GetTokenType() == Token.TYPE.KEYWORD)
			{
				throw new ParserException($"The operator: {previous} must be followed by a value.");
			}
			ParseExpression(exp, isSelectExpression);
		}
		else if (exp.hasEquals && !exp.select.finishedJoining)
		{
			exp.select.joinedIdentifiers.Add(exp.joinedIdentifiers);
		}
		void ParseSubQuery(string keywordUsed, bool enforceSingleSelection = false)
		{
			if (!current.Equals("("))
			{
				throw new ParserException("The " + keywordUsed + " condition must be followed by a SELECT subquery with parentheses surrounding it.");
			}
			string text13 = "All expressions that start with an opening parenthesis must be closed with a closing parenthesis.";
			GetNextToken(text13, exp);
			if (current.Equals(")"))
			{
				throw new ParserException("Empty parentheses are not allowed.");
			}
			if (current.Equals("SELECT"))
			{
				Select obj2 = new Select(exp.select, !isSelectExpression);
				ParseSelectCore(obj2);
				if (!isSelectExpression)
				{
					AssertValidReferences(obj2, exp.select, isSubQuery: true);
				}
				exp.subQueries.Add(obj2);
				if (enforceSingleSelection)
				{
					EnforceSingleSelection(obj2);
				}
				exp.stringifiedExpression += obj2.stringifiedSelect;
			}
			if (current == null || !current.Equals(")"))
			{
				throw new ParserException(text13);
			}
		}
	}

	private string GetDescriptiveName(Token token, string prefix = "a ")
	{
		if (token.Equals("."))
		{
			return prefix + "period";
		}
		if (token.Equals(","))
		{
			return prefix + "comma";
		}
		if (token.GetTokenType() == Token.TYPE.KEYWORD)
		{
			return token.Upper();
		}
		return token.ToString();
	}

	private void AddColumnSelectName(ref HashSet<string> columnNames, string name)
	{
		if (!columnNames.Contains(name))
		{
			columnNames.Add(name);
			return;
		}
		int i;
		for (i = 1; columnNames.Contains($"{name}:{i}"); i++)
		{
		}
		columnNames.Add($"{name}:{i}");
	}

	private HashSet<string> GetSelectedColumnNames(Select select)
	{
		HashSet<string> columnNames = new HashSet<string>();
		foreach (Expression selectExpression in select.selectExpressions)
		{
			if (selectExpression == null)
			{
				foreach (string fromTable in select.fromTables)
				{
					foreach (string tableColumnName in GetTableColumnNames(fromTable))
					{
						AddColumnSelectName(ref columnNames, tableColumnName);
					}
				}
				foreach (Select fromSubQuery in select.fromSubQueries)
				{
					foreach (string selectedColumnName in GetSelectedColumnNames(fromSubQuery))
					{
						AddColumnSelectName(ref columnNames, selectedColumnName);
					}
				}
				continue;
			}
			string text = selectExpression.stringifiedExpression.Trim();
			var (flag, text2, text3) = GetTableAccessorColumnValues(text);
			if (flag)
			{
				string tableName2 = (select.tableAliases.ContainsKey(text2) ? select.tableAliases[text2] : text2);
				if (dbAccessor.ContainsTable(tableName2))
				{
					HashSet<string> tableColumnNames = GetTableColumnNames(tableName2);
					if (text3 == "*")
					{
						if (tableColumnNames == null)
						{
							continue;
						}
						foreach (string item in tableColumnNames)
						{
							AddColumnSelectName(ref columnNames, item);
						}
						continue;
					}
					if (tableColumnNames != null && tableColumnNames.Contains(text3))
					{
						AddColumnSelectName(ref columnNames, text3);
						continue;
					}
				}
			}
			if (select.selectExpressionAliases.ContainsKey(selectExpression))
			{
				AddColumnSelectName(ref columnNames, select.selectExpressionAliases[selectExpression]);
			}
			else
			{
				AddColumnSelectName(ref columnNames, text);
			}
		}
		return columnNames;
	}

	private void EnforceCoreKeyword(string statement)
	{
		if (current == null)
		{
			return;
		}
		switch (current.GetTokenType())
		{
		case Token.TYPE.KEYWORD:
			if (!current.Equals("SELECT") && !current.Equals("FROM") && !current.Equals("WHERE") && !current.Equals("GROUP") && !current.Equals("HAVING") && !current.Equals("ORDER") && !current.Equals("EXCEPT") && !current.Equals("UNION") && !current.Equals("INTERSECT"))
			{
				goto default;
			}
			break;
		case Token.TYPE.SPECIAL:
			if (current.Equals(")") || current.Equals(";"))
			{
				break;
			}
			goto default;
		default:
			throw new ParserException("The " + GetDescriptiveName(current, "") + " after the " + statement.ToUpperInvariant() + " statement is in an unexpected place.");
		case Token.TYPE.COMMENT:
			break;
		}
	}

	private void GetNextToken(string nullError, Select select)
	{
		GetNextToken(select);
		if (current == null)
		{
			throw new ParserException(nullError);
		}
	}

	private void GetNextToken(string nullError, Expression exp)
	{
		GetNextToken(exp);
		if (current == null)
		{
			throw new ParserException(nullError);
		}
	}

	private void EnforceKeywordOrdering(Select select)
	{
		if (current != null)
		{
			if (current.Equals("JOIN") && !select.keywordsSeen.Contains(Select.CoreKeywords.FROM))
			{
				throw new ParserException("The JOIN statement must be placed directly after the FROM statement.");
			}
			if (current.Equals("WHERE") && (select.keywordsSeen.Contains(Select.CoreKeywords.GROUP_BY) || select.keywordsSeen.Contains(Select.CoreKeywords.HAVING)))
			{
				throw new ParserException("The WHERE statement must be placed directly after the FROM statement and before the GROUP BY and HAVING statements.");
			}
			if ((current.Equals("JOIN") || current.Equals("FROM")) && select.keywordsSeen.Contains(Select.CoreKeywords.WHERE))
			{
				throw new ParserException("The WHERE statement cannot be placed before the FROM and JOIN statements.");
			}
		}
	}

	private bool GetNextToken(Select select)
	{
		bool nextToken = GetNextToken(delegate(Token token)
		{
			select.stringifiedSelect += token.GetString();
		});
		EnforceKeywordOrdering(select);
		return nextToken;
	}

	private bool GetNextToken(Expression exp)
	{
		bool nextToken = GetNextToken(delegate(Token token)
		{
			exp.stringifiedExpression += token.GetString();
		});
		EnforceKeywordOrdering(exp.select);
		return nextToken;
	}

	private bool GetNextToken(Action<Token> appendString)
	{
		if (current != null)
		{
			appendString(current);
		}
		if (!tokenizer.HasNextToken())
		{
			previous = current;
			current = null;
			return false;
		}
		Token token = tokenizer.NextToken();
		if (!SkipToken(token))
		{
			Debug.Log($"CURRENT TOKEN: {token.GetString()} {token.GetTokenType()}");
		}
		while (tokenizer.HasNextToken() && SkipToken(token))
		{
			if (token.GetTokenType() == Token.TYPE.WHITESPACE)
			{
				appendString(token);
			}
			token = tokenizer.NextToken();
			if (token.GetTokenType() != Token.TYPE.WHITESPACE)
			{
				Debug.Log($"CURRENT TOKEN: {token.GetString()} {token.GetTokenType()}");
			}
		}
		previous = current;
		current = token;
		if (!tokenizer.HasNextToken() && SkipToken(token))
		{
			current = null;
		}
		return true;
	}

	private bool SkipToken(Token token)
	{
		if (token.GetTokenType() != Token.TYPE.WHITESPACE)
		{
			return token.GetTokenType() == Token.TYPE.COMMENT;
		}
		return true;
	}

	private bool IsBinaryOperator(Token token)
	{
		switch (token.Upper())
		{
		case "||":
		case ">":
		case "<":
		case "<=":
		case ">=":
		case "=":
		case "==":
		case "*":
		case "/":
		case "%":
		case "!=":
		case "<>":
		case "AND":
		case "OR":
		case "+":
		case "-":
		case "LIKE":
		case "IS":
			return true;
		default:
			return false;
		}
	}

	private bool IsAggregateFunction(Token token)
	{
		switch (token.Upper())
		{
		case "MAX":
		case "MIN":
		case "COUNT":
		case "SUM":
		case "AVG":
			return true;
		default:
			return false;
		}
	}

	private bool IsSQLiteFunction(Token token)
	{
		switch (token.Upper())
		{
		case "CONCAT":
		case "POW":
		case "SQRT":
			return true;
		default:
			return false;
		}
	}

	private void AssertValidReferences(Select select, Select baseSelect, bool isSubQuery)
	{
		CheckValidTables(select);
		Dictionary<string, ICollection<string>> tableColumns = CheckValidColumns(select, baseSelect, isSubQuery);
		if (isSubQuery)
		{
			select.RemoveTableReferences(baseSelect);
		}
		EnforceJoins(select, baseSelect, tableColumns, isSubQuery);
		CheckWarnings(select);
	}

	private void EnforceJoins(Select select, Select baseSelect, Dictionary<string, ICollection<string>> tableColumns, bool isSubQuery)
	{
		Debug.Log("Enforcing JOINS");
		Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		ICollection<string> collection = new HashSet<string>(tableColumns.Keys, StringComparer.OrdinalIgnoreCase);
		foreach (string key3 in tableColumns.Keys)
		{
			foreach (string item4 in tableColumns[key3])
			{
				dictionary[item4] = key3;
			}
		}
		List<Identifiers> joinedIdentifiers = select.joinedIdentifiers;
		int num = 0;
		List<string> list = new List<string>();
		foreach (string joinedUsingColumn in select.joinedUsingColumns)
		{
			_ = joinedUsingColumn;
			foreach (string key4 in tableColumns.Keys)
			{
				if (collection.Contains(key4))
				{
					list.Add(key4);
				}
			}
		}
		foreach (Identifiers item5 in joinedIdentifiers)
		{
			List<string> list2 = new List<string>();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (var tableColumnAccessor in item5.tableColumnAccessors)
			{
				string item2 = tableColumnAccessor.Item1;
				if (collection.Contains(item2))
				{
					if (!list2.Contains(item2, StringComparer.OrdinalIgnoreCase))
					{
						Debug.Log(item2);
						list2.Add(item2);
					}
				}
				else if (select.tableAliases.ContainsKey(item2))
				{
					if (!hashSet.Contains(item2, StringComparer.OrdinalIgnoreCase))
					{
						list2.Add(select.tableAliases[item2]);
						hashSet.Add(item2);
					}
				}
				else if (isSubQuery && baseSelect.tableAliases.ContainsKey(item2))
				{
					if (!hashSet.Contains(item2, StringComparer.OrdinalIgnoreCase))
					{
						list2.Add(baseSelect.tableAliases[item2]);
						hashSet.Add(item2);
					}
				}
				else
				{
					select.subQueryAliases.ContainsKey(item2);
				}
			}
			foreach (string identifier in item5.identifiers)
			{
				if (IsTableColumnAccessor(identifier))
				{
					continue;
				}
				if (dictionary.ContainsKey(identifier))
				{
					if (!list2.Contains(dictionary[identifier], StringComparer.OrdinalIgnoreCase))
					{
						Debug.Log(dictionary[identifier]);
						list2.Add(dictionary[identifier]);
					}
				}
				else
				{
					if (!select.selectAliases.ContainsKey(identifier))
					{
						continue;
					}
					foreach (string identifier2 in select.selectAliases[identifier].identifiers)
					{
						if (!list2.Contains(dictionary[identifier2], StringComparer.OrdinalIgnoreCase))
						{
							list2.Add(dictionary[identifier2]);
						}
					}
					foreach (var tableColumnAccessor2 in select.selectAliases[identifier].tableColumnAccessors)
					{
						string item3 = tableColumnAccessor2.Item1;
						if (tableColumns.ContainsKey(item3))
						{
							if (!list2.Contains(item3, StringComparer.OrdinalIgnoreCase))
							{
								list2.Add(item3);
							}
						}
						else if (select.tableAliases.ContainsKey(item3))
						{
							if (!hashSet.Contains(item3, StringComparer.OrdinalIgnoreCase))
							{
								list2.Add(select.tableAliases[item3]);
								hashSet.Add(item3);
							}
						}
						else if (isSubQuery && baseSelect.tableAliases.ContainsKey(item3) && !hashSet.Contains(item3, StringComparer.OrdinalIgnoreCase))
						{
							list2.Add(baseSelect.tableAliases[item3]);
							hashSet.Add(item3);
						}
					}
				}
			}
			num++;
			if (list2.Count > 1 || item5.hasValue)
			{
				list.AddRange(list2);
			}
		}
		List<string> list3 = new List<string>();
		foreach (string fromTable in select.fromTables)
		{
			if (!list.Contains(fromTable, StringComparer.OrdinalIgnoreCase))
			{
				list3.Add(fromTable);
			}
		}
		if (select.fromTables.Count > 1 && list3.Count >= 1)
		{
			throw new ParserException("The table: " + list3[0] + " is not joined with another table in your query. You can join tables by adding an equals expression in the ON statement of your JOIN. For example, add the expression: <i>table1.column = table2.column</i> to join table1 with table2.");
		}
	}

	private void AssertValidSelectSubQueryReferences(Select baseQuery)
	{
		foreach (Select subQuerySelect in subQuerySelects)
		{
			subQuerySelect.AddTableReferences(baseQuery);
			AssertValidReferences(subQuerySelect, baseQuery, isSubQuery: true);
		}
	}

	private void CheckValidTables(Select select)
	{
		foreach (string fromTable in select.fromTables)
		{
			if (!dbAccessor.ContainsTable(fromTable))
			{
				throw new ParserException("Cannot find table named: " + fromTable + " Are you sure this is the right table name?");
			}
		}
		foreach (string key in select.tableAliases.Keys)
		{
			string text2 = select.tableAliases[key];
			if (!dbAccessor.ContainsTable(text2))
			{
				throw new ParserException("Cannot find table named: " + text2 + ". Are you sure this is the right table name?");
			}
		}
	}

	private bool IsTableColumnAccessor(string columnName)
	{
		return columnName.Contains(".");
	}

	private Dictionary<string, ICollection<string>> CheckValidColumns(Select select, Select baseSelect, bool isSubQuery)
	{
		Debug.Log("CHECKING VALID COLUMNS FOR " + select.stringifiedSelect);
		Dictionary<string, ICollection<string>> dictionary = new Dictionary<string, ICollection<string>>();
		foreach (string selectedTableName in GetSelectedTableNames())
		{
			HashSet<string> tableColumnNames = GetTableColumnNames(selectedTableName);
			dictionary.Add(selectedTableName, tableColumnNames);
		}
		foreach (string identifier in select.identifiers)
		{
			string text2 = identifier;
			bool flag = false;
			bool flag2 = false;
			if (text2.Length > 1)
			{
				flag2 = text2[0] == '[' && text2[text2.Length - 1] == ']';
				flag = text2[0] == '"' && text2[text2.Length - 1] == '"';
				if (flag || flag2)
				{
					string text3 = text2;
					text2 = text3.Substring(1, text3.Length - 1 - 1);
				}
			}
			if (select.selectAliases.ContainsKey(text2) || IsTableColumnAccessor(text2) || (isSubQuery && DoesColumnExist(baseSelect.selectColumnNames, text2)))
			{
				continue;
			}
			if (!DoesColumnExist(select.selectColumnNames, text2) && !flag && !text2.ToUpperInvariant().Equals("NULL"))
			{
				throw new ParserException("Cannot find a column named: " + text2 + " in the tables mentioned in the FROM statement. Are you sure this is the right column name?");
			}
			int num = 0;
			foreach (string key4 in dictionary.Keys)
			{
				if (dictionary[key4].Contains(text2))
				{
					num++;
				}
			}
			if (num > 1)
			{
				throw new ParserException("Column named: " + text2 + " exists in multiple tables. Please specify which table this column is from by adding the table name/alias and a period before the column name.");
			}
		}
		foreach (string key5 in select.selectAliases.Keys)
		{
			foreach (string identifier2 in select.selectAliases[key5].identifiers)
			{
				if (!IsTableColumnAccessor(identifier2) && !DoesColumnExist(select.selectColumnNames, identifier2) && !select.parentSelectAliases.ContainsKey(identifier2) && !identifier2.ToUpperInvariant().Equals("NULL"))
				{
					throw new ParserException("Cannot find named a column named: " + identifier2 + " In the tables mentioned in the FROM statement. Are you sure this is the right column name?");
				}
			}
		}
		foreach (var (text5, text6) in select.tableColumnAccessors)
		{
			if (select.subQueryAliases.ContainsKey(text5))
			{
				Select obj = select.subQueryAliases[text5];
				if (!obj.selectColumnNames.Contains(text6, StringComparer.OrdinalIgnoreCase) && !obj.selectAliases.ContainsKey(text6))
				{
					throw new ParserException("Cannot find named a column named: " + text6 + " In the subquery of alias named " + text5 + ". Are you sure this is the right column name?");
				}
				continue;
			}
			if (!select.tableAliases.ContainsKey(text5) && !select.fromTables.Contains(text5, StringComparer.OrdinalIgnoreCase))
			{
				throw new ParserException("The table named " + text5 + " has not been specified in the FROM statement or declared as an alias of a valid table.");
			}
			string text7 = (select.tableAliases.ContainsKey(text5) ? select.tableAliases[text5] : text5);
			if (!dbAccessor.ContainsTable(text7))
			{
				throw new ParserException("Cannot find table named: " + text7 + ". Are you sure this is the right table name?");
			}
			if (!(text6 == "*") && !GetTableColumnNames(text7).Contains(text6, StringComparer.OrdinalIgnoreCase))
			{
				throw new ParserException("Cannot find column named: " + text6 + " in the table " + text7 + ". Are you sure this is the right column name?");
			}
		}
		return dictionary;
		static bool DoesColumnExist(HashSet<string> selectedColumnNames, string columnName)
		{
			return selectedColumnNames.Contains(columnName, StringComparer.OrdinalIgnoreCase);
		}
		ICollection<string> GetSelectedTableNames()
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (string fromTable in select.fromTables)
			{
				hashSet.Add(fromTable);
			}
			foreach (string key6 in select.tableAliases.Keys)
			{
				hashSet.Add(select.tableAliases[key6]);
			}
			return hashSet;
		}
	}

	private void CheckWarnings(Select select)
	{
		if (select.keywordsSeen.Contains(Select.CoreKeywords.GROUP_BY))
		{
			CheckAggregateWarning(select);
			return;
		}
		bool flag = false;
		foreach (Expression selectExpression in select.selectExpressions)
		{
			if (selectExpression != null && selectExpression.aggregatedIdentifiers != null)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			CheckAggregateWarning(select);
		}
	}

	private void CheckAggregateWarning(Select select)
	{
		foreach (Expression selectExpression in select.selectExpressions)
		{
			if (selectExpression == null)
			{
				throw new WarningException("By selecting all columns, you might be selecting columns that are not in a GROUP BY or in an aggregate function. Column results that are ungrouped and unaggregated will be unexpected and random.");
			}
			List<string> list = new List<string>(selectExpression.identifiers);
			List<(string, string)> tupleList = new List<(string, string)>(selectExpression.tableColumnAccessors);
			if (selectExpression.aggregatedIdentifiers != null)
			{
				foreach (string aggregatedIdentifier in selectExpression.aggregatedIdentifiers)
				{
					RemoveListCaseInsensitive(ref list, aggregatedIdentifier);
				}
			}
			if (selectExpression.aggregatedTableColumnAccessors != null)
			{
				foreach (var (item2, item3) in selectExpression.aggregatedTableColumnAccessors)
				{
					RemoveTupleCaseInsensitive(ref tupleList, item2, item3);
				}
			}
			if (select.groupExpressions != null)
			{
				foreach (Expression groupExpression in select.groupExpressions)
				{
					foreach (string identifier2 in groupExpression.identifiers)
					{
						if (select.selectAliases.ContainsKey(identifier2))
						{
							foreach (string identifier3 in select.selectAliases[identifier2].identifiers)
							{
								RemoveIdentifier(ref list, ref tupleList, identifier3);
							}
							foreach (var (item4, text2) in select.selectAliases[identifier2].tableColumnAccessors)
							{
								RemoveTupleCaseInsensitive(ref tupleList, item4, text2);
								RemoveListCaseInsensitive(ref list, text2);
							}
						}
						else
						{
							RemoveIdentifier(ref list, ref tupleList, identifier2);
						}
					}
					foreach (var (item5, text3) in groupExpression.tableColumnAccessors)
					{
						RemoveTupleCaseInsensitive(ref tupleList, item5, text3);
						RemoveListCaseInsensitive(ref list, text3);
					}
				}
			}
			if (tupleList.Count + list.Count >= 1)
			{
				string text4 = ((list.Count >= 1) ? list[0] : (tupleList[0].Item1 + "." + tupleList[0].Item2));
				throw new WarningException("The selected column: " + text4 + " is not in a GROUP BY or in an aggregate function. Results with this ungrouped and unaggregated column will not necessarily be from the same row as the value from the GROUP BY or aggregate function.");
			}
		}
		static bool EqualsCaseInsensitive(string text5, string value)
		{
			return text5.Equals(value, StringComparison.OrdinalIgnoreCase);
		}
		static void RemoveIdentifier(ref List<string> identifiers, ref List<(string, string)> tableColumnAccessors, string text5)
		{
			RemoveListCaseInsensitive(ref identifiers, text5);
			int num = tableColumnAccessors.FindIndex(((string, string) n) => EqualsCaseInsensitive(n.Item2, text5));
			if (num >= 0)
			{
				tableColumnAccessors.RemoveAt(num);
			}
		}
		static void RemoveListCaseInsensitive(ref List<string> reference, string item6)
		{
			int num = reference.FindIndex((string n) => EqualsCaseInsensitive(n, item6));
			if (num >= 0)
			{
				reference.RemoveAt(num);
			}
		}
		static void RemoveTupleCaseInsensitive(ref List<(string, string)> reference, string item6, string item7)
		{
			int num = reference.FindIndex(((string, string) n) => EqualsCaseInsensitive(n.Item1, item6) && EqualsCaseInsensitive(n.Item2, item7));
			if (num >= 0)
			{
				reference.RemoveAt(num);
			}
		}
	}

	private (bool, string) IsSelectStar(Select select)
	{
		if (select.selectExpressions.Contains(null))
		{
			return (true, null);
		}
		foreach (var tableColumnAccessor in select.tableColumnAccessors)
		{
			var (item, _) = tableColumnAccessor;
			if (tableColumnAccessor.Item2.Equals("*"))
			{
				return (true, item);
			}
		}
		return (false, null);
	}

	private void EnforceSingleSelection(Select select)
	{
		string message = "SELECT statements outside of the FROM statement must only result in a single column.";
		if (select.selectCount > 1)
		{
			throw new ParserException(message);
		}
		var (flag, text) = IsSelectStar(select);
		if (!flag)
		{
			return;
		}
		int count = select.fromTables.Count;
		int count2 = select.fromSubQueries.Count;
		bool flag2 = count + count2 > 1;
		if (text == null && flag2)
		{
			throw new ParserException(message);
		}
		if (flag2)
		{
			string tableName = text;
			if (!select.fromTables.Contains(text, StringComparer.OrdinalIgnoreCase))
			{
				if (!select.tableAliases.ContainsKey(text))
				{
					throw new ParserException("Table named " + text + " has not been specified in the FROM statement or declared as an alias of a valid table.");
				}
				tableName = select.tableAliases[text];
			}
			if (GetTableColumnNames(tableName).Count > 1)
			{
				throw new ParserException(message);
			}
		}
		else if (count == 1)
		{
			string tableName2 = select.fromTables[0];
			if (GetTableColumnNames(tableName2).Count > 1)
			{
				throw new ParserException(message);
			}
		}
		else
		{
			Select obj = select.fromSubQueries[0];
			EnforceSingleSelection(obj);
		}
	}

	private void CheckRemaining(Select select)
	{
		if (current != null && current.Equals(";"))
		{
			GetNextToken(select);
		}
		if (current == null)
		{
			return;
		}
		if (current.Equals(")"))
		{
			throw new ParserException("There is an extra parenthesis after '" + previous.GetString() + "'");
		}
		if (current.GetTokenType() == Token.TYPE.KEYWORD)
		{
			throw new ParserException("Unexpected keyword '" + current.Upper() + "' spotted right after '" + GetDescriptiveName(previous) + "' - is this keyword in the right place?");
		}
		throw new ParserException("The end of the SELECT query was expected, but found '" + current.GetString() + "' instead.");
	}

	private HashSet<string> GetTableColumnNames(string tableName)
	{
		if (tableColumnNamesCache == null)
		{
			tableColumnNamesCache = new Dictionary<string, HashSet<string>>();
		}
		if (tableColumnNamesCache.ContainsKey(tableName))
		{
			return tableColumnNamesCache[tableName];
		}
		if (!dbAccessor.ContainsTable(tableName))
		{
			throw new ParserException("Cannot find table named: " + tableName + ". Are you sure this is the right table name?");
		}
		HashSet<string> columnNames = dbAccessor.GetColumnNames(tableName);
		tableColumnNamesCache[tableName] = columnNames;
		return columnNames;
	}

	private bool IsUnaryOperator(Token token)
	{
		if (!token.Equals("+"))
		{
			return token.Equals("-");
		}
		return true;
	}

	private void LogFunction(string functionName)
	{
		Debug.Log(functionName + "() -> Token=" + ((current != null) ? current.GetString() : "NULL"));
	}

	private (bool, string, string) GetTableAccessorColumnValues(string selectValue)
	{
		string[] array = selectValue.Split('.');
		bool item = false;
		string item2 = null;
		string item3 = null;
		if (array.Count() == 2)
		{
			item2 = array[0].Trim();
			item3 = array[1].Trim();
			item = true;
		}
		return (item, item2, item3);
	}

	private string GetCommaErrorMessage(string statement)
	{
		return "There must be a value specified before the comma in the beginning of the " + statement + " statement.";
	}

	private string GetStarErrorMessage(string statement)
	{
		return "The " + statement + " statement cannot contain the special select all (*) character.";
	}
}
