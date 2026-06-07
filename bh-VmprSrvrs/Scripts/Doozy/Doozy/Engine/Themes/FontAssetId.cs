using System;
using UnityEngine;

namespace Doozy.Engine.Themes
{
	[Serializable]
	public struct FontAssetId : ISerializationCallbackReceiver
	{
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

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}

		public void SetId(Guid newGuid)
		{
		}
	}
}
