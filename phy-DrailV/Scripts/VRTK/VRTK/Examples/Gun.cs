using UnityEngine;

namespace VRTK.Examples
{
	public class Gun : VRTK_InteractableObject
	{
		private GameObject bullet;

		private float bulletSpeed = 1000f;

		private float bulletLife = 5f;

		public override void StartUsing(VRTK_InteractUse usingObject)
		{
			base.StartUsing(usingObject);
			FireBullet();
		}

		protected void Start()
		{
			bullet = base.transform.Find("Bullet").gameObject;
			bullet.SetActive(value: false);
		}

		private void FireBullet()
		{
			GameObject obj = Object.Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
			obj.SetActive(value: true);
			obj.GetComponent<Rigidbody>().AddForce(-bullet.transform.forward * bulletSpeed);
			Object.Destroy(obj, bulletLife);
		}
	}
}
