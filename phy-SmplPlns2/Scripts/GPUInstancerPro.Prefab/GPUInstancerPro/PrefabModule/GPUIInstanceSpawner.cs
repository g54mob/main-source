using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GPUInstancerPro.PrefabModule
{
	public class GPUIInstanceSpawner : MonoBehaviour
	{
		public enum SpawnMode
		{
			Sphere = 0,
			Grid = 1,
			Ring = 2
		}

		[Serializable]
		public class GPUIInstanceSpawnerInstantiatedPrefabEvent : UnityEvent<GameObject>
		{
		}

		public bool isRandomSeed = true;

		public int seed = 42;

		public SpawnMode spawnMode = SpawnMode.Grid;

		public int startInstanceCount;

		public List<GameObject> prefabObjects;

		public bool addInstantly = true;

		public float addSpeed;

		public float removeSpeed;

		public int maxAddCount = 1000;

		public bool3 randomRotation;

		public Quaternion rotation = Quaternion.identity;

		public Vector3 spacing = Vector3.one;

		public Vector3 randomPosition = Vector3.zero;

		public Vector3 center;

		public float distanceFromCenter = 100f;

		public float radius = 1f;

		public bool addAsChildGameObject = true;

		public Vector2 minMaxScale = Vector2.one;

		public GPUIInstanceSpawnerInstantiatedPrefabEvent instantiatedPrefabEvent;

		public Text instanceCountText;

		public Text currentInstanceCountText;

		public Slider instanceCountSlider;

		public RectTransform loadingPanel;

		private int _currentInstanceCount;

		private float _lastAddTime;

		private float _addWaitTime;

		private int _targetInstanceCount;

		private List<GameObject> _instances;

		private List<GameObject> _instancesToRemove;

		private List<GPUIPrefab> _addedInstances;

		private List<GameObject>[] _addedGOs;

		private GPUIPrefabManager _prefabManager;

		public float TargetInstanceCount
		{
			get
			{
				return _targetInstanceCount;
			}
			set
			{
				_targetInstanceCount = (int)value;
				if (_targetInstanceCount < 0)
				{
					_targetInstanceCount = 0;
				}
				if (instanceCountText != null)
				{
					instanceCountText.text = _targetInstanceCount.ToString();
				}
			}
		}

		private void Awake()
		{
			if (prefabObjects == null || prefabObjects.Count == 0)
			{
				base.enabled = false;
				return;
			}
			if (startInstanceCount < 0)
			{
				startInstanceCount = 0;
			}
			_instances = new List<GameObject>();
			_instancesToRemove = new List<GameObject>();
			_addedInstances = new List<GPUIPrefab>();
			_addedGOs = new List<GameObject>[prefabObjects.Count];
			for (int i = 0; i < _addedGOs.Length; i++)
			{
				_addedGOs[i] = new List<GameObject>();
			}
			TargetInstanceCount = startInstanceCount;
			if (instanceCountSlider != null)
			{
				instanceCountSlider.value = _targetInstanceCount;
			}
			if (instantiatedPrefabEvent == null)
			{
				instantiatedPrefabEvent = new GPUIInstanceSpawnerInstantiatedPrefabEvent();
			}
		}

		private void OnEnable()
		{
			UnityEngine.Random.InitState(isRandomSeed ? UnityEngine.Random.Range(100, 100000) : seed);
			if (_prefabManager == null)
			{
				_prefabManager = UnityEngine.Object.FindAnyObjectByType<GPUIPrefabManager>();
			}
			_lastAddTime = float.MinValue;
			if (!addInstantly && addSpeed > 0f)
			{
				_addWaitTime = 1f / addSpeed;
			}
			else
			{
				_addWaitTime = 0f;
			}
		}

		private void Update()
		{
			if (_instances.Count > _targetInstanceCount)
			{
				RemoveInstance();
			}
			else if (_instances.Count < _targetInstanceCount)
			{
				AddInstance();
			}
			else if (loadingPanel != null && loadingPanel.gameObject.activeSelf)
			{
				loadingPanel.gameObject.SetActive(value: false);
			}
			ApplyDelayedRemoval();
			UpdateCurrentInstanceCount();
		}

		[ContextMenu("Spawn Instances")]
		private void SpawnInstances()
		{
			if (!Application.isPlaying)
			{
				Awake();
			}
			if (_instances != null)
			{
				while (_instances.Count > _targetInstanceCount || _instances.Count < _targetInstanceCount)
				{
					Update();
				}
			}
		}

		private void AddInstance()
		{
			float time = Time.time;
			if (_addWaitTime > 0f && _addWaitTime > time - _lastAddTime)
			{
				return;
			}
			int num = 0;
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Quaternion quaternion2 = transform.rotation;
			Vector3 lossyScale = transform.lossyScale;
			bool flag = _prefabManager != null;
			do
			{
				int count = _instances.Count;
				Vector3 vector = Vector3.zero;
				Vector3 eulerAngles = rotation.eulerAngles;
				if (randomRotation.x)
				{
					eulerAngles.x = UnityEngine.Random.Range(0f, 360f);
				}
				if (randomRotation.y)
				{
					eulerAngles.y = UnityEngine.Random.Range(0f, 360f);
				}
				if (randomRotation.z)
				{
					eulerAngles.z = UnityEngine.Random.Range(0f, 360f);
				}
				Quaternion quaternion3 = Quaternion.Euler(eulerAngles);
				switch (spawnMode)
				{
				case SpawnMode.Sphere:
					vector = UnityEngine.Random.insideUnitSphere * radius + center;
					break;
				case SpawnMode.Grid:
				{
					int num2 = Mathf.FloorToInt(Mathf.Sqrt(count));
					int num3 = num2 * num2 + num2;
					vector.x = ((count >= num3) ? (count - num3) : num2);
					vector.z = ((count >= num3) ? num2 : (count - num2 * num2));
					vector.Scale(spacing);
					vector = quaternion2 * vector;
					vector += position + new Vector3(UnityEngine.Random.Range(0f - randomPosition.x, randomPosition.x), UnityEngine.Random.Range(0f - randomPosition.y, randomPosition.y), UnityEngine.Random.Range(0f - randomPosition.z, randomPosition.z));
					break;
				}
				case SpawnMode.Ring:
				{
					vector = UnityEngine.Random.insideUnitSphere * radius + center;
					float f = UnityEngine.Random.value * 360f;
					vector.x += Mathf.Cos(f) * distanceFromCenter;
					vector.z += Mathf.Sin(f) * distanceFromCenter;
					vector.Scale(lossyScale);
					vector = quaternion2 * vector;
					vector += position;
					break;
				}
				}
				int num4 = UnityEngine.Random.Range(0, prefabObjects.Count);
				GameObject gameObject = UnityEngine.Object.Instantiate(prefabObjects[num4], vector, quaternion3, addAsChildGameObject ? transform : null);
				instantiatedPrefabEvent.Invoke(gameObject);
				gameObject.name = gameObject.name + " [" + count + "]";
				gameObject.transform.localScale = Vector3.one * (UnityEngine.Random.value * (minMaxScale.y - minMaxScale.x) + minMaxScale.x);
				_instances.Add(gameObject);
				if (gameObject.TryGetComponent<GPUIPrefab>(out var component))
				{
					_addedInstances.Add(component);
				}
				else if (flag)
				{
					_addedGOs[num4].Add(gameObject);
				}
				num++;
				_lastAddTime = time;
			}
			while (addInstantly && _instances.Count < _targetInstanceCount && num < maxAddCount);
			if (_addedInstances.Count > 0)
			{
				GPUIPrefabAPI.AddPrefabInstances(_addedInstances);
			}
			_addedInstances.Clear();
			if (!flag)
			{
				return;
			}
			for (int i = 0; i < _addedGOs.Length; i++)
			{
				if (_addedGOs[i].Count > 0)
				{
					int prototypeIndex = _prefabManager.GetPrototypeIndex(prefabObjects[i]);
					if (prototypeIndex >= 0)
					{
						_prefabManager.AddPrefabInstances(_addedGOs[i], prototypeIndex);
					}
				}
				_addedGOs[i].Clear();
			}
		}

		private void RemoveInstance()
		{
			if (removeSpeed <= 0f)
			{
				for (int num = _instances.Count - 1; num >= _targetInstanceCount; num--)
				{
					GameObject gameObject = _instances[num];
					_instances.RemoveAt(num);
					if (!(gameObject == null))
					{
						if (gameObject.TryGetComponent<GPUIPrefab>(out var component) && component.IsInstanced)
						{
							GPUIPrefabAPI.RemovePrefabInstance(component);
						}
						UnityEngine.Object.Destroy(gameObject);
					}
				}
			}
			else
			{
				_instancesToRemove.Add(_instances[_instances.Count - 1]);
				_instances.RemoveAt(_instances.Count - 1);
			}
		}

		private void ApplyDelayedRemoval()
		{
			float deltaTime = Time.deltaTime;
			for (int i = 0; i < _instancesToRemove.Count; i++)
			{
				GameObject gameObject = _instancesToRemove[i];
				if (gameObject == null)
				{
					_instancesToRemove.RemoveAt(i);
					i--;
					continue;
				}
				gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Vector3.zero, removeSpeed * deltaTime * 100f);
				if (Vector3.Distance(gameObject.transform.position, Vector3.zero) < 0.5f)
				{
					if (gameObject.TryGetComponent<GPUIPrefab>(out var component) && component.IsInstanced)
					{
						component.RemovePrefabInstance();
					}
					UnityEngine.Object.Destroy(gameObject);
					_instancesToRemove.RemoveAt(i);
					i--;
				}
			}
		}

		private void UpdateCurrentInstanceCount()
		{
			if (_currentInstanceCount != _instances.Count + _instancesToRemove.Count)
			{
				_currentInstanceCount = _instances.Count + _instancesToRemove.Count;
				if (currentInstanceCountText != null)
				{
					currentInstanceCountText.text = _currentInstanceCount.ToString();
				}
			}
		}

		public void AddInstances(int amount)
		{
			TargetInstanceCount += amount;
		}

		public void RemoveInstances(int amount)
		{
			TargetInstanceCount -= amount;
		}
	}
}
