using System;
using System.Collections.Generic;
using QFSW.MOP2;
using Rewired.Utils.Libraries.TinyJson;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Validation;

namespace VampireSurvivors.App.Framework
{
	public class GenericPoolFactory<T> : SerializedScriptableObject, IValidateReferences
	{
		[Serializable]
		public class PoolsDictionary : UnitySerializedDictionary<T, ObjectPool>
		{
		}

		[Serializable]
		public class PoolRefsDictionary : UnitySerializedDictionary<T, PrefabRefData>
		{
		}

		[Serializable]
		public class PrefabRefData
		{
			[SerializeField]
			private AssetReference _PoolRef;

			public AssetReference PoolRef
			{
				get
				{
					return null;
				}
				set
				{
				}
			}
		}

		[SerializeField]
		private ObjectPool _DefaultPool;

		[SerializeField]
		protected PoolsDictionary _Pools;

		[SerializeField]
		protected PoolRefsDictionary _PoolRefs;

		[SerializeField]
		private List<GenericPoolFactory<T>> _LinkedFactories;

		[DoNotSerialize]
		private readonly Dictionary<T, ObjectPool> _cachedPools;

		protected virtual GenericPoolFactory<T> GetDlcFactory(BundleManifestData bmd)
		{
			return null;
		}

		public void InitPools()
		{
		}

		public ObjectPool GetPool(T poolType)
		{
			return null;
		}

		public Dictionary<T, ObjectPool> GetAllPools()
		{
			return null;
		}

		public void PurgePools()
		{
		}

		private void InitPool(T poolType, ObjectPool pool)
		{
		}

		private void MergeFactoryAndInitPool(GenericPoolFactory<T> other, DlcType? dlcType)
		{
		}

		public List<string> ValidateReferences()
		{
			return null;
		}
	}
}
