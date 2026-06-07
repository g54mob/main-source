using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Unique.Cthulhu
{
	public class CthulhuReveal : MonoBehaviour
	{
		private Animator _animator;

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (IsCockpit(other))
			{
				_animator.SetTrigger("Rise Trigger");
			}
		}

		protected virtual void OnTriggerExit(Collider other)
		{
			if (IsCockpit(other))
			{
				_animator.SetTrigger("Sink Trigger");
			}
		}

		protected virtual void Start()
		{
			_animator = GetComponentInParent<Animator>();
		}

		private bool IsCockpit(Collider collider)
		{
			return collider == FlightSceneScript.Instance.LocalPlayer?.Aircraft?.MainCockpit.PrimaryPartCollider;
		}
	}
}
