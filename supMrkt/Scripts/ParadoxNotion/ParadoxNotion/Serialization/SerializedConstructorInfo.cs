using System;
using System.Reflection;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	[Serializable]
	public class SerializedConstructorInfo : ISerializedMethodBaseInfo, ISerializedReflectedInfo, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string _baseInfo;

		[SerializeField]
		private string _paramsInfo;

		[NonSerialized]
		private ConstructorInfo _constructor;

		[NonSerialized]
		private bool _hasChanged;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public SerializedConstructorInfo()
		{
		}

		public SerializedConstructorInfo(ConstructorInfo constructor)
		{
		}

		public MemberInfo AsMemberInfo()
		{
			return null;
		}

		public MethodBase GetMethodBase()
		{
			return null;
		}

		public bool HasChanged()
		{
			return false;
		}

		public string AsString()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public static implicit operator ConstructorInfo(SerializedConstructorInfo value)
		{
			return null;
		}
	}
}
