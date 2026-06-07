using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Unique.Cthulhu
{
	public class CthulhuFreeze : MonoBehaviour
	{
		private Animator _animator;

		private CthulhuBrains _brains;

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (IsCockpit(other))
			{
				_animator.enabled = false;
				_brains.FadeInBrainLoop();
			}
		}

		protected virtual void OnTriggerExit(Collider other)
		{
			if (IsCockpit(other))
			{
				_animator.enabled = true;
				_brains.FadeOutBrainLoop();
			}
		}

		protected virtual void Start()
		{
			_animator = GetComponentInParent<Animator>();
			_brains = GetComponentInParent<CthulhuBrains>();
		}

		private bool IsCockpit(Collider collider)
		{
			return collider == FlightSceneScript.Instance.LocalPlayer?.Aircraft?.MainCockpit.PrimaryPartCollider;
		}
	}
}
