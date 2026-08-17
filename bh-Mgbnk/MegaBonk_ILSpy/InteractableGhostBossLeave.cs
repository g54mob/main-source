using System;
using Assets.Scripts.Actors.Player;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableGhostBossLeave : BaseInteractable
{
	public LocalizedString stringLeave;

	private bool hasInteracted;

	private bool isBossDead;

	private Vector3 teleportPosition;

	private Vector3 teleportDir;

	public void OpenDoor()
	{
		isBossDead = true;
	}

	public override bool Interact()
	{
		//IL_0073: Expected I4, but got O
		hasInteracted = true;
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			instance.isTeleporting = true;
			Action action = Teleport;
			if ((object)TransitionUI.Instance != null)
			{
				TransitionUI.Instance.StartTransition(action, 0.25f, 0f);
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void Teleport()
	{
		//IL_0034: Expected O, but got Ref
		//IL_0059: Expected O, but got Ref
		MyPlayer instance = MyPlayer.Instance;
		instance.isTeleporting = false;
		MyPlayer instance2 = MyPlayer.Instance;
		Vector3 vector = default(Vector3);
		instance2.playerMovement.TeleportPlayerBackToBounds((Vector3)(&vector));
		MyPlayer instance3 = MyPlayer.Instance;
		instance3.playerInput.SetSpawnDirection((Vector3)(&vector));
		RsgController.Instance.ClearMap();
		RsgController instance4 = RsgController.Instance;
		GameObject gameObject = instance4.roomBoss.gameObject;
		gameObject.SetActive(value: false);
	}

	public override string GetInteractString()
	{
		if (stringLeave != null)
		{
			return stringLeave.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public override bool CanInteract()
	{
		if (hasInteracted)
		{
			return false;
		}
		return isBossDead;
	}

	public void SetTeleportTransform(Vector3 pos, Vector3 dir)
	{
		//IL_000f: Expected O, but got F4
		//IL_002c: Expected O, but got F4
		teleportPosition = (Vector3)pos.x;
		_ = pos.z;
		object obj = dir.z ^ -0f;
		Vector3 vector = default(Vector3);
		teleportDir = vector;
	}

	public InteractableGhostBossLeave()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
