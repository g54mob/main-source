using System;
using System.Collections.Generic;
using UnityConsole;
using UnityEngine;
using UnityEngine.Audio;

namespace TH20
{
	[DontSave]
	public class AudioListenerManager : MustCallDestroy
	{
		private readonly GameObject _gameObject;

		private readonly MetagameMap _metagameMap;

		private readonly Level _level;

		private readonly LevelCameraManager _levelCameraManager;

		private readonly AudioListenerManagerConfig _config;

		private Vector3 _listenerPosition;

		private readonly float _minRadius;

		private readonly float _maxRadius;

		public bool ShowDebugRadius;

		public static AudioListenerManager Instance { get; private set; }

		public float Radius { get; private set; }

		public Vector3 ListenerPosition => _listenerPosition;

		public float StandardMinRadius => Radius * _config.MinRadiusFraction;

		public float StandardMaxRadius => Radius * _config.MaxRadiusFraction;

		public List<AudioMixerGroup> InHositalAudioMixerGroups => _config.InHositalAudioMixerGroups;

		public float ClosestLowPassRadius => Radius * _config.ClosestLowPassRadius;

		public float FurthestLowPassRadius => Radius * _config.FurthestLowPassRadius;

		public float ClosestLowPassCutoffFrequency => _config.ClosestLowPassCutoffFrequency;

		public float FurthestLowPassCutoffFrequency => _config.FurthestLowPassCutoffFrequency;

		public AudioListenerManager(MetagameMap metagameMap, Level level, LevelCameraManager levelCameraManager, AudioListenerManagerConfig config)
		{
			_metagameMap = metagameMap;
			_level = level;
			_gameObject = new GameObject("Level Audio Listener");
			_gameObject.AddComponent<AudioListener>();
			_levelCameraManager = levelCameraManager;
			_config = config;
			_minRadius = config.MinRadiusCap;
			_maxRadius = config.MaxRadiusCap;
			MetagameMap metagameMap2 = _metagameMap;
			metagameMap2.OnOpen = (Action)Delegate.Combine(metagameMap2.OnOpen, new Action(OnMetagameMapOpen));
			MetagameMap metagameMap3 = _metagameMap;
			metagameMap3.OnClose = (Action)Delegate.Combine(metagameMap3.OnClose, new Action(OnMetagameMapClose));
			ConsoleCommandsDatabase.RegisterCommand("ToggleSFXRadiusGizmos", "Toggle SFX Radius Gizmos", "Toggle SFX Radius Gizmos. Green circles are minimum radius and red circles are max radius", ToggleSFXRadius);
			Instance = this;
		}

		private void OnMetagameMapOpen()
		{
			if (_gameObject != null)
			{
				_gameObject.SetActive(value: false);
			}
		}

		private void OnMetagameMapClose()
		{
			if (_metagameMap.Level == _level && _gameObject != null)
			{
				_gameObject.SetActive(value: true);
			}
		}

		public float GetSignedFalloffDistance(Vector3 position)
		{
			if (_levelCameraManager.CurrentLevelCamera != null)
			{
				Plane[] frustumPlanes = _levelCameraManager.CurrentLevelCamera.FrustumPlanes;
				float num = float.PositiveInfinity;
				Plane[] array = frustumPlanes;
				foreach (Plane plane in array)
				{
					num = Mathf.Min(num, plane.GetDistanceToPoint(position));
				}
				return num;
			}
			return 0f - _config.SilentFrustumDistance;
		}

		public float Get3DHospitalFalloffValue(Vector3 position)
		{
			float signedFalloffDistance = GetSignedFalloffDistance(position);
			if (signedFalloffDistance > 0f)
			{
				return 1f;
			}
			return Mathf.Lerp(1f, 0f, (0f - signedFalloffDistance) / _config.SilentFrustumDistance);
		}

		private ConsoleCommandResult ToggleSFXRadius(params string[] args)
		{
			ShowDebugRadius = !ShowDebugRadius;
			if (ShowDebugRadius)
			{
				return ConsoleCommandResult.Succeeded("Enabled");
			}
			return ConsoleCommandResult.Succeeded("Disabled");
		}

		public void Update()
		{
			TopDownCameraLogic currentLevelCamera = _levelCameraManager.CurrentLevelCamera;
			if (currentLevelCamera == null)
			{
				return;
			}
			Camera cameraComponent = currentLevelCamera.CameraComponent;
			Plane plane = new Plane(Vector3.up, new Vector3(0f, _config.ListenerHeight, 0f));
			Ray ray = new Ray(cameraComponent.transform.position, cameraComponent.transform.forward);
			Vector3 zero = Vector3.zero;
			int num = 0;
			float enter;
			for (int i = 0; i < 4; i++)
			{
				Ray ray2 = new Ray(currentLevelCamera.CameraComponent.transform.position, currentLevelCamera.FrustumCorners[i]);
				if (plane.Raycast(ray2, out enter))
				{
					zero += ray2.GetPoint(enter);
					num++;
				}
			}
			if (num == 4)
			{
				zero *= 0.25f;
				_gameObject.transform.position = zero;
				_listenerPosition = zero;
			}
			else if (plane.Raycast(ray, out enter))
			{
				_gameObject.transform.position = ray.GetPoint(enter);
				_listenerPosition = ray.GetPoint(enter);
			}
			_gameObject.transform.forward = cameraComponent.transform.forward;
			Plane plane2 = new Plane(Vector3.up, new Vector3(0f, 0f, 0f));
			float num2 = 0f;
			Vector3 a = _gameObject.transform.position;
			for (int j = 0; j < 4; j++)
			{
				Ray ray3 = new Ray(currentLevelCamera.CameraComponent.transform.position, currentLevelCamera.FrustumCorners[j]);
				if (plane2.Raycast(ray3, out var enter2) && enter2 > num2)
				{
					num2 = enter2;
					a = ray3.GetPoint(enter2);
				}
			}
			Radius = Mathf.Clamp(Vector3.Distance(a, _gameObject.transform.position), _minRadius, _maxRadius);
		}

		public override void Destroy()
		{
			ConsoleCommandsDatabase.UnRegisterCommand("ToggleSFXRadiusGizmos");
			MetagameMap metagameMap = _metagameMap;
			metagameMap.OnOpen = (Action)Delegate.Remove(metagameMap.OnOpen, new Action(OnMetagameMapOpen));
			MetagameMap metagameMap2 = _metagameMap;
			metagameMap2.OnClose = (Action)Delegate.Remove(metagameMap2.OnClose, new Action(OnMetagameMapClose));
			if (_gameObject != null)
			{
				UnityEngine.Object.Destroy(_gameObject);
			}
			Instance = null;
			base.Destroy();
		}
	}
}
