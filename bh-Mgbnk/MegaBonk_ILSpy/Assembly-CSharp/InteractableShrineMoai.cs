using System;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InteractableShrineMoai : BaseInteractable
{
	public GameObject minimapIcon;

	public GameObject alertIcon;

	public bool done;

	public static string debugName = "Moais";

	public override bool Interact()
	{
		//IL_00ac: Expected I4, but got O
		if (!done)
		{
			done = true;
			UiManager instance = UiManager.Instance;
			if ((object)UiManager.Instance != null && (object)instance.encounterWindows != null)
			{
				instance.encounterWindows.AddEncounter(EEncounter.Moai);
				UnityEngine.Object.Destroy(minimapIcon);
				UnityEngine.Object.Destroy(alertIcon);
				UnityEngine.Object.Destroy(this);
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C8B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "SHRINE_MOAI");
	}

	public override bool ShowInDebug()
	{
		return true;
	}

	public override string GetDebugName()
	{
		return debugName;
	}

	public InteractableShrineMoai()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
