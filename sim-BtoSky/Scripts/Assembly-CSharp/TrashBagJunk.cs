using System;
using UnityEngine;
using UnityEngine.Localization;

public class TrashBagJunk : MonoBehaviour, IInteractable, ITrash
{
	protected virtual LocalizedString interactionText { get; } = new LocalizedString("MyTable", "interaction-grab");

	public virtual string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				return interactionText.GetLocalizedString();
			}
			return "Grab";
		}
	}

	public event Action<ITrash> OnStatusChanged;

	public void Interact()
	{
		if (GameManager.S.player.itemOnHand == null)
		{
			GameManager.S.player.GrabItem(base.gameObject);
			this.OnStatusChanged?.Invoke(this);
		}
	}

	public void OnDetected()
	{
	}

	public void OnLost()
	{
	}
}
