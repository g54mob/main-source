using UnityEngine;

namespace JUTPS.WeaponSystem
{
	[AddComponentMenu("JU TPS/Weapon System/Ammunition Box")]
	public class AmmoBox : MonoBehaviour
	{
		[Header("Bullet Amount")]
		public int AmmoCount = 32;

		public GameObject Effect;

		[Header("Weapon ID")]
		public string WeaponName = "AnyWeapon";

		private void OnTriggerEnter(Collider other)
		{
			if (!(other.gameObject.tag == "Player"))
			{
				return;
			}
			JUCharacterController component = other.GetComponent<JUCharacterController>();
			if (!component.IsItemEquiped || (component.WeaponInUseLeftHand == null && component.WeaponInUseRightHand == null))
			{
				return;
			}
			if (component.WeaponInUseRightHand != null && component.WeaponInUseRightHand.ItemName == WeaponName)
			{
				component.WeaponInUseRightHand.TotalBullets += ((component.WeaponInUseLeftHand == null) ? AmmoCount : (AmmoCount / 2));
			}
			if (component.WeaponInUseLeftHand != null && component.WeaponInUseLeftHand.ItemName == WeaponName)
			{
				component.WeaponInUseLeftHand.TotalBullets += ((component.WeaponInUseRightHand == null) ? AmmoCount : (AmmoCount / 2));
			}
			if (WeaponName == "AnyWeapon")
			{
				if (component.WeaponInUseRightHand != null)
				{
					component.WeaponInUseRightHand.TotalBullets += ((component.WeaponInUseLeftHand == null) ? AmmoCount : (AmmoCount / 2));
				}
				if (component.WeaponInUseLeftHand != null)
				{
					component.WeaponInUseLeftHand.TotalBullets += ((component.WeaponInUseRightHand == null) ? AmmoCount : (AmmoCount / 2));
				}
			}
			Object.Destroy(Object.Instantiate(Effect, base.transform.position, base.transform.rotation), 5f);
			Object.Destroy(base.gameObject, 0.1f);
		}
	}
}
