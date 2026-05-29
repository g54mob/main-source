using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	[Obsolete]
	[UsedImplicitly]
	public class Pool<T> : IPool
	{
		private readonly List<T> mObjects;

		private double mLastTime;

		private double mDeltaTime;

		public string Identifier { get; set; }

		public PoolSettings Settings { get; protected set; }

		public Type Type => null;

		public int Count => 0;

		public Pool(PoolSettings settings = null)
		{
		}

		public void Update()
		{
		}

		public void Reset()
		{
		}

		public void Clear()
		{
		}

		public virtual T Pop(Transform parent = null)
		{
			return default(T);
		}

		public virtual void Push(T item)
		{
		}

		protected virtual void sendBeforePush(T item)
		{
		}

		protected virtual void sendAfterPop(T item)
		{
		}

		protected virtual void setParent(T item, Transform parent)
		{
		}

		protected virtual T create()
		{
			return default(T);
		}

		protected virtual void destroy(T item)
		{
		}

		private void log(string msg)
		{
		}
	}
}
