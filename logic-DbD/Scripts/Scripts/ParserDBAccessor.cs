using System.Collections.Generic;
using System.Data;

public class ParserDBAccessor : IParserDBAccessor
{
	private IDbConnection dbConnection;

	public ParserDBAccessor(IDbConnection connection)
	{
		dbConnection = connection;
	}

	public bool ContainsTable(string tableName)
	{
		return DatabaseUtils.ContainsTable(tableName, dbConnection);
	}

	public HashSet<string> GetColumnNames(string tableName)
	{
		return DatabaseUtils.GetTableColumnNames(dbConnection, tableName);
	}

	public ICollection<string> GetAllTableNames()
	{
		return DatabaseUtils.GetAllTableNames(dbConnection);
	}
}
