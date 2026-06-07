using UnityEngine;

namespace VRTK.Examples
{
	public class GunShoot : MonoBehaviour
	{
		public VRTK_InteractableObject linkedObject;

		public GameObject projectile;

		public Transform projectileSpawnPoint;

		public float projectileSpeed = 1000f;

		public float projectileLife = 5f;

		protected virtual void OnEnable()
		{
			linkedObject = ((linkedObject == null) ? GetComponent<VRTK_InteractableObject>() : linkedObject);
			if (linkedObject != null)
			{
				linkedObject.InteractableObjectUsed += InteractableObjectUsed;
			}
		}

		protected virtual void OnDisable()
		{
			if (linkedObject != null)
			{
				linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
			}
		}

		protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
		{
			FireProjectile();
		}

		protected virtual void FireProjectile()
		{
			if (projectile != null && projectileSpawnPoint != null)
			{
				GameObject gameObject = Object.Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
				Rigidbody component = gameObject.GetComponent<Rigidbody>();
				float t = 0f;
				if (component != null)
				{
					component.AddForce(gameObject.transform.forward * projectileSpeed);
					t = projectileLife;
				}
				Object.Destroy(gameObject, t);
			}
		}
	}
}
