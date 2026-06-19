using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolablePrefabBank : ScriptableObject
{
	[Serializable]
	public class PoolablePrefab
	{
		public GameObject prefab;

		public int initialSize = 16;

		public int maxFreeSize = 16;

		public int maxSize = 32;
	}

	[Serializable]
	public class PlatformObjectPoolScaling
	{
		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Scale to apply for the amount of pooled objects initial values.")]
		private float initialPoolScale = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Scale to apply for the amount of pooled objects max values.")]
		private float maxPoolScale = 1f;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Scale to apply for the amount of free objects max values.")]
		private float maxFreeScale = 1f;

		[SerializeField]
		[Tooltip("Initial pooled amount will not decrease below this value through scaling unless set lower in the related PoolablePrefab.")]
		public int initialHardMinimum = 1;

		[SerializeField]
		[Tooltip("Max pooled amount will not decrease below this value through scaling unless set lower in the related PoolablePrefab.")]
		public int maxHardMinimum = 32;

		[SerializeField]
		[Tooltip("Max pooled amount will not decrease below this value through scaling unless set lower in the related PoolablePrefab.")]
		public int maxFreeHardMinimum = 32;

		[field: SerializeField]
		[field: Tooltip("Device platform to use the scaling for.")]
		public RuntimePlatform Platform { get; set; }

		public int GetScaledInitialAmount(PoolablePrefab prefabBank)
		{
			return Mathf.Clamp(Mathf.CeilToInt((float)prefabBank.initialSize * initialPoolScale), initialHardMinimum, prefabBank.initialSize);
		}

		public int GetScaledMaxAmount(PoolablePrefab prefabBank)
		{
			return Mathf.Clamp(Mathf.CeilToInt((float)prefabBank.maxSize * maxPoolScale), maxHardMinimum, prefabBank.maxSize);
		}

		public int GetScaledMaxFreeAmount(PoolablePrefab prefabBank)
		{
			return Mathf.Clamp(Mathf.CeilToInt((float)prefabBank.maxFreeSize * maxFreeScale), maxFreeHardMinimum, prefabBank.maxFreeSize);
		}
	}

	public abstract IEnumerator<PoolablePrefab> GetEnumerator();

	public virtual bool TryGetCurrentPlatformPoolScaling(out PlatformObjectPoolScaling poolScaling)
	{
		poolScaling = null;
		return false;
	}
}
