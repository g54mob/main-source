using System.Collections.Generic;

public interface IParserDBAccessor
{
	bool ContainsTable(string tableName);

	HashSet<string> GetColumnNames(string tableName);

	ICollection<string> GetAllTableNames();
}
