using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.Utilities
{
	public class Materials : CTSSingleton<Materials>
	{
		public struct PooledMaterial : IEquatable<PooledMaterial>
		{
			public StringKey Key { get; }

			public Material Mat { get; }

			public PooledMaterial(StringKey key, Material mat)
			{
				Key = key;
				Mat = mat;
			}

			public static implicit operator Material(PooledMaterial pooledMaterial)
			{
				return pooledMaterial.Mat;
			}

			public bool Equals(PooledMaterial other)
			{
				if (Key == other.Key)
				{
					return Mat == other.Mat;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is PooledMaterial other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return Mat.GetHashCode();
			}
		}

		[SerializeField]
		private MaterialList _materialList;

		private readonly SerializableDictionary<StringKey, Stack<Material>> _pools = new SerializableDictionary<StringKey, Stack<Material>>();

		private readonly Dictionary<StringKey, Material> _sharedMaterials = new Dictionary<StringKey, Material>();

		public Material GetSharedMaterial(StringKey key)
		{
			if (!_sharedMaterials.TryGetValue(key, out var value))
			{
				if (!_materialList.Materials.TryGetValue(key, out var value2))
				{
					return null;
				}
				value = UnityEngine.Object.Instantiate(value2);
				_sharedMaterials[key] = value;
			}
			return value;
		}

		public PooledMaterial GetMaterialInstance(StringKey key)
		{
			if (!_pools.TryGetValue(key, out var value) || !value.TryPop(out var result))
			{
				return new PooledMaterial(key, UnityEngine.Object.Instantiate(_materialList.Materials[key]));
			}
			return new PooledMaterial(key, result);
		}

		public void PushMaterialInstance(PooledMaterial material)
		{
			if (!material.Key.IsValid())
			{
				Debug.LogException(new Exception("Key Invalid"));
				return;
			}
			if (!_pools.TryGetValue(material.Key, out var value))
			{
				value = new Stack<Material>();
				_pools[material.Key] = value;
			}
			if (!value.Contains(material.Mat))
			{
				value.Push(material.Mat);
			}
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
