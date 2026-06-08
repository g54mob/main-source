using System;
using System.Collections.Generic;

public class QueryParser
{
	public static readonly ICollection<string> KEYWORDS = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"SELECT", "FROM", "WHERE", "HAVING", "GROUP", "ORDER", "BY", "MAX", "MIN", "COUNT",
		"SUM", "AVG", "AND", "OR", "ON", "AS", "NULL", "JOIN", "RIGHT", "LEFT",
		"INNER", "DISTINCT", "DESC", "ASC", "LIKE", "EXCEPT", "IN", "NOT", "IS", "NATURAL",
		"USING", "EXISTS", "LIMIT", "POW", "SQRT", "CONCAT"
	};

	public static readonly ICollection<string> ILLEGAL_MATERIALS = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "DROP", "INSERT", "UPDATE", "DELETE", "REPLACE", "TABLE", "sqlite_master", "sqlite_temp_master" };

	public static (bool, string) HasForbiddenKeywords(string query)
	{
		return (QueryInputUtils.contrabandUsed != null, QueryInputUtils.contrabandUsed);
	}

	public static bool IsKeyword(string word)
	{
		if (!KEYWORDS.Contains(word))
		{
			return ILLEGAL_MATERIALS.Contains(word);
		}
		return true;
	}

	public static string SelectIntoQueryConvertor(string query, string newTableName)
	{
		return "CREATE TABLE " + newTableName + " AS " + query;
	}
}
