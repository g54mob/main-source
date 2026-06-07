using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
	public class TypeInfoBoxAttribute : Attribute
	{
		public string Message;

		public TypeInfoBoxAttribute(string message)
		{
			Message = message;
		}
	}
}
