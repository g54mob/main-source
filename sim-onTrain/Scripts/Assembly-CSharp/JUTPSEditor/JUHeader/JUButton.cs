using System;
using UnityEngine;

namespace JUTPSEditor.JUHeader
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class JUButton : PropertyAttribute
	{
		public string methodName;

		public string labelText;

		private Type classType;

		public Type ClassType
		{
			get
			{
				return classType;
			}
			set
			{
				classType = value;
			}
		}

		public JUButton(string labelText = "Button", Type scriptType = null, string methodName = "")
		{
			this.methodName = methodName;
			this.labelText = labelText;
			ClassType = scriptType;
		}
	}
}
