using System;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public struct TextureId : ISerializationCallbackReceiver
	{
		[SerializeField]
		private Texture m_texture;

		[SerializeField]
		private byte[] SerializedGuid;

		[SerializeField]
		private Guid m_id;

		public Guid Id
		{
			get
			{
				return default(Guid);
			}
			set
			{
			}
		}

		public Texture Texture
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TextureId(Texture texture)
		{
			m_texture = null;
			SerializedGuid = null;
			m_id = default(Guid);
		}

		public TextureId(Guid id, Texture texture)
		{
			m_texture = null;
			SerializedGuid = null;
			m_id = default(Guid);
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void SetId(Guid newGuid)
		{
		}

		public void SetTexture(Texture texture)
		{
		}
	}
}
