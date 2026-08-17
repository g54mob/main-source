using System;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using UnityEngine;

public class InteractableShrineMagnet : BaseInteractable
{
	public GameObject minimapIcon;

	public GameObject shrineIcon;

	private bool done;

	public GameObject interactFx;

	public static string debugName = "Magnet Shrines";

	public override bool Interact()
	{
		//IL_008e: Expected I4, but got O
		if (!done)
		{
			done = true;
			if ((object)interactFx != null)
			{
				interactFx.SetActive(value: true);
				if ((object)PickupManager.Instance != null)
				{
					PickupManager.Instance.PickupAllXp();
					UnityEngine.Object.Destroy(minimapIcon);
					UnityEngine.Object.Destroy(shrineIcon);
					UnityEngine.Object.Destroy(this);
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public override string GetInteractString()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C87]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return LocalizationUtility.GetLocalizedString("Game_Interactables", "SHRINE_MAGNET");
	}

	public override bool ShowInDebug()
	{
		return true;
	}

	public override string GetDebugName()
	{
		return debugName;
	}

	public InteractableShrineMagnet()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
