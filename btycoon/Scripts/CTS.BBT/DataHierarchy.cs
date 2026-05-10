using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataHierarchy
{
	[Serializable]
	public struct DataHierarchyWorker
	{
		public string job;

		public string name;

		public bool isSubtitle;
	}

	[Space]
	public string HierarchyTeam;

	public List<DataHierarchyWorker> _CurrentWorker = new List<DataHierarchyWorker>();

	public static DataHierarchy CreateCopyWithNewValues(DataHierarchy p_original, HierarchyImportStruct p_data)
	{
		return new DataHierarchy
		{
			HierarchyTeam = p_data.HierarchyTeam
		};
	}

	public void SetNewValues(HierarchyImportStruct p_data)
	{
		HierarchyTeam = p_data.HierarchyTeam;
	}

	public static DataHierarchy CreateNewFromImport(HierarchyImportStruct importData, CreditsDatabase creditsDataBase, int currentPosition)
	{
		DataHierarchy dataHierarchy = new DataHierarchy
		{
			HierarchyTeam = importData.HierarchyTeam
		};
		Debug.Log(dataHierarchy.HierarchyTeam);
		creditsDataBase._listHierarchy.Insert(currentPosition, dataHierarchy);
		return dataHierarchy;
	}

	public void ChangeTitleName(string name)
	{
	}

	public string GetJobName()
	{
		return null;
	}

	public string GetWorkerName()
	{
		return null;
	}
}
