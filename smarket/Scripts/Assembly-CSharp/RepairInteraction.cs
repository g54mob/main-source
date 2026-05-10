using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RepairInteraction : MonoBehaviour
{
	[SerializeField]
	public float HoldingInteractionTime;

	private bool m_Holding;

	private float m_HoldingPercentage;

	private float m_HoldingTime;

	public Action<bool> onRepairStateChanged;

	public Action<float> onRepairing;

	private PlayerInstance m_PlayerInstance;

	public IInteractable LastInteractable;

	public float HoldingTime => 0f;

	public float HoldingPercentage
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool Holding
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public PlayerInstance PlayerInstance => null;

	private void Update()
	{
	}

	public void OnUse(InputAction.CallbackContext context)
	{
	}

	private void SetRepairInteraction(bool value)
	{
	}

	private void CheckForHoldingInteraction()
	{
	}
}
