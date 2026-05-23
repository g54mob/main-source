using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Battle
{
	public class HitEffect : BaseBattleEffect
	{
		private class PrefabEffectManager
		{
			private readonly LinkedList<HitEffect> _activeEffects;

			private readonly Dictionary<HitEffect, LinkedListNode<HitEffect>> _effectNodes;

			private readonly HitEffect _prefab;

			private int MaxInstances => 0;

			public PrefabEffectManager(HitEffect prefab)
			{
			}

			public void AddEffect(HitEffect effect)
			{
			}

			public void RemoveEffect(HitEffect effect)
			{
			}

			public HitEffect GetOrReuseOldest()
			{
				return null;
			}

			public void CleanupInvalidEffects()
			{
			}
		}

		public bool finishKill;

		[Label("有効：フリップ")]
		public bool isFlip;

		[Label("有効：Z回転")]
		[Tooltip("方向数2では無効")]
		public bool isRotation;

		[Label("エフェクトを間引かない")]
		public bool importantEffect;

		private const int MaxInstancesLowFPS = 1;

		private const int MaxInstancesMidFPS = 3;

		private const int MaxInstancesHighFPS = 30;

		private const float LowFPSThreshold = 30f;

		private const float HighFPSThreshold = 50f;

		private int _cachedMaxInstances;

		private float _lastCacheTime;

		private const float CacheInterval = 0.5f;

		public UnityAction FinishAction;

		private bool _isNewCreated;

		private bool _ignoreKill;

		private static readonly Dictionary<HitEffect, PrefabEffectManager> _prefabManagers;

		private int MaxInstancesPerPrefab => 0;

		private int CalculateMaxInstances()
		{
			return 0;
		}

		protected override void Update()
		{
		}

		private void OnDisable()
		{
		}

		private void AddToPrefabManager(HitEffect prefab)
		{
		}

		private void RemoveFromPrefabManager()
		{
		}

		private void StopAndResetEffect()
		{
		}

		public void ForceFinishEffect()
		{
		}

		public HitEffect CreateEffect()
		{
			return null;
		}

		public HitEffect PlayEffect(Vector3 position, float degree, bool newCreate = true, UnityAction finishAction = null)
		{
			return null;
		}

		public HitEffect PlayEffect(Vector3 position, Vector2 dirVec, bool newCreate = true, UnityAction finishAction = null)
		{
			return null;
		}

		public void PlayEffect(Vector3 position, string animationName, Vector2 dirVec)
		{
		}
	}
}
