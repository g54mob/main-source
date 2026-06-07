using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	[HelpURL("https://curvyeditor.com/doclink/dtpoolmanager")]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class PoolManager : DTVersionedMonoBehaviour
	{
		[SerializeField]
		[Tooltip("Whether pools should be automatically created when requested but not found")]
		[Section("General", true, false, 100)]
		private bool m_AutoCreatePools;

		[AsGroup(null, Expanded = false)]
		[SerializeField]
		private PoolSettings m_DefaultSettings;

		public Dictionary<string, IPool> Pools;

		[Obsolete("TypePools are no more part of Curvy Splines")]
		[UsedImplicitly]
		public Dictionary<Type, IPool> TypePools;

		[UsedImplicitly]
		[Obsolete]
		private IPool[] mPools;

		public bool AutoCreatePools
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public PoolSettings DefaultSettings
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsInitialized { get; private set; }

		public int Count => 0;

		protected override void OnValidate()
		{
		}

		protected override void ResetOnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		[UsedImplicitly]
		private void Update()
		{
		}

		private void Initialize()
		{
		}

		[NotNull]
		public string GetUniqueIdentifier([NotNull] string ident)
		{
			return null;
		}

		[Obsolete("TypePools are no more part of Curvy Splines")]
		[UsedImplicitly]
		public Pool<T> GetTypePool<T>()
		{
			return null;
		}

		public ComponentPool GetComponentPool<T>() where T : Component
		{
			return null;
		}

		public PrefabPool GetPrefabPool([NotNull] string identifier, params GameObject[] prefabs)
		{
			return null;
		}

		[Obsolete("TypePools are no more part of Curvy Splines")]
		[UsedImplicitly]
		public Pool<T> CreateTypePool<T>(PoolSettings settings = null)
		{
			return null;
		}

		public ComponentPool CreateComponentPool<T>(PoolSettings settings = null) where T : Component
		{
			return null;
		}

		public PrefabPool CreatePrefabPool([NotNull] string name, PoolSettings settings = null, params GameObject[] prefabs)
		{
			return null;
		}

		public List<IPool> FindPools(string identifierStartsWith)
		{
			return null;
		}

		public void DeletePools(string startsWith)
		{
		}

		public void DeletePool(IPool pool)
		{
		}

		[UsedImplicitly]
		[Obsolete("TypePools are no more part of Curvy Splines")]
		public void DeletePool<T>()
		{
		}
	}
}
