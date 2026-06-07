using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[DontApplyToListElements]
	public class DetailedInfoBoxAttribute : Attribute
	{
		public string Message;

		public string Details;

		public InfoMessageType InfoMessageType;

		public string VisibleIf;

		public DetailedInfoBoxAttribute(string message, string details, InfoMessageType infoMessageType = InfoMessageType.Info, string visibleIf = null)
		{
			Message = message;
			Details = details;
			InfoMessageType = infoMessageType;
			VisibleIf = visibleIf;
		}
	}
}
