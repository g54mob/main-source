using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Kamgam.SettingsGenerator
{
	public class SettingsVolume : MonoBehaviour
	{
		private static SettingsVolume _instance;

		[NonSerialized]
		public Volume Volume;

		private static float _defaultPriority = 99f;

		protected List<ISettingsVolumeControl> _controls;

		[NonSerialized]
		protected bool _volumeWasRegisteredWithMananger;

		public static SettingsVolume Instance
		{
			get
			{
				if (!_instance)
				{
					_instance = new GameObject().AddComponent<SettingsVolume>();
					_instance.name = _instance.GetType().ToString();
					_instance.createVolume();
					UnityEngine.Object.DontDestroyOnLoad(_instance.gameObject);
				}
				return _instance;
			}
		}

		public static float Priority
		{
			get
			{
				if (_instance != null)
				{
					return _instance.Volume.priority;
				}
				return _defaultPriority;
			}
			set
			{
				_defaultPriority = value;
				if (_instance != null)
				{
					_instance.Volume.priority = value;
				}
			}
		}

		protected virtual void createVolume()
		{
			Volume = base.gameObject.AddComponent<Volume>();
			Volume.priority = _defaultPriority;
			Volume.profile = ScriptableObject.CreateInstance<VolumeProfile>();
			Volume.isGlobal = true;
		}

		public void MatchMainCameraLayer()
		{
			if (Camera.main != null && Volume != null)
			{
				int indexOfFirstLayerInMask = LayerUtils.GetIndexOfFirstLayerInMask(Camera.main.GetComponent<UniversalAdditionalCameraData>().volumeLayerMask);
				if (indexOfFirstLayerInMask >= 0)
				{
					Volume.gameObject.layer = indexOfFirstLayerInMask;
				}
			}
		}

		public TComp GetOrAddComponent<TComp>() where TComp : VolumeComponent
		{
			if (!Volume.profile.TryGet<TComp>(out var component))
			{
				return Volume.profile.Add<TComp>();
			}
			return component;
		}

		public T GetOrCreateControl<T>() where T : ISettingsVolumeControl, new()
		{
			bool isNew;
			return GetOrCreateControl<T>(out isNew);
		}

		public T GetOrCreateControl<T>(out bool isNew) where T : ISettingsVolumeControl, new()
		{
			if (_controls == null)
			{
				_controls = new List<ISettingsVolumeControl>();
			}
			foreach (ISettingsVolumeControl control in _controls)
			{
				if (control is T)
				{
					isNew = false;
					return (T)control;
				}
			}
			T val = new T();
			val.Initialize(this);
			_controls.Add(val);
			isNew = true;
			return val;
		}

		public T FindDefaultVolumeComponent<T>(bool useStackAsFallback = false, int layerMask = -1) where T : VolumeComponent
		{
			Camera main = Camera.main;
			if (main == null)
			{
				return null;
			}
			Volume[] volumes = VolumeManager.instance.GetVolumes(layerMask);
			foreach (Volume volume in volumes)
			{
				bool flag = main != null && (volume.transform.IsChildOf(main.transform) || volume.transform == main.transform);
				if ((volume.isGlobal || flag) && volume.isActiveAndEnabled && !(volume.profile == null) && !(volume == Volume) && volume.profile.TryGet<T>(out var component) && component.active)
				{
					return component;
				}
			}
			if (useStackAsFallback)
			{
				if (Camera.main != null)
				{
					unregisterFromVolumeMananger(Volume, Camera.main.gameObject.layer);
					VolumeManager.instance.Update(VolumeManager.instance.stack, Camera.main.transform, -1);
					if (VolumeManager.instance.stack != null)
					{
						T component2 = VolumeManager.instance.stack.GetComponent<T>();
						registerWithVolumeMananger(Volume, Camera.main.gameObject.layer);
						return component2;
					}
					Volume[] array = findVolumesInActiveScene(includeInactive: true);
					if (!array.IsNullOrEmpty())
					{
						Volume volume2 = null;
						volumes = array;
						foreach (Volume volume3 in volumes)
						{
							if (!(volume3 == Volume) && volume3.isGlobal && (volume2 == null || volume2.priority < volume3.priority))
							{
								volume2 = volume3;
							}
						}
						if (volume2 != null && volume2.profile.TryGet<T>(out var component3))
						{
							return component3;
						}
						if (Camera.main != null)
						{
							Vector3 position = Camera.main.transform.position;
							volumes = array;
							foreach (Volume volume4 in volumes)
							{
								if (!(volume4 == Volume) && !volume4.isGlobal && volume4.gameObject.TryGetComponent<Collider>(out var component4) && component4.bounds.Contains(position) && volume4.profile.TryGet<T>(out var component5))
								{
									return component5;
								}
							}
						}
					}
					return null;
				}
				return VolumeManager.instance.stack.GetComponent<T>();
			}
			return null;
		}

		private static Volume[] findVolumesInActiveScene(bool includeInactive = false)
		{
			return UnityEngine.Object.FindObjectsByType<Volume>(FindObjectsInactive.Include, FindObjectsSortMode.None);
		}

		private static void registerWithVolumeMananger(Volume volume, int layer)
		{
			VolumeManager.instance.Register(volume);
		}

		private static void unregisterFromVolumeMananger(Volume volume, int layer)
		{
			VolumeManager.instance.Unregister(volume);
		}

		public void Update()
		{
			if (!_volumeWasRegisteredWithMananger && VolumeManager.instance.isInitialized)
			{
				_volumeWasRegisteredWithMananger = true;
				unregisterFromVolumeMananger(Volume, Camera.main.gameObject.layer);
				registerWithVolumeMananger(Volume, Camera.main.gameObject.layer);
			}
		}
	}
}
