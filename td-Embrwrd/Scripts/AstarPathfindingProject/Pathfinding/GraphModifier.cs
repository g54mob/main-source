using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[ExecuteInEditMode]
	public abstract class GraphModifier : VersionedMonoBehaviour
	{
		public enum EventType
		{
			PostScan = 1,
			PreScan = 2,
			LatePostScan = 4,
			PreUpdate = 8,
			PostUpdate = 0x10,
			PostCacheLoad = 0x20
		}

		private static GraphModifier root;

		private GraphModifier prev;

		private GraphModifier next;

		[HideInInspector]
		[SerializeField]
		protected ulong uniqueID;

		protected static Dictionary<ulong, GraphModifier> usedIDs;

		protected static List<T> GetModifiersOfType<T>() where T : GraphModifier
		{
			return null;
		}

		public static void FindAllModifiers()
		{
		}

		public static void TriggerEvent(EventType type)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected override void Awake()
		{
		}

		private void ConfigureUniqueID()
		{
		}

		private void AddToLinkedList()
		{
		}

		private void RemoveFromLinkedList()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		public virtual void OnPostScan()
		{
		}

		public virtual void OnPreScan()
		{
		}

		public virtual void OnLatePostScan()
		{
		}

		public virtual void OnPostCacheLoad()
		{
		}

		public virtual void OnGraphsPreUpdate()
		{
		}

		public virtual void OnGraphsPostUpdate()
		{
		}

		protected override void Reset()
		{
		}
	}
}
