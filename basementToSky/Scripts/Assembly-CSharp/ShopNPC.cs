using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Localization;

public class ShopNPC : NPC, IInteractable
{
	private LocalizedString attachModeString = new LocalizedString("MyTable", "talk");

	public CinemachineCamera shopNpcCam;

	private bool isPlayerAround;

	public JunkScale junkScale;

	public string InteractionText => attachModeString.GetLocalizedString();

	private void Update()
	{
		if ((isTalking || isPlayerAround) && dirToPlayer.sqrMagnitude > 0.001f)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, targetRotation, Time.deltaTime * 3f);
		}
	}

	public override void ConversationEnd()
	{
		FirstPersonController.S.LookAtTarget(base.transform.position + Vector3.up);
		isTalking = false;
		if (!FirstPersonController.S.rcControl)
		{
			FirstPersonController.S.canControl = true;
		}
		shopNpcCam.Priority = 0;
	}

	public override void ConversationEndKickOut()
	{
		FirstPersonController.S.LookAtTarget(base.transform.position + Vector3.up);
		isTalking = false;
		shopNpcCam.Priority = 0;
	}

	public override void ConversationEndShop()
	{
		FirstPersonController.S.LookAtTarget(base.transform.position + Vector3.up);
		isTalking = false;
		shopNpcCam.Priority = 0;
	}

	public void Interact()
	{
		FirstPersonController.S.canControl = false;
		shopNpcCam.Priority = 2;
		StartConversation();
	}

	public void OnDetected()
	{
	}

	public void OnLost()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<FirstPersonController>(out var _))
		{
			Debug.Log("PlayerDetected");
			headIk.headIkTarget = FirstPersonController.S.playerCamPos;
			headIk.ikActive = true;
			isPlayerAround = true;
			dirToPlayer = Camera.main.transform.position - base.transform.position;
			dirToPlayer.y = 0f;
			targetRotation = Quaternion.LookRotation(dirToPlayer);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent<FirstPersonController>(out var _))
		{
			Debug.Log("PlayerLost");
			headIk.ikActive = false;
			isPlayerAround = false;
		}
	}
}
