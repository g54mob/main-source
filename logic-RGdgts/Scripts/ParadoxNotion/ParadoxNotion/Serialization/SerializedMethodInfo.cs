using System;
using System.Reflection;
using UnityEngine;

namespace ParadoxNotion.Serialization
{
	[Serializable]
	public class SerializedMethodInfo : ISerializedMethodBaseInfo, ISerializedReflectedInfo, ISerializationCallbackReceiver
	{
		[SerializeField]
		private string _baseInfo;

		[SerializeField]
		private string _paramsInfo;

		[SerializeField]
		private string _genericArgumentsInfo;

		[NonSerialized]
		private MethodInfo _method;

		[NonSerialized]
		private bool _hasChanged;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public SerializedMethodInfo()
		{
		}

		public SerializedMethodInfo(MethodInfo method)
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

		public static implicit operator MethodInfo(SerializedMethodInfo value)
		{
			return null;
		}
	}
}
