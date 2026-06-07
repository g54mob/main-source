using System.Collections.Generic;
using System.Diagnostics;
using Assets.Scripts.Mods;
using Jundroo.Common.Resource;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Flight.Proximity
{
	public class ProximityLoadedObject : MonoBehaviour
	{
		private static GameObject _rootContainer;

		[SerializeField]
		[Tooltip("The path of the prefab to be loaded when the player gets within the specified proximity.")]
		private string _prefabPath;

		[SerializeField]
		[Tooltip("The reference to the prefab to be instantiated when the player gets within the specified proximity. NOTE: Setting this disables asynchronous loading.")]
		private GameObject _prefabReference;

		[SerializeField]
		[Tooltip("The IDs of the dynamic locations loaded by this proximity loaded item.")]
		private List<string> _dynamicLocationIds;

		[SerializeField]
		[Tooltip("If true, the game object will be cached after it is first loaded. Unloading and loading of the object will then simply be toggling the enabled state of game object.")]
		private bool _cache;

		[SerializeField]
		[Tooltip("If true, the game object prefab will be loaded upon awake. If set to cache as well, the object will be instantiated and cached upon awake.")]
		private bool _preload;

		[SerializeField]
		[Tooltip("True if this object should only be loaded by the host.")]
		private bool _hostOnly;

		[SerializeField]
		[Tooltip("Flag to indicate this should only be loaded in sandbox mode.")]
		private bool _sandboxOnly;

		[SerializeField]
		[Tooltip("The maximum distance at which the object will be synchronously loaded if an asynchronous load is not already taking place. This cannot be changed after the object has been started.")]
		private float _syncLoadDistance = 50000f;

		[SerializeField]
		[Tooltip("The maximum distance at which the object will start being asynchronously loaded. This cannot be changed after the object has been started.")]
		private float _asyncLoadDistance = 52500f;

		[SerializeField]
		[Tooltip("The minimum distance at which the object will be unloaded. This cannot be changed after the object has been started.")]
		private float _unloadDistance = 55000f;

		private float _asynchronousLoadDistanceSquared;

		private float _synchronousLoadDistanceSquared;

		private List<Terrain> _terrains = new List<Terrain>();

		private float _unloadDistanceSquared;

		public float AsynchronousLoadDistanceSquared => _asynchronousLoadDistanceSquared;

		public bool Cache
		{
			get
			{
				return _cache;
			}
			set
			{
				_cache = value;
			}
		}

		public GameObject CachedObject { get; protected set; }

		public bool HostOnly => _hostOnly;

		public virtual bool IsEnabled
		{
			get
			{
				if (base.gameObject.activeInHierarchy)
				{
					return base.enabled;
				}
				return false;
			}
		}

		public string Name => base.gameObject.name;

		public virtual Vector3 Position => base.transform.position;

		public bool Preload
		{
			get
			{
				return _preload;
			}
			set
			{
				_preload = value;
			}
		}

		public virtual bool ProximityCheckingEnabled => base.isActiveAndEnabled;

		public virtual Quaternion Rotation => base.transform.rotation;

		public virtual bool SupportsAsynchronousLoading
		{
			get
			{
				if (PrefabReference == null)
				{
					return CachedObject == null;
				}
				return false;
			}
		}

		public float SynchronousLoadDistanceSquared => _synchronousLoadDistanceSquared;

		public List<Terrain> Terrains => _terrains;

		public float UnloadDistanceSquared => _unloadDistanceSquared;

		protected virtual string PrefabPath
		{
			get
			{
				return _prefabPath;
			}
			set
			{
				_prefabPath = value;
			}
		}

		protected virtual GameObject PrefabReference
		{
			get
			{
				return _prefabReference;
			}
			set
			{
				_prefabReference = value;
			}
		}

		public bool ContainsDynamicLocation(string dynamicLocationId)
		{
			return _dynamicLocationIds?.Contains(dynamicLocationId) ?? false;
		}

		public virtual AsyncAssetRequest<GameObject> LoadAsynchronously()
		{
			return new AsyncResourceRequest<GameObject>(Resources.LoadAsync<GameObject>(PrefabPath), instantiate: true);
		}

		public virtual GameObject LoadSynchronously()
		{
			GameObject gameObject;
			if (CachedObject == null)
			{
				if (PrefabReference != null)
				{
					gameObject = Object.Instantiate(PrefabReference);
				}
				else
				{
					GameObject gameObject2 = Resources.Load<GameObject>(PrefabPath);
					if (gameObject2 == null)
					{
						UnityEngine.Debug.LogErrorFormat("Could not find the prefab '{0}' for proximity loaded object.", PrefabPath);
					}
					gameObject = Object.Instantiate(gameObject2);
					if (gameObject == null)
					{
						UnityEngine.Debug.LogErrorFormat("Could not instantiate the prefab '{0}' for proximity loaded object.", PrefabPath);
					}
				}
				if (Cache)
				{
					CachedObject = gameObject;
				}
				else if (gameObject != null)
				{
					gameObject.name = base.gameObject.name;
				}
			}
			else
			{
				CachedObject.SetActive(value: true);
				gameObject = CachedObject;
			}
			return gameObject;
		}

		public virtual void OnLoadCancelled()
		{
		}

		public virtual void OnObjectLoaded(GameObject obj)
		{
			if (_rootContainer != null)
			{
				obj.transform.parent = _rootContainer.transform;
			}
			if (Cache && CachedObject != obj)
			{
				CachedObject = obj;
			}
			_terrains.AddRange(obj.GetComponentsInChildren<Terrain>());
		}

		public virtual void OnObjectLoading(bool asynchronous)
		{
		}

		public virtual void OnObjectUnloaded()
		{
		}

		public virtual void OnObjectUnloading(GameObject obj)
		{
		}

		public virtual void UnloadObject(GameObject obj)
		{
			if (obj != null)
			{
				if (Cache)
				{
					obj.SetActive(value: false);
				}
				else
				{
					Object.Destroy(obj);
				}
			}
		}

		protected virtual void Awake()
		{
			if (GameState.Instance.CurrentMapName != "Default Map")
			{
				Object.Destroy(base.gameObject);
				return;
			}
			if (_rootContainer == null)
			{
				_rootContainer = new GameObject("ProximityLoadedObjects");
				_rootContainer.transform.localPosition = Vector3.zero;
				_rootContainer.transform.localRotation = Quaternion.identity;
				_rootContainer.transform.localScale = Vector3.one;
				_rootContainer.transform.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
				_rootContainer.AddComponent<IgnoreFloatingOriginScript>().RepositionChildren = true;
			}
			base.hideFlags = HideFlags.HideInHierarchy;
			_rootContainer.hideFlags = HideFlags.HideInHierarchy;
			if (Preload)
			{
				PreloadObject();
			}
		}

		[Conditional("UNITY_EDITOR")]
		protected virtual void LogFormatEditorOnly(string message, params string[] args)
		{
			if (ProximityLoader.Instance.DebugLevel >= 1)
			{
				UnityEngine.Debug.LogFormat(message, args);
			}
		}

		protected virtual void PreloadObject()
		{
			if (PrefabReference == null)
			{
				PrefabReference = Resources.Load<GameObject>(PrefabPath);
				if (PrefabReference == null)
				{
					UnityEngine.Debug.LogErrorFormat("Could not find the prefab '{0}' for proximity loaded object while attempting to preload it.", PrefabPath);
				}
			}
			if (Cache)
			{
				CachedObject = Object.Instantiate(PrefabReference);
				if (CachedObject == null)
				{
					UnityEngine.Debug.LogErrorFormat("Could not instantiate the prefab '{0}' for proximity loaded object while attempting to preload it.", PrefabPath);
				}
				CachedObject.transform.SetPositionAndRotation(Position, Rotation);
				OnObjectLoaded(CachedObject);
				CachedObject.SetActive(value: false);
			}
		}

		protected virtual void Start()
		{
			_synchronousLoadDistanceSquared = _syncLoadDistance * _syncLoadDistance;
			_asynchronousLoadDistanceSquared = ((_syncLoadDistance > _asyncLoadDistance) ? _synchronousLoadDistanceSquared : (_asyncLoadDistance * _asyncLoadDistance));
			_unloadDistanceSquared = _unloadDistance * _unloadDistance;
			if (_unloadDistance < _asyncLoadDistance && _unloadDistance > 0f)
			{
				_unloadDistance = _asynchronousLoadDistanceSquared;
			}
			ProximityLoader instance = ProximityLoader.Instance;
			if (instance == null)
			{
				UnityEngine.Debug.LogErrorFormat("Unable to register proximity loaded object '{0} ({1})' because the proximity loader is null", base.name, GetType().FullName);
			}
			else if (Game.Instance.CurrentLevel.IsSandbox || !_sandboxOnly)
			{
				instance.Register(this);
			}
		}

		private void CreateDebugCylinder(float radius, Color color)
		{
			GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			obj.transform.parent = base.transform;
			float num = radius * 2f;
			obj.transform.localScale = new Vector3(num, num, num);
			obj.transform.rotation = Quaternion.identity;
			obj.transform.localPosition = Vector3.zero;
			MeshRenderer component = obj.GetComponent<MeshRenderer>();
			component.shadowCastingMode = ShadowCastingMode.Off;
			component.receiveShadows = false;
			component.material.color = color;
			component.material.SetFloat("_Mode", 3f);
			Object.DestroyImmediate(obj.GetComponent<Collider>());
		}
	}
}
