using System;
using System.Diagnostics;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class PlayaBelowInfoBox : PlayaInfoBoxAttribute
	{
		public PlayaBelowInfoBox(string content, EMessageType messageType = EMessageType.Info, string show = null, bool isCallback = false, string groupBy = "")
			: base(content, messageType, show, isCallback, below: true, groupBy)
		{
		}

		public PlayaBelowInfoBox(string content, bool isCallback)
			: base(content, isCallback)
		{
		}
	}
}
