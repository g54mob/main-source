using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Obsolete("Use [RequiredIn(PrefabKind.PrefabAsset)] instead.", true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class RequiredInPrefabAssetsAttribute : Attribute
	{
		public string ErrorMessage;

		public InfoMessageType MessageType;

		public RequiredInPrefabAssetsAttribute()
		{
		}

		public RequiredInPrefabAssetsAttribute(string errorMessage, InfoMessageType messageType)
		{
		}

		public RequiredInPrefabAssetsAttribute(string errorMessage)
		{
		}

		public RequiredInPrefabAssetsAttribute(InfoMessageType messageType)
		{
		}
	}
}
