using UnityEngine;

namespace Restory.Gameplay.MoneyCash
{
	public class MoneyFromNpcReceivingSpace : MonoBehaviour
	{
		[SerializeField]
		private Transform parentForMoneyItems;

		public Transform ParentForMoneyItems => parentForMoneyItems;
	}
}
