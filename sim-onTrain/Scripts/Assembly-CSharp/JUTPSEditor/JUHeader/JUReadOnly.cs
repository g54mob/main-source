using System;
using UnityEngine;

namespace JUTPSEditor.JUHeader
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class JUReadOnly : PropertyAttribute
	{
		public string ConditionPropertyName;

		public bool Inverse;

		public bool DisableOnFalse;

		public JUReadOnly(string conditionPropertyName = "", bool inverse = false, bool disableonfalse = true)
		{
			ConditionPropertyName = conditionPropertyName;
			Inverse = inverse;
			DisableOnFalse = disableonfalse;
		}
	}
}
