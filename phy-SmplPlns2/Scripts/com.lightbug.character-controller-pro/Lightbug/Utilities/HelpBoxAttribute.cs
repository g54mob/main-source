using System;
using UnityEngine;

namespace Lightbug.Utilities
{
	[AttributeUsage(AttributeTargets.Field)]
	public class HelpBoxAttribute : PropertyAttribute
	{
		public string Text;

		public HelpBoxMessageType MessageType;

		public HelpBoxAttribute(string text, HelpBoxMessageType messageType)
		{
			Text = text;
			MessageType = messageType;
		}
	}
}
