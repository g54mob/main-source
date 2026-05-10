using System;
using System.Reflection;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	[Serializable]
	public class SerializedUnityEventInfo : ISerializedReflectedInfo, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string _baseInfo;

		[NonSerialized]
		private MemberInfo _memberInfo;

		public bool isStatic => false;

		public Type memberType => null;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public SerializedUnityEventInfo()
		{
		}

		public SerializedUnityEventInfo(FieldInfo info)
		{
		}

		public SerializedUnityEventInfo(PropertyInfo info)
		{
		}

		public SerializedUnityEventInfo(MemberInfo info)
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

		public static implicit operator FieldInfo(SerializedUnityEventInfo value)
		{
			return null;
		}

		public static implicit operator PropertyInfo(SerializedUnityEventInfo value)
		{
			return null;
		}
	}
}
