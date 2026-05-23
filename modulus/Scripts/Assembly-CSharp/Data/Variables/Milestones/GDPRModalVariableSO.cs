using Data.SaveData;
using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Data.Variables.Milestones
{
	[CreateAssetMenu(menuName = "Variables/GDPR Modal VariableSO", fileName = "GDPRModalVariableSO", order = 0)]
	public class GDPRModalVariableSO : BoolVariableSO
	{
		[SerializeField]
		private GlobalPersistentManager _globalPersistentManager;

		[SerializeField]
		private GeneralPersistentSO _generalPersistentSO;

		public override void SetValue(bool value)
		{
			base.SetValue(value);
			if (value)
			{
				_globalPersistentManager.SavePersistentSOManually(_generalPersistentSO);
			}
		}
	}
}
