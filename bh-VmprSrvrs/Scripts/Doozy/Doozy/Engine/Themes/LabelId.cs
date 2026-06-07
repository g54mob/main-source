using System;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public struct LabelId : ISerializationCallbackReceiver
	{
		[SerializeField]
		private string m_label;

		[SerializeField]
		private byte[] SerializedGuid;

		[SerializeField]
		private Guid m_id;

		public Guid Id => default(Guid);

		public string Label
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public LabelId(string label)
		{
			m_label = null;
			SerializedGuid = null;
			m_id = default(Guid);
		}

		public LabelId(Guid guid, string label)
		{
			m_label = null;
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

		public void SetLabel(string label)
		{
		}
	}
}
