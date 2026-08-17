using System;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace Doozy.Engine.Progress;

[Serializable]
public class ProgressEvent : UnityEvent<float>
{
	public ProgressEvent()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
	}
}
