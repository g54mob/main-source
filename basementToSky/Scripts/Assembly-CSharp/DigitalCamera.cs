using System;
using UnityEngine;
using UnityEngine.Localization;

public class DigitalCamera : Furniture, IAltInteractable
{
	[SerializeField]
	private GameObject cameraGO;

	private int angleIndex;

	private int dir = 1;

	private LocalizedString altInteractionText { get; } = new LocalizedString("MyTable", "interaction-rotate");

	public string AltInteractionText => altInteractionText.GetLocalizedString();

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
						return base.disassembleText.GetLocalizedString();
					}
					if (!usable)
					{
						return "";
					}
					return base.grabText.GetLocalizedString();
				}
				return base.grabText.GetLocalizedString();
			}
			return "Read";
		}
	}

	public static event Action OnDicaInstalled;

	private void OnEnable()
	{
		GameManager.S.isDicaInstalled = true;
		DigitalCamera.OnDicaInstalled?.Invoke();
	}

	private void OnDestroy()
	{
		GameManager.S.isDicaInstalled = false;
	}

	public override void Interact()
	{
		CameraDisassemble();
	}

	public void AltInteract()
	{
		Temp();
	}

	public void CameraDisassemble()
	{
		if (FirstPersonController.S.itemOnHand == null)
		{
			if (furnitureGO != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(furnitureGO, base.transform.position, base.transform.rotation);
				UnityEngine.Object.Destroy(base.gameObject);
				GameManager.S.player.GrabItem(gameObject);
				GameManager.S.player.furnitureOnHand = true;
				GameManager.S.FurnitureObtained(gameObject.GetComponent<Furniture>());
			}
			else
			{
				GameManager.S.CannotDisassemble();
			}
		}
		else
		{
			GameManager.S.HandsFull();
		}
	}

	public void Temp()
	{
		if (dir == 1)
		{
			if (angleIndex < 6)
			{
				cameraGO.transform.transform.Rotate(-15f, 0f, 0f, Space.Self);
				angleIndex++;
			}
			else
			{
				dir = -1;
				cameraGO.transform.transform.Rotate(15f, 0f, 0f, Space.Self);
				angleIndex--;
			}
		}
		else if (angleIndex > 0)
		{
			cameraGO.transform.transform.Rotate(15f, 0f, 0f, Space.Self);
			angleIndex--;
		}
		else
		{
			dir = 1;
			cameraGO.transform.transform.Rotate(-15f, 0f, 0f, Space.Self);
			angleIndex++;
		}
		AudioManager.S.PlaySFX(AudioManager.S.cameraAngle);
	}
}
