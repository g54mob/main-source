using FMOD.Studio;
using UnityEngine;

public class RigidbodyDragObject : MonoBehaviour
{
	[Tooltip("Reference to the AI controller object attached to the citizen")]
	[Header("Referedynces")]
	public NewAIController ai;

	public Rigidbody targetRigidbody;

	private Camera _cam;

	private Vector3 _screenTargetPos;

	private Vector3 _rigidbodyPos;

	public Vector3 mousePositionOffset;

	private float _dragDistance;

	public LayerMask mask;

	public float draggableDistance;

	public bool dragIsActive;

	private EventInstance _dragAudioInstance;

	private AudioController.LoopingSoundInfo _dragBodyLoop;

	public void OnEnterRagdollState(NewAIController newAI)
	{
	}

	public void OnExitRagdollState()
	{
	}

	public void OnAttemptPlayerInteraction()
	{
	}

	public void CancelDrag()
	{
	}

	private void Update()
	{
	}

	public bool IsValidRagdollDragable()
	{
		return false;
	}

	private void FixedUpdate()
	{
	}

	private void UpdateMousePositionOffset()
	{
	}

	private bool GetRigidbodyFromCamera(out Rigidbody targetedRigidbody, out float dragDistance, out Vector3 screenTargetPos, out Vector3 rigidBodyPos)
	{
		targetedRigidbody = null;
		dragDistance = default(float);
		screenTargetPos = default(Vector3);
		rigidBodyPos = default(Vector3);
		return false;
	}
}
