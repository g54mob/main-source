using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public struct IdPathString : ISerializationCallbackReceiver
	{
		[SerializeField]
		private string m_String;

		[SerializeField]
		private int m_ID;

		public string String => m_String;

		public int ID => m_ID;

		public IdPathString(string value)
		{
			m_String = value;
			m_ID = new PropertyName(value).GetHashCode();
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (!AssemblyUtils.IsReloading && !string.IsNullOrEmpty(m_String))
			{
				m_String = TextUtils.ProcessID(m_String, isPath: true);
				m_ID = new PropertyName(m_String).GetHashCode();
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}
	}
}
