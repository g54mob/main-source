using UnityEngine;

public class RagdollPositionUpdater : MonoBehaviour
{
	[Tooltip("Reference to the AI controller object attached to the citizen")]
	[Header("References")]
	public NewAIController ai;

	public float freeFallForceTimer;

	public void Setup(NewAIController newHuman)
	{
	}

	private void Update()
	{
	}
}
