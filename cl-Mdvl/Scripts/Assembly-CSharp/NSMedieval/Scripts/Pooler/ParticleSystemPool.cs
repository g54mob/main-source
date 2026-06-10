using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Map;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace NSMedieval.Scripts.Pooler
{
	public class ParticleSystemPool : MonoSingleton<ParticleSystemPool>
	{
		[Serializable]
		public struct ParticlePrefabById
		{
			[SerializeField]
			private string id;

			[SerializeField]
			private GameObject prefab;

			[SerializeField]
			private int poolSize;

			[SerializeField]
			[Tooltip("If true, new instances will override old instances if there is no room in the pool. Use with caution.")]
			private bool doNotAllowNewInstances;

			[SerializeField]
			[Tooltip("Max distance from the camera. Above this distance the particle system will not be spawn.")]
			public float maxZDistanceFromCamera;

			[FormerlySerializedAs("doNotSpawnOutsideCameraFrustum")]
			[SerializeField]
			[Tooltip("If true, the particle system will not spawn outside the view's frustum.")]
			public bool spawnOutsideCameraFrustum;

			public GameObject Prefab => prefab;

			public string Id => id;

			public int PoolSize => poolSize;

			public bool DoNotAllowNewInstances => doNotAllowNewInstances;

			public void SetMaxZDistanceFromCamera(float maxZDistanceFromCamera)
			{
				this.maxZDistanceFromCamera = maxZDistanceFromCamera;
			}

			public void SetDoNotAllowNewInstances(bool doNotAllowNewInstances)
			{
				this.doNotAllowNewInstances = doNotAllowNewInstances;
			}

			public void SetSpawnOutsideCameraFrustum(bool spawnOutsideCameraFrustum)
			{
				this.spawnOutsideCameraFrustum = spawnOutsideCameraFrustum;
			}
		}

		private const int DefaultPoolSize = 10;

		[SerializeField]
		private List<ParticlePrefabById> prefabs;

		[SerializeField]
		private Dictionary<string, ParticlePrefabById> prefabStructsById;

		private Dictionary<string, GameObject> prefabsDict;

		private Dictionary<string, List<ParticleSystem>> prefabParticlesDict;

		private Dictionary<string, HashSet<GameObject>> pool;

		private HashSet<GameObject> used;

		private Dictionary<GameObject, List<ParticleSystem>> particleSystemsByInstance;

		private Camera gameCamera;

		public List<ParticlePrefabById> Prefabs => prefabs;

		public GameObject PlayParticles(string id, Vector3 position, bool autoStop = true, bool useUnscaledTime = false, Action<GameObject> callback = null, SkinnedMeshRenderer skinnedMeshRenderer = null)
		{
			if (!TryGetFromPool(id, out var maxZDistanceFromCamera, out var spawnOutsideCameraFrustum, out var needCreateNewInstance, out var poolContents))
			{
				return null;
			}
			if (!spawnOutsideCameraFrustum || maxZDistanceFromCamera > 0f)
			{
				Vector3 vector = gameCamera.WorldToViewportPoint(position);
				if (maxZDistanceFromCamera > 0f && vector.z > maxZDistanceFromCamera)
				{
					return null;
				}
				if (!spawnOutsideCameraFrustum)
				{
					if (vector.z < 0f)
					{
						return null;
					}
					if (vector.x < 0f || vector.x > 1f)
					{
						return null;
					}
					if (vector.y < 0f || vector.y > 1f)
					{
						return null;
					}
				}
			}
			if (needCreateNewInstance)
			{
				CreateNewInstance(id);
			}
			GameObject gameObject = poolContents.First();
			used.Add(gameObject);
			poolContents.Remove(gameObject);
			gameObject.transform.position = position;
			gameObject.transform.parent = base.transform;
			ResetEmitters(gameObject, id);
			ResetParticleSize(gameObject, id);
			StartParticles(gameObject, start: true, autoStop, useUnscaledTime, callback, skinnedMeshRenderer);
			gameObject.SetActive(value: true);
			return gameObject;
		}

		public GameObject PlayParticles(string id, Transform parent, bool autoStop = true, bool useUnscaledTime = false, Action<GameObject> callback = null, SkinnedMeshRenderer skinnedMeshRenderer = null)
		{
			if (!LoadingController.IsLoadingComplete || LoadingController.IsSceneTransition || LoadingController.IsLeavingMainScene)
			{
				return null;
			}
			if (!TryGetFromPool(id, out var maxZDistanceFromCamera, out var spawnOutsideCameraFrustum, out var needCreateNewInstance, out var poolContents))
			{
				return null;
			}
			if (!spawnOutsideCameraFrustum || maxZDistanceFromCamera > 0f)
			{
				Vector3 vector = gameCamera.WorldToViewportPoint(parent.position);
				if (maxZDistanceFromCamera > 0f && vector.z > maxZDistanceFromCamera)
				{
					return null;
				}
				if (!spawnOutsideCameraFrustum)
				{
					if (vector.z < 0f)
					{
						return null;
					}
					if (vector.x < 0f || vector.x > 1f)
					{
						return null;
					}
					if (vector.y < 0f || vector.y > 1f)
					{
						return null;
					}
				}
			}
			if (needCreateNewInstance)
			{
				CreateNewInstance(id);
			}
			GameObject gameObject = poolContents.First();
			used.Add(gameObject);
			poolContents.Remove(gameObject);
			gameObject.transform.position = parent.position;
			gameObject.transform.parent = parent;
			ResetEmitters(gameObject, id);
			ResetParticleSize(gameObject, id);
			StartParticles(gameObject, start: true, autoStop, useUnscaledTime, callback, skinnedMeshRenderer);
			gameObject.SetActive(value: true);
			return gameObject;
		}

		public void StopParticles(GameObject particlesHolder)
		{
			foreach (ParticleSystem item in particleSystemsByInstance[particlesHolder])
			{
				if (item.isPlaying)
				{
					item.Stop();
				}
			}
		}

		public void ReturnToPool(GameObject obj, Action<GameObject> callback = null)
		{
			if (obj == null || !used.Contains(obj))
			{
				return;
			}
			string text = obj.name;
			bool isEnabled;
			if (!pool.TryGetValue(text, out var value))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Pool not found with id ");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
			}
			else if (value.Contains(obj))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(31, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Pool ");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral(" already contains object ");
					messageBuilder.AppendFormatted(obj.name);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
			}
			else
			{
				obj.transform.parent = base.transform;
				pool[text].Add(obj);
				used.Remove(obj);
				StopParticles(obj);
				obj.SetActive(value: false);
				callback?.Invoke(obj);
			}
		}

		public void SetEmitterSize(string prefabId, GameObject particlesHolder, Collider coll, float scaleMod, bool scaleEmitRateToVolume = true)
		{
			if (particlesHolder == null)
			{
				return;
			}
			bool isEnabled;
			if (!prefabsDict.TryGetValue(prefabId, out var value))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ResetParticles: cannot find prefab for id ");
					messageBuilder.AppendFormatted(prefabId);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				return;
			}
			if (value == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ResetParticles: no prefab is paired with ");
					messageBuilder.AppendFormatted(prefabId);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				return;
			}
			List<ParticleSystem> list = particleSystemsByInstance[particlesHolder];
			List<ParticleSystem> list2 = prefabParticlesDict[prefabId];
			for (int i = 0; i < list.Count; i++)
			{
				ParticleSystem.ShapeModule shape = list[i].shape;
				ParticleSystem.EmissionModule emission = list[i].emission;
				ParticleSystem.EmissionModule emission2 = list2[i].emission;
				float num = 1f;
				if (!(coll is BoxCollider boxCollider))
				{
					if (coll is MeshCollider meshCollider)
					{
						shape.shapeType = ParticleSystemShapeType.Mesh;
						shape.meshShapeType = ParticleSystemMeshShapeType.Triangle;
						shape.mesh = meshCollider.sharedMesh;
						shape.position = Vector3.zero;
						Transform transform = coll.transform.parent.transform;
						Vector3 vector = Vector3.one;
						if (transform != null)
						{
							vector = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
						}
						shape.rotation = meshCollider.transform.rotation.eulerAngles;
						shape.scale = new Vector3(coll.transform.localScale.x * vector.x * scaleMod, coll.transform.localScale.y * vector.y * scaleMod, coll.transform.localScale.z * vector.z * scaleMod);
						num = vector.x * coll.transform.localScale.x * vector.y * coll.transform.localScale.y * vector.z * coll.transform.localScale.z / (float)World.MapBlockHeight;
					}
				}
				else
				{
					shape.shapeType = ParticleSystemShapeType.Box;
					shape.position = boxCollider.transform.TransformPoint(boxCollider.center) - coll.transform.position;
					shape.rotation = boxCollider.transform.rotation.eulerAngles;
					shape.scale = new Vector3(boxCollider.transform.localScale.x * boxCollider.size.x * scaleMod, boxCollider.transform.localScale.y * boxCollider.size.y * scaleMod, boxCollider.transform.localScale.z * boxCollider.size.z * scaleMod);
					num = boxCollider.size.x * boxCollider.size.y * boxCollider.size.z / (float)World.MapBlockHeight;
				}
				if (scaleEmitRateToVolume)
				{
					for (int j = 0; j < emission.burstCount; j++)
					{
						emission.SetBurst(j, new ParticleSystem.Burst(0f, 1, (short)(num * (float)emission2.GetBurst(j).maxCount)));
					}
					if (emission.rateOverTime.constant > 0f)
					{
						emission.rateOverTime = num * emission.rateOverTime.constantMax;
					}
				}
			}
		}

		public IEnumerable<string> GetIds()
		{
			return prefabsDict.Keys;
		}

		private void Start()
		{
			Init();
			SceneManager.sceneUnloaded += OnSceneUnloaded;
			MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent += OnMainSceneLoaded;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLoadedEvent -= OnMainSceneLoaded;
			}
			gameCamera = null;
			if (pool != null)
			{
				foreach (KeyValuePair<string, HashSet<GameObject>> item in pool)
				{
					foreach (GameObject item2 in item.Value)
					{
						UnityEngine.Object.DestroyImmediate(item2);
					}
					item.Value.Clear();
				}
				pool.Clear();
			}
			if (used == null)
			{
				return;
			}
			foreach (GameObject item3 in used)
			{
				UnityEngine.Object.DestroyImmediate(item3);
			}
			used.Clear();
		}

		private void OnMainSceneLoaded()
		{
			gameCamera = MonoSingleton<CameraManager>.Instance.GameplayCamera;
		}

		private void OnSceneUnloaded(Scene scene)
		{
			ReturnAllToPool();
		}

		private void ReturnAllToPool()
		{
			if (used.Count == 0)
			{
				return;
			}
			using PooledList<GameObject> pooledList = used.ToPooledListJanitor();
			foreach (GameObject item in pooledList)
			{
				ReturnToPool(item);
			}
		}

		private void Init()
		{
			prefabsDict = new Dictionary<string, GameObject>();
			prefabStructsById = new Dictionary<string, ParticlePrefabById>();
			prefabParticlesDict = new Dictionary<string, List<ParticleSystem>>();
			pool = new Dictionary<string, HashSet<GameObject>>();
			used = new HashSet<GameObject>();
			particleSystemsByInstance = new Dictionary<GameObject, List<ParticleSystem>>();
			foreach (ParticlePrefabById prefab in prefabs)
			{
				prefabStructsById.Add(prefab.Id, prefab);
				string id = prefab.Id;
				prefabsDict.Add(id, prefab.Prefab);
				prefabParticlesDict.Add(id, new List<ParticleSystem>());
				if (!(prefabsDict[id] == null))
				{
					prefabParticlesDict[id].AddRange(prefab.Prefab.GetComponentsInChildren<ParticleSystem>());
					pool.Add(id, new HashSet<GameObject>());
					int num = ((prefab.PoolSize > 0) ? prefab.PoolSize : 10);
					for (int i = 0; i < num; i++)
					{
						CreateNewInstance(id);
					}
				}
			}
		}

		private GameObject CreateNewInstance(string id)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(prefabsDict[id], base.transform, worldPositionStays: true);
			gameObject.name = id;
			gameObject.SetActive(value: false);
			pool[id].Add(gameObject);
			particleSystemsByInstance.Add(gameObject, new List<ParticleSystem>(gameObject.GetComponentsInChildren<ParticleSystem>()));
			return gameObject;
		}

		private bool TryGetFromPool(string id, out float maxZDistanceFromCamera, out bool spawnOutsideCameraFrustum, out bool needCreateNewInstance, out HashSet<GameObject> poolContents)
		{
			needCreateNewInstance = false;
			if (string.IsNullOrEmpty(id))
			{
				maxZDistanceFromCamera = 0f;
				spawnOutsideCameraFrustum = true;
				poolContents = null;
				return false;
			}
			bool isEnabled;
			if (!pool.TryGetValue(id, out poolContents))
			{
				maxZDistanceFromCamera = 0f;
				spawnOutsideCameraFrustum = true;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(23, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot find particles: ");
					messageBuilder.AppendFormatted(id);
				}
				Log.Info(messageBuilder);
				return false;
			}
			maxZDistanceFromCamera = prefabStructsById[id].maxZDistanceFromCamera;
			spawnOutsideCameraFrustum = prefabStructsById[id].spawnOutsideCameraFrustum;
			if (poolContents.Count == 0)
			{
				FVLogTraceInterpolationHandler messageBuilder2;
				if (prefabStructsById[id].DoNotAllowNewInstances)
				{
					messageBuilder2 = new FVLogTraceInterpolationHandler(81, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("No more objects in pool ");
						messageBuilder2.AppendFormatted(id);
						messageBuilder2.AppendLiteral(". Returning null (because DoNotAllowNewInstances = true).");
					}
					Log.Trace(messageBuilder2);
					return false;
				}
				messageBuilder2 = new FVLogTraceInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("No more objects in pool ");
					messageBuilder2.AppendFormatted(id);
					messageBuilder2.AppendLiteral(". Need to create a new instance.");
				}
				Log.Trace(messageBuilder2);
				needCreateNewInstance = true;
			}
			return true;
		}

		private void StartParticles(GameObject obj, bool start, bool autoStop, bool useUnscaledTime = true, Action<GameObject> stopCallback = null, SkinnedMeshRenderer skinnedMeshRenderer = null)
		{
			List<ParticleSystem> list = particleSystemsByInstance[obj];
			foreach (ParticleSystem item in list)
			{
				if (item.isPlaying)
				{
					item.Stop();
				}
				if (start)
				{
					item.Play();
					ParticleSystem.MainModule main = item.main;
					main.useUnscaledTime = useUnscaledTime;
					main.loop = !autoStop;
				}
				if (!(skinnedMeshRenderer == null))
				{
					ParticleSystem.ShapeModule shape = item.shape;
					if (shape.shapeType == ParticleSystemShapeType.SkinnedMeshRenderer)
					{
						shape.skinnedMeshRenderer = skinnedMeshRenderer;
					}
				}
			}
			if (!autoStop)
			{
				return;
			}
			float num = 0f;
			foreach (ParticleSystem item2 in list)
			{
				float duration = item2.main.duration;
				if (duration > num)
				{
					num = duration;
				}
			}
			if (useUnscaledTime)
			{
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(num).Then(delegate
				{
					ReturnToPool(obj, stopCallback);
				});
			}
			else
			{
				MonoSingleton<TaskController>.Instance.WaitFor(num).Then(delegate
				{
					ReturnToPool(obj, stopCallback);
				});
			}
		}

		private void ResetEmitters(GameObject particlesInstance, string prefabId)
		{
			bool isEnabled;
			if (!prefabsDict.TryGetValue(prefabId, out var value))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ResetParticles: cannot find prefab for id ");
					messageBuilder.AppendFormatted(prefabId);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				return;
			}
			if (value == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ResetParticles: no prefab is paired with ");
					messageBuilder.AppendFormatted(prefabId);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				return;
			}
			List<ParticleSystem> list = prefabParticlesDict[prefabId];
			List<ParticleSystem> list2 = particleSystemsByInstance[particlesInstance];
			if (list == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ResetParticles: this.prefabParticlesDict[");
					messageBuilder.AppendFormatted(prefabId);
					messageBuilder.AppendLiteral("] is null.");
				}
				Log.Error(messageBuilder);
				return;
			}
			if (list.Count != list2.Count)
			{
				Log.Error("ResetParticles: particle systems count does not match on prefab and instance.", "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				ParticleSystem.ShapeModule shape = list2[i].shape;
				shape.scale = list[i].shape.scale;
				shape.position = list[i].shape.position;
				ParticleSystem.EmissionModule emission = list2[i].emission;
				emission.rateOverTime = list[i].emission.rateOverTime;
				ParticleSystem.Burst[] array = new ParticleSystem.Burst[emission.burstCount];
				for (int j = 0; j < array.Length; j++)
				{
					array[j].minCount = list[i].emission.GetBurst(j).minCount;
					array[j].maxCount = list[i].emission.GetBurst(j).maxCount;
				}
			}
		}

		private void ResetParticleSize(GameObject particlesInstance, string prefabId)
		{
			bool isEnabled;
			if (!prefabsDict.TryGetValue(prefabId, out var value))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ResetParticles: cannot find prefab for id ");
					messageBuilder.AppendFormatted(prefabId);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				return;
			}
			if (value == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(42, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ResetParticles: no prefab is paired with ");
					messageBuilder.AppendFormatted(prefabId);
					messageBuilder.AppendLiteral(".");
				}
				Log.Error(messageBuilder);
				return;
			}
			List<ParticleSystem> list = prefabParticlesDict[prefabId];
			List<ParticleSystem> list2 = particleSystemsByInstance[particlesInstance];
			if (list == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(51, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("ResetParticles: this.prefabParticlesDict[");
					messageBuilder.AppendFormatted(prefabId);
					messageBuilder.AppendLiteral("] is null.");
				}
				Log.Error(messageBuilder);
				return;
			}
			if (list.Count != list2.Count)
			{
				Log.Error("ResetParticles: particle systems count does not match on prefab and instance.", "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\ParticleSystemPool.cs");
				return;
			}
			value.transform.position = Vector3.zero;
			value.transform.rotation = Quaternion.identity;
			value.transform.localScale = Vector3.one;
			for (int i = 0; i < list.Count; i++)
			{
				ParticleSystem.MainModule main = list2[i].main;
				float constantMin = list[i].main.startSize.constantMin;
				float constantMax = list[i].main.startSize.constantMax;
				main.startSize = new ParticleSystem.MinMaxCurve(constantMin, constantMax);
			}
		}

		public string GetDebugInfo()
		{
			return null;
		}
	}
}
