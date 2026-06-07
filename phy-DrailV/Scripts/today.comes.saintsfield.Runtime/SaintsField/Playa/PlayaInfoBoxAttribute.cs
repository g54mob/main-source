using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;

namespace SaintsField.Playa
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class PlayaInfoBoxAttribute : Attribute, IPlayaAttribute, IPlayaIMGUIGroupBy
	{
		public readonly bool Below;

		public readonly string Content;

		public readonly EMessageType MessageType;

		public readonly bool IsCallback;

		public readonly string ShowCallback;

		public string GroupBy { get; }

		public PlayaInfoBoxAttribute(string content, EMessageType messageType = EMessageType.Info, string show = null, bool isCallback = false, bool below = false, string groupBy = "")
		{
			GroupBy = groupBy;
			Below = below;
			(string content, bool isCallback) tuple = RuntimeUtil.ParseCallback(content, isCallback);
			string item = tuple.content;
			bool item2 = tuple.isCallback;
			Content = item;
			IsCallback = item2;
			MessageType = messageType;
			ShowCallback = show;
		}

		public PlayaInfoBoxAttribute(string content, bool isCallback)
			: this(content, EMessageType.Info, null, isCallback)
		{
		}
	}
}
