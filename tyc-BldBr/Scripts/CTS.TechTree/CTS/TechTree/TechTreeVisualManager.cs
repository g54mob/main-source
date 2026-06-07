using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT.TechTree;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS.TechTree
{
	public class TechTreeVisualManager : MonoBehaviour
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		private ETechTreeDisposition _techTreeDisposition;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("GameObject Links")]
		private GameObject _categoryAnchor;

		[SerializeField]
		[BoxGroup("GameObject Links")]
		private TechTreeCategorieSetup _categoryPrefab;

		private Dictionary<TechTreeCategoriesSO, TechTreeCategorieSetup> _categories = new Dictionary<TechTreeCategoriesSO, TechTreeCategorieSetup>();

		private TechTreeCategoriesSO[] _categoriesData;

		private TechTreeCategoriesSO[] _sortedCategoriesData;

		private TechTreeTechnologySO[] _nodesData;

		private List<TechTreeCategorieSetup> _techTreeCatergoriesList = new List<TechTreeCategorieSetup>();

		public static event Action UnlockEvent;

		private void Awake()
		{
			_categoriesData = Addressables.LoadAssetsAsync<TechTreeCategoriesSO>("TechCategories").WaitForCompletion().ToArray();
			_nodesData = Addressables.LoadAssetsAsync<TechTreeTechnologySO>("Technologies").WaitForCompletion().ToArray();
		}

		private void OnEnable()
		{
			TechTreeNodeSetup.TechUnlockFull += CheckIfallIsFinish;
			TechTreeManager.OnTechTreeInitialized += PopulateVisual;
			if (TechTreeManager.IsInitialized)
			{
				PopulateVisual();
			}
		}

		private void OnDisable()
		{
			TechTreeManager.OnTechTreeInitialized -= PopulateVisual;
			TechTreeNodeSetup.TechUnlockFull -= CheckIfallIsFinish;
		}

		private void CheckIfallIsFinish()
		{
			bool flag = true;
			Debug.Log("test");
			foreach (TechTreeCategorieSetup techTreeCatergories in _techTreeCatergoriesList)
			{
				foreach (TechTreeNodeSetup item in techTreeCatergories.GetNode())
				{
					Debug.Log(item.GetState());
					if (item.GetState() != ENodeState.FullyResearched)
					{
						flag = false;
						break;
					}
				}
			}
			Debug.Log(flag);
			if (flag)
			{
				TechTreeVisualManager.UnlockEvent?.Invoke();
			}
		}

		private void PopulateVisual()
		{
			_sortedCategoriesData = _categoriesData.OrderBy((TechTreeCategoriesSO category) => category.Order).ToArray();
			TechTreeCategoriesSO[] sortedCategoriesData = _sortedCategoriesData;
			foreach (TechTreeCategoriesSO techTreeCategoriesSO in sortedCategoriesData)
			{
				if (!_categories.ContainsKey(techTreeCategoriesSO))
				{
					TechTreeCategorieSetup techTreeCategorieSetup = UnityEngine.Object.Instantiate(_categoryPrefab, _categoryAnchor.transform);
					techTreeCategorieSetup.CategorySO = techTreeCategoriesSO;
					techTreeCategorieSetup.TechTreeVisualManager = this;
					techTreeCategorieSetup.CategoryName = techTreeCategoriesSO.CategoryName;
					techTreeCategorieSetup.CategoryDescription = techTreeCategoriesSO.CategoryDescription;
					techTreeCategorieSetup.CategorySize = techTreeCategoriesSO.CategorySize;
					techTreeCategorieSetup.Setup();
					_categories[techTreeCategoriesSO] = techTreeCategorieSetup;
					_techTreeCatergoriesList.Add(techTreeCategorieSetup);
				}
			}
		}

		public TechTreeTechnologySO[] GetNodesList()
		{
			return _nodesData;
		}
	}
}
