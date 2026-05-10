using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class RequiredAttribute : Attribute
	{
		public string ErrorMessage;

		public InfoMessageType MessageType;

		public RequiredAttribute()
		{
		}

		public RequiredAttribute(string errorMessage, InfoMessageType messageType)
		{
		}

		public RequiredAttribute(string errorMessage)
		{
		}

		public RequiredAttribute(InfoMessageType messageType)
		{
		}
	}
}
