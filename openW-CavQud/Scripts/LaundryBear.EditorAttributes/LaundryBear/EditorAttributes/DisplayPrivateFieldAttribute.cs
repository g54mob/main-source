using System;
using UnityEngine;

namespace LaundryBear.EditorAttributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class DisplayPrivateFieldAttribute : PropertyAttribute
	{
	}
}
