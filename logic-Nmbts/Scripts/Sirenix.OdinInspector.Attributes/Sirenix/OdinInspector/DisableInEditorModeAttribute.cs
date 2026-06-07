using System;

namespace Sirenix.OdinInspector
{
	[DontApplyToListElements]
	[AttributeUsage(AttributeTargets.All)]
	public class DisableInEditorModeAttribute : Attribute
	{
	}
}
