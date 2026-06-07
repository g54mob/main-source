using System;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public struct ColorId : ISerializationCallbackReceiver
	{
		[SerializeField]
		private Color m_color;

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

		public Color Color
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public ColorId(Color color)
		{
			m_color = default(Color);
			SerializedGuid = null;
			m_id = default(Guid);
		}

		public ColorId(Guid id, Color color)
		{
			m_color = default(Color);
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

		public void SetColor(Color color)
		{
		}
	}
}
