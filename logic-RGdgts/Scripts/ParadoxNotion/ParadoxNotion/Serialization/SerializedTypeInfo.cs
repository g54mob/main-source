using System;
using System.Reflection;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	[Serializable]
	public class SerializedTypeInfo : ISerializedReflectedInfo, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string _baseInfo;

		[NonSerialized]
		private Type _type;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public SerializedTypeInfo()
		{
		}

		public SerializedTypeInfo(Type info)
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

		public static implicit operator Type(SerializedTypeInfo value)
		{
			return null;
		}
	}
}
