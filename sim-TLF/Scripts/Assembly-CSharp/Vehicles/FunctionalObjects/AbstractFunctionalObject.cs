using UnityEngine;
using UnityEngine.Events;

namespace Vehicles.FunctionalObjects
{
	public abstract class AbstractFunctionalObject : MonoBehaviour
	{
		public UnityEvent OnEnabled;

		public UnityEvent OnDisabled;

		[SerializeField]
		protected bool _enabled;

		public bool Enabled => _enabled;

		private void UpdateEnableStatus()
		{
			if (_enabled)
			{
				OnEnabled?.Invoke();
			}
			else
			{
				OnDisabled?.Invoke();
			}
		}

		public virtual void TryEnable()
		{
			if (!_enabled)
			{
				_enabled = true;
				OnEnabled?.Invoke();
			}
		}

		public virtual void TryDisable()
		{
			if (_enabled)
			{
				_enabled = false;
				OnDisabled?.Invoke();
			}
		}
	}
}
