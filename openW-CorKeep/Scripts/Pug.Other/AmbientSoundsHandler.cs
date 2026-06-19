using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Serialization;

public class AmbientSoundsHandler : MonoBehaviour
{
	[Serializable]
	public class AmbientSound
	{
		public AudioInfo audioInfo;

		[FormerlySerializedAs("tileTypeAndTilesets")]
		[ArrayElementTitle("tileType, tileset")]
		public List<ContributingTiles> contributingTiles;
	}

	[Serializable]
	public class ContributingTiles
	{
		public TileType tileType;

		public Tileset tileset;
	}

	[Serializable]
	public class AudioInfo
	{
		public AssetReferenceT<AudioClip> audioReference;

		public AsyncOperationHandle<AudioClip> loadHandle;

		public AudioSource audio;

		public float volumeMultiply = 1f;

		private float _audioSeekPosition;

		private bool _loading;

		private bool _hasValidClip;

		public void LoadAudioAsset()
		{
			if (_loading || _hasValidClip)
			{
				return;
			}
			if (!audioReference.RuntimeKeyIsValid())
			{
				Debug.LogError("AudioInfo " + audio.name + ": no valid asset reference to load.");
				return;
			}
			_loading = true;
			loadHandle = Addressables.LoadAssetAsync<AudioClip>(audioReference);
			loadHandle.Completed += delegate(AsyncOperationHandle<AudioClip> handle)
			{
				audio.clip = handle.Result;
				if (audio.playOnAwake && !audio.isPlaying)
				{
					audio.time = _audioSeekPosition;
					audio.Play();
				}
				_loading = false;
				_hasValidClip = true;
			};
		}

		public void ReleaseAudioAsset()
		{
			if (_hasValidClip)
			{
				if (audio.isPlaying)
				{
					_audioSeekPosition = audio.time;
					audio.Stop();
				}
				_hasValidClip = false;
				Addressables.Release(loadHandle);
				loadHandle = default(AsyncOperationHandle<AudioClip>);
				audio.clip = null;
			}
		}
	}

	[BurstCompile]
	private struct ComputeFromNearbyTilesJob : IJob
	{
		[ReadOnly]
		public SinglePugMap.TileLayerLookup TileLookup;

		[ReadOnly]
		public NativeParallelMultiHashMap<TileTypeAndTileset, int> AudioSourceByTile;

		public int2 CameraOrigin;

		public int2 PlayerRenderPosition;

		public NativeHashMap<TileTypeAndTileset, int> NearbyTileCount;

		public NativeArray<float2> AudioSourceDirection;

		public NativeArray<float> AudioSourceVolume;

		public NativeArray<float> AudioSourceSpatialBlend;

		public void Execute()
		{
			NearbyTileCount.Clear();
			for (int i = 0; i < AudioSourceDirection.Length; i++)
			{
				AudioSourceDirection[i] = float2.zero;
				AudioSourceVolume[i] = 0f;
				AudioSourceSpatialBlend[i] = 0f;
			}
			for (int j = PlayerRenderPosition.x - 10; j < PlayerRenderPosition.x + 10; j++)
			{
				for (int k = PlayerRenderPosition.y - 10; k < PlayerRenderPosition.y + 10; k++)
				{
					int2 int5 = new int2(j, k);
					float num = math.length(int5 - PlayerRenderPosition);
					if (num > 10f)
					{
						continue;
					}
					TileInfo topTile = TileLookup.GetTopTile(CameraOrigin + int5);
					TileTypeAndTileset key = new TileTypeAndTileset
					{
						TileType = topTile.tileType,
						Tileset = (Tileset)topTile.tileset
					};
					if (!NearbyTileCount.TryAdd(key, 1))
					{
						NearbyTileCount[key]++;
					}
					foreach (int item in AudioSourceByTile.GetValuesForKey(key))
					{
						AudioSourceDirection[item] += (float2)int5;
						AudioSourceVolume[item] += num;
						AudioSourceSpatialBlend[item] += 1f;
					}
				}
			}
			for (int l = 0; l < AudioSourceDirection.Length; l++)
			{
				float2 obj = AudioSourceDirection[l];
				float num2 = AudioSourceVolume[l];
				int num3 = (int)AudioSourceSpatialBlend[l];
				float num4 = (float)num3 - num2 / 10f;
				AudioSourceVolume[l] = num4 * 0.01f * 1.8f;
				float2 x = obj - PlayerRenderPosition * num3;
				float2 value = math.normalizesafe(x, float2.zero);
				AudioSourceDirection[l] = value;
				AudioSourceSpatialBlend[l] = math.max(0.01f, math.length(x) / (float)(num3 * 10));
			}
		}
	}

