using System;
using UnityEngine;

namespace Aggro.Core
{
	[AttributeUsage(AttributeTargets.Field)]
	public class TagContextLabelAttribute : PropertyAttribute
	{
		public readonly string context;

		public TagContextLabelAttribute(string context)
		{
			this.context = context;
		}
	}
}
