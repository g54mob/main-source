#define ENABLE_DEBUG_WARNINGS
using Data.FactoryFloor.Buildings;
using Data.Variables;
using UnityEngine;
using Utils;

namespace Data.TechTree.Behaviours
{
	[CreateAssetMenu(menuName = "Tech Tree/Behaviors/Increase Max Locked BuildingStage", fileName = "IncreaseMaxLockedBuildingStage")]
	public class IncreaseMaxLockedBuildingStageTechTreeNodeBehaviour : AbstractTechTreeNodeBehaviour
	{
		[SerializeField]
		private BuildingMaxLockedStageData _buildingMaxLockedStageData;

		[SerializeField]
		private int _newMaxLockedStage;

		public override void Unlock()
		{
			if (_buildingMaxLockedStageData.Value >= _newMaxLockedStage)
			{
				this.LogWarning($"The techtree node is setting the building upgrades to {_newMaxLockedStage} but it's already at {_buildingMaxLockedStageData.Value}", "Unlock", 18);
			}
			else
			{
				_buildingMaxLockedStageData.SetValue(_newMaxLockedStage);
			}
		}

		public override void RefunableReUnlock()
		{
			Unlock();
		}

		public override bool TryGetRefunableVariable(out VariableSO variable)
		{
			variable = _buildingMaxLockedStageData;
			return true;
		}
	}
}
