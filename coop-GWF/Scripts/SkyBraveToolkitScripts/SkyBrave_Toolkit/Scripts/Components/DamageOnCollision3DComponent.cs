using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	[RequireComponent(typeof(Collider), typeof(Rigidbody))]
	public class DamageOnCollision3DComponent : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField]
		private float damageAmount = 10f;

		[Header("Logic")]
		[SerializeField]
		private UnityEvent onDamageDealt;

		[SerializeField]
		private UnityEvent onBehaviourFailed;

		private void OnEnable()
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
			GameObject objectToDamage = collision.gameObject;
			TryDamageObject(objectToDamage);
		}

		private void TryDamageObject(GameObject objectToDamage)
		{
			if (objectToDamage.TryGetComponent<DamageableComponent>(out var component))
			{
				component.DealDamage(damageAmount);
				onDamageDealt.Invoke();
			}
			else
			{
				onBehaviourFailed.Invoke();
			}
		}
	}
}
