using System;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public struct FontId : ISerializationCallbackReceiver
	{
		[SerializeField]
		private Font m_font;

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

		public Font Font
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public FontId(Font font)
		{
			m_font = null;
			SerializedGuid = null;
			m_id = default(Guid);
		}

		public FontId(Guid id, Font font)
		{
			m_font = null;
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

		public void SetFont(Font font)
		{
		}
	}
}
