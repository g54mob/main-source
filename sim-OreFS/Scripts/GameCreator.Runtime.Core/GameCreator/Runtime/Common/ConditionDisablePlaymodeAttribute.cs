using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class ConditionDisablePlaymodeAttribute : PropertyAttribute
	{
	}
}
