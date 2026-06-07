using System;
using UnityEngine;
using UnityEngine.Localization;

public class Paint : MonoBehaviour, IInteractable
{
	public Color color;

	private Outline outLine;

	public LocalizedString itemName;

	private static MaterialPropertyBlock propertyBlock;

	protected virtual LocalizedString interactionText { get; } = new LocalizedString("MyTable", "junkshopDevice_interact");

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

	public static event Action<Color> OnNewColorUnlocked;

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		if (propertyBlock == null)
		{
			propertyBlock = new MaterialPropertyBlock();
		}
		Renderer componentInChildren = GetComponentInChildren<Renderer>();
		interactionText.Arguments = new object[1] { 1 };
		propertyBlock.SetColor("_Color", color);
		componentInChildren.SetPropertyBlock(propertyBlock);
	}

	public void Interact()
	{
		if (FirstPersonController.S.ticket >= 1)
		{
			FirstPersonController.S.ticket--;
			GameManager.S.TicketUpdated();
			Paint.OnNewColorUnlocked?.Invoke(color);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			GameManager.S.NotEnoughMoney();
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

	public void UnlockColor()
	{
		Paint.OnNewColorUnlocked?.Invoke(color);
	}
}
