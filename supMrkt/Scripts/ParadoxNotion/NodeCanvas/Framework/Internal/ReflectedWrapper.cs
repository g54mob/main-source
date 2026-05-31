using System.Reflection;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Framework.Internal
{
	public abstract class ReflectedWrapper : IReflectedWrapper
	{
		[SerializeField]
		protected SerializedMethodInfo _targetMethod;

		public ReflectedWrapper()
		{
		}

		public static ReflectedWrapper Create(MethodInfo method, IBlackboard bb)
		{
			return null;
		}

		ISerializedReflectedInfo IReflectedWrapper.GetSerializedInfo()
		{
			return null;
		}

		public void SetVariablesBB(IBlackboard bb)
		{
		}

		public SerializedMethodInfo GetSerializedMethod()
		{
			return null;
		}

		public MethodInfo GetMethod()
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

		public abstract BBParameter[] GetVariables();

		public abstract void Init(object instance);
	}
}
