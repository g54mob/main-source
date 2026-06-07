using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	[RequireComponent(typeof(Collider))]
	public abstract class GPUIColliderHelper<T> : MonoBehaviour where T : GPUIPrefabExtension
	{
		[SerializeField]
		protected Transform _followTransform;

		protected Collider _collider;

		protected List<T> _enteredInstances;

		protected Transform _cachedTransform;

		protected virtual void OnEnable()
		{
			_collider = GetComponent<Collider>();
			_enteredInstances = new List<T>();
			_cachedTransform = base.transform;
		}

		private void Update()
		{
			if (_collider == null)
			{
				return;
			}
			if (_followTransform != null)
			{
				_cachedTransform.position = _followTransform.position;
			}
			for (int i = 0; i < _enteredInstances.Count; i++)
			{
				T val = _enteredInstances[i];
				if (val == null)
				{
					_enteredInstances.RemoveAt(i);
					i--;
				}
				else if (!IsInsideCollider(val) && OnExitedCollider(val))
				{
					_enteredInstances.RemoveAt(i);
					i--;
				}
				else
				{
					OnUpdate(val);
				}
			}
		}

		private void OnTriggerEnter(Collider collider)
		{
			if (collider.gameObject.TryGetComponent<T>(out var component))
			{
				_enteredInstances.Add(component);
				OnEnteredCollider(component);
			}
		}

		protected bool IsInsideCollider(T instance)
		{
			if (_collider == null)
			{
				return false;
			}
			return _collider.bounds.Contains(instance.CachedTransform.position);
		}

		protected abstract void OnEnteredCollider(T instance);

		protected abstract bool OnExitedCollider(T instance);

		protected abstract void OnUpdate(T instance);
	}
}
