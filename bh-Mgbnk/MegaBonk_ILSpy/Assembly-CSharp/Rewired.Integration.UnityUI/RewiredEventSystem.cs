using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace Rewired.Integration.UnityUI;

public class RewiredEventSystem : EventSystem
{
	private bool _alwaysUpdate;

	public bool alwaysUpdate
	{
		get
		{
			return _alwaysUpdate;
		}
		set
		{
			_alwaysUpdate = value;
		}
	}

	protected override void Update()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Rewired.Integration.UnityUI.RewiredEventSystem)+60]");
		if ((nint)0 != 0)
		{
			EventSystem eventSystem = EventSystem.current;
			if (eventSystem != this)
			{
				EventSystem.current = this;
			}
			EventSystem eventSystem2 = default(EventSystem);
			eventSystem2.Update();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18039EFD0");
		}
		else
		{
			base.Update();
		}
	}
}
