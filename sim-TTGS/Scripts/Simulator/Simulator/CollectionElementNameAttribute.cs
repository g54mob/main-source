using System;
using UnityEngine;

namespace Simulator
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	public class CollectionElementNameAttribute : PropertyAttribute
	{
	}
}
