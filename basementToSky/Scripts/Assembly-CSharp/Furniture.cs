using UnityEngine;
using UnityEngine.Localization;

public class Furniture : Item
{
	public bool usable;

	public GameObject furnitureGO;

	public LocalizedString description;

	public Vector3 size;

	public LayerMask installableLayerMask;

	protected override LocalizedString interactionText { get; } = new LocalizedString("MyTable", "use");

	protected LocalizedString grabText { get; } = new LocalizedString("MyTable", "interaction-grab");

	protected LocalizedString disassembleText { get; } = new LocalizedString("MyTable", "disassemble");

	public override string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				if (!canGrab)
				{
					if (FirstPersonController.S.itemOnHand != null && FirstPersonController.S.itemOnHand.TryGetComponent<Rench>(out var _))
					{
						return disassembleText.GetLocalizedString();
					}
					if (!usable)
					{
						return "";
					}
					return interactionText.GetLocalizedString();
				}
				return grabText.GetLocalizedString();
			}
			return "Read";
		}
	}

	public override void Interact()
	{
		Rench component;
		if (canGrab)
		{
			if (GameManager.S.player.itemOnHand == null)
			{
				if (outLine != null)
				{
					outLine.enabled = false;
				}
				GameManager.S.player.GrabItem(base.gameObject);
				GameManager.S.player.furnitureOnHand = true;
				GameManager.S.FurnitureObtained(this);
			}
			else
			{
				TryGrabItemWhenCannot();
			}
		}
		else if (GameManager.S.player.itemOnHand != null && FirstPersonController.S.itemOnHand.TryGetComponent<Rench>(out component))
		{
			DisAssemble();
		}
	}

	public void DisAssemble()
	{
		if (furnitureGO != null)
		{
			Object.Instantiate(furnitureGO, base.transform.position, base.transform.rotation);
			Object.Destroy(base.gameObject);
		}
		else
		{
			GameManager.S.CannotDisassemble();
		}
	}
}
