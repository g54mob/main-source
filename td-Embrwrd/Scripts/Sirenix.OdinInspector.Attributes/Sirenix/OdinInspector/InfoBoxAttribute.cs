using System;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[DontApplyToListElements]
	[Conditional("UNITY_EDITOR")]
	public sealed class InfoBoxAttribute : Attribute
	{
		public string Message;

		public InfoMessageType InfoMessageType;

		public string VisibleIf;

		public bool GUIAlwaysEnabled;

		public string IconColor;

		private SdfIconType icon;

		public SdfIconType Icon
		{
			get
			{
				return default(SdfIconType);
			}
			set
			{
			}
		}

		public bool HasDefinedIcon { get; private set; }

		public InfoBoxAttribute(string message, InfoMessageType infoMessageType = InfoMessageType.Info, string visibleIfMemberName = null)
		{
		}

		public InfoBoxAttribute(string message, string visibleIfMemberName)
		{
		}

		public InfoBoxAttribute(string message, SdfIconType icon, string visibleIfMemberName = null)
		{
		}
	}
}
