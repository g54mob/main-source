using System;
using UnityEngine;

[Serializable]
public class ExcelExample : ScriptableObject
{
	[HideInInspector]
	[SerializeField]
	public string SheetName = "";

	[HideInInspector]
	[SerializeField]
	public string WorksheetName = "";

	public ExcelExampleData[] dataArray;

	private void OnEnable()
	{
		if (dataArray == null)
		{
			dataArray = new ExcelExampleData[0];
		}
	}
}
