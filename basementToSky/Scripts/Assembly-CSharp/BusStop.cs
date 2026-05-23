using System;
using UnityEngine;
using UnityEngine.Localization;

public class BusStop : MonoBehaviour, IInteractable
{
	private LocalizedString interactionString = new LocalizedString("MyTable", "interaction-interact");

	private Outline outLine;

	public string InteractionText => interactionString.GetLocalizedString();

	public static event Action OnTryTakeBusWithoutRocket;

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	private void Update()
	{
	}

	public void Interact()
	{
		if (FirstPersonController.S.itemOnHand != null)
		{
			if (FirstPersonController.S.itemOnHand.TryGetComponent<Rocket>(out var _))
			{
				AudioManager.S.PlaySFX(AudioManager.S.busStopInteract);
				GameManager.S.BusStopInteracted();
			}
			else
			{
				BusStop.OnTryTakeBusWithoutRocket?.Invoke();
			}
		}
		else
		{
			BusStop.OnTryTakeBusWithoutRocket?.Invoke();
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
