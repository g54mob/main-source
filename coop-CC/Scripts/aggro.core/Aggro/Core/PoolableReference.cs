using System;
using System.Diagnostics;
using UnityEngine;

namespace Aggro.Core
{
	public struct PoolableReference
	{
		internal GameObject obj;

		internal int generation;

		internal int poolGeneration;

		internal IGameObjectPool pool;

		public bool isValid => obj != null;

		public static PoolableReference invalid => default(PoolableReference);

		public GameObject gameObject => obj;

		public void Release()
		{
			pool.Release(obj);
			obj = null;
		}

		public PoolableReference<T> WithComponent<T>() where T : Component
		{
			return new PoolableReference<T>
			{
				reference = this,
				comp = obj.GetComponent<T>()
			};
		}

		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal void CheckValidReference()
		{
			if (!isValid)
			{
				throw new InvalidOperationException("Pool Reference is not valid!");
			}
		}
	}
	public struct PoolableReference<T> where T : Component
	{
		internal PoolableReference reference;

		internal T comp;

		public static PoolableReference<T> invalid;

		public bool isValid => reference.isValid;

		public PoolableReference generic => reference;

		public GameObject gameObject => reference.gameObject;

		public T component => comp;

		public void Release()
		{
			reference.Release();
		}
	}
}
