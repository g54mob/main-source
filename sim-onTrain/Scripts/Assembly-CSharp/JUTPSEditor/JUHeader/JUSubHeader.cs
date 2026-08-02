using System;
using UnityEngine;

namespace JUTPSEditor.JUHeader
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class JUSubHeader : PropertyAttribute
	{
		public string text;

		public JUSubHeader(string text)
		{
			this.text = text;
		}
	}
}
