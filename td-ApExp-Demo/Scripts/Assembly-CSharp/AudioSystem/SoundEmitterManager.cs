using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.Pool;

namespace AudioSystem
{
	public class SoundEmitterManager : PersistentSingleton<SoundEmitterManager>
	{
		[NonSerialized]
		public IObjectPool<SoundEmitter> soundEmitterPool;

		public readonly List<SoundEmitter> activeSoundEmitters = new List<SoundEmitter>();

		[SerializeField]
		private SoundEmitter soundEmitterPrefab;

		[SerializeField]
		private bool collectionCheck = true;

		[SerializeField]
		private int defaultCapacity = 10;

		[SerializeField]
		private int maxPoolSize = 100;

		[SerializeField]
		private SerializedDictionary<FrequentSoundTypes, int> maxSoundInstances;

		public Dictionary<FrequentSoundTypes, LinkedList<SoundEmitter>> FrequentSoundEmitters;

		private void Start()
		{
			InitializePool();
			FrequentSoundEmitters = new Dictionary<FrequentSoundTypes, LinkedList<SoundEmitter>>();
			foreach (FrequentSoundTypes value in Enum.GetValues(typeof(FrequentSoundTypes)))
			{
				FrequentSoundEmitters.Add(value, new LinkedList<SoundEmitter>());
			}
		}

		public SoundBuilder CreateSoundBuilder()
		{
			return new SoundBuilder(this);
		}

		public bool CanPlaySound(SoundData data)
		{
			if (!data.frequentSound)
			{
				return true;
			}
			if (FrequentSoundEmitters[data.frequentSoundType].Count >= maxSoundInstances[data.frequentSoundType])
			{
				try
				{
					FrequentSoundEmitters[data.frequentSoundType].First.Value.Stop();
					return true;
				}
				catch
				{
					Debug.Log("SoundEmitter is already released");
				}
				return false;
			}
			return true;
		}

		public SoundEmitter Get()
		{
			return soundEmitterPool.Get();
		}

		public void ReturnToPool(SoundEmitter soundEmitter)
		{
			soundEmitterPool.Release(soundEmitter);
		}

		public void StopAll()
		{
			foreach (SoundEmitter item in new LinkedList<SoundEmitter>(activeSoundEmitters))
			{
				item.Stop();
			}
			foreach (LinkedList<SoundEmitter> value in FrequentSoundEmitters.Values)
			{
				value.Clear();
			}
		}

		private void InitializePool()
		{
			soundEmitterPool = new ObjectPool<SoundEmitter>(CreateSoundEmitter, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionCheck, defaultCapacity, maxPoolSize);
		}

		private SoundEmitter CreateSoundEmitter()
		{
			SoundEmitter soundEmitter = UnityEngine.Object.Instantiate(soundEmitterPrefab);
			soundEmitter.gameObject.SetActive(value: false);
			return soundEmitter;
		}

		private void OnTakeFromPool(SoundEmitter soundEmitter)
		{
			soundEmitter.gameObject.SetActive(value: true);
			activeSoundEmitters.Add(soundEmitter);
		}

		private void OnReturnedToPool(SoundEmitter soundEmitter)
		{
			if (soundEmitter.Node != null)
			{
				FrequentSoundEmitters[soundEmitter.FrequentSoundType].Remove(soundEmitter.Node);
				soundEmitter.Node = null;
			}
			soundEmitter.gameObject.SetActive(value: false);
			activeSoundEmitters.Remove(soundEmitter);
		}

		private void OnDestroyPoolObject(SoundEmitter soundEmitter)
		{
			UnityEngine.Object.Destroy(soundEmitter.gameObject);
		}
	}
}
