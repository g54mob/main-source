using UnityEngine;

namespace UltimateRadialMenuExample.CharacterInventory2D
{
	public class WorldItem : MonoBehaviour
	{
		public CharacterInventoryGameManager myManager;

		public CharacterInventoryGameManager.ItemInformation myInformation;

		public void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.name == "Player")
			{
				myManager.PickupItem(myInformation);
				Object.Destroy(base.gameObject);
			}
		}
	}
}
