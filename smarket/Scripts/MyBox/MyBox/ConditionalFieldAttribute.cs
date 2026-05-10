using System;
using MyBox.Internal;
using UnityEngine;

namespace MyBox
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class ConditionalFieldAttribute : PropertyAttribute
	{
		public readonly ConditionalData Data;

		public bool IsSet => false;

		public ConditionalFieldAttribute(string fieldToCheck, bool inverse = false, params object[] compareValues)
		{
		}

		public ConditionalFieldAttribute(string[] fieldToCheck, bool[] inverse = null, params object[] compare)
		{
		}

		public ConditionalFieldAttribute(params string[] fieldToCheck)
		{
		}

		public ConditionalFieldAttribute(bool useMethod, string method, bool inverse = false)
		{
		}
	}
}
