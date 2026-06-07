using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Events;
using NaughtyAttributes;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Logic.Factory
{
	[CreateAssetMenu(menuName = "Factory/Tools/FactoryClearer", fileName = "FactoryClearer", order = 0)]
	public class FactoryClearer : ScriptableObject
	{
		[SerializeField]
		private FreightersManagerLocator _freightersManagerLocator;

		[SerializeField]
		private FactoryLayersLibrary _factoryLayersLibrary;

		[SerializeField]
		private IslandDatabase _islandsDatabase;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private BaseEvent _clearMapEvent;

		[Space]
		[SerializeField]
		private BaseEvent _levelClearedEvent;

		[Button(null, EButtonEnableMode.Always)]
		public void ClearLevel()
		{
			IntIdGenerator.Reset();
			if (_freightersManagerLocator.Manager != null)
			{
				_freightersManagerLocator.Manager.Reset();
			}
			_factoryLayersLibrary.ClearAll();
			_islandLayer.Clear();
			_islandsDatabase.Clear();
			_clearMapEvent.Fire();
			_levelClearedEvent.Fire();
		}
	}
}
