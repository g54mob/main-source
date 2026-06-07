using DV.InventorySystem;
using UnityEngine;

namespace DV.Utils
{
	public class TestMoneySetter : MonoBehaviour
	{
		public float startMoney = 10000000f;

		private void Start()
		{
			SingletonBehaviour<Inventory>.Instance.SetMoney(startMoney);
		}
	}
}
