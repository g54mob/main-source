using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All)]
	[DontApplyToListElements]
	public class HideInPlayModeAttribute : Attribute
	{
	}
}
