using System;

namespace Febucci.TextAnimatorCore.Typing
{
	[Flags]
	public enum StartTypewriterMode
	{
		FromScriptOnly = 0,
		OnEnable = 1,
		OnShowText = 2,
		AutomaticallyFromAllEvents = 3
	}
}
