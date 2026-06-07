using Data.FactoryFloor.Maps;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using Presentation.Locators;
using UnityEngine;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Unlock GNN Gate Island", fileName = "UnlockGNNGateIsland")]
	public class UnlockGNNGateIslandBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private BoolVariableSO _gnnGateIsUnlockedSO;

		[SerializeField]
		private BoolVariableSO _isLoadingSaveSO;

		public override void Unlock()
		{
			if (!_isLoadingSaveSO.Value)
			{
				UnlockGNNIsland();
			}
			else
			{
				_isLoadingSaveSO.ValueChanged += UnlockGNNIslandAfterLoading;
			}
		}

		private void UnlockGNNIslandAfterLoading(bool isLoading)
		{
			_isLoadingSaveSO.ValueChanged -= UnlockGNNIslandAfterLoading;
			UnlockGNNIsland();
		}

		private void UnlockGNNIsland()
		{
			_uiMenuManagerLocator.UIMenuManager.CloseAllOpenMenus();
			foreach (IslandObject allIsland in _islandLayer.GetAllIslands())
			{
				if (allIsland.IslandConfig.IsGNNGateIsland)
				{
					_unlockedIslandsPersistentSO.UnlockIsland(allIsland);
				}
			}
			_gnnGateIsUnlockedSO.SetValue(value: true);
		}

		public override void RefunableReUnlock()
		{
			if (!_gnnGateIsUnlockedSO.Value)
			{
				Unlock();
			}
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _gnnGateIsUnlockedSO;
			return true;
		}
	}
}
