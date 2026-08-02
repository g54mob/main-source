using UnityEngine;

namespace JUTPS.PowerUps
{
	[RequireComponent(typeof(BoxCollider))]
	[AddComponentMenu("JU TPS/Weapon System/Health Power Up")]
	public class HealthPowerUp : MonoBehaviour
	{
		[Header("Health")]
		public float HealthToAdd = 30f;

		public GameObject Effect;

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Player")
			{
				JUHealth component = other.GetComponent<JUHealth>();
				if (component != null && component.Health != component.MaxHealth)
				{
					component.Health += HealthToAdd;
					Object.Destroy(Object.Instantiate(Effect, base.transform.position, base.transform.rotation), 5f);
					Object.Destroy(base.gameObject, 0.1f);
				}
			}
		}
	}
}
