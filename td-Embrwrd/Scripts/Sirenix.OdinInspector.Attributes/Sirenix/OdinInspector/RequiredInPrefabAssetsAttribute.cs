using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Conditional("UNITY_EDITOR")]
	[Obsolete("Use [RequiredIn(PrefabKind.PrefabAsset)] instead.", true)]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
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
