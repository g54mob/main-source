using UnityEngine;

namespace Assets.BeneathThePetals.Scripts.Steam
{
	public class CasseyAchivement : MonoBehaviour
	{
		private void OnCollisionEnter(Collision other)
		{
			other.gameObject.CompareTag("Player");
		}
	}
}
