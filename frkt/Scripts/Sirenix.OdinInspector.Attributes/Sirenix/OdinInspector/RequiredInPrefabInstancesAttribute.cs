using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use [RequiredIn(PrefabKind.PrefabInstance)] instead.", true)]
	public sealed class RequiredInPrefabInstancesAttribute : Attribute
	{
		public string ErrorMessage;

		public InfoMessageType MessageType;

		public RequiredInPrefabInstancesAttribute()
		{
		}

		public RequiredInPrefabInstancesAttribute(string errorMessage, InfoMessageType messageType)
		{
		}

		public RequiredInPrefabInstancesAttribute(string errorMessage)
		{
		}

		public RequiredInPrefabInstancesAttribute(InfoMessageType messageType)
		{
		}
	}
}
