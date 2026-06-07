using System.Collections.Generic;
using UnityEngine;

public class BatchChildren : MonoBehaviour
{
	public int MAX_OBJECTS = 5;

	public bool Recursively;

	private void Start()
	{
		Batch(base.transform, Recursively);
	}

	private void Batch(Transform t, bool rec)
	{
		int num = 0;
		int num2 = 0;
		List<GameObject> list = new List<GameObject>();
		List<Transform> list2 = new List<Transform>();
		foreach (Transform item in t)
		{
			list2.Add(item);
		}
		list2.Sort(UnityUtils.CompareTransform);
		foreach (Transform item2 in list2)
		{
			num2++;
			if (item2.GetComponent<MeshRenderer>() != null)
			{
				list.Add(item2.gameObject);
			}
			if (list.Count >= MAX_OBJECTS || num2 == t.childCount)
			{
				GameObject gameObject = new GameObject($"batch {base.gameObject.name}/{num}");
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				StaticBatchingUtility.Combine(list.ToArray(), gameObject);
				list.Clear();
				num++;
			}
			if (rec)
			{
				Batch(item2, rec);
			}
		}
	}
}
