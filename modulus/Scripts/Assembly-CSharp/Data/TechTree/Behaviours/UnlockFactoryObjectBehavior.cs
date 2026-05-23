#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Data.Variables;
using UnityEngine;
using Utils;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Unlock FactoryObject", fileName = "UnlockFactoryObjectBehavior")]
	public class UnlockFactoryObjectBehavior : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private LockedFactoryObjectsPersistentSO _lockedFactoryObjectsPersistentSO;

		[SerializeField]
		private List<FactoryObjectData> _factoryObjectDatas;

		public List<FactoryObjectData> FactoryObjectDatas => _factoryObjectDatas;

		public override void Unlock()
		{
			if (_lockedFactoryObjectsPersistentSO == null)
			{
				this.LogError("Needs ref to persistent SO", "Unlock", 22);
			}
			foreach (FactoryObjectData factoryObjectData in _factoryObjectDatas)
			{
				_lockedFactoryObjectsPersistentSO.UnlockObject(factoryObjectData);
			}
		}

		public override void RefunableReUnlock()
		{
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = null;
			return false;
		}
	}
}
