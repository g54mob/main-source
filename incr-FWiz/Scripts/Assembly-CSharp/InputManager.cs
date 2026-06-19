using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{
	public static InputActions Controls;

	private static short _disableStack;

	public static Vector2 MovementInput;

	private static float _lastScrollTime;

	private const float MaxScrollPerSecond = 15f;

	private static float _scrollFactorAccumulated;

	public static Vector2 MousePosition => default(Vector2);

	public static bool Pressing { get; private set; }

	public static bool Collecting { get; private set; }

	public static bool Dropping { get; private set; }

	public static event Action AnnounceEscape
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceEscapeStart
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceEscapeEnd
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceMovePointer
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action<Vector2> AnnounceMovePointerTo
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action<Vector2> AnnounceMove
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnouncePress
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnouncePressEnd
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceCollecting
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceCollectingEnd
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceDropping
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceDroppingEnd
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceSprintingStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceSprintingPerformed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceCursorMoveStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceCursorMovePerformed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action<int> AnnounceScroll
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceBuild
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceDeconstruct
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnouncePipelines
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static event Action AnnounceItemBook
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public static void AddDisableStack()
	{
	}

	public static void RemoveDisableStack()
	{
	}

	private static void InitControls()
	{
	}

	public static InputAction GetAction(string actionMapName, string actionName)
	{
		return null;
	}

	public static void SaveRebind(InputAction inputAction)
	{
	}

	public static void LoadRebind(InputAction inputAction)
	{
	}

	[RuntimeInitializeOnLoadMethod]
	private static void Start()
	{
	}

	public static void SetupInputManager()
	{
	}

	private static void OnEscapeStart(InputAction.CallbackContext context)
	{
	}

	private static void OnEscapeEnd(InputAction.CallbackContext context)
	{
	}

	private static void OnMovePointer(InputAction.CallbackContext context)
	{
	}

	public static bool IsMouseOnScreen()
	{
		return false;
	}

	private static void OnMovePerformed(InputAction.CallbackContext context)
	{
	}

	private static void OnHoldStart(InputAction.CallbackContext obj)
	{
	}

	private static void OnHoldComplete(InputAction.CallbackContext obj)
	{
	}

	private static void OnCollectStart(InputAction.CallbackContext obj)
	{
	}

	private static void OnCollectComplete(InputAction.CallbackContext obj)
	{
	}

	private static void OnDropStart(InputAction.CallbackContext obj)
	{
	}

	private static void OnDropPerformed(InputAction.CallbackContext obj)
	{
	}

	private static void OnSprintingStart(InputAction.CallbackContext obj)
	{
	}

	private static void OnSprintingPerformed(InputAction.CallbackContext obj)
	{
	}

	private static void OnCursorMoveStart(InputAction.CallbackContext obj)
	{
	}

	private static void OnCursorMovePerformed(InputAction.CallbackContext obj)
	{
	}

	private static void OnScroll(InputAction.CallbackContext context)
	{
	}

	private static void OnScrollUp(InputAction.CallbackContext context)
	{
	}

	private static void OnScrollDown(InputAction.CallbackContext context)
	{
	}

	private static void OnBuild(InputAction.CallbackContext context)
	{
	}

	private static void OnDeconstruct(InputAction.CallbackContext context)
	{
	}

	private static void OnPipelines(InputAction.CallbackContext context)
	{
	}

	private static void OnItemBook(InputAction.CallbackContext context)
	{
	}
}
