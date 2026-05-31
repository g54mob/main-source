using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MyBox
{
	public class GuidManager
	{
		private struct GuidInfo
		{
			public GameObject GameObject;

			[CompilerGenerated]
			private Action<GameObject> m_OnAdd;

			[CompilerGenerated]
			private Action m_OnRemove;

			public event Action<GameObject> OnAdd
			{
				[CompilerGenerated]
				add
				{
				}
				[CompilerGenerated]
				remove
				{
				}
			}

			public event Action OnRemove
			{
				[CompilerGenerated]
				add
				{
				}
				[CompilerGenerated]
				remove
				{
				}
			}

			public GuidInfo(GuidComponent comp)
			{
				GameObject = null;
				this.OnAdd = null;
				this.OnRemove = null;
			}

			public void HandleAddCallback()
			{
			}

			public void HandleRemoveCallback()
			{
			}
		}

		private static GuidManager _instance;

		private readonly Dictionary<Guid, GuidInfo> _guidToObjectMap;

		private static GuidManager Instance => null;

		public static bool Add(GuidComponent guidComponent)
		{
			return false;
		}

		public static void Remove(Guid guid)
		{
		}

		public static GameObject ResolveGuid(Guid guid, Action<GameObject> onAddCallback, Action onRemoveCallback)
		{
			return null;
		}

		public static GameObject ResolveGuid(Guid guid, Action onDestroyCallback)
		{
			return null;
		}

		public static GameObject ResolveGuid(Guid guid)
		{
			return null;
		}

		private bool InternalAdd(GuidComponent guidComponent)
		{
			return false;
		}

		private void InternalRemove(Guid guid)
		{
		}

		private GameObject ResolveGuidInternal(Guid guid, Action<GameObject> onAddCallback, Action onRemoveCallback)
		{
			return null;
		}
	}
}
