using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Factory.Allocators;
using JetBrains.Annotations;
using Unity.Profiling;
using UnityEngine;

namespace Factory.Pools
{
	public class Pool<T> : IAllocator<T>, IDisposable, IPoolInspectable where T : IReusable
	{
		private class Entry
		{
			public T Object { get; private set; }

			public Entry Next { get; set; }

			public Entry(T obj, Entry nextEntry)
			{
				Object = obj;
				Next = nextEntry;
			}
		}

		private readonly IAllocator<T> _objectAllocator;

		private Entry _firstFreeEntry;

		private Entry _firstUsedEntry;

		private int _allocatedObjectCount;

		private int _freeObjectCount;

		private Dictionary<MemberInfo, int> _referenceMembers;

		private Vector3 _referencePosition;

		private Quaternion _referenceRotation;

		private Vector3 _referenceScale;

		private readonly string GrowProfilerSampleName = "Pool<" + typeof(T).Name + ">.Grow";

		private static readonly ProfilerMarker Profiler_ValidatingObjectScrubbing = new ProfilerMarker(ProfilerCategory.Memory, "Pool.ValidatingObjectScrubbing");

		public int InitialSize { get; set; }

		public GrowthStrategy GrowthStrategy { get; set; }

		public int BlockSize { get; set; }

		public int LastGrownBy { get; private set; }

		public bool NoUsedEntries => _firstUsedEntry == null;

		public bool IsValidatingObjectScrubbing { get; set; }

		public int AllocatedObjectCount => _allocatedObjectCount;

		public Pool(IAllocator<T> objectAllocator)
		{
			_objectAllocator = objectAllocator;
			InitialSize = 10;
			GrowthStrategy = GrowthStrategy.Block;
			BlockSize = 10;
			if (FeatureToggle.IsFeatureEnabled(Feature.ValidatePooledObjectScrubbing))
			{
				IsValidatingObjectScrubbing = true;
			}
			else
			{
				IsValidatingObjectScrubbing = false;
			}
		}

		public T Allocate(IScope context)
		{
			if (_firstFreeEntry == null)
			{
				if (_firstUsedEntry == null)
				{
					Grow(InitialSize, context);
				}
				else
				{
					switch (GrowthStrategy)
					{
					case GrowthStrategy.OnDemand:
						Grow(1, context);
						break;
					case GrowthStrategy.Block:
						Grow(BlockSize, context);
						break;
					}
				}
			}
			if (_firstFreeEntry == null)
			{
				return default(T);
			}
			Entry firstFreeEntry = _firstFreeEntry;
			_firstFreeEntry = firstFreeEntry.Next;
			firstFreeEntry.Next = _firstUsedEntry;
			_firstUsedEntry = firstFreeEntry;
			_allocatedObjectCount++;
			_freeObjectCount--;
			OnObjectAllocated(firstFreeEntry.Object, context);
			return firstFreeEntry.Object;
		}

