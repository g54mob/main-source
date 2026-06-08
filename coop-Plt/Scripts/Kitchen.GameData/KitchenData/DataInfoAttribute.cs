using System;
using System.Diagnostics;
using Sirenix.OdinInspector;

namespace KitchenData
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[DontApplyToListElements]
	[Conditional("UNITY_EDITOR")]
	public class DataInfoAttribute : Attribute
	{
		public string Message;

		public SdfIconType Icon = SdfIconType.InfoCircleFill;

		public DataInfoAttribute(string message)
		{
			Message = message;
		}
	}
}
