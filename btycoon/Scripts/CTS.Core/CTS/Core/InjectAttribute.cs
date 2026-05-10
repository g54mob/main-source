using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.Core
{
	[AttributeUsage(AttributeTargets.Field)]
	public class InjectAttribute : PropertyAttribute, INaughtyAttribute
	{
		public bool ForceReplace { get; }

		public InjectAttribute(bool forceReplace = false)
		{
			base.order = 100;
			ForceReplace = forceReplace;
		}
	}
}
