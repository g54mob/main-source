using Data.SaveData;
using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Data.Variables.Milestones
{
	[CreateAssetMenu(menuName = "Variables/Monuments/Monument Built Variable", fileName = "MonumentBuiltVariableSO", order = 0)]
	public class MonumentBuiltVariableSO : BoolVariableSO
	{
		[SerializeField]
		private GlobalPersistentManager _globalPersistentManager;

		[SerializeField]
		private MonumentsPersistentSO _monumentsPersistentSO;

		public override void SetValue(bool value)
		{
			base.SetValue(value);
			if (value)
			{
				_globalPersistentManager.SavePersistentSOManually(_monumentsPersistentSO);
			}
		}
	}
}
