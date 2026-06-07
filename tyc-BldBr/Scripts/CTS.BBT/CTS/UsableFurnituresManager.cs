using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class UsableFurnituresManager : CTSSingleton<UsableFurnituresManager>
	{
		[SerializeField]
		private SerializableDictionary<Transform, List<UsableFurnituresCategoriesSO>> _furnituresToSpawn = new SerializableDictionary<Transform, List<UsableFurnituresCategoriesSO>>();

		[SerializeField]
		private SerializableDictionary<EMachineProductionMode, LocalizedString> _productionModeLocalizations = new SerializableDictionary<EMachineProductionMode, LocalizedString>();

		[SerializeField]
		[BoxGroup("Debug View")]
		private bool _debugMode;

		private UsableFurnituresCategoriesSO[] _usableFurnituresCategoriesSO;

		private SerializableDictionary<UsableFurnituresCategoriesSO, UsableFurnituresCategory> _categoryInstances = new SerializableDictionary<UsableFurnituresCategoriesSO, UsableFurnituresCategory>();

		public ReadOnlyDictionary<EMachineProductionMode, LocalizedString> ProductionModesLocalizations => _productionModeLocalizations;

		public ReadOnlyDictionary<UsableFurnituresCategoriesSO, UsableFurnituresCategory> Categories => _categoryInstances;

		protected override void SingletonAwake()
		{
		}

		private void Start()
		{
			InstantiateCategories();
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void InstantiateCategories()
		{
			foreach (var (parent, list2) in _furnituresToSpawn)
			{
				foreach (UsableFurnituresCategoriesSO item in list2)
				{
					UsableFurnituresCategory usableFurnituresCategory = CTSFactory.Instantiate(item.CategoryPrefab, parent, instantiateInWorldSpace: false, false);
					usableFurnituresCategory.Setup(item);
					usableFurnituresCategory.gameObject.SetActive(value: true);
					_categoryInstances[item] = usableFurnituresCategory;
				}
			}
		}
	}
}
