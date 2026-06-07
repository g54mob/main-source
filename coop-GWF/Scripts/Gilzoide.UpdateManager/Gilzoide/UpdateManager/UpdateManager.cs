using System;
using Gilzoide.UpdateManager.Internal;
using Gilzoide.UpdateManager.Jobs;
using UnityEngine;

namespace Gilzoide.UpdateManager
{
	[ExecuteAlways]
	public class UpdateManager : MonoBehaviour
	{
		protected static UpdateManager _instance;

		private readonly FastRemoveList<IUpdatable> _updatableObjects = new FastRemoveList<IUpdatable>();

		private readonly FastRemoveList<ILateUpdatable> _lateUpdatableObjects = new FastRemoveList<ILateUpdatable>();

		private readonly FastRemoveList<IFixedUpdatable> _fixedUpdatableObjects = new FastRemoveList<IFixedUpdatable>();

		public static UpdateManager Instance
		{
			get
			{
				if (!ApplicationUtils.IsQuitting && !(_instance != null))
				{
					return _instance = CreateInstance();
				}
				return _instance;
			}
		}

		public bool HasRegisteredObjects
		{
			get
			{
				if (_updatableObjects.Count <= 0 && _lateUpdatableObjects.Count <= 0)
				{
					return _fixedUpdatableObjects.Count > 0;
				}
				return true;
			}
		}

		private static UpdateManager CreateInstance()
		{
			GameObject obj = new GameObject("UpdateManager")
			{
				hideFlags = HideFlags.DontSave
			};
			UnityEngine.Object.DontDestroyOnLoad(obj);
			return obj.AddComponent<UpdateManager>();
		}

		protected void Update()
		{
			UpdateJobTime.InstanceRef.Refresh();
			foreach (IUpdatable updatableObject in _updatableObjects)
			{
				try
				{
					updatableObject.ManagedUpdate();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		protected void LateUpdate()
		{
			foreach (ILateUpdatable lateUpdatableObject in _lateUpdatableObjects)
			{
				try
				{
					lateUpdatableObject.ManagedLateUpdate();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		protected void FixedUpdate()
		{
			foreach (IFixedUpdatable fixedUpdatableObject in _fixedUpdatableObjects)
			{
				try
				{
					fixedUpdatableObject.ManagedFixedUpdate();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		public void Register(IManagedObject obj)
		{
			if (obj is IUpdatable value)
			{
				_updatableObjects.Add(value);
			}
			if (obj is ILateUpdatable value2)
			{
				_lateUpdatableObjects.Add(value2);
			}
			if (obj is IFixedUpdatable value3)
			{
				_fixedUpdatableObjects.Add(value3);
			}
			base.enabled = HasRegisteredObjects;
		}

		public void Unregister(IManagedObject obj)
		{
			if (obj is IUpdatable value)
			{
				_updatableObjects.Remove(value);
			}
			if (obj is ILateUpdatable value2)
			{
				_lateUpdatableObjects.Remove(value2);
			}
			if (obj is IFixedUpdatable value3)
			{
				_fixedUpdatableObjects.Remove(value3);
			}
			base.enabled = HasRegisteredObjects;
		}

		public void Clear()
		{
			_updatableObjects.Clear();
			_lateUpdatableObjects.Clear();
			_fixedUpdatableObjects.Clear();
			base.enabled = false;
		}
	}
}
