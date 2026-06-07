using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[AttributeUsage(AttributeTargets.Method)]
	public class ButtonMethodAttribute : PropertyAttribute
	{
		public readonly ButtonMethodDrawOrder DrawOrder;

		public readonly ConditionalData Condition;

		public ButtonMethodAttribute(ButtonMethodDrawOrder drawOrder = ButtonMethodDrawOrder.AfterInspector)
		{
		}

		public ButtonMethodAttribute(ButtonMethodDrawOrder drawOrder, string fieldToCheck, bool inverse = false, params object[] compareValues)
		{
		}

		public ButtonMethodAttribute(ButtonMethodDrawOrder drawOrder, string[] fieldToCheck, bool[] inverse = null, params object[] compare)
		{
		}

		public ButtonMethodAttribute(ButtonMethodDrawOrder drawOrder, params string[] fieldToCheck)
		{
		}

		public ButtonMethodAttribute(ButtonMethodDrawOrder drawOrder, bool useMethod, string method, bool inverse = false)
		{
		}
	}
}
