using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class VFXManager : MonoBehaviour, IGive<VFXData, TrailTarget>
	{
		private static VFXManager _worldManager;

		[SerializeField]
		private bool _isWorldManager;

		private readonly Dictionary<VFXData, TrailTarget> _trailTargets = new Dictionary<VFXData, TrailTarget>();

		private readonly Bictionary<VFXData, VFXTimer> _currentVFX = new Bictionary<VFXData, VFXTimer>();

		public static VFXManager WorldManager
		{
			get
			{
				if ((bool)_worldManager)
				{
					return _worldManager;
				}
				_worldManager = new GameObject("World VFX Manager").AddComponent<VFXManager>();
				return _worldManager;
			}
		}

		private void Awake()
		{
			if (_isWorldManager)
			{
				_worldManager = this;
			}
		}

		public void Play(VFXData data, Transform spawnParent, bool spawnAsChild = true)
		{
			if ((object)data == null)
			{
				throw new ArgumentNullException("data");
			}
			if ((object)spawnParent == null)
			{
				throw new ArgumentNullException("spawnParent");
			}
			if (_currentVFX.TryGet(data, out var value))
			{
				value.ReturnedToPool -= OnVFXReturnedToPool;
				if (value.IsLoop && value.IsPlaying)
				{
					value.Stop();
				}
				_currentVFX.Remove(value);
			}
			value = (spawnAsChild ? Pooler.Pull(data.Prefab, spawnParent) : Pooler.Pull(data.Prefab));
			value.transform.SetPositionAndRotation(spawnParent);
			value.ReturnedToPool += OnVFXReturnedToPool;
			_currentVFX.Add(value, data);
			ResolveDependencies(value.gameObject, data);
			value.gameObject.SetActive(value: true);
		}

		public void Play(VFXData data, Vector3 position, Quaternion rotation, Transform parent = null, bool worldPosition = false)
		{
			if ((object)data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (_currentVFX.TryGet(data, out var value))
			{
				value.ReturnedToPool -= OnVFXReturnedToPool;
				if (value.IsLoop && value.IsPlaying)
				{
					value.Stop();
				}
				_currentVFX.Remove(value);
			}
			value = (parent ? Pooler.Pull(data.Prefab, parent) : Pooler.Pull(data.Prefab, base.transform));
			if (worldPosition)
			{
				value.transform.SetPositionAndRotation(position, rotation);
			}
			else
			{
				value.transform.SetLocalPositionAndRotation(position, rotation);
			}
			value.ReturnedToPool += OnVFXReturnedToPool;
			_currentVFX.Add(value, data);
			ResolveDependencies(value.gameObject, data);
			value.gameObject.SetActive(value: true);
		}

		public void Kill(VFXData vfxData)
		{
			if (_currentVFX.TryGet(vfxData, out var value))
			{
				_ = value.IsLoop;
				value.ReturnedToPool -= OnVFXReturnedToPool;
				value.Stop();
				_currentVFX.Remove(vfxData);
			}
		}

		private void ResolveDependencies(GameObject vfxInstance, VFXData vfxData)
		{
			IDependencyResolver<VFXData>[] componentsInChildren = vfxInstance.GetComponentsInChildren<IDependencyResolver<VFXData>>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].ResolveDependencies(vfxInstance, vfxData);
			}
		}

		private void OnVFXReturnedToPool(VFXTimer vfxInstance)
		{
			vfxInstance.ReturnedToPool -= OnVFXReturnedToPool;
			if (_currentVFX.Contains(vfxInstance))
			{
				_currentVFX.Remove(vfxInstance);
			}
		}

		public void SetTrailTarget(VFXData vfxData, Transform target)
		{
			_trailTargets[vfxData] = new TrailTarget(target);
		}

		public TrailTarget Get(VFXData key)
		{
			if (!_trailTargets.TryGetValue(key, out var value))
			{
				return default(TrailTarget);
			}
			return value;
		}
	}
}
