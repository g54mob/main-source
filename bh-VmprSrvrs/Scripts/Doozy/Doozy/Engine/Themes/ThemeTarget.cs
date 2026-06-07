using System;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public abstract class ThemeTarget : MonoBehaviour, ISerializationCallbackReceiver
	{
		public Guid ThemeId;

		public Guid VariantId;

		public Guid PropertyId;

		[SerializeField]
		private byte[] ThemeIdSerializedGuid;

		[SerializeField]
		private byte[] VariantIdSerializedGuid;

		[SerializeField]
		private byte[] PropertyIdSerializedGuid;

		protected virtual void OnValidate()
		{
		}

		public virtual void Awake()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
		}

		public virtual void UpdateTarget(ThemeData theme)
		{
		}
	}
}
