using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QueryHistoryRow : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI visibleText;

	[SerializeField]
	private TextMeshProUGUI invisibleText;

	private QueryHistoryManager queryHistoryManager;

	private void Awake()
	{
		queryHistoryManager = base.transform.parent.parent.parent.GetComponentInParent<QueryHistoryManager>();
	}

	private void Start()
	{
		ICollection<string> tableNames = queryHistoryManager.GetTableNames();
		QueryInputUtils.HighlightKeywords(visibleText, tableNames, QueryInputUtils.GetQueryTables(visibleText.text, tableNames));
	}

	public void SetQuery(string query)
	{
		invisibleText.text = query;
		visibleText.text = query;
	}

	public void RestoreQuery()
	{
		queryHistoryManager.ReplaceQuery(invisibleText.text);
	}

	public void DeleteEntry()
	{
		CursorManager.SetCursorNormal();
		queryHistoryManager.DeleteQuery(invisibleText.text);
		queryHistoryManager.CheckEmptyQueryHistory();
		Object.Destroy(base.gameObject);
	}
}
