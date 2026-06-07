using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public struct Signal : ISerializationCallbackReceiver
	{
		[SerializeField]
		private string m_String;

		[NonSerialized]
		private PropertyName m_Value;

		public PropertyName Value
		{
			get
			{
				if (PropertyName.IsNullOrEmpty(m_Value))
				{
					m_Value = new PropertyName(m_String);
				}
				return m_Value;
			}
		}

		public override string ToString()
		{
			return m_String;
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (!AssemblyUtils.IsReloading && !string.IsNullOrEmpty(m_String))
			{
				m_String = TextUtils.ProcessID(m_String);
			}
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}
	}
}