	private const int SIZE = 10;

	private const int SIZE_SQUARE = 100;

	private const float VOLUME_CONTRIBUTION_PER_TILE = 0.01f;

	private const float VOLUME_MULTIPLIER = 1.8f;

	public float recomputeIntervalSeconds;

	public float recomputeAfterDistanceMoved;

	public List<AmbientSound> ambientSounds;

	private float2 _lastComputedPlayerWorldPosition;

	private TimerSimple _recomputeTimer;

	private bool _shouldPlayAmbientSounds;

	private bool _ambientSoundLevelUpdatePending;

	private float _assetLoadVolumeThreshold = 0.02f;

	private float _assetUnloadVolumeThreshold = 0.01f;

	private ComputeFromNearbyTilesJob _computeFromNearbyTilesJob;

	private JobHandle _computeFromNearbyTilesJobHandle;

	public JobHandle GetNearbyTileData(out NativeHashMap<TileTypeAndTileset, int> tileCount)
	{
		tileCount = _computeFromNearbyTilesJob.NearbyTileCount;
		return _computeFromNearbyTilesJobHandle;
	}

	private void Awake()
	{
		NativeParallelMultiHashMap<TileTypeAndTileset, int> audioSourceByTile = new NativeParallelMultiHashMap<TileTypeAndTileset, int>(64, Allocator.Persistent);
		for (int i = 0; i < ambientSounds.Count; i++)
		{
			AmbientSound ambientSound = ambientSounds[i];
			ambientSound.audioInfo.audio.volume = 0f;
			foreach (ContributingTiles contributingTile in ambientSound.contributingTiles)
			{
				TileTypeAndTileset key = new TileTypeAndTileset
				{
					TileType = contributingTile.tileType,
					Tileset = contributingTile.tileset
				};
				audioSourceByTile.Add(key, i);
			}
		}
		_computeFromNearbyTilesJob = new ComputeFromNearbyTilesJob
		{
			NearbyTileCount = new NativeHashMap<TileTypeAndTileset, int>(64, Allocator.Persistent),
			AudioSourceByTile = audioSourceByTile,
			AudioSourceDirection = new NativeArray<float2>(ambientSounds.Count, Allocator.Persistent),
			AudioSourceVolume = new NativeArray<float>(ambientSounds.Count, Allocator.Persistent),
			AudioSourceSpatialBlend = new NativeArray<float>(ambientSounds.Count, Allocator.Persistent)
		};
		_recomputeTimer.Start(0.1f);
		_lastComputedPlayerWorldPosition = float.MaxValue;
		PlatformConfiguration instance = PlatformConfiguration.Instance;
		if (instance != null)
		{
			_assetLoadVolumeThreshold = instance.PerformanceDeviceProfile.AmbienceAssetLoadThreshold;
			_assetUnloadVolumeThreshold = instance.PerformanceDeviceProfile.AmbienceAssetUnloadThreshold;
		}
		if (_assetLoadVolumeThreshold <= _assetUnloadVolumeThreshold)
		{
			Debug.LogWarning("AmbientSoundsHandler: ambient asset load threshold is lower or the same as the unload threshold! Fixing...");
			_assetLoadVolumeThreshold = 0.02f;
			_assetUnloadVolumeThreshold = 0.01f;
		}
	}

