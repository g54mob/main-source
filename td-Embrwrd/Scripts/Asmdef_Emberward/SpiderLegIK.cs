using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SpiderLegIK : MonoBehaviour
{
	private enum eFootState
	{
		STAY = 0,
		MOVING = 1
	}

	[SerializeField]
	private Rig rig;

	public Transform footTip;

	public Transform footTarget;

	public Transform footMoveCenter;

	public LayerMask groundLayer;

	public Transform node_FootTipConnection;

	public Transform node_FootTipConnection2;

	public Transform node_FootTipConnectModel;

	public float footMoveDistance;

	public float moveSpeed;

	public float rayHeightOffset;

	public float rayLength;

	public float stopThreshold;

	public float jumpHeight;

	public float jumpDuration;

	public ParticleSystem particle_Smoke;

	private Vector3 footTargetPosition;

	private eFootState footState;

	private Obj_ScrapMasterMachine parentMachine;

	private float targetRigWeight;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	public void ResetFootPosition()
	{
	}

	public void RegisterParentMachine(Obj_ScrapMasterMachine parentMachine)
	{
	}

	private void OnControlStateChanged(bool isInControl)
	{
	}

	public bool IsMoving()
	{
		return false;
	}

	public bool NeedsToStep(Vector3 moveDirection)
	{
		return false;
	}

	public bool NeedsToStepImmediately(Vector3 moveDirection)
	{
		return false;
	}

	public void TriggerStep(Vector3 movingDirection)
	{
	}

	private void StartStep()
	{
	}
}
