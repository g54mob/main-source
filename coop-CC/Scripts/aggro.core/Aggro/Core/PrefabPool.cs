using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aggro.Core
{
	internal class PrefabPool : MonoBehaviour, IGameObjectPool
	{
		[SerializeField]
		private bool _disablePermanentOnRelease;

		private Stack<GameObject> _pool = new Stack<GameObject>();

		private List<GameObject> _disabled = new List<GameObject>();

		[NonSerialized]
		private bool _initialized;

		[NonSerialized]
		private bool _hasGatheredEnabledBehaviours;

		[SerializeField]
		[HideInInspector]
		private List<Behaviour> _enabledBehaviours = new List<Behaviour>();

		public void Populate(int count)
		{
			CheckInitialization();
			if (!GameObjectPoolManager.IsPopulationEnabled())
			{
				return;
			}
			if (!_hasGatheredEnabledBehaviours)
			{
				_hasGatheredEnabledBehaviours = true;
				_enabledBehaviours.Clear();
				Behaviour[] componentsInChildren = GetComponentsInChildren<Behaviour>();
				foreach (Behaviour behaviour in componentsInChildren)
				{
					if (behaviour.enabled)
					{
						_enabledBehaviours.Add(behaviour);
					}
				}
			}
			try
			{
				for (int j = 0; j < _enabledBehaviours.Count; j++)
				{
					_enabledBehaviours[j].enabled = false;
				}
				while (_pool.Count < count)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(base.gameObject, GameObjectPoolManager.GetContainer());
					gameObject.SetActive(value: false);
					PrefabPool component = gameObject.GetComponent<PrefabPool>();
					for (int k = 0; k < component._enabledBehaviours.Count; k++)
					{
						component._enabledBehaviours[k].enabled = true;
					}
					UnityEngine.Object.Destroy(component);
					_pool.Push(gameObject);
				}
			}
			finally
			{
				for (int l = 0; l < _enabledBehaviours.Count; l++)
				{
					_enabledBehaviours[l].enabled = true;
				}
			}
		}

		public PoolableReference Get()
		{
			GameObject gameObject = null;
			if (_pool.Count > 0)
			{
				gameObject = _pool.Pop();
				gameObject.SetActive(value: true);
			}
			if ((object)gameObject == null)
			{
				CheckInitialization();
				gameObject = UnityEngine.Object.Instantiate(base.gameObject, GameObjectPoolManager.GetContainer());
				UnityEngine.Object.Destroy(gameObject.GetComponent<PrefabPool>());
			}
			return new PoolableReference
			{
				obj = gameObject,
				pool = this
			};
		}

		public void Release(GameObject obj)
		{
			obj.transform.SetParent(GameObjectPoolManager.GetContainer());
			obj.SetActive(value: false);
			if (_disablePermanentOnRelease)
			{
				_disabled.Add(obj);
			}
			else
			{
				_pool.Push(obj);
			}
		}

		private void Clear()
		{
			_initialized = false;
			_pool.Clear();
			_disabled.Clear();
		}

		private void ClearDisabled()
		{
			for (int i = 0; i < _disabled.Count; i++)
			{
				UnityEngine.Object.Destroy(_disabled[i]);
			}
			_disabled.Clear();
		}

		private void CheckInitialization()
		{
			if (!_initialized)
			{
				_initialized = true;
				GameObjectPoolManager.RegisterClear(Clear);
				GameObjectPoolManager.RegisterClearDisabled(ClearDisabled);
			}
		}
	}
}
