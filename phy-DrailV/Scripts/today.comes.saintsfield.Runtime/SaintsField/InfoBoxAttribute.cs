using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class InfoBoxAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly bool Below;

		public readonly string Content;

		public readonly EMessageType MessageType;

		public readonly bool IsCallback;

		public readonly string ShowCallback;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy { get; }

		public InfoBoxAttribute(string content, EMessageType messageType = EMessageType.Info, string show = null, bool isCallback = false, bool below = false, string groupBy = "")
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

		public InfoBoxAttribute(string content, bool isCallback)
			: this(content, EMessageType.Info, null, isCallback)
		{
		}
	}
}
