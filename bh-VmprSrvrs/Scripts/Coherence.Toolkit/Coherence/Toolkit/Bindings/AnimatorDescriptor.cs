using System;
using System.Reflection;
using UnityEngine;

namespace Coherence.Toolkit.Bindings
{
	[Serializable]
	public class AnimatorDescriptor : Descriptor
	{
		[SerializeField]
		private int parameterHash;

		public int ParameterHash => 0;

		public AnimatorDescriptor(Type bindingType, AnimatorControllerParameter parameter)
			: base((Type)null, (MemberInfo)null)
		{
		}
	}
}
