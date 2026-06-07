using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field)]
	public class RichLabelAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly string RichTextXml;

		public readonly bool IsCallback;

		public virtual SaintsAttributeType AttributeType => SaintsAttributeType.Label;

		public virtual string GroupBy => "__LABEL_FIELD__";

		public RichLabelAttribute(string richTextXml, bool isCallback = false)
		{
			(string content, bool isCallback) tuple = RuntimeUtil.ParseCallback(richTextXml, isCallback);
			string item = tuple.content;
			bool item2 = tuple.isCallback;
			RichTextXml = item;
			IsCallback = item2;
		}
	}
}
