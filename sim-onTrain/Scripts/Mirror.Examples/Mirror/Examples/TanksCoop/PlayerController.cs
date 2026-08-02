using Mirror.RemoteCalls;
using UnityEngine;

namespace Mirror.Examples.TanksCoop
{
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(CharacterController))]
	[RequireComponent(typeof(NetworkTransformUnreliable))]
	[RequireComponent(typeof(Rigidbody))]
	public class PlayerController : NetworkBehaviour
	{
		public enum GroundState : byte
		{
			Jumping = 0,
			Falling = 1,
			Grounded = 2
		}

		[Header("Avatar Components")]
		public CharacterController characterController;

		[Header("Movement")]
		[Range(1f, 20f)]
		public float moveSpeedMultiplier = 8f;

		[Header("Turning")]
		[Range(1f, 200f)]
		public float maxTurnSpeed = 100f;

		[Range(0.5f, 5f)]
		public float turnDelta = 3f;

		[Header("Jumping")]
		[Range(0.1f, 1f)]
		public float initialJumpSpeed = 0.2f;

		[Range(1f, 10f)]
		public float maxJumpSpeed = 5f;

		[Range(0.1f, 1f)]
		public float jumpDelta = 0.2f;

		[Header("Diagnostics - Do Not Modify")]
		public GroundState groundState = GroundState.Grounded;

		[Range(-1f, 1f)]
		public float horizontal;

		[Range(-1f, 1f)]
		public float vertical;

		[Range(-200f, 200f)]
		public float turnSpeed;

		[Range(-10f, 10f)]
		public float jumpSpeed;

		[Range(-1.5f, 1.5f)]
		public float animVelocity;

		[Range(-1.5f, 1.5f)]
		public float animRotation;

		public Vector3Int velocity;

		public Vector3 direction;

		public TankController tankController;

		public bool canControlPlayer = true;

		protected override void OnValidate()
		{
			base.OnValidate();
			if (characterController == null)
			{
				characterController = GetComponent<CharacterController>();
			}
			characterController.enabled = false;
			characterController.skinWidth = 0.02f;
			characterController.minMoveDistance = 0f;
			GetComponent<Rigidbody>().isKinematic = true;
			base.enabled = false;
		}

		public override void OnStartAuthority()
		{
			characterController.enabled = true;
			base.enabled = true;
		}

		public override void OnStopAuthority()
		{
			base.enabled = false;
			characterController.enabled = false;
		}

		private void Update()
		{
			if (!characterController.enabled)
			{
				return;
			}
			HandleInput();
			if (canControlPlayer)
			{
				HandleTurning();
				HandleJumping();
				HandleMove();
				if (characterController.isGrounded)
				{
					groundState = GroundState.Grounded;
				}
				else if (groundState != GroundState.Jumping)
				{
					groundState = GroundState.Falling;
				}
				velocity = Vector3Int.FloorToInt(characterController.velocity);
			}
		}

		private void HandleTurning()
		{
			if (Input.GetKey(KeyCode.Q))
			{
				turnSpeed = Mathf.MoveTowards(turnSpeed, 0f - maxTurnSpeed, turnDelta);
			}
			if (Input.GetKey(KeyCode.E))
			{
				turnSpeed = Mathf.MoveTowards(turnSpeed, maxTurnSpeed, turnDelta);
			}
			if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.E))
			{
				turnSpeed = Mathf.MoveTowards(turnSpeed, 0f, turnDelta);
			}
			if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
			{
				turnSpeed = Mathf.MoveTowards(turnSpeed, 0f, turnDelta);
			}
			base.transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
		}

		private void HandleJumping()
		{
			if (groundState != GroundState.Falling && Input.GetKey(KeyCode.Space))
			{
				if (groundState != GroundState.Jumping)
				{
					groundState = GroundState.Jumping;
					jumpSpeed = initialJumpSpeed;
				}
				else
				{
					jumpSpeed = Mathf.MoveTowards(jumpSpeed, maxJumpSpeed, jumpDelta);
				}
				if (jumpSpeed == maxJumpSpeed)
				{
					groundState = GroundState.Falling;
				}
			}
			else if (groundState != GroundState.Grounded)
			{
				groundState = GroundState.Falling;
				jumpSpeed = Mathf.Min(jumpSpeed, maxJumpSpeed);
				jumpSpeed += Physics.gravity.y * Time.deltaTime;
			}
			else
			{
				jumpSpeed = Physics.gravity.y * Time.deltaTime;
			}
		}

		private void HandleMove()
		{
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");
			direction = new Vector3(horizontal, 0f, vertical);
			direction = Vector3.ClampMagnitude(direction, 1f);
			direction = base.transform.TransformDirection(direction);
			direction *= moveSpeedMultiplier;
			direction.y = jumpSpeed;
			characterController.Move(direction * Time.deltaTime);
		}

		private void HandleInput()
		{
			if (!tankController)
			{
				return;
			}
			if (canControlPlayer && tankController.NetworkobjectOwner == null)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					CmdAssignAuthority(tankController.netIdentity);
				}
			}
			else if (Input.GetKeyDown(KeyCode.Q))
			{
				CmdRemoveAuthority(tankController.netIdentity);
			}
			if (tankController.NetworkobjectOwner == base.netIdentity)
			{
				base.transform.position = tankController.seatPosition.position;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (base.isOwned && other.name == "TankTrigger" && canControlPlayer)
			{
				tankController = other.transform.root.GetComponent<TankController>();
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (base.isOwned && other.name == "TankTrigger" && (bool)tankController && tankController.NetworkobjectOwner != base.netIdentity)
			{
				tankController = null;
			}
		}

		[Command]
		public void CmdAssignAuthority(NetworkIdentity _networkIdentity)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteNetworkIdentity(_networkIdentity);
			SendCommandInternal("System.Void Mirror.Examples.TanksCoop.PlayerController::CmdAssignAuthority(Mirror.NetworkIdentity)", 152325933, writer, 0);
			NetworkWriterPool.Return(writer);
		}

		[Command]
		public void CmdRemoveAuthority(NetworkIdentity _networkIdentity)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteNetworkIdentity(_networkIdentity);
			SendCommandInternal("System.Void Mirror.Examples.TanksCoop.PlayerController::CmdRemoveAuthority(Mirror.NetworkIdentity)", 868343352, writer, 0);
			NetworkWriterPool.Return(writer);
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_CmdAssignAuthority__NetworkIdentity(NetworkIdentity _networkIdentity)
		{
			tankController = _networkIdentity.GetComponent<TankController>();
			if (tankController.NetworkobjectOwner != base.netIdentity)
			{
				_networkIdentity.RemoveClientAuthority();
				_networkIdentity.AssignClientAuthority(base.connectionToClient);
				tankController.NetworkobjectOwner = base.netIdentity;
			}
		}

		protected static void InvokeUserCode_CmdAssignAuthority__NetworkIdentity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdAssignAuthority called on client.");
			}
			else
			{
				((PlayerController)obj).UserCode_CmdAssignAuthority__NetworkIdentity(reader.ReadNetworkIdentity());
			}
		}

		protected void UserCode_CmdRemoveAuthority__NetworkIdentity(NetworkIdentity _networkIdentity)
		{
			tankController = _networkIdentity.GetComponent<TankController>();
			if (tankController.NetworkobjectOwner != null && tankController.NetworkobjectOwner == base.netIdentity)
			{
				_networkIdentity.RemoveClientAuthority();
				tankController.NetworkobjectOwner = null;
			}
		}

		protected static void InvokeUserCode_CmdRemoveAuthority__NetworkIdentity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkServer.active)
			{
				Debug.LogError("Command CmdRemoveAuthority called on client.");
			}
			else
			{
				((PlayerController)obj).UserCode_CmdRemoveAuthority__NetworkIdentity(reader.ReadNetworkIdentity());
			}
		}

		static PlayerController()
		{
			RemoteProcedureCalls.RegisterCommand(typeof(PlayerController), "System.Void Mirror.Examples.TanksCoop.PlayerController::CmdAssignAuthority(Mirror.NetworkIdentity)", InvokeUserCode_CmdAssignAuthority__NetworkIdentity, requiresAuthority: true);
			RemoteProcedureCalls.RegisterCommand(typeof(PlayerController), "System.Void Mirror.Examples.TanksCoop.PlayerController::CmdRemoveAuthority(Mirror.NetworkIdentity)", InvokeUserCode_CmdRemoveAuthority__NetworkIdentity, requiresAuthority: true);
		}
	}
}
