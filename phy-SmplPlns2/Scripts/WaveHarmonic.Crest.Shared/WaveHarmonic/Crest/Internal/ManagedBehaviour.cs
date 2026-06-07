using System;

namespace WaveHarmonic.Crest.Internal
{
	public abstract class ManagedBehaviour<T> : CustomBehaviour where T : ManagerBehaviour<T>
	{
		private readonly Action<T> _OnUpdate;

		private readonly Action<T> _OnLateUpdate;

		private readonly Action<T> _OnFixedUpdate;

		private readonly Action<T> _OnEnable;

		private readonly Action<T> _OnDisable;

		private protected virtual Action<T> OnUpdateMethod => null;

		private protected virtual Action<T> OnLateUpdateMethod => null;

		private protected virtual Action<T> OnFixedUpdateMethod => null;

		private protected virtual Action<T> OnEnableMethod => null;

		private protected virtual Action<T> OnDisableMethod => null;

		public ManagedBehaviour()
		{
			if (OnUpdateMethod != null)
			{
				_OnUpdate = OnUpdateMethod.Invoke;
			}
			if (OnLateUpdateMethod != null)
			{
				_OnLateUpdate = OnLateUpdateMethod.Invoke;
			}
			if (OnFixedUpdateMethod != null)
			{
				_OnFixedUpdate = OnFixedUpdateMethod.Invoke;
			}
			if (OnEnableMethod != null)
			{
				_OnEnable = OnEnableMethod.Invoke;
			}
			if (OnDisableMethod != null)
			{
				_OnDisable = OnDisableMethod.Invoke;
			}
		}

		private protected override void OnEnable()
		{
			base.OnEnable();
			UpdateSubscription(listen: true);
			if (_OnEnable != null && ManagerBehaviour<T>.Instance != null)
			{
				_OnEnable(ManagerBehaviour<T>.Instance);
			}
		}

		private protected virtual void OnDisable()
		{
			UpdateSubscription(listen: false);
			if (_OnDisable != null && ManagerBehaviour<T>.Instance != null)
			{
				_OnDisable(ManagerBehaviour<T>.Instance);
			}
		}

		private void UpdateSubscription(bool listen)
		{
			if (_OnUpdate != null)
			{
				ManagerBehaviour<T>.s_OnUpdate.Remove(_OnUpdate);
				if (listen)
				{
					ManagerBehaviour<T>.s_OnUpdate.Add(_OnUpdate);
				}
			}
			if (_OnLateUpdate != null)
			{
				ManagerBehaviour<T>.s_OnLateUpdate.Remove(_OnLateUpdate);
				if (listen)
				{
					ManagerBehaviour<T>.s_OnLateUpdate.Add(_OnLateUpdate);
				}
			}
			if (_OnFixedUpdate != null)
			{
				ManagerBehaviour<T>.s_OnFixedUpdate.Remove(_OnFixedUpdate);
				if (listen)
				{
					ManagerBehaviour<T>.s_OnFixedUpdate.Add(_OnFixedUpdate);
				}
			}
			if (_OnEnable != null)
			{
				ManagerBehaviour<T>.s_OnEnable.Remove(_OnEnable);
				if (listen)
				{
					ManagerBehaviour<T>.s_OnEnable.Add(_OnEnable);
				}
			}
			if (_OnDisable != null)
			{
				ManagerBehaviour<T>.s_OnDisable.Remove(_OnDisable);
				if (listen)
				{
					ManagerBehaviour<T>.s_OnDisable.Add(_OnDisable);
				}
			}
		}
	}
}
