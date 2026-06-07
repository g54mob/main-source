using UnityEngine;

namespace DV.Shops
{
	public abstract class APurchaseTrigger : MonoBehaviour
	{
		public abstract void OnPurchased(GameObject instantiatedItem);
	}
}
