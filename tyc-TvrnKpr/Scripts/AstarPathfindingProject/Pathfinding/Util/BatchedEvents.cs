using System;
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
			}

			public void Remove(int index)
			{
			}
		}

		private const int ArchetypeOffset = 22;

		private const int ArchetypeMask = 1069547520;

		private static Archetype[] data;

		private static BatchedEvents instance;

		private static int isIteratingOverTypeIndex;

		private static bool isIterating;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private static void CreateInstance()
		{
		}

		public static T Find<T, K>(K key, Func<T, K, bool> predicate) where T : class, IEntityIndex
		{
			return null;
		}

		public static void Remove<T>(T obj) where T : IEntityIndex
		{
		}

		public static int GetComponents<T>(Event eventTypes, out TransformAccessArray transforms, out T[] components) where T : Component, IEntityIndex
		{
			transforms = default(TransformAccessArray);
			components = null;
			return 0;
		}

		public static bool Has<T>(T obj) where T : IEntityIndex
		{
			return false;
		}

		public static void Add<T>(T obj, Event eventTypes, Action<T[], int> action, int archetypeVariant = 0) where T : Component, IEntityIndex
		{
		}

		public static void Add<T>(T obj, Event eventTypes, Action<T[], int, TransformAccessArray, Event> action, int archetypeVariant = 0) where T : Component, IEntityIndex
		{
		}

		private static void Add<T>(T obj, Event eventTypes, Action<T[], int, TransformAccessArray, Event> action1, Action<T[], int> action2, int archetypeVariant = 0) where T : Component, IEntityIndex
		{
		}

		private void Process(Event eventType, Type typeFilter)
		{
		}

		public static void ProcessEvent<T>(Event eventType)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
