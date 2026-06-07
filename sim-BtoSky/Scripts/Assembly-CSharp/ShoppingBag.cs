using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Localization;

public class ShoppingBag : Item, IPayable
{
	private bool hasGrabbed;

	private bool beingDestroyed;

	public List<GameObject> contents = new List<GameObject>();

	protected override LocalizedString interactionText { get; } = new LocalizedString("MyTable", "interaction-grab");

	public override string InteractionText
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

	public bool isPayed { get; set; }

	public static event Action<Food> OnUnlockFood;

	public static event Action<MotorIngredientItem> OnUnlockMaterial;

	private void Start()
	{
		isPayed = false;
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	public void PutItemIntheBag(GameObject itm)
	{
		Item component = itm.GetComponent<Item>();
		GameObject gameObject = UnityEngine.Object.Instantiate(itm, base.transform.position, quaternion.identity);
		gameObject.SetActive(value: false);
		value += component.value;
		contents.Add(gameObject);
		hasGrabbed = true;
		AudioManager.S.PlaySFX(AudioManager.S.grabItem);
	}

	public void PutAliveItemIntheBag(GameObject itm)
	{
		Item component = itm.GetComponent<Item>();
		itm.SetActive(value: false);
		value += component.value;
		contents.Add(itm);
		hasGrabbed = true;
		AudioManager.S.PlaySFX(AudioManager.S.grabItem);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!hasGrabbed || beingDestroyed || collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			return;
		}
		foreach (GameObject content in contents)
		{
			content.transform.position = base.transform.position + Vector3.up * 0.2f;
			content.GetComponent<IPayable>().isPayed = true;
			content.SetActive(value: true);
		}
		beingDestroyed = true;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public bool IsPayed()
	{
		if (!isPayed && contents.Count > 0)
		{
			return false;
		}
		return true;
	}

	public void UnlockStuff()
	{
		foreach (GameObject content in contents)
		{
			if (content.TryGetComponent<Food>(out var component))
			{
				ShoppingBag.OnUnlockFood?.Invoke(component);
				continue;
			}
			MotorIngredientItem component2 = content.GetComponent<MotorIngredientItem>();
			if (component2 != null)
			{
				ShoppingBag.OnUnlockMaterial(component2);
			}
		}
	}
}
