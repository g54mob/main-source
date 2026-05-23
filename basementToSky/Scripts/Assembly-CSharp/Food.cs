using System;
using UnityEngine;
using UnityEngine.Localization;

public class Food : Item, IPayable
{
	[Serializable]
	public struct Ingredient
	{
		public GameObject food;

		public int number;
	}

	[Serializable]
	public struct Recipe
	{
		public CookingController.CookingMethod cookingMethod;

		public GameObject[] food;
	}

	public float hungerGain;

	public int knowledgeGain;

	public Ingredient[] ingredients;

	public Recipe[] recipe;

	protected override LocalizedString interactionText { get; } = new LocalizedString("MyTable", "interaction-grab");

	private LocalizedString interactionTextShoppingBag { get; } = new LocalizedString("MyTable", "interaction-pack");

	public override string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				if (FirstPersonController.S.itemOnHand != null)
				{
					if (GameManager.S.player.itemOnHand.TryGetComponent<ShoppingBag>(out var _))
					{
						return interactionTextShoppingBag.GetLocalizedString();
					}
					return interactionText.GetLocalizedString();
				}
				return interactionText.GetLocalizedString();
			}
			return "Grab";
		}
	}

	public bool isPayed { get; set; }

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		canGrab = true;
		isPayed = false;
	}

	public override void Interact()
	{
		if (canGrab)
		{
			ShoppingBag component;
			if (GameManager.S.player.itemOnHand == null)
			{
				GameManager.S.player.GrabItem(base.gameObject);
			}
			else if (GameManager.S.player.itemOnHand.TryGetComponent<ShoppingBag>(out component))
			{
				component.PutAliveItemIntheBag(base.gameObject);
			}
			else
			{
				TryGrabItemWhenCannot();
			}
		}
	}

	public bool IsPayed()
	{
		return isPayed;
	}
}
