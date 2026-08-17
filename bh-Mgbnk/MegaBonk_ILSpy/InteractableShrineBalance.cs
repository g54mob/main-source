using System;
using Assets.Scripts.UI.InGame.Rewards;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InteractableShrineBalance : BaseInteractable
{
	public GameObject minimapIcon;

	public GameObject alertIcon;

	public bool done;

	public static string debugName = "Bald Heads";

	public override bool Interact()
	{
		//IL_00ac: Expected I4, but got O
		if (!done)
		{
			done = true;
			UiManager instance = UiManager.Instance;
			if ((object)UiManager.Instance != null && (object)instance.encounterWindows != null)
			{
				instance.encounterWindows.AddEncounter(EEncounter.BalanceShrine);
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C75]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "SHRINE_BALANCE");
	}

	public override bool ShowInDebug()
	{
		return true;
	}

	public override string GetDebugName()
	{
		return debugName;
	}

	public InteractableShrineBalance()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
