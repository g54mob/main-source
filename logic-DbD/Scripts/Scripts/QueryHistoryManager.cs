using System;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class QueryHistoryManager : MonoBehaviour
{
	private readonly string SAVED_QUERY_HISTORY_TABLE = "queryhistories";

	[SerializeField]
	private GameObject queryHistoryRowPrefab;

	[SerializeField]
	private GameObject queryHistoryContainer;

	[SerializeField]
	private GameObject emptyQueryHistory;

	[SerializeField]
	private TMP_InputField queryInput;

	[SerializeField]
	private PanelManager tableManager;

	private HashSet<string> queries;

	private void Start()
	{
		CheckEmptyQueryHistory();
	}

	public void CheckEmptyQueryHistory()
	{
		emptyQueryHistory.SetActive(queries.Count <= 0);
	}

	public void ReplaceQuery(string text)
	{
		queryInput.text = text;
	}

	public ICollection<string> GetTableNames()
	{
		return tableManager.GetTableNames();
	}

	public void AddQueryHistory(string query)
	{
		if (!queries.Contains(query))
		{
			queries.Add(query);
			AddQueryHistoryRow(query);
			SaveQuery(query);
			emptyQueryHistory.SetActive(value: false);
		}
	}

	private void AddQueryHistoryRow(string query)
	{
		GameObject obj = UnityEngine.Object.Instantiate(queryHistoryRowPrefab, queryHistoryContainer.transform);
		obj.GetComponent<QueryHistoryRow>().SetQuery(query);
		obj.transform.SetAsFirstSibling();
	}

	public void DeleteQuery(string query)
	{
		queries.Remove(query);
		using IDbConnection connection = DatabaseUtils.GetConnection(Save.PERSISTENT_SAVES_DATABASE);
		if (DatabaseUtils.ContainsTable(SAVED_QUERY_HISTORY_TABLE, connection))
		{
			DatabaseUtils.DeleteFromTable(connection, SAVED_QUERY_HISTORY_TABLE, "query = \"" + CreateTablesHelpers.RemoveQuotations(query) + "\"");
		}
	}

	private void SaveQuery(string query)
	{
		using IDbConnection connection = DatabaseUtils.GetConnection(Save.PERSISTENT_SAVES_DATABASE);
		if (!DatabaseUtils.ContainsTable(SAVED_QUERY_HISTORY_TABLE, connection))
		{
			DatabaseUtils.CreateTable(connection, SAVED_QUERY_HISTORY_TABLE, "query TEXT, date_created INT, time_created INT");
		}
		int num = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
		int num2 = int.Parse(DateTime.Now.ToString("HHmm"));
		DatabaseUtils.AddSingleRowToTable(connection, SAVED_QUERY_HISTORY_TABLE, "query, date_created, time_created", $"\"{CreateTablesHelpers.RemoveQuotations(query)}\", {num}, {num2}");
	}

	public void LoadQueries()
	{
		queries = new HashSet<string>();
		using (IDbConnection connection = DatabaseUtils.GetConnection(Save.PERSISTENT_SAVES_DATABASE))
		{
			if (!DatabaseUtils.ContainsTable(SAVED_QUERY_HISTORY_TABLE, connection))
			{
				return;
			}
			CreateTablesHelpers.LoadSavedTable(connection, SAVED_QUERY_HISTORY_TABLE, LoadQuery, "date_created, time_created");
		}
		foreach (string query in queries)
		{
			AddQueryHistoryRow(query);
		}
		void LoadQuery(string[] row)
		{
			queries.Add(CreateTablesHelpers.RestoreQuotations(row[0]));
		}
	}
}
