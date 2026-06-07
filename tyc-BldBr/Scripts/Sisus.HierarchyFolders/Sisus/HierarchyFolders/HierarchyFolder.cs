using System.Collections.Generic;
using UnityEngine;

namespace Sisus.HierarchyFolders
{
	[ExecuteAlways]
	[DefaultExecutionOrder(-32000)]
	public sealed class HierarchyFolder : MonoBehaviour
	{
		private void Awake()
		{
			FlattenAndDestroy(base.transform);
		}

		private static void FlattenAndDestroy(Transform transform)
		{
			List<GameObject> list = null;
			FlattenAndDestroy(transform, list);
			if (list == null)
			{
				return;
			}
			int i = 0;
			for (int count = list.Count; i < count; i++)
			{
				GameObject gameObject = list[i];
				if (!(gameObject == null))
				{
					gameObject.SetActive(value: true);
				}
			}
		}

		private static void FlattenAndDestroy(Transform transform, List<GameObject> setChildrenActiveDelayed)
		{
			Transform parent = transform.parent;
			if (transform.gameObject.activeSelf)
			{
				if (parent == null)
				{
					transform.DetachChildren();
				}
				else
				{
					int childCount = transform.childCount;
					Transform[] array = new Transform[childCount];
					for (int i = 0; i < childCount; i++)
					{
						array[i] = transform.GetChild(i);
					}
					for (int j = 0; j < childCount; j++)
					{
						array[j].SetParent(parent, worldPositionStays: true);
					}
					transform.SetParent(null, worldPositionStays: false);
				}
			}
			else
			{
				int childCount2 = transform.childCount;
				Transform[] array2 = new Transform[childCount2];
				for (int k = 0; k < childCount2; k++)
				{
					array2[k] = transform.GetChild(k);
				}
				for (int l = 0; l < childCount2; l++)
				{
					Transform transform2 = array2[l];
					if (transform2.gameObject.activeSelf)
					{
						if (setChildrenActiveDelayed == null)
						{
							setChildrenActiveDelayed = new List<GameObject>();
						}
						transform2.gameObject.SetActive(value: false);
						setChildrenActiveDelayed.Add(transform2.gameObject);
					}
					transform2.SetParent(parent, worldPositionStays: true);
				}
				transform.SetParent(null, worldPositionStays: false);
			}
			transform.gameObject.SetActive(value: false);
			Object.Destroy(transform.gameObject);
		}
	}
}
