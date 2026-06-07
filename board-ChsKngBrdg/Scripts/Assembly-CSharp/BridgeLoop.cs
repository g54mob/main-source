using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BridgeLoop : MonoBehaviour
{
	public Transform playerTransform;

	public GameObject bridgeSequencePrefab;

	public Vector3 nextBridgeSequenceOffset;

	private List<Transform> bridgeSequences = new List<Transform>();

	public void Awake()
	{
		if (SaveSystem.currentPlayerSaveData.overworldState == OverworldTrollManager.OverworldState.ACT_II)
		{
			GenerateNewBridgeSequence(nextBridgeSequenceOffset);
			GenerateNewBridgeSequence(Vector3.zero);
			GenerateNewBridgeSequence(-nextBridgeSequenceOffset);
			SortBridgeSequences();
		}
	}

	public void Update()
	{
		if (SaveSystem.currentPlayerSaveData.overworldState == OverworldTrollManager.OverworldState.ACT_II)
		{
			CheckForSequenceShifting();
		}
	}

	public void CheckForSequenceShifting()
	{
		if (playerTransform.position.y >= bridgeSequences[0].position.y)
		{
			ShiftBridgeSequence(bridgeSequences[2], bridgeSequences[0].position + nextBridgeSequenceOffset);
		}
		if (playerTransform.position.y <= bridgeSequences[2].position.y)
		{
			ShiftBridgeSequence(bridgeSequences[0], bridgeSequences[2].position - nextBridgeSequenceOffset);
		}
	}

	public void ShiftBridgeSequence(Transform bridgeSequence, Vector3 position)
	{
		bridgeSequence.position = position;
		SortBridgeSequences();
	}

	public void GenerateNewBridgeSequence(Vector3 position)
	{
		GameObject gameObject = Object.Instantiate(bridgeSequencePrefab, position, Quaternion.identity, base.transform);
		bridgeSequences.Add(gameObject.transform);
	}

	public void SortBridgeSequences()
	{
		bridgeSequences = bridgeSequences.OrderByDescending((Transform x) => x.transform.position.y).ToList();
	}
}
