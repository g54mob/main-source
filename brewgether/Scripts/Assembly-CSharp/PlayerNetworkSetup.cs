using Synty.AnimationBaseLocomotion.Samples;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkSetup : NetworkBehaviour
{
	[Header("Component References")]
	[SerializeField]
	private SamplePlayerAnimationController animationController;

	[SerializeField]
	private InputReader inputReader;

	[SerializeField]
	private SampleCameraController cameraController;

	[SerializeField]
	private CharacterController characterController;

	[SerializeField]
	private Animator animator;

	[Header("Debug")]
	[SerializeField]
	private bool debugMode;

	private void Awake()
	{
	}

	public override void OnNetworkSpawn()
	{
	}

	private void SetupLocalPlayer()
	{
	}

	[ServerRpc]
	private void RequestTutorialQuestServerRpc()
	{
	}

	private void SetupRemotePlayer()
	{
	}

	private void ValidateComponents()
	{
	}

	public override void OnNetworkDespawn()
	{
	}

	protected override void __initializeVariables()
	{
	}

	protected override void __initializeRpcs()
	{
	}

	private static void __rpc_handler_3670050235(NetworkBehaviour target, FastBufferReader reader, __RpcParams rpcParams)
	{
	}

	protected internal override string __getTypeName()
	{
		return null;
	}
}
