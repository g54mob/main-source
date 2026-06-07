using System.Collections.Generic;
using UnityEngine;

namespace PrefabSwapperSuburb
{
	[AddComponentMenu("PrefabSwapper/SwapPrefabSuburb")]
	[ExecuteInEditMode]
	public class SwapPrefab : MonoBehaviour
	{
		public static List<string> categoryList;

		public static List<string> prefabList;

		public bool placed;

		public string category;

		public string prefab;

		public string[] additionals;

		public string[] additionalsBtns;

		public Vector3[] additionalsPos;

		public Vector3[] additionalsRot;

		private string exCategory;

		private string exPrefab;

		public void CreateCategoryList()
		{
			categoryList = new List<string>();
			SwapPrefabList.SwapPrefabProperties[] swapPrefabProperties = SwapPrefabList.swapPrefabProperties;
			foreach (SwapPrefabList.SwapPrefabProperties swapPrefabProperties2 in swapPrefabProperties)
			{
				if (!categoryList.Contains(swapPrefabProperties2.category))
				{
					categoryList.Add(swapPrefabProperties2.category);
				}
			}
		}

		public void CreatePrefabList()
		{
			prefabList = new List<string>();
			SwapPrefabList.SwapPrefabProperties[] swapPrefabProperties = SwapPrefabList.swapPrefabProperties;
			foreach (SwapPrefabList.SwapPrefabProperties swapPrefabProperties2 in swapPrefabProperties)
			{
				if (swapPrefabProperties2.category == category && !prefabList.Contains(swapPrefabProperties2.prefabName))
				{
					prefabList.Add(swapPrefabProperties2.prefabName);
				}
			}
		}

		public void FindPrefabProperties()
		{
			SwapPrefabList.SwapPrefabProperties[] swapPrefabProperties = SwapPrefabList.swapPrefabProperties;
			foreach (SwapPrefabList.SwapPrefabProperties swapPrefabProperties2 in swapPrefabProperties)
			{
				if (swapPrefabProperties2.prefabName == base.transform.name)
				{
					GetPrefabProperties(swapPrefabProperties2);
					break;
				}
			}
		}

		public void CleanPrefabProperties()
		{
			category = "";
			prefab = "";
			additionals = new string[0];
			additionalsBtns = new string[0];
			additionalsPos = new Vector3[0];
			additionalsRot = new Vector3[0];
			exCategory = "";
			exPrefab = "";
		}

		public void GetPrefabProperties(SwapPrefabList.SwapPrefabProperties _prefab)
		{
			category = _prefab.category;
			prefab = _prefab.prefabName;
			additionals = _prefab.addAdditional;
			additionalsBtns = _prefab.addAdditionalButtonName;
			additionalsPos = _prefab.addAdditionalPos;
			additionalsRot = _prefab.addAdditionalRot;
			exCategory = category;
			exPrefab = prefab;
		}

		public void Initialize()
		{
			FindPrefabProperties();
			CreateCategoryList();
			CreatePrefabList();
		}
	}
}
