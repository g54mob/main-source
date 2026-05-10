using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "CreditsDataBase", menuName = "Sheet/CreditsDataBase")]
public class CreditsDatabase : ScriptableObject
{
	public List<DataHierarchy> _listHierarchy = new List<DataHierarchy>();

	[ReadOnly]
	public float _ySizeText;

	public void AddItem(string workerName, string workerJob, string TeamJob)
	{
		new DataCredit
		{
			Name = workerName,
			Title = workerJob,
			Team = TeamJob
		};
		foreach (DataHierarchy item2 in _listHierarchy)
		{
			if (item2.HierarchyTeam == TeamJob)
			{
				DataHierarchy.DataHierarchyWorker item = new DataHierarchy.DataHierarchyWorker
				{
					job = workerJob,
					name = workerName
				};
				if (item.job == "Subtitle")
				{
					item.isSubtitle = true;
					item.job = "None";
				}
				item2._CurrentWorker.Add(item);
			}
		}
		Debug.Log(workerName + workerJob + TeamJob);
	}

	public void RemoveListNull()
	{
		_listHierarchy.RemoveAll((DataHierarchy item) => item == null);
	}

	public void RemoveListAlone()
	{
		for (int i = 0; i < _listHierarchy.Count; i++)
		{
			_ = _listHierarchy[i]._CurrentWorker.Count;
			_ = 0;
		}
	}

	public void ArrangeList()
	{
		RemoveListAlone();
		foreach (DataHierarchy item in _listHierarchy)
		{
			_ = item;
		}
	}

	public void SizeCreditTextContent(float ySizeContent)
	{
		_ySizeText = ySizeContent;
		Debug.Log(ySizeContent);
	}

	public float ReturnSize()
	{
		return _ySizeText;
	}
}
