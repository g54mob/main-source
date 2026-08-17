using System;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace Com.LuisPedroFonseca.ProCamera2D;

[Serializable]
public class CinematicEvent : UnityEvent<int>
{
	public CinematicEvent()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180494DF0");
	}
}
