using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FluffyUnderware.DevTools
{
	[HelpURL("https://curvyeditor.com/doclink/dtcomponentpool")]
	public class ComponentPool : UnityObjectPool<Component>, ISerializationCallbackReceiver
	{
		[SerializeField]
		[HideInInspector]
		private string m_Identifier;

		public override string Identifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Type Type => null;

		public void Initialize(Type type, PoolSettings settings)
		{
		}

		protected override Component CreateObject()
		{
			return null;
		}

		protected override GameObject GetItemGameObject(Component item)
		{
			return null;
		}

		[UsedImplicitly]
		[Obsolete]
		public void OnSceneLoaded(Scene scn, LoadSceneMode mode)
		{
		}

		[UsedImplicitly]
		[Obsolete("Use other Pop method instead")]
		public T Pop<T>(Transform parent) where T : Component
		{
			return null;
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
