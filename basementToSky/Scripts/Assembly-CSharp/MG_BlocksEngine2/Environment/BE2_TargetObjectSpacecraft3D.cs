using System.Collections;
using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_TargetObjectSpacecraft3D : BE2_TargetObject
	{
		private GameObject _bullet;

		public new Transform Transform => base.transform;

		private void Awake()
		{
			foreach (Transform item in base.transform)
			{
				if (item.name == "Bullet")
				{
					_bullet = item.gameObject;
				}
			}
		}

		public void Shoot()
		{
			GameObject gameObject = Object.Instantiate(_bullet, _bullet.transform.position, Quaternion.identity);
			gameObject.SetActive(value: true);
			gameObject.GetComponent<Rigidbody>().AddForce(base.transform.forward * 1000f);
			StartCoroutine(C_DestroyTime(gameObject));
		}

		private IEnumerator C_DestroyTime(GameObject go)
		{
			yield return new WaitForSeconds(1f);
			Object.Destroy(go);
		}
	}
}
