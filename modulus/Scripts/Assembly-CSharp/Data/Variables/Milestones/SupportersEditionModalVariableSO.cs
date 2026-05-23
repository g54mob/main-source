using Data.SaveData;
using Data.SaveData.PersistentSOs;
using UnityEngine;

namespace Data.Variables.Milestones
{
	[CreateAssetMenu(menuName = "Variables/SupportersEdition/Supporters Edition Modal", fileName = "SupportersEditionModalVariableSO", order = 0)]
	public class SupportersEditionModalVariableSO : BoolVariableSO
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
