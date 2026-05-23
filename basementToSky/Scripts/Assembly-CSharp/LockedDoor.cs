using System;
using Suburb;
using UnityEngine;
using UnityEngine.Localization;

public class LockedDoor : MonoBehaviour, IInteractable
{
	public enum DoorType
	{
		BaseMent = 0,
		MyRoom = 1,
		Entrance = 2,
		ParentsRoom = 3,
		HardwardShop = 4
	}

	public DoorType doorType;

	private LocalizedString interactionText = new LocalizedString("MyTable", "interaction-open");

	private Outline outLine;

	public string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				return interactionText.GetLocalizedString();
			}
			return "Open";
		}
	}

	public static event Action OnTryOpenLockedDoor;

	private void Start()
	{
		if (doorType == DoorType.MyRoom)
		{
			GameManager.S.OnMyRoomUnlocked += Gm_OnMyRoomUnlocked;
			if (GameManager.S.isMyRoomUnlocked)
			{
				GameManager.S.OnMyRoomUnlocked -= Gm_OnMyRoomUnlocked;
				base.gameObject.AddComponent<SimpleOpenClose>();
				UnityEngine.Object.Destroy(this);
			}
		}
		else if (doorType == DoorType.BaseMent)
		{
			GameManager.S.OnBasementUnlocked += S_OnBasementUnlocked;
			if (GameManager.S.isBasementUnlocked)
			{
				GameManager.S.OnBasementUnlocked -= S_OnBasementUnlocked;
				base.gameObject.AddComponent<SimpleOpenClose>();
				UnityEngine.Object.Destroy(this);
			}
		}
		else if (doorType == DoorType.Entrance)
		{
			GameManager.S.OnEntranceUnlocked += Gm_OnEntranceUnlocked;
			if (GameManager.S.isEntranceUnlocked)
			{
				GameManager.S.OnEntranceUnlocked -= Gm_OnEntranceUnlocked;
				base.gameObject.AddComponent<SimpleOpenClose>();
				UnityEngine.Object.Destroy(this);
			}
		}
		else if (doorType == DoorType.ParentsRoom)
		{
			GameManager.S.OnParentsRoomUnlocked += S_OnParentsRoomUnlocked;
			if (GameManager.S.isParentsRoomUnlocked)
			{
				GameManager.S.OnParentsRoomUnlocked -= S_OnParentsRoomUnlocked;
				base.gameObject.AddComponent<SimpleOpenClose>();
				UnityEngine.Object.Destroy(this);
			}
		}
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	private void S_OnParentsRoomUnlocked()
	{
		base.gameObject.AddComponent<SimpleOpenClose>();
		UnityEngine.Object.Destroy(this);
	}

	private void S_OnBasementUnlocked()
	{
		base.gameObject.AddComponent<SimpleOpenClose>();
		UnityEngine.Object.Destroy(this);
	}

	private void OnDestroy()
	{
		GameManager.S.OnMyRoomUnlocked -= Gm_OnMyRoomUnlocked;
		GameManager.S.OnEntranceUnlocked -= Gm_OnEntranceUnlocked;
		GameManager.S.OnBasementUnlocked -= S_OnBasementUnlocked;
	}

	private void Gm_OnEntranceUnlocked()
	{
		base.gameObject.AddComponent<SimpleOpenClose>();
		UnityEngine.Object.Destroy(this);
	}

	private void Gm_OnMyRoomUnlocked()
	{
		base.gameObject.AddComponent<SimpleOpenClose>();
		UnityEngine.Object.Destroy(this);
	}

	public void Interact()
	{
		LockedDoor.OnTryOpenLockedDoor?.Invoke();
		AudioManager.S.PlaySFX(AudioManager.S.doorLocked);
	}

	private void Update()
	{
	}

	public void OnDetected()
	{
		if (outLine != null)
		{
			outLine.enabled = true;
		}
	}

	public void OnLost()
	{
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}
}
