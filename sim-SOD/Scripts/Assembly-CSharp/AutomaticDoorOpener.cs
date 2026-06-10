using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorOpener : MonoBehaviour
{
	[Header("Setup")]
	public DoorMovementController door;

	public bool closeTrigger;

	[Header("State")]
	public List<Citizen> overlapping;

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
	}
}
