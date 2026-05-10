using System;
using System.Reflection;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	[Serializable]
	public class SerializedFieldInfo : ISerializedReflectedInfo, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string _baseInfo;

		[NonSerialized]
		private FieldInfo _field;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public SerializedFieldInfo()
		{
		}

		public SerializedFieldInfo(FieldInfo info)
		{
		}

		public MemberInfo AsMemberInfo()
		{
			return null;
		}

		public string AsString()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator FieldInfo(SerializedFieldInfo value)
		{
			return null;
		}
	}
}
