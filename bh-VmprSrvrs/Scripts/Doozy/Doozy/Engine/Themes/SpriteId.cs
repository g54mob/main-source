using System;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public struct SpriteId : ISerializationCallbackReceiver
	{
		[SerializeField]
		private Sprite m_sprite;

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

		public Sprite Sprite
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SpriteId(Sprite sprite)
		{
			m_sprite = null;
			SerializedGuid = null;
			m_id = default(Guid);
		}

		public SpriteId(Guid id, Sprite sprite)
		{
			m_sprite = null;
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

		public void SetSprite(Sprite sprite)
		{
		}
	}
}
