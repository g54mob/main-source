using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Events;
using FishNet;
using Jundroo.Common.Resource;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity
{
	public class ProximityLoader : MonoBehaviour
	{
		public delegate void ObjectLoadedEventHandler(GameObject obj);

		public delegate void TerrainLoadedEventHandler(Terrain terrain);

		public enum ProximityLoaderItemState
		{
			Unloaded = 0,
			Loading = 1,
			Loaded = 2
		}

		public class ProximityLoaderItem
		{
			public AsyncAssetRequest<GameObject> AsyncLoadRequest { get; set; }

			public GameObject LoadedObject { get; set; }

			public ProximityLoadedObject Placeholder { get; private set; }

			public ProximityLoaderItemState State { get; set; }

			public ProximityLoaderItem(ProximityLoadedObject placeholder)
			{
				Placeholder = placeholder;
				State = ProximityLoaderItemState.Unloaded;
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker ChangeItemState = new ProfilerMarker("ProximityLoader.ChangeItemState");

			public static readonly ProfilerMarker GetPlayerPositions = new ProfilerMarker("ProximityLoader.GetPlayerPositions");

			public static readonly ProfilerMarker GetProximityLoadedGameObject = new ProfilerMarker("ProximityLoader.GetProximityLoadedGameObject");

			public static readonly ProfilerMarker GetProximityLoadedObjectForDynamicLocation = new ProfilerMarker("ProximityLoader.GetProximityLoadedObjectForDynamicLocation");

			public static readonly ProfilerMarker LoadItem = new ProfilerMarker("ProximityLoader.LoadItem");

			public static readonly ProfilerMarker LoadItemAsynchronously = new ProfilerMarker("ProximityLoader.LoadItemAsynchronously");

			public static readonly ProfilerMarker OnLoadCancelled = new ProfilerMarker("ProximityLoader.OnLoadCancelled");

			public static readonly ProfilerMarker OnObjectLoaded = new ProfilerMarker("ProximityLoader.OnObjectLoaded");

			public static readonly ProfilerMarker OnObjectLoading = new ProfilerMarker("ProximityLoader.OnObjectLoading");

			public static readonly ProfilerMarker OnObjectUnloaded = new ProfilerMarker("ProximityLoader.OnObjectUnloaded");

			public static readonly ProfilerMarker OnObjectUnloading = new ProfilerMarker("ProximityLoader.OnObjectUnloading");

			public static readonly ProfilerMarker ProcessAsyncLoadRequest = new ProfilerMarker("ProximityLoader.ProcessAsyncLoadRequest");

			public static readonly ProfilerMarker RefreshPlayerTransforms = new ProfilerMarker("ProximityLoader.RefreshPlayerTransforms");

			public static readonly ProfilerMarker UnloadItem = new ProfilerMarker("ProximityLoader.UnloadItem");

			public static readonly ProfilerMarker UpdateAll = new ProfilerMarker("ProximityLoader.UpdateAll");

			public static readonly ProfilerMarker UpdateItem = new ProfilerMarker("ProximityLoader.UpdateItem");

			public static readonly ProfilerMarker UpdateItems = new ProfilerMarker("ProximityLoader.UpdateItems");
		}

		private const int MaxItemsToCheckPerUpdate = 10;

		private const float MaxSecondsToUpdateAllItems = 1f;

		private static ProximityLoader _instance;

		private bool _cleanupUnloadedAssets;

		[SerializeField]
		[Range(0f, 2f)]
		private int _debugLevel;

		private bool _firstFrame;

		private int _nextItemToUpdate;

		private List<Func<Transform>> _playerTransforms;

		private List<ProximityLoaderItem> _proximityLoadedObjects = new List<ProximityLoaderItem>();

		private Vector2 _temp;

		private bool _updateItems = true;

		public static ProximityLoader Instance => _instance;

		public int DebugLevel => _debugLevel;

		public List<Terrain> Terrains { get; private set; }

		protected List<Func<Transform>> PlayerTransforms => _playerTransforms;

		public event ObjectLoadedEventHandler ObjectProximityLoaded;

		public event ObjectLoadedEventHandler ObjectProximityUnloaded;

		public event TerrainLoadedEventHandler TerrainProximityLoaded;

		public event TerrainLoadedEventHandler TerrainProximityUnloaded;

		public GameObject GetProximityLoadedGameObject(string name)
		{
			using (Profile.GetProximityLoadedGameObject.Auto())
			{
				for (int i = 0; i < _proximityLoadedObjects.Count; i++)
				{
					if (_proximityLoadedObjects[i].Placeholder.Name == name)
					{
						return _proximityLoadedObjects[i].LoadedObject;
					}
				}
				return null;
			}
		}

		public ProximityLoadedObject GetProximityLoadedObjectForDynamicLocation(string dynamicLocationId)
		{
			using (Profile.GetProximityLoadedObjectForDynamicLocation.Auto())
			{
				foreach (ProximityLoaderItem proximityLoadedObject in _proximityLoadedObjects)
				{
					if (proximityLoadedObject.Placeholder.ContainsDynamicLocation(dynamicLocationId))
					{
						return proximityLoadedObject.Placeholder;
					}
				}
				return null;
			}
		}

		public void Register(ProximityLoadedObject obj)
		{
			_proximityLoadedObjects.Add(new ProximityLoaderItem(obj));
		}

		public void UpdateAll()
		{
			using (Profile.UpdateAll.Auto())
			{
				List<Vector2> list = new List<Vector2>(PlayerTransforms.Count);
				GetPlayerPositions(list);
				for (int i = 0; i < _proximityLoadedObjects.Count; i++)
				{
					UpdateItem(_proximityLoadedObjects[i], list);
				}
				FlightSceneScript.Instance?.UnloadUnusedAssets(force: false);
			}
		}

		protected virtual void Awake()
		{
			_instance = this;
			Terrains = new List<Terrain>();
			_playerTransforms = new List<Func<Transform>>();
			StartCoroutine(UpdateItems());
		}

		protected virtual void LateUpdate()
		{
			if (_firstFrame)
			{
				FirstFrameLateUpdate();
				_firstFrame = false;
			}
		}

		protected virtual void OnDestroy()
		{
			_updateItems = false;
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded -= OnPlayerLoaded;
				instance.PlayerUnloaded -= OnPlayerUnloaded;
				instance.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft -= OnPlayerExitedAircraft;
			}
			_instance = null;
		}

		protected virtual void Start()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded += OnPlayerLoaded;
				instance.PlayerUnloaded += OnPlayerUnloaded;
				instance.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft += OnPlayerExitedAircraft;
				instance.RaiseLocalPlayerLoaded(OnPlayerLoaded);
				instance.RaisePlayerEnteredAircraft(OnPlayerEnteredAircraft);
			}
		}

		private void ChangeItemState(ProximityLoaderItem item, ProximityLoaderItemState targetState)
		{
			using (Profile.ChangeItemState.Auto())
			{
				switch (targetState)
				{
				case ProximityLoaderItemState.Unloaded:
					UnloadItem(item);
					break;
				case ProximityLoaderItemState.Loaded:
					LoadItem(item);
					break;
				case ProximityLoaderItemState.Loading:
					LoadItemAsynchronously(item);
					break;
				}
			}
		}

		private void FirstFrameLateUpdate()
		{
			TerrainLoadedEventHandler terrainLoadedEventHandler = this.TerrainProximityLoaded;
			if (terrainLoadedEventHandler == null)
			{
				return;
			}
			foreach (Terrain terrain in Terrains)
			{
				terrainLoadedEventHandler(terrain);
			}
		}

		private void GetPlayerPositions(List<Vector2> positions)
		{
			using (Profile.GetPlayerPositions.Auto())
			{
				positions.Clear();
				List<Func<Transform>> playerTransforms = PlayerTransforms;
				for (int i = 0; i < playerTransforms.Count; i++)
				{
					Transform transform = playerTransforms[i]();
					if (transform != null && transform.gameObject != null)
					{
						Vector3 position = transform.position;
						positions.Add(new Vector2(position.x, position.z));
					}
				}
			}
		}

		private void LoadItem(ProximityLoaderItem item)
		{
			using (Profile.LoadItem.Auto())
			{
				OnObjectLoading(item, asynchronous: false);
				item.LoadedObject = item.Placeholder.LoadSynchronously();
				item.State = ProximityLoaderItemState.Loaded;
				OnObjectLoaded(item);
			}
		}

		private void LoadItemAsynchronously(ProximityLoaderItem item)
		{
			using (Profile.LoadItemAsynchronously.Auto())
			{
				OnObjectLoading(item, asynchronous: true);
				item.AsyncLoadRequest = item.Placeholder.LoadAsynchronously();
				item.State = ProximityLoaderItemState.Loading;
				StartCoroutine(ProcessAsyncLoadRequest(item));
			}
		}

		private void OnLoadCancelled(ProximityLoaderItem item)
		{
			using (Profile.OnLoadCancelled.Auto())
			{
				item.Placeholder.OnLoadCancelled();
			}
		}

		private void OnObjectLoaded(ProximityLoaderItem item)
		{
			using (Profile.OnObjectLoaded.Auto())
			{
				GameObject loadedObject = item.LoadedObject;
				if (loadedObject != null)
				{
					loadedObject.transform.SetPositionAndRotation(item.Placeholder.Position, item.Placeholder.Rotation);
				}
				item.Placeholder.OnObjectLoaded(loadedObject);
				item.Placeholder.Terrains.RemoveAll((Terrain x) => x == null);
				Terrains.AddRange(item.Placeholder.Terrains);
				this.ObjectProximityLoaded?.Invoke(loadedObject);
				TerrainLoadedEventHandler terrainLoadedEventHandler = this.TerrainProximityLoaded;
				if (terrainLoadedEventHandler == null)
				{
					return;
				}
				foreach (Terrain terrain in item.Placeholder.Terrains)
				{
					terrainLoadedEventHandler(terrain);
				}
			}
		}

		private void OnObjectLoading(ProximityLoaderItem item, bool asynchronous)
		{
			using (Profile.OnObjectLoading.Auto())
			{
				item.Placeholder.OnObjectLoading(asynchronous);
			}
		}

		private void OnObjectUnloaded(ProximityLoaderItem item)
		{
			using (Profile.OnObjectUnloaded.Auto())
			{
				item.Placeholder.OnObjectUnloaded();
				this.ObjectProximityUnloaded?.Invoke(item.LoadedObject);
				TerrainLoadedEventHandler terrainLoadedEventHandler = this.TerrainProximityUnloaded;
				foreach (Terrain terrain in item.Placeholder.Terrains)
				{
					Terrains.Remove(terrain);
					terrainLoadedEventHandler?.Invoke(terrain);
				}
			}
		}

		private void OnObjectUnloading(ProximityLoaderItem item)
		{
			using (Profile.OnObjectUnloading.Auto())
			{
				item.Placeholder.OnObjectUnloading(item.LoadedObject);
			}
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				RefreshPlayerTransforms(e.Player, e.Aircraft);
			}
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				RefreshPlayerTransforms(e.Player, null);
			}
		}

		private void OnPlayerLoaded(object sender, FlightScenePlayerEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				RefreshPlayerTransforms(e.Player, e.Player.Aircraft);
			}
		}

		private void OnPlayerUnloaded(object sender, FlightScenePlayerEventArgs e)
		{
			if (e.Player.IsPrimaryLocal)
			{
				RefreshPlayerTransforms(e.Player, null);
			}
		}

		private IEnumerator ProcessAsyncLoadRequest(ProximityLoaderItem item)
		{
			AsyncAssetRequest<GameObject> request = item.AsyncLoadRequest;
			yield return request.Coroutine;
			using (Profile.ProcessAsyncLoadRequest.Auto())
			{
				if (!request.CancellationRequested)
				{
					item.LoadedObject = request.Asset;
					item.State = ProximityLoaderItemState.Loaded;
					item.AsyncLoadRequest = null;
					OnObjectLoaded(item);
					yield break;
				}
				GameObject asset = request.Asset;
				if (asset != null)
				{
					UnityEngine.Object.Destroy(asset);
				}
				OnLoadCancelled(item);
			}
		}

		private void RefreshPlayerTransforms(FlightScenePlayer player, AircraftScript craft)
		{
			using (Profile.RefreshPlayerTransforms.Auto())
			{
				_playerTransforms.Clear();
				if (player != null)
				{
					_playerTransforms.Add(() => player.RepositionTarget);
					_playerTransforms.Add(() => player.Avatar.transform);
				}
				if (!(craft != null))
				{
					return;
				}
				CameraVantageScript[] componentsInChildren = craft.gameObject.GetComponentsInChildren<CameraVantageScript>(includeInactive: true);
				_playerTransforms.Add(() => craft.MainCockpit.transform);
				foreach (CameraVantageScript camScript in componentsInChildren)
				{
					if (camScript.Data.ViewMode != ViewMode.None)
					{
						_playerTransforms.Add(() => camScript.TransformToTrack);
					}
				}
			}
		}

		private void UnloadItem(ProximityLoaderItem item)
		{
			using (Profile.UnloadItem.Auto())
			{
				OnObjectUnloading(item);
				if (item.LoadedObject != null)
				{
					item.Placeholder.UnloadObject(item.LoadedObject);
				}
				if (item.State == ProximityLoaderItemState.Loading)
				{
					item.AsyncLoadRequest.RequestCancellation();
					item.AsyncLoadRequest = null;
				}
				item.LoadedObject = null;
				item.State = ProximityLoaderItemState.Unloaded;
				_cleanupUnloadedAssets = true;
				OnObjectUnloaded(item);
			}
		}

		private void UpdateItem(ProximityLoaderItem item, List<Vector2> currentPositions)
		{
			using (Profile.UpdateItem.Auto())
			{
				if (!item.Placeholder.IsEnabled)
				{
					return;
				}
				if (item.Placeholder.HostOnly && !InstanceFinder.IsServerStarted)
				{
					item.Placeholder.gameObject.SetActive(value: false);
					return;
				}
				Vector3 position = item.Placeholder.Position;
				_temp.x = position.x;
				_temp.y = position.z;
				ProximityLoaderItemState? proximityLoaderItemState = null;
				for (int i = 0; i < currentPositions.Count; i++)
				{
					float sqrMagnitude = (currentPositions[i] - _temp).sqrMagnitude;
					if (_debugLevel >= 2)
					{
						Debug.LogFormat("Distance from '{0}': {1}", item.Placeholder.name, Mathf.Sqrt(sqrMagnitude));
					}
					ProximityLoaderItemState? proximityLoaderItemState2 = null;
					if (sqrMagnitude <= item.Placeholder.SynchronousLoadDistanceSquared)
					{
						proximityLoaderItemState2 = ProximityLoaderItemState.Loaded;
					}
					else if (sqrMagnitude <= item.Placeholder.AsynchronousLoadDistanceSquared)
					{
						proximityLoaderItemState2 = (item.Placeholder.SupportsAsynchronousLoading ? ProximityLoaderItemState.Loading : ProximityLoaderItemState.Loaded);
					}
					else if (sqrMagnitude >= item.Placeholder.UnloadDistanceSquared && item.Placeholder.UnloadDistanceSquared > 0f)
					{
						proximityLoaderItemState2 = ProximityLoaderItemState.Unloaded;
					}
					if (proximityLoaderItemState2.HasValue)
					{
						proximityLoaderItemState = ((!proximityLoaderItemState.HasValue || proximityLoaderItemState == proximityLoaderItemState2) ? proximityLoaderItemState2 : ((proximityLoaderItemState.Value != ProximityLoaderItemState.Loaded && proximityLoaderItemState2.Value != ProximityLoaderItemState.Loaded) ? ((proximityLoaderItemState.Value != ProximityLoaderItemState.Loading && proximityLoaderItemState2.Value != ProximityLoaderItemState.Loading) ? new ProximityLoaderItemState?(ProximityLoaderItemState.Unloaded) : new ProximityLoaderItemState?(ProximityLoaderItemState.Loading)) : new ProximityLoaderItemState?(ProximityLoaderItemState.Loaded)));
					}
				}
				if (proximityLoaderItemState.HasValue)
				{
					if (item.State == ProximityLoaderItemState.Loaded && proximityLoaderItemState.Value == ProximityLoaderItemState.Loading)
					{
						proximityLoaderItemState = ProximityLoaderItemState.Loaded;
					}
					if (item.State == ProximityLoaderItemState.Loading && proximityLoaderItemState.Value == ProximityLoaderItemState.Loaded)
					{
						proximityLoaderItemState = ProximityLoaderItemState.Loading;
					}
					if (proximityLoaderItemState.Value != item.State)
					{
						ChangeItemState(item, proximityLoaderItemState.Value);
					}
				}
			}
		}

		private IEnumerator UpdateItems()
		{
			yield return new WaitForEndOfFrame();
			List<Vector2> playerPositions = new List<Vector2>(5);
			float maxSecondsTimesMaxItems = 10f;
			while (_updateItems)
			{
				int count = _proximityLoadedObjects.Count;
				if (count == 0)
				{
					yield return new WaitForSecondsRealtime(2f);
					continue;
				}
				using (Profile.UpdateItems.Auto())
				{
					int num = 0;
					int num2 = _nextItemToUpdate;
					if (num2 >= count)
					{
						num2 = 0;
						_nextItemToUpdate = 0;
					}
					GetPlayerPositions(playerPositions);
					while (num < 10)
					{
						UpdateItem(_proximityLoadedObjects[_nextItemToUpdate], playerPositions);
						num++;
						_nextItemToUpdate++;
						if (_nextItemToUpdate >= count)
						{
							_nextItemToUpdate = 0;
						}
						if (_nextItemToUpdate == num2)
						{
							break;
						}
					}
					if (_cleanupUnloadedAssets)
					{
						_cleanupUnloadedAssets = false;
					}
				}
				yield return new WaitForSecondsRealtime(Mathf.Min(maxSecondsTimesMaxItems / (float)count, 1f));
			}
		}
	}
}
