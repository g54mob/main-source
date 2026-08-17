using System;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace Doozy.Engine.Events;

[Serializable]
public class StringEvent : UnityEvent<string>
{
	public StringEvent()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
	}
}
