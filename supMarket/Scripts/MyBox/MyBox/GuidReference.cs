using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class GuidReference : ISerializationCallbackReceiver
	{
		private GameObject cachedReference;

		private bool isCacheSet;

		[SerializeField]
		private byte[] serializedGuid;

		private Guid guid;

		private Action<GameObject> addDelegate;

		private Action removeDelegate;

		public GameObject gameObject
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public event Action<GameObject> OnGuidAdded
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

		public event Action OnGuidRemoved
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

		public GuidReference()
		{
		}

		public GuidReference(GuidComponent target)
		{
		}

		private void GuidAdded(GameObject go)
		{
		}

		private void GuidRemoved()
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