	private void OnDestroy()
	{
		_computeFromNearbyTilesJobHandle.Complete();
		_computeFromNearbyTilesJob.NearbyTileCount.Dispose();
		_computeFromNearbyTilesJob.AudioSourceByTile.Dispose();
		_computeFromNearbyTilesJob.AudioSourceDirection.Dispose();
		_computeFromNearbyTilesJob.AudioSourceVolume.Dispose();
		_computeFromNearbyTilesJob.AudioSourceSpatialBlend.Dispose();
		foreach (AmbientSound ambientSound in ambientSounds)
		{
			ambientSound.audioInfo.ReleaseAudioAsset();
		}
	}

	private void Update()
	{
		_shouldPlayAmbientSounds = Manager.sceneHandler != null && Manager.sceneHandler.isInGame && Manager.main.player != null;
		if (_shouldPlayAmbientSounds)
		{
			float2 float5 = Manager.main.player.WorldPosition.ToFloat2();
			float num = math.lengthsq(float5 - _lastComputedPlayerWorldPosition);
			if (_recomputeTimer.isTimerElapsed || !(num <= recomputeAfterDistanceMoved))
			{
				_ambientSoundLevelUpdatePending = true;
				_recomputeTimer.Start(math.max(recomputeIntervalSeconds + UnityEngine.Random.Range(-0.5f, 0f), 0f));
				_lastComputedPlayerWorldPosition = float5;
				JobHandle tileLayerLookup = Manager.multiMap.GetTileLayerLookup(default(JobHandle), out _computeFromNearbyTilesJob.TileLookup);
				_computeFromNearbyTilesJob.CameraOrigin = Manager.camera.RenderOrigo.ToInt2();
				_computeFromNearbyTilesJob.PlayerRenderPosition = Manager.main.player.RenderPosition.RoundToInt2();
				_computeFromNearbyTilesJobHandle = _computeFromNearbyTilesJob.Schedule(tileLayerLookup);
				Manager.multiMap.AddTileLayerLookupDependency(_computeFromNearbyTilesJobHandle);
			}
		}
	}

	public void LateUpdate()
	{
		if (!_shouldPlayAmbientSounds)
		{
			foreach (AmbientSound ambientSound in ambientSounds)
			{
				ambientSound.audioInfo.audio.volume = 0f;
				ambientSound.audioInfo.ReleaseAudioAsset();
			}
			return;
		}
		if (!_ambientSoundLevelUpdatePending)
		{
			return;
		}
		_computeFromNearbyTilesJobHandle.Complete();
		_ambientSoundLevelUpdatePending = false;
		for (int i = 0; i < ambientSounds.Count; i++)
		{
			float num = math.clamp(_computeFromNearbyTilesJob.AudioSourceVolume[i] * ambientSounds[i].audioInfo.volumeMultiply, 0f, 1f);
			ambientSounds[i].audioInfo.audio.volume = num;
			if (num <= _assetUnloadVolumeThreshold)
			{
				ambientSounds[i].audioInfo.ReleaseAudioAsset();
				continue;
			}
			if (ambientSounds[i].audioInfo.audio.volume > _assetLoadVolumeThreshold)
			{
				ambientSounds[i].audioInfo.LoadAudioAsset();
			}
			ambientSounds[i].audioInfo.audio.gameObject.transform.localPosition = new Vector3(_computeFromNearbyTilesJob.AudioSourceDirection[i].x, 0f, _computeFromNearbyTilesJob.AudioSourceDirection[i].y) * 0.1f;
			ambientSounds[i].audioInfo.audio.spatialBlend = math.max(0.01f, _computeFromNearbyTilesJob.AudioSourceSpatialBlend[i]);
		}
	}
}
