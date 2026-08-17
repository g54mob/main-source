using System;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InteractableShrineCursed : BaseInteractable
{
	public GameObject minimapIcon;

	public GameObject alertIcon;

	public bool done;

	public GameObject impactFx;

	public GameObject constantFx;

	public static string debugName = "Boss Curses";

	public override bool Interact()
	{
		//IL_00f5: Expected I4, but got O
		if (!done)
		{
			done = true;
			if ((object)impactFx != null)
			{
				impactFx.SetActive(value: true);
				if ((object)constantFx != null)
				{
					constantFx.SetActive(value: true);
					GameManager instance = GameManager.Instance;
					if ((object)GameManager.Instance != null)
					{
						int bossCurses = instance.bossCurses + 1;
						instance.bossCurses = bossCurses;
						UnityEngine.Object.Destroy(minimapIcon);
						UnityEngine.Object.Destroy(alertIcon);
						UnityEngine.Object.Destroy(this);
						return true;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C80]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "SHRINE_CURSED");
	}

	public override bool ShowInDebug()
	{
		return true;
	}

	public override string GetDebugName()
	{
		return debugName;
	}

	public InteractableShrineCursed()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
