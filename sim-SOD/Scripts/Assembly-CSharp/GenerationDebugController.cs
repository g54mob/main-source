using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class GenerationDebugController : MonoBehaviour
{
	[Tooltip("This room attempt was valid")]
	public bool valid;

	[Tooltip("This room attempt was successful")]
	public bool executed;

	[Tooltip("The configuration of the attempted room")]
	public RoomTypePreset preset;

	[Tooltip("The generated room location")]
	public GenerationController.PossibleRoomLocation location;

	public List<string> log;

	[NonSerialized]
	public List<NewNode> attemptedValidNodes;

	public Dictionary<NewNode, string> overridenNodes;

	public Dictionary<NewNode, string> attemptedInvalidNodes;

	private List<GameObject> spawnedObjects;

	public void Setup(string newName, RoomTypePreset newPreset)
	{
	}

	public void Log(string newLog)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void DisplayAttempedArea()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RemoveAttempedArea()
	{
	}
}
