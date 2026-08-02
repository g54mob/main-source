using JUTPS.CharacterBrain;
using JUTPS.DestructibleSystem;
using UnityEngine;

namespace JUTPS.PhysicsScripts
{
	[AddComponentMenu("JU TPS/Physics/Explosion")]
	public class Explosion : MonoBehaviour
	{
		[Header("Explosion Settings")]
		public bool ExplodeOnAwake;

		public float ExplosionForce = 5f;

		public float ExplosionUpForce = 3f;

		public float ExplosionRadious = 5f;

		[Header("Damage Characters")]
		public bool DamageCharacters;

		public LayerMask CharacterLayer;

		public float Damage = 100f;

		private void Start()
		{
			if (ExplodeOnAwake)
			{
				Explode();
			}
		}

		public void AddExplode(float ExplosionForce, float ExplosionUpForce, float ExplosionRadious)
		{
			Vector3 position = base.transform.position;
			Collider[] array = Physics.OverlapSphere(position, ExplosionRadious);
			for (int i = 0; i < array.Length; i++)
			{
				Rigidbody component = array[i].GetComponent<Rigidbody>();
				if (component != null)
				{
					component.AddExplosionForce(ExplosionForce, position, ExplosionRadious, ExplosionUpForce);
				}
			}
		}

		public void Explode()
		{
			Invoke("doExplosionForce", 0.1f);
			if (!DamageCharacters)
			{
				return;
			}
			Collider[] array = Physics.OverlapSphere(base.transform.position, ExplosionRadious, CharacterLayer);
			foreach (Collider obj in array)
			{
				JUCharacterBrain component = obj.GetComponent<JUCharacterBrain>();
				JUHealth component2 = obj.GetComponent<JUHealth>();
				if (obj.TryGetComponent<DestructibleObject>(out var component3))
				{
					component3.FractureThisObject();
				}
				if (component != null)
				{
					Debug.DrawLine(component.transform.position, base.transform.position, Color.yellow, 2f, depthTest: true);
					Physics.Linecast(base.transform.position, component.HumanoidSpine.position, out var hitInfo);
					if (hitInfo.collider != null && hitInfo.collider.gameObject == component.gameObject)
					{
						float damage = (int)Mathf.Lerp(Damage, Damage / 10f, Vector3.Distance(component.transform.position, base.transform.position) / ExplosionRadious);
						if (component != null)
						{
							component.TakeDamage(damage);
						}
					}
				}
				if (component == null && component2 != null)
				{
					float damage2 = (int)Mathf.Lerp(Damage, Damage / 10f, Vector3.Distance(component2.transform.position, base.transform.position) / ExplosionRadious);
					component2.DoDamage(damage2);
				}
			}
		}

		public void doExplosionForce()
		{
			Vector3 position = base.transform.position;
			Collider[] array = Physics.OverlapSphere(position, ExplosionRadious);
			for (int i = 0; i < array.Length; i++)
			{
				Rigidbody component = array[i].GetComponent<Rigidbody>();
				if (component != null)
				{
					component.AddExplosionForce(ExplosionForce, position, ExplosionRadious, ExplosionUpForce, ForceMode.Impulse);
				}
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(base.transform.position, ExplosionRadious);
		}
	}
}
