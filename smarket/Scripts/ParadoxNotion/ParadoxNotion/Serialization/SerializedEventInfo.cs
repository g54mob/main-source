using System;
using System.Reflection;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	[Serializable]
	public class SerializedEventInfo : ISerializedReflectedInfo, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string _baseInfo;

		[NonSerialized]
		private EventInfo _event;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public SerializedEventInfo()
		{
		}

		public SerializedEventInfo(EventInfo info)
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

		public static implicit operator EventInfo(SerializedEventInfo value)
		{
			return null;
		}
	}
}
