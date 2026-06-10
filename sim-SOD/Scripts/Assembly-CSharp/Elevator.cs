using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Elevator
{
	[Serializable]
	public class ElevatorFloor
	{
		public int floor;

		public NewTile elevatorTile;

		public NewRoom elevatorRoom;

		public GameObject spawned;

		[NonSerialized]
		public Interactable upButton;

		[NonSerialized]
		public Interactable downButton;

		[NonSerialized]
		public Interactable door;
	}

	[Serializable]
	public class ElevatorCall
	{
		public ElevatorFloor floor;

		public bool callUp;

		public float registered;

		public ElevatorCall(ElevatorFloor newFloor, bool newUp, float newRegistered)
		{
		}
	}

	[Tooltip("Setup")]
	public NewBuilding building;

	public Transform spawnedObject;

	public StairwellPreset preset;

	[NonSerialized]
	public Interactable controls;

	public Collider vehicleDetector;

	public Transform cable1;

	public Transform cable2;

	public AudioController.LoopingSoundInfo movementAudio;

	[Tooltip("List of floors that the elevator can travel too using the passed elevator rooms")]
	public Dictionary<int, ElevatorFloor> elevatorFloors;

	[Header("Game State")]
	[Tooltip("The bottom tile (start")]
	public NewTile bottom;

	[Tooltip("The top")]
	public NewTile top;

	private float reachedSpeed;

	public float currentSpeed;

	public float desiredY;

	private float prevY;

	public float liftTimer;

	[Tooltip("The elevator's current floor position")]
	public int currentFloor;

	[Tooltip("Is the elevator currently moving?")]
	public bool inTransit;

	[Tooltip("The elevator's current direction")]
	public bool isGoingUp;

	[Tooltip("The elevator's current destination: The next floor this will stop at")]
	public int currentDestination;

	[Tooltip("The elevator's current destination: The furthest floor this will stop at")]
	public int ultimateDesitnation;

	public bool isActive;

	public bool isMoving;

	[Tooltip("Used for elevator AI: Call on floors on the way to destination")]
	public Dictionary<int, List<ElevatorCall>> calls;

	public Elevator(StairwellPreset newPreset, NewBuilding newBuilding, NewTile newBottom)
	{
	}

	public void LoadElevatorSaveData(StateSaveData.ElevatorStateSave data)
	{
	}

	public void AddFloor(NewTile newTile)
	{
	}

	public void OnSpawnStairwell(NewTile tile)
	{
	}

	public void CallElevator(int newFloor, bool upButton)
	{
	}

	public void ElevatorUpdate()
	{
	}

	private void UpdateCables()
	{
	}

	private void EndMovement()
	{
	}

	public void SetInTransit(bool val)
	{
	}

	public void UpdateDestination()
	{
	}
}
