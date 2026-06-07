using System;
using System.Collections;
using DV.CabControls;
using DV.CabControls.Spec;
using UnityEngine;

public class Padlock : MonoBehaviour
{
	public PadlockKeyType unlockingKey;

	public AudioClip unlockSound;

	private Item padlockItem;

	[SerializeField]
	private GameObject triggerColliderContainer;

	public bool IsLocked { get; private set; } = true;

	public event Action Unlocked;

	private void Start()
	{
		padlockItem = GetComponentInChildren<Item>();
	}

	private void OnAnimationEnded()
	{
		FinalizeUnlocking();
	}

	public bool TryToUnlock(PadlockKey plk)
	{
		if (plk.keyType == unlockingKey && plk.Item.IsGrabbed())
		{
			plk.KeyUsed();
			RemoveKey(plk.Item);
			ContinueUnlockingPadlock();
			return true;
		}
		return false;
	}

	public void ContinueUnlockingPadlock()
	{
		IsLocked = false;
		if ((bool)unlockSound)
		{
			unlockSound.Play(base.transform.position);
		}
		Animation component = GetComponent<Animation>();
		if ((bool)component)
		{
			component.Play();
		}
		else
		{
			FinalizeUnlocking();
		}
	}

	private void FinalizeUnlocking()
	{
		this.Unlocked?.Invoke();
		if (padlockItem != null)
		{
			padlockItem.enabled = true;
		}
		else
		{
			Rigidbody component = GetComponent<Rigidbody>();
			if ((bool)component)
			{
				component.isKinematic = false;
			}
		}
		StartCoroutine(RemovePadlockLogicAndTrigger());
	}

	private IEnumerator RemovePadlockLogicAndTrigger()
	{
		if ((bool)triggerColliderContainer)
		{
			if (triggerColliderContainer == base.gameObject)
			{
				Collider[] componentsInChildren = triggerColliderContainer.GetComponentsInChildren<Collider>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					UnityEngine.Object.Destroy(componentsInChildren[i]);
				}
			}
			else
			{
				UnityEngine.Object.Destroy(triggerColliderContainer);
			}
		}
		yield return null;
		yield return WaitFor.EndOfFrame;
		UnityEngine.Object.Destroy(this);
	}

	private void RemoveKey(ItemBase item)
	{
		if (!(item == null))
		{
			if (item.IsGrabbed())
			{
				StartCoroutine(FinalizeKeyRemoval(item));
			}
			else
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
	}

	private IEnumerator FinalizeKeyRemoval(ItemBase item)
	{
		item.ForceEndInteraction();
		yield return null;
		UnityEngine.Object.Destroy(item.gameObject);
	}
}
