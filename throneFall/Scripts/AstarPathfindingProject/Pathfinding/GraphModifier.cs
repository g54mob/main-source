using System;
using System.Collections.Generic;
using Pathfinding.Util;
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
			PostCacheLoad = 0x20,
			PostUpdateBeforeAreaRecalculation = 0x40,
			PostGraphLoad = 0x80
		}

		private static GraphModifier root;

		private GraphModifier prev;

		private GraphModifier next;

		[SerializeField]
		[HideInInspector]
		protected ulong uniqueID;

		protected static Dictionary<ulong, GraphModifier> usedIDs = new Dictionary<ulong, GraphModifier>();

		protected static List<T> GetModifiersOfType<T>() where T : GraphModifier
		{
			GraphModifier graphModifier = root;
			List<T> list = new List<T>();
			while (graphModifier != null)
			{
				T val = graphModifier as T;
				if (val != null)
				{
					list.Add(val);
				}
				graphModifier = graphModifier.next;
			}
			return list;
		}

		public static void FindAllModifiers()
		{
			GraphModifier[] array = UnityCompatibility.FindObjectsByTypeSorted<GraphModifier>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].enabled && array[i].next == null)
				{
					array[i].enabled = false;
					array[i].enabled = true;
				}
			}
		}

		public static void TriggerEvent(EventType type)
		{
			if (!Application.isPlaying)
			{
				FindAllModifiers();
			}
			try
			{
				GraphModifier graphModifier = root;
				switch (type)
				{
				case EventType.PreScan:
					while (graphModifier != null)
					{
						graphModifier.OnPreScan();
						graphModifier = graphModifier.next;
					}
					return;
				case EventType.PostScan:
					while (graphModifier != null)
					{
						graphModifier.OnPostScan();
						graphModifier = graphModifier.next;
					}
					return;
				case EventType.LatePostScan:
					while (graphModifier != null)
					{
						graphModifier.OnLatePostScan();
						graphModifier = graphModifier.next;
					}
					return;
				case EventType.PreUpdate:
					while (graphModifier != null)
					{
						graphModifier.OnGraphsPreUpdate();
						graphModifier = graphModifier.next;
					}
					return;
				case EventType.PostUpdate:
					while (graphModifier != null)
					{
						graphModifier.OnGraphsPostUpdate();
						graphModifier = graphModifier.next;
					}
					return;
				case EventType.PostUpdateBeforeAreaRecalculation:
					while (graphModifier != null)
					{
						graphModifier.OnGraphsPostUpdateBeforeAreaRecalculation();
						graphModifier = graphModifier.next;
					}
					return;
				case EventType.PostCacheLoad:
					while (graphModifier != null)
					{
						graphModifier.OnPostCacheLoad();
						graphModifier = graphModifier.next;
					}
					return;
				case EventType.PostGraphLoad:
					break;
				default:
					return;
				}
				while (graphModifier != null)
				{
					graphModifier.OnPostGraphLoad();
					graphModifier = graphModifier.next;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		protected virtual void OnEnable()
		{
			RemoveFromLinkedList();
			AddToLinkedList();
			ConfigureUniqueID();
		}

		protected virtual void OnDisable()
		{
			RemoveFromLinkedList();
		}

		protected override void Awake()
		{
			base.Awake();
			ConfigureUniqueID();
		}

		private void ConfigureUniqueID()
		{
			if (usedIDs.TryGetValue(uniqueID, out var value) && value != this)
			{
				Reset();
			}
			usedIDs[uniqueID] = this;
		}

		private void AddToLinkedList()
		{
			if (root == null)
			{
				root = this;
				return;
			}
			next = root;
			root.prev = this;
			root = this;
		}

		private void RemoveFromLinkedList()
		{
			if (root == this)
			{
				root = next;
				if (root != null)
				{
					root.prev = null;
				}
			}
			else
			{
				if (prev != null)
				{
					prev.next = next;
				}
				if (next != null)
				{
					next.prev = prev;
				}
			}
			prev = null;
			next = null;
		}

		protected virtual void OnDestroy()
		{
			usedIDs.Remove(uniqueID);
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

		public virtual void OnPostGraphLoad()
		{
		}

		public virtual void OnGraphsPreUpdate()
		{
		}

		public virtual void OnGraphsPostUpdate()
		{
		}

		public virtual void OnGraphsPostUpdateBeforeAreaRecalculation()
		{
		}

		protected override void Reset()
		{
			base.Reset();
			ulong num = (ulong)UnityEngine.Random.Range(0, int.MaxValue);
			ulong num2 = (ulong)((long)UnityEngine.Random.Range(0, int.MaxValue) << 32);
			uniqueID = num | num2;
			usedIDs[uniqueID] = this;
		}
	}
}
