using Data.Operator;
using Data.SaveData;
using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Data.Variables.Milestones
{
	[CreateAssetMenu(menuName = "Variables/Monuments/GNN Gate Finished Variable", fileName = "GNNGateFinishedVariableSO", order = 0)]
	public class GNNGateFinishedVariableSO : BoolVariableSO
	{
		[SerializeField]
		private GlobalPersistentManager _globalPersistentManager;

		[SerializeField]
		private MonumentsPersistentSO _monumentsPersistentSO;

		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

		[SerializeField]
		private FactoryObjectData _atlasStatueData;

		public override void SetValue(bool value)
		{
			base.SetValue(value);
			if (value)
			{
				_globalPersistentManager.SavePersistentSOManually(_monumentsPersistentSO);
				_lockedFactoryObjectsPersistentSO.UnlockObject(_atlasStatueData);
			}
		}
	}
}
