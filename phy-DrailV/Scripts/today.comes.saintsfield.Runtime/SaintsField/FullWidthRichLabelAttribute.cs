using System;
using System.Diagnostics;
using SaintsField.Interfaces;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
	public class FullWidthRichLabelAttribute : PropertyAttribute, ISaintsAttribute
	{
		public readonly bool Above;

		public readonly string RichTextXml;

		public readonly bool IsCallback;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public string GroupBy { get; }

		public FullWidthRichLabelAttribute(string richTextXml, bool isCallback = false, bool above = false, string groupBy = "")
		{
			GroupBy = groupBy;
			Above = above;
			(string content, bool isCallback) tuple = RuntimeUtil.ParseCallback(richTextXml, isCallback);
			string item = tuple.content;
			bool item2 = tuple.isCallback;
			RichTextXml = item;
			IsCallback = item2;
		}
	}
}
