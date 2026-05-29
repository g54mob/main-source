using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class TransformExtensions
	{
		public readonly struct TransformChildrenEnumerator
		{
			public struct Enumerator : IEnumerator<Transform>, IEnumerator, IDisposable
			{
				private readonly Transform _transform;

				private int _currentIndex;

				public Transform Current { get; private set; }

				object IEnumerator.Current => Current;

				public Enumerator(Transform transform)
				{
					_transform = transform;
					_currentIndex = 0;
					Current = null;
				}

				public bool MoveNext()
				{
					if (_currentIndex >= _transform.childCount)
					{
						return false;
					}
					Current = _transform.GetChild(_currentIndex);
					_currentIndex++;
					return true;
				}

				public void Reset()
				{
				}

				public void Dispose()
				{
				}
			}

			private readonly Transform _transform;

			public TransformChildrenEnumerator(Transform transform)
			{
				_transform = transform;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(_transform);
			}
		}

		private static readonly Dictionary<int, Transform[]> _allocs = new Dictionary<int, Transform[]>();

		public static TransformChildrenEnumerator GetChildren(this Transform transform)
		{
			return new TransformChildrenEnumerator(transform);
		}

		public static Transform GetRandomChild(this Transform transform)
		{
			if (transform.childCount <= 0)
			{
				return null;
			}
			int index = UnityEngine.Random.Range(0, transform.childCount);
			return transform.GetChild(index);
		}

		public static Transform GetRandomChild(this Transform transform, Func<Transform, bool> filter)
		{
			int childCount = transform.childCount;
			if (childCount <= 0)
			{
				return null;
			}
			Transform[] alloc = GetAlloc(childCount);
			int num = 0;
			foreach (Transform child in transform.GetChildren())
			{
				if (filter(child))
				{
					alloc[num] = child;
					num++;
				}
			}
			if (num <= 0)
			{
				return null;
			}
			int num2 = UnityEngine.Random.Range(0, num);
			return alloc[num2];
		}

		public static Transform GetRandomChild<TArg>(this Transform transform, Func<Transform, TArg, bool> filter, TArg arg)
		{
			int childCount = transform.childCount;
			if (childCount <= 0)
			{
				return null;
			}
			Transform[] alloc = GetAlloc(childCount);
			int num = 0;
			foreach (Transform child in transform.GetChildren())
			{
				if (filter(child, arg))
				{
					alloc[num] = child;
					num++;
				}
			}
			if (num <= 0)
			{
				return null;
			}
			int num2 = UnityEngine.Random.Range(0, num);
			return alloc[num2];
		}

		public static Transform GetRandomChild<TArg1, TArg2>(this Transform transform, Func<Transform, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2)
		{
			int childCount = transform.childCount;
			if (childCount <= 0)
			{
				return null;
			}
			Transform[] alloc = GetAlloc(childCount);
			int num = 0;
			foreach (Transform child in transform.GetChildren())
			{
				if (filter(child, arg1, arg2))
				{
					alloc[num] = child;
					num++;
				}
			}
			if (num <= 0)
			{
				return null;
			}
			int num2 = UnityEngine.Random.Range(0, num);
			return alloc[num2];
		}

		private static Transform[] GetAlloc(int count)
		{
			if (!_allocs.TryGetValue(count, out var value))
			{
				value = new Transform[count];
				_allocs[count] = value;
			}
			return value;
		}

		public static void SetPositionAndRotation(this Transform transform, Transform anchor)
		{
			Transform transform2 = anchor.transform;
			transform.SetPositionAndRotation(transform2.position, transform2.rotation);
		}
	}
}
