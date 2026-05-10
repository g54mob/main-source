using System;
using UnityEngine;

namespace PG
{
	[AttributeUsage(AttributeTargets.Field)]
	public class HideInInspectorIf : PropertyAttribute
	{
		public string PropertyToCheck;

		public bool HideInInspector;

		public HideInInspectorIf(string propertyToCheck, bool hideInInspector = true)
		{
		}
	}
}