		public bool Release(T obj, IScope context)
		{
			Entry entry = null;
			Entry entry2 = _firstUsedEntry;
			while (entry2 != null && (object)entry2.Object != (object)obj)
			{
				entry = entry2;
				entry2 = entry2.Next;
			}
			if (entry2 == null)
			{
				return false;
			}
			if (entry == null)
			{
				_firstUsedEntry = entry2.Next;
			}
			else
			{
				entry.Next = entry2.Next;
			}
			entry2.Next = _firstFreeEntry;
			_firstFreeEntry = entry2;
			_allocatedObjectCount--;
			_freeObjectCount++;
			obj.Reset();
			if (IsValidatingObjectScrubbing)
			{
				if (_referenceMembers == null)
				{
					bool flag = false;
					T val;
					if (_firstFreeEntry != null)
					{
						val = _firstFreeEntry.Object;
					}
					else
					{
						val = _objectAllocator.Allocate(context);
						flag = true;
					}
					_referenceMembers = new Dictionary<MemberInfo, int>();
					FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						if (fieldInfo.GetCustomAttribute<DependencyAttribute>() == null && fieldInfo.GetCustomAttribute<UnscrubbedAttribute>() == null)
						{
							if (typeof(ICollection).IsAssignableFrom(fieldInfo.FieldType))
							{
								int value = ((!(fieldInfo.GetValue(val) is ICollection collection)) ? (-1) : collection.Count);
								_referenceMembers[fieldInfo] = value;
							}
							else if (fieldInfo.FieldType.IsPrimitive || fieldInfo.FieldType.IsValueType)
							{
								int value2 = fieldInfo.GetValue(val)?.GetHashCode() ?? 0;
								_referenceMembers[fieldInfo] = value2;
							}
						}
					}
					if (typeof(Component).IsAssignableFrom(typeof(T)))
					{
						Transform transform = (val as Component)?.transform;
						if (transform != null)
						{
							_referencePosition = transform.localPosition;
							_referenceRotation = transform.localRotation;
							_referenceScale = transform.localScale;
						}
					}
					if (flag)
					{
						_objectAllocator.Release(val, context);
					}
				}
				List<string> list = new List<string>();
				foreach (MemberInfo key in _referenceMembers.Keys)
				{
					if (key is FieldInfo)
					{
						FieldInfo fieldInfo2 = key as FieldInfo;
						object value3 = fieldInfo2.GetValue(obj);
						int num = 0;
						num = ((!typeof(ICollection).IsAssignableFrom(fieldInfo2.FieldType)) ? (value3?.GetHashCode() ?? 0) : ((!(value3 is ICollection collection2)) ? (-1) : collection2.Count));
						int num2 = _referenceMembers[key];
						if (num != num2)
						{
							list.Add(key.Name);
						}
					}
				}
				if (typeof(Component).IsAssignableFrom(typeof(T)))
				{
					Transform transform2 = (obj as Component)?.transform;
					if (transform2 != null)
					{
						if (transform2.localPosition != _referencePosition)
						{
							list.Add("transform.localPosition");
						}
						if (transform2.localRotation != _referenceRotation)
						{
							list.Add("transform.localRotation");
						}
						if (transform2.localScale != _referenceScale)
						{
							list.Add("transform.localScale");
						}
					}
				}
				if (list.Count > 0)
				{
					Diagnostics.FailAssert("{0} has {1} ({2}).", obj, (list.Count > 1) ? "unscrubbed members" : "an unscrubbed member", string.Join(", ", list));
				}
			}
			OnObjectReleased(obj, context);
			return true;
		}

		public void Clear()
		{
			if (_firstUsedEntry != null)
			{
				Entry entry = _firstUsedEntry;
				while (entry.Next != null)
				{
					entry = entry.Next;
					_allocatedObjectCount--;
					_freeObjectCount++;
				}
				entry.Next = _firstFreeEntry;
				_firstFreeEntry = _firstUsedEntry;
				_firstUsedEntry = null;
			}
		}

		protected virtual void OnObjectCreated(T obj, IScope context)
		{
		}

		protected virtual void OnObjectAllocated(T obj, IScope context)
		{
		}

		public virtual void OnObjectAssembled(T obj, IScope context)
		{
		}

		protected virtual void OnObjectReleased(T obj, IScope context)
		{
		}

		public void Dispose()
		{
			for (Entry entry = _firstFreeEntry; entry != null; entry = entry.Next)
			{
				_objectAllocator.Release(entry.Object, null);
			}
			_firstFreeEntry = null;
			for (Entry entry = _firstUsedEntry; entry != null; entry = entry.Next)
			{
				_objectAllocator.Release(entry.Object, null);
			}
			_firstUsedEntry = null;
		}

		private void Grow(int size, IScope context)
		{
			int num = 0;
			for (int i = 0; i < size; i++)
			{
				T obj = _objectAllocator.Allocate(context);
				OnObjectCreated(obj, context);
				Entry firstFreeEntry = new Entry(obj, _firstFreeEntry);
				_firstFreeEntry = firstFreeEntry;
				num++;
			}
			LastGrownBy = num;
			_freeObjectCount += size;
		}

		public void GetAllElements([NotNull] List<object> allocated, [NotNull] List<object> free)
		{
			allocated.Clear();
			for (Entry entry = _firstUsedEntry; entry != null; entry = entry.Next)
			{
				allocated.Add(entry.Object);
			}
			free.Clear();
			for (Entry entry = _firstFreeEntry; entry != null; entry = entry.Next)
			{
				free.Add(entry.Object);
			}
		}

		protected virtual bool DefaultExpanded()
		{
			return true;
		}

		protected virtual string GroupingName(object entryInstance)
		{
			return "Hash Code " + entryInstance.GetHashCode();
		}

		public void InspectEntryGrouping(object entryInstance, Dictionary<object, bool> expandedLookup)
		{
		}

		public virtual void InspectEntry(object entryInstance)
		{
		}
	}
}
