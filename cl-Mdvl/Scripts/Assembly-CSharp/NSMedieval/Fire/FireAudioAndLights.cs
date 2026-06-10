using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Sound;
using NSMedieval.Tools;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;
using UnityEngine.Pool;

namespace NSMedieval.Fire
{
	public class FireAudioAndLights
	{
		private const string FirePrefabAddressable = "fire_light";

		private const string FireSoundEventName = "FireRegion";

		private readonly Dictionary<Region, EventInstance> fireSoundEvents = new Dictionary<Region, EventInstance>();

		private VillageMap map;

		private HashSet<Region> changedRegions;

		private HashSet<Region> fireRegions;

		private Dictionary<Region, GameObject> lightByRegion;

		private HashSet<GameObject> activeFireLights;

		private ObjectPool<GameObject> fireLightObjectPool;

		public void Initialize(VillageMap map)
		{
			this.map = map;
			this.map.RegionManager.OnRegionAddedEvent += OnRegionAdded;
			this.map.OnNodeAddedToRegionEvent += OnNodeAddedToRegion;
			this.map.OnNodeRemovedFromRegionEvent += OnNodeRemovedFromRegion;
			this.map.RegionManager.OnRegionRemovingEvent += OnRegionRemoving;
			fireRegions = new HashSet<Region>();
			changedRegions = new HashSet<Region>();
			lightByRegion = new Dictionary<Region, GameObject>();
			activeFireLights = new HashSet<GameObject>();
			fireLightObjectPool = new ObjectPool<GameObject>(CreatePooledFireLight, GetFireLightFromPool, ReturnPooledFireLightToPool, delegate
			{
			}, collectionCheck: true, 10, 512);
			MonoSingleton<SceneController>.Instance.Tick += Tick;
		}

		public void Dispose()
		{
			fireRegions.Clear();
			fireRegions = null;
			changedRegions.Clear();
			changedRegions = null;
			if (map != null)
			{
				map.OnNodeAddedToRegionEvent -= OnNodeAddedToRegion;
				map.OnNodeRemovedFromRegionEvent -= OnNodeRemovedFromRegion;
				if (map.RegionManager != null)
				{
					map.RegionManager.OnRegionAddedEvent -= OnRegionAdded;
					map.RegionManager.OnRegionRemovingEvent -= OnRegionRemoving;
				}
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.Tick -= Tick;
			}
			fireLightObjectPool.Dispose();
			fireLightObjectPool = null;
			activeFireLights.Clear();
			activeFireLights = null;
			map = null;
		}

		private void OnNodeRemovedFromRegion(Region region, MapNode node)
		{
			changedRegions.Add(region);
		}

		private void OnNodeAddedToRegion(Region region, MapNode node)
		{
			changedRegions.Add(region);
		}

		private void OnRegionAdded(Region region)
		{
			changedRegions.Add(region);
		}

		private void OnRegionRemoving(Region region)
		{
			changedRegions.Add(region);
		}

		private void Tick(float dt)
		{
			using (ProfilerSampleJanitor.Begin("FireAudioAndLights.Tick"))
			{
				using PooledHashSet<Region> pooledHashSet = NSMedieval.Utils.Pool.HashSetPool<Region>.GetJanitor();
				foreach (Region fireRegion in fireRegions)
				{
					if (!fireRegion.IsFire)
					{
						pooledHashSet.Add(fireRegion);
					}
				}
				foreach (Region item in pooledHashSet)
				{
					RemoveLightFromRegion(item);
					fireRegions.Remove(item);
					StopFireAudio(item);
				}
				foreach (Region changedRegion in changedRegions)
				{
					if (changedRegion.HasDisposed || changedRegion.Nodes.Count <= 0 || !changedRegion.IsFire)
					{
						fireRegions.Remove(changedRegion);
						RemoveLightFromRegion(changedRegion);
						StopFireAudio(changedRegion);
					}
					else
					{
						fireRegions.Add(changedRegion);
						AddLightToRegion(changedRegion);
						StartFireAudio(changedRegion);
					}
				}
				changedRegions.Clear();
			}
		}

		private void StopFireAudio(Region region)
		{
			if (fireSoundEvents.TryGetValue(region, out var value))
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(27, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Fire\\FireAudioAndLights.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Stop fire audio for region ");
					messageBuilder.AppendFormatted(region.UniqueId);
				}
				Log.Debug(messageBuilder);
				value.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
				fireSoundEvents.Remove(region);
			}
		}

		private void StartFireAudio(Region region)
		{
			int num = Mathf.Clamp(region.Nodes.Count, 1, 50);
			if (!fireSoundEvents.ContainsKey(region))
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Fire\\FireAudioAndLights.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Start fire audio for region ");
					messageBuilder.AppendFormatted(region.UniqueId);
				}
				Log.Debug(messageBuilder);
				EventInstance eventInstance = RuntimeManager.CreateInstance(MonoSingleton<AudioManager>.Instance.GetEvent("FireRegion"));
				MonoSingleton<AudioManager>.Instance.PlayLoopAtPosition(eventInstance, region.BoundsCenter);
				fireSoundEvents.Add(region, eventInstance);
			}
			fireSoundEvents[region].setParameterByName("Size", num);
		}

		private void AddLightToRegion(Region region)
		{
			if (!lightByRegion.ContainsKey(region))
			{
				GameObject gameObject = fireLightObjectPool.Get();
				gameObject.transform.position = region.BoundsCenter;
				lightByRegion.Add(region, gameObject);
			}
		}

		private void RemoveLightFromRegion(Region region)
		{
			if (lightByRegion.TryGetValue(region, out var value))
			{
				fireLightObjectPool.Release(value);
				lightByRegion.Remove(region);
			}
		}

		public void DrawGizmos()
		{
			Color color = Gizmos.color;
			foreach (Region fireRegion in fireRegions)
			{
				if (!fireRegion.IsFire)
				{
					continue;
				}
				Color color2 = Color.HSVToRGB(Mathf.Abs((float)fireRegion.GetHashCode() / 100f) % 1f, 1f, 1f);
				color2.a = 0.9f;
				Gizmos.color = color2;
				foreach (MapNode node in fireRegion.Nodes)
				{
					int index = node.Index;
					float x = GridDataIndexTools.GetX(index);
					float y = (float)GridDataIndexTools.GetY(index) * 3f;
					float z = GridDataIndexTools.GetZ(index);
					Gizmos.DrawCube(new Vector3(x, y, z), Vector3.right + Vector3.forward + Vector3.up * 0.1f);
				}
				Gizmos.color = Color.white;
				Gizmos.DrawWireCube(fireRegion.BoundsCenter, fireRegion.BoundsSize);
			}
			Gizmos.color = color;
		}

		private void GetFireLightFromPool(GameObject obj)
		{
			activeFireLights.Add(obj);
			obj.SetActive(value: true);
		}

		private static GameObject CreatePooledFireLight()
		{
			return Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress("fire_light"));
		}

		private void ReturnPooledFireLightToPool(GameObject obj)
		{
			activeFireLights.Remove(obj);
			obj.SetActive(value: false);
			obj.transform.position = Vector3.zero;
		}
	}
}
