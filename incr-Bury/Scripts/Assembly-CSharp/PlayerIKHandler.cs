using RootMotion.FinalIK;
using Unity.Netcode;
using UnityEngine;

public class PlayerIKHandler : NetworkBehaviour
{
	[Header("IK Rigs & Scripts")]
	[SerializeField]
	private FullBodyBipedIK fullBodyIK;

	[SerializeField]
	private GrounderFBBIK grounderIK;

	[SerializeField]
	private LookAtIK lookAtIK;

	[Header("Character Scripts")]
	[SerializeField]
	private PlayerMovement playerMovement;

	[Header("Head IK Look At")]
	[SerializeField]
	private GameObject playerCam;

	[SerializeField]
	private GameObject lookTarget;

	[SerializeField]
	private LayerMask lookLayerMask;

	[Header("Hand Related")]
	[SerializeField]
	private GameObject ikHandTarget_Left;

	[SerializeField]
	private GameObject ikHandTarget_Right;

	[SerializeField]
	private GameObject camHandMatcherTarget_Left_Reach;

	[SerializeField]
	private GameObject camHandMatcherTarget_Right_Reach;

	[SerializeField]
	private GameObject camHandMatcherTarget_Left_Close;

	[SerializeField]
	private GameObject camHandMatcherTarget_Right_Close;

	private GameObject leftHandMatcherTarget_Current;

	private GameObject rightHandMatcherTarget_Current;

	[SerializeField]
	private float handIkLerpSpeed;

	private void Start()
	{
	}

	public override void OnNetworkSpawn()
	{
		if (base.IsOwner)
		{
			lookAtIK.enabled = false;
		}
		else
		{
			lookAtIK.enabled = true;
		}
	}

	private void Update()
	{
		if (base.IsOwner)
		{
			PlayerCamNullCheck();
			HandleGroundedIKBasedOnMovementState();
			HandleLookAtWhereCameraIsFacingIK();
			LerpHandTargetsToMoveTargets_Owner();
		}
	}

	private void PlayerCamNullCheck()
	{
		if (playerCam == null)
		{
			playerCam = GameObject.FindGameObjectWithTag("MainCamera");
		}
	}

	private void HandleGroundedIKBasedOnMovementState()
	{
		if (playerMovement.airState == PlayerMovement.AirState.Grounded)
		{
			grounderIK.weight = 1f;
		}
		else
		{
			grounderIK.weight = 0f;
		}
	}

	private void HandleLookAtWhereCameraIsFacingIK()
	{
		if (Physics.Raycast(new Ray(playerCam.transform.position, playerCam.transform.forward), out var hitInfo, 100f, lookLayerMask, QueryTriggerInteraction.Ignore))
		{
			lookTarget.transform.position = hitInfo.point;
		}
		else
		{
			lookTarget.transform.position = playerCam.transform.position + playerCam.transform.forward * 20f;
		}
	}

	private void LerpHandTargetsToMoveTargets_Owner()
	{
		if (base.IsOwner)
		{
			if (!leftHandMatcherTarget_Current)
			{
				leftHandMatcherTarget_Current = camHandMatcherTarget_Left_Close;
			}
			if (!rightHandMatcherTarget_Current)
			{
				rightHandMatcherTarget_Current = camHandMatcherTarget_Right_Close;
			}
			ikHandTarget_Left.transform.position = Vector3.Lerp(ikHandTarget_Left.transform.position, leftHandMatcherTarget_Current.transform.position, handIkLerpSpeed * Time.deltaTime);
			ikHandTarget_Right.transform.position = Vector3.Lerp(ikHandTarget_Right.transform.position, rightHandMatcherTarget_Current.transform.position, handIkLerpSpeed * Time.deltaTime);
		}
	}

	public void ChangeCurrentHandMatchTarget_Left(bool _close)
	{
		if (_close)
		{
			leftHandMatcherTarget_Current = camHandMatcherTarget_Left_Close;
		}
		else
		{
			leftHandMatcherTarget_Current = camHandMatcherTarget_Left_Reach;
		}
	}

	public void ChangeCurrentHandMatchTarget_Right(bool _close)
	{
		if (_close)
		{
			rightHandMatcherTarget_Current = camHandMatcherTarget_Right_Close;
		}
		else
		{
			rightHandMatcherTarget_Current = camHandMatcherTarget_Right_Reach;
		}
	}

	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	protected override void __initializeRpcs()
	{
		base.__initializeRpcs();
	}

	protected internal override string __getTypeName()
	{
		return "PlayerIKHandler";
	}
}
