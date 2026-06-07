using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.Profiling;

namespace Pathfinding.Util
{
	[HelpURL("https://arongranberg.com/astar/documentation/stable/batchedevents.html")]
	public class BatchedEvents : VersionedMonoBehaviour
	{
		[Flags]
		public enum Event
		{
			Update = 1,
			LateUpdate = 2,
			FixedUpdate = 4,
			Custom = 8,
			None = 0
		}

		private struct Archetype
		{
			public object[] objects;

			public int objectCount;

			public Type type;

			public TransformAccessArray transforms;

			public int variant;

			public int archetypeIndex;

			public Event events;

			public Action<object[], int, TransformAccessArray, Event> action;

			public CustomSampler sampler;

			public void Add(Component obj)
			{
				objectCount++;
				if (objects == null)
				{
					objects = (object[])Array.CreateInstance(type, math.ceilpow2(objectCount));
				}
				if (objectCount > objects.Length)
				{
					Array array = Array.CreateInstance(type, math.ceilpow2(objectCount));
					objects.CopyTo(array, 0);
					objects = (object[])array;
				}
				objects[objectCount - 1] = obj;
				if (!transforms.isCreated)
				{
					transforms = new TransformAccessArray(16);
				}
				transforms.Add(obj.transform);
				((IEntityIndex)obj).EntityIndex = (archetypeIndex << 22) | (objectCount - 1);
			}

			public void Remove(int index)
			{
				objectCount--;
				((IEntityIndex)objects[objectCount]).EntityIndex = (archetypeIndex << 22) | index;
				((IEntityIndex)objects[index]).EntityIndex = 0;
				objects[index] = objects[objectCount];
				objects[objectCount] = null;
				transforms.RemoveAtSwapBack(index);
				if (objectCount == 0)
				{
					transforms.Dispose();
				}
			}
		}

		private const int ArchetypeOffset = 22;

		private const int ArchetypeMask = 1069547520;

		private static Archetype[] data = new Archetype[0];

		private static BatchedEvents instance;

		private static int isIteratingOverTypeIndex = -1;

		private static bool isIterating = false;

		private void OnEnable()
		{
			if (instance == null)
			{
				instance = this;
			}
			_ = instance != this;
		}

		private static void CreateInstance()
		{
			GameObject obj = new GameObject("Batch Helper")
			{
				hideFlags = (HideFlags.HideAndDontSave | HideFlags.HideInInspector)
			};
			instance = obj.AddComponent<BatchedEvents>();
			UnityEngine.Object.DontDestroyOnLoad(obj);
		}

		public static T Find<T, K>(K key, Func<T, K, bool> predicate) where T : class, IEntityIndex
		{
			Type typeFromHandle = typeof(T);
			for (int i = 0; i < data.Length; i++)
			{
				if (!(data[i].type == typeFromHandle))
				{
					continue;
				}
				T[] array = data[i].objects as T[];
				for (int j = 0; j < data[i].objectCount; j++)
				{
					if (predicate(array[j], key))
					{
						return array[j];
					}
				}
			}
			return null;
		}

		public static void Remove<T>(T obj) where T : IEntityIndex
		{
			int entityIndex = obj.EntityIndex;
			if (entityIndex != 0)
			{
				int num = ((entityIndex & 0x3FC00000) >> 22) - 1;
				entityIndex &= -1069547521;
				if (isIterating && isIteratingOverTypeIndex == num)
				{
					throw new Exception("Cannot add or remove entities during an event (Update/LateUpdate/...) that this helper initiated");
				}
				data[num].Remove(entityIndex);
			}
		}

		public static int GetComponents<T>(Event eventTypes, out TransformAccessArray transforms, out T[] components) where T : Component, IEntityIndex
		{
			if (instance == null)
			{
				CreateInstance();
			}
			int num = (int)eventTypes * 12582917;
			if (isIterating && isIteratingOverTypeIndex == num)
			{
				throw new Exception("Cannot add or remove entities during an event (Update/LateUpdate/...) that this helper initiated");
			}
			Type typeFromHandle = typeof(T);
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].type == typeFromHandle && data[i].variant == num)
				{
					transforms = data[i].transforms;
					components = data[i].objects as T[];
					return data[i].objectCount;
				}
			}
			transforms = default(TransformAccessArray);
			components = null;
			return 0;
		}

		public static bool Has<T>(T obj) where T : IEntityIndex
		{
			return obj.EntityIndex != 0;
		}

		public static void Add<T>(T obj, Event eventTypes, Action<T[], int> action, int archetypeVariant = 0) where T : Component, IEntityIndex
		{
			Add(obj, eventTypes, null, action, archetypeVariant);
		}

		public static void Add<T>(T obj, Event eventTypes, Action<T[], int, TransformAccessArray, Event> action, int archetypeVariant = 0) where T : Component, IEntityIndex
		{
			Add(obj, eventTypes, action, null, archetypeVariant);
		}

		private static void Add<T>(T obj, Event eventTypes, Action<T[], int, TransformAccessArray, Event> action1, Action<T[], int> action2, int archetypeVariant = 0) where T : Component, IEntityIndex
		{
			if (obj.EntityIndex != 0)
			{
				throw new ArgumentException("This object is already registered. Call Remove before adding the object again.");
			}
			if (instance == null)
			{
				CreateInstance();
			}
			archetypeVariant = (int)eventTypes * 12582917;
			if (isIterating && isIteratingOverTypeIndex == archetypeVariant)
			{
				throw new Exception("Cannot add or remove entities during an event (Update/LateUpdate/...) that this helper initiated");
			}
			Type type = obj.GetType();
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].type == type && data[i].variant == archetypeVariant)
				{
					data[i].Add(obj);
					return;
				}
			}
			Memory.Realloc(ref data, data.Length + 1);
			Action<T[], int, TransformAccessArray, Event> ac1 = action1;
			Action<T[], int> ac2 = action2;
			Action<object[], int, TransformAccessArray, Event> action3 = delegate(object[] objs, int count, TransformAccessArray tr, Event ev)
			{
				ac1((T[])objs, count, tr, ev);
			};
			Action<object[], int, TransformAccessArray, Event> action4 = delegate(object[] objs, int count, TransformAccessArray tr, Event ev)
			{
				ac2((T[])objs, count);
			};
			data[data.Length - 1] = new Archetype
			{
				type = type,
				events = eventTypes,
				variant = archetypeVariant,
				archetypeIndex = data.Length - 1 + 1,
				action = ((ac1 != null) ? action3 : action4),
				sampler = CustomSampler.Create(type.Name)
			};
			data[data.Length - 1].Add(obj);
		}

		private void Process(Event eventType, Type typeFilter)
		{
			try
			{
				isIterating = true;
				for (int i = 0; i < data.Length; i++)
				{
					ref Archetype reference = ref data[i];
					if (reference.objectCount > 0 && (reference.events & eventType) != Event.None && (typeFilter == null || typeFilter == reference.type))
					{
						isIteratingOverTypeIndex = reference.variant;
						try
						{
							reference.action(reference.objects, reference.objectCount, reference.transforms, eventType);
						}
						finally
						{
						}
					}
				}
			}
			finally
			{
				isIterating = false;
			}
		}

		public static void ProcessEvent<T>(Event eventType)
		{
			instance?.Process(eventType, typeof(T));
		}

		private void Update()
		{
			Process(Event.Update, null);
		}

		private void LateUpdate()
		{
			Process(Event.LateUpdate, null);
		}

		private void FixedUpdate()
		{
			Process(Event.FixedUpdate, null);
		}
	}
}
