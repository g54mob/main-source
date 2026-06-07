using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Components
{
	[RequireComponent(typeof(Collider))]
	public class DamageOnTrigger3DComponent : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField]
		private float damageAmount = 10f;

		[Header("Logic")]
		[SerializeField]
		private UnityEvent onDamageDealt;

		[SerializeField]
		private UnityEvent onBehaviourFailed;

		[Header("Settings")]
		[SerializeField]
		private DebugLoggerComponent debugLoggerComponent;

		private void OnEnable()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
			GameObject objectToDamage = other.gameObject;
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
			Log("Will find ways to implement this to other scripts, maybe?");
		}

		private void Log(object message)
		{
			if ((bool)debugLoggerComponent)
			{
				debugLoggerComponent.LogMessageWithSender(message, this);
			}
		}
	}
}
