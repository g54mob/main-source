using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Engine.Events;

[Serializable]
public class ColorEvent : UnityEvent<Color>
{
	public ColorEvent()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
	}
}
