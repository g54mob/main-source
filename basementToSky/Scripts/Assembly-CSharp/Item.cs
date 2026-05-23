using System;
using UnityEngine;
using UnityEngine.Localization;

public class Item : MonoBehaviour, IInteractable
{
	public LocalizedString itemNameTemp;

	public string itemName;

	public Sprite mainImage;

	public float value;

	public bool canGrab;

	public Outline outLine;

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

	public static event Action OnTryGrabItemWhenCannot;

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	protected void TryGrabItemWhenCannot()
	{
		Item.OnTryGrabItemWhenCannot?.Invoke();
	}

	private void Update()
	{
	}

	public virtual void Interact()
	{
		if (canGrab)
		{
			if (GameManager.S.player.itemOnHand == null)
			{
				GameManager.S.player.GrabItem(base.gameObject);
			}
			else
			{
				Item.OnTryGrabItemWhenCannot?.Invoke();
			}
		}
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
