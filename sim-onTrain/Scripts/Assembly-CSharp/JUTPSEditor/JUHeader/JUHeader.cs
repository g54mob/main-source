using System;
using UnityEngine;

namespace JUTPSEditor.JUHeader
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class JUHeader : PropertyAttribute
	{
		public string text;

		public JUHeader(string text)
		{
			this.text = text;
		}
	}
}
