using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Animancer
{
	public static class ObjectPool
	{
		public static class Disposable
		{
			public static ObjectPool<T>.Disposable Acquire<T>(out T item) where T : class, new()
			{
				return new ObjectPool<T>.Disposable(out item);
			}

			public static ObjectPool<List<T>>.Disposable AcquireList<T>(out List<T> list)
			{
				return new ObjectPool<List<T>>.Disposable(out list, delegate(List<T> l)
				{
					l.Clear();
				});
			}

			public static ObjectPool<HashSet<T>>.Disposable AcquireSet<T>(out HashSet<T> set)
			{
				return new ObjectPool<HashSet<T>>.Disposable(out set, delegate(HashSet<T> s)
				{
					s.Clear();
				});
			}

			public static ObjectPool<GUIContent>.Disposable AcquireContent(out GUIContent content, string text = null, string tooltip = null, bool narrowText = true)
			{
				ObjectPool<GUIContent>.Disposable result = new ObjectPool<GUIContent>.Disposable(out content, delegate(GUIContent c)
				{
					c.text = null;
					c.tooltip = null;
					c.image = null;
				});
				content.text = text;
				content.tooltip = tooltip;
				content.image = null;
				return result;
			}
		}

		public const string NotClearError = " They must be cleared before being released to the pool and not modified after that.";

		public static T Acquire<T>() where T : class, new()
		{
			return ObjectPool<T>.Acquire();
		}

		public static void Acquire<T>(out T item) where T : class, new()
		{
			item = ObjectPool<T>.Acquire();
		}

		public static void Release<T>(T item) where T : class, new()
		{
			ObjectPool<T>.Release(item);
		}

		public static void Release<T>(ref T item) where T : class, new()
		{
			ObjectPool<T>.Release(item);
			item = null;
		}

		public static List<T> AcquireList<T>()
		{
			return ObjectPool<List<T>>.Acquire();
		}

		public static void Acquire<T>(out List<T> list)
		{
			list = AcquireList<T>();
		}

		public static void Release<T>(List<T> list)
		{
			list.Clear();
			ObjectPool<List<T>>.Release(list);
		}

		public static void Release<T>(ref List<T> list)
		{
			Release(list);
			list = null;
		}

		public static HashSet<T> AcquireSet<T>()
		{
			return ObjectPool<HashSet<T>>.Acquire();
		}

		public static void Acquire<T>(out HashSet<T> set)
		{
			set = AcquireSet<T>();
		}

		public static void Release<T>(HashSet<T> set)
		{
			set.Clear();
			ObjectPool<HashSet<T>>.Release(set);
		}

		public static void Release<T>(ref HashSet<T> set)
		{
			Release(set);
			set = null;
		}

		public static StringBuilder AcquireStringBuilder()
		{
			return ObjectPool<StringBuilder>.Acquire();
		}

		public static void Release(StringBuilder builder)
		{
			builder.Length = 0;
			ObjectPool<StringBuilder>.Release(builder);
		}

		public static string ReleaseToString(this StringBuilder builder)
		{
			string result = builder.ToString();
			Release(builder);
			return result;
		}
	}
	public static class ObjectPool<T> where T : class, new()
	{
		public readonly struct Disposable : IDisposable
		{
			public readonly T Item;

			public readonly Action<T> OnRelease;

			public Disposable(out T item, Action<T> onRelease = null)
			{
				Item = (item = ObjectPool<T>.Acquire());
				OnRelease = onRelease;
			}

			void IDisposable.Dispose()
			{
				OnRelease?.Invoke(Item);
				ObjectPool<T>.Release(Item);
			}
		}

		private static readonly List<T> Items = new List<T>();

		public static int Count
		{
			get
			{
				return Items.Count;
			}
			set
			{
				int num = Items.Count;
				if (num < value)
				{
					if (Items.Capacity < value)
					{
						Items.Capacity = Mathf.NextPowerOfTwo(value);
					}
					do
					{
						Items.Add(new T());
						num++;
					}
					while (num < value);
				}
				else if (num > value)
				{
					Items.RemoveRange(value, num - value);
				}
			}
		}

		public static int Capacity
		{
			get
			{
				return Items.Capacity;
			}
			set
			{
				if (Items.Count > value)
				{
					Items.RemoveRange(value, Items.Count - value);
				}
				Items.Capacity = value;
			}
		}

		public static void IncreaseCountTo(int count)
		{
			if (Count < count)
			{
				Count = count;
			}
		}

		public static void IncreaseCapacityTo(int capacity)
		{
			if (Capacity < capacity)
			{
				Capacity = capacity;
			}
		}

		public static T Acquire()
		{
			int count = Items.Count;
			if (count == 0)
			{
				return new T();
			}
			count--;
			T result = Items[count];
			Items.RemoveAt(count);
			return result;
		}

		public static void Release(T item)
		{
			Items.Add(item);
		}

		public static string GetDetails()
		{
			return typeof(T).Name + string.Format(" ({0} = {1}", "Count", Items.Count) + string.Format(", {0} = {1}", "Capacity", Items.Capacity) + ")";
		}
	}
}
