using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Rendering.Events;
using Jundroo.Common.Attributes;
using UnityEngine;

namespace Assets.Scripts.Rendering
{
	public class LodScript : MonoBehaviour
	{
		[Serializable]
		public class LodLevel
		{
			[SerializeField]
			private float _distance;

			[SerializeField]
			private float _distanceMobile;

			[SerializeField]
			private List<GameObject> _gameObjects;

			[SerializeField]
			private List<MeshRenderer> _meshRenderers;

			public float Distance => _distance;

			public float DistanceSquared { get; private set; }

			public IReadOnlyList<GameObject> GameObjects => _gameObjects;

			public int Level { get; private set; }

			public IReadOnlyList<MeshRenderer> MeshRenderers => _meshRenderers;

			public void Disable()
			{
				foreach (MeshRenderer meshRenderer in _meshRenderers)
				{
					meshRenderer.enabled = false;
				}
				foreach (GameObject gameObject in _gameObjects)
				{
					gameObject.SetActive(value: false);
				}
			}

			public void Enable()
			{
				foreach (MeshRenderer meshRenderer in _meshRenderers)
				{
					meshRenderer.enabled = true;
				}
				foreach (GameObject gameObject in _gameObjects)
				{
					gameObject.SetActive(value: true);
				}
			}

			public void Initialize(int level, bool enabled)
			{
				Level = level;
				DistanceSquared = Distance * Distance;
				SetEnabled(enabled);
			}

			public void SetEnabled(bool enabled)
			{
				foreach (MeshRenderer meshRenderer in _meshRenderers)
				{
					meshRenderer.enabled = enabled;
				}
				foreach (GameObject gameObject in _gameObjects)
				{
					gameObject.SetActive(enabled);
				}
			}
		}

		private Transform _cameraTransform;

		[SerializeField]
		[ReadOnlyInInspector]
		private int _currentLevel;

		[SerializeField]
		private Transform _distanceTransform;

		[SerializeField]
		private List<LodLevel> _lodLevels;

		public int CurrentLevel
		{
			get
			{
				return _currentLevel;
			}
			set
			{
				if (_currentLevel != value)
				{
					if (value < 0 || value >= _lodLevels.Count)
					{
						throw new ArgumentOutOfRangeException($"LOD Level '{value}' is out of the range of available LOD levels.");
					}
					int currentLevel = _currentLevel;
					_lodLevels[currentLevel].Disable();
					_lodLevels[value].Enable();
					_currentLevel = value;
					this.LodLevelChanged?.Invoke(this, new LodLevelChangedEvent(this, currentLevel, value));
				}
			}
		}

		public Transform DistanceTransform
		{
			get
			{
				return _distanceTransform;
			}
			set
			{
				_distanceTransform = value;
			}
		}

		public IReadOnlyList<LodLevel> LodLevels => _lodLevels;

		public event EventHandler<LodLevelChangedEvent> LodLevelChanged;

		protected virtual void Awake()
		{
			if (_distanceTransform == null)
			{
				_distanceTransform = base.transform;
			}
		}

		protected virtual void LateUpdate()
		{
			Vector3 obj = _cameraTransform?.position ?? Camera.main.transform.position;
			Vector3 position = _distanceTransform.position;
			float sqrMagnitude = (obj - position).sqrMagnitude;
			int num = _lodLevels.Count - 1;
			int num2 = num - 1;
			while (num2 >= 0 && sqrMagnitude <= _lodLevels[num2].DistanceSquared)
			{
				num = num2;
				num2--;
			}
			CurrentLevel = num;
		}

		protected virtual void Start()
		{
			_cameraTransform = CameraManagerScript.Instance?.CameraTransform;
			_lodLevels.FirstOrDefault()?.Initialize(0, enabled: true);
			for (int i = 1; i < _lodLevels.Count; i++)
			{
				_lodLevels[i].Initialize(i, enabled: false);
			}
		}
	}
}
