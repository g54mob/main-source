using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	public abstract class UnityObjectPool<T> : DTVersionedMonoBehaviour, IPool where T : UnityEngine.Object
	{
		[NotNull]
		private readonly List<T> pooledObjects;

		[NotNull]
		[SerializeField]
		[Inline]
		private PoolSettings m_Settings;

		private double lastProcessingTime;

		private double unprocessedDuration;

		public virtual PoolSettings Settings
		{
			get
			{
				return null;
			}
			[Obsolete("The setter will be made private. Rather than assigning a new Settings instance, modify the existing one")]
			[UsedImplicitly]
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use GetComponent<PoolManager>() instead")]
		public PoolManager Manager => null;

		public int Count => 0;

		public abstract string Identifier { get; set; }

		private static double Now => 0.0;

		public virtual void Push(T item)
		{
		}

		[NotNull]
		public virtual T Pop(Transform parent = null)
		{
			return null;
		}

		public virtual void Clear()
		{
		}

		public void Update()
		{
		}

		public new void Reset()
		{
		}

		[NotNull]
		protected abstract T CreateObject();

		[NotNull]
		protected abstract GameObject GetItemGameObject([NotNull] T item);

		protected override void OnValidate()
		{
		}

		protected override void ResetOnEnable()
		{
		}

		protected void Initialize([NotNull] PoolSettings settings)
		{
		}

		protected void ConfigureCreatedGameObject([NotNull] GameObject item, string itemName)
		{
		}

		[UsedImplicitly]
		private void Start()
		{
		}

		private void DestroyObject([CanBeNull] T item)
		{
		}

		[NotNull]
		private T RetrievedPoppedItem()
		{
			return null;
		}

		private void ConfigurePushedGameObject([NotNull] GameObject item)
		{
		}

		private void ConfigurePoppedGameObject([NotNull] GameObject item, [CanBeNull] Transform parent)
		{
		}

		private void LogMessage(string message)
		{
		}

		private void AdjustItemsCount(int minItemsCount, int maxItemsCount, int maxAdjustmentsCount, bool logOperations)
		{
		}

		private void InstantShit()
		{
		}

		[UsedImplicitly]
		private void ResetTimeRelatedFields()
		{
		}

		private int GetAdjustmentsCount()
		{
			return 0;
		}
	}
}
