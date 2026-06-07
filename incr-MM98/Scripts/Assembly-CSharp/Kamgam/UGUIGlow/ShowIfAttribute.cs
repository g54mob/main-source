using System;
using UnityEngine;

namespace Kamgam.UGUIGlow
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
	public class ShowIfAttribute : PropertyAttribute
	{
		public enum DisablingType
		{
			ReadOnly = 2,
			DontDraw = 3
		}

		public string comparedPropertyName { get; private set; }

		public object comparedValue0 { get; private set; }

		public object comparedValue1 { get; private set; }

		public DisablingType disablingType { get; private set; }

		public bool invertLogic { get; private set; }

		public ShowIfAttribute(string comparedPropertyName, object comparedValue0, DisablingType disablingType = DisablingType.DontDraw, bool invertLogic = false, object comparedValue1 = null)
		{
		}
	}
}
