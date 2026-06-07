using System;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : NetworkBehaviour
{
	public Camera playerCamera;

	public float crouchSpeed = 4f;

	public float walkSpeed = 6f;

	public float runSpeed = 12f;

	public float downedSpeed = 3f;

	public float jumpPower = 7f;

	public float gravity = 10f;

	public float lookXLimit = 45f;

	public Vector3 moveDirection = Vector3.zero;

	private float rotationX;

	public bool lockMove;

	public bool lockCam;

	public bool lookAtState;

	public Animator headbobAnim;

	public float focusFOV;

	private bool isRunning;

	public ParticleSystem runParticles;

	private CharacterController characterController;

	public PlayerManager playerMan;

	public InteractManager interactMan;

	public InventoryManager inventoryMan;

	public Transform objectToLookAt;

	private bool justGrounded;

	private bool justLockedCam = true;

	private bool justUnlockedCam = true;

	public AudioSource jumpSFX;

	public AudioSource landSFX;

	public Animator characterAnim;

	public bool crouching;

	public StoreManager storeMan;

	public float volume;

	public bool lockVolume;

	public bool canRun = true;

	public ThirdPersonManager thirdPersonMan;

	public bool downed;

	public Transform headCheck;

	public LayerMask headHitLayer;

	private bool justStoppedCrouching = true;

	public float lookAtSpeed = 1f;

	public float sensitivityMultiplier = 1f;

	public float moveMultiplier = 1f;

	public bool canSprint = true;

	private bool justLockedMove;

	public void OnEnable()
	{
		storeMan = StoreManager.Instance;
	}

	private void Start()
	{
		interactMan = playerMan.interactMan;
		characterController = GetComponent<CharacterController>();
		if (!base.isLocalPlayer)
		{
			base.enabled = false;
		}
		else
		{
			LockCursor();
		}
	}

	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void UnlockVolume()
	{
		lockVolume = false;
	}

	public void ChangeVolume(float volume_)
	{
		if (volume != volume_)
		{
			if (base.isServer)
			{
				ChangeVolumeRpc(volume_);
			}
			else
			{
				ChangeVolumeCmd(volume_);
			}
		}
	}

	[Command(requiresAuthority = false)]
	private void ChangeVolumeCmd(float volume)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(volume);
		SendCommandInternal("System.Void FPSController::ChangeVolumeCmd(System.Single)", -1725876099, writer, 0, requiresAuthority: false);
		NetworkWriterPool.Return(writer);
	}

	[ClientRpc]
	private void ChangeVolumeRpc(float volume_)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteFloat(volume_);
		SendRPCInternal("System.Void FPSController::ChangeVolumeRpc(System.Single)", -1073163936, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void Update()
	{
		if (!lockMove)
		{
			Move();
			justLockedMove = true;
		}
		else
		{
			if (justLockedMove)
			{
				justLockedMove = false;
				headbobAnim.SetBool("Running", value: false);
				headbobAnim.SetBool("Walking", value: false);
				thirdPersonMan.legsAnim.SetBool("Walking", value: false);
				thirdPersonMan.legsAnim.SetBool("Running", value: false);
				thirdPersonMan.armsAnim.SetBool("Walking", value: false);
				thirdPersonMan.armsAnim.SetBool("Running", value: false);
				thirdPersonMan.bodyAnim.SetBool("Walking", value: false);
				thirdPersonMan.bodyAnim.SetBool("Running", value: false);
			}
			ParticleSystem.EmissionModule emission = runParticles.emission;
			emission.rateOverTime = 0f;
			if (!lookAtState)
			{
				playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, PlayerPrefs.GetFloat("FOV", 70f), Time.deltaTime * 8f);
			}
			playerMan.isRunning = false;
			if (!lockVolume)
			{
				storeMan.volume = 0f;
			}
			moveDirection.x = 0f;
			moveDirection.z = 0f;
			if (!characterController.isGrounded)
			{
				moveDirection.y -= gravity * Time.deltaTime;
			}
			characterController.Move(moveDirection * Time.deltaTime);
		}
		if (!characterController.isGrounded)
		{
			headbobAnim.SetBool("Running", value: false);
			headbobAnim.SetBool("Walking", value: false);
			thirdPersonMan.legsAnim.SetBool("Walking", value: false);
			thirdPersonMan.legsAnim.SetBool("Running", value: false);
			thirdPersonMan.armsAnim.SetBool("Walking", value: false);
			thirdPersonMan.legsAnim.SetBool("Running", value: false);
			thirdPersonMan.armsAnim.SetBool("Walking", value: false);
			thirdPersonMan.armsAnim.SetBool("Running", value: false);
			thirdPersonMan.bodyAnim.SetBool("Walking", value: false);
			thirdPersonMan.bodyAnim.SetBool("Running", value: false);
			justGrounded = true;
			thirdPersonMan.legsAnim.SetBool("MidAir", value: true);
			thirdPersonMan.armsAnim.SetBool("MidAir", value: true);
		}
		else if (justGrounded)
		{
			if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
			{
				headbobAnim.SetTrigger("Land");
			}
			landSFX.Play();
			justGrounded = false;
			thirdPersonMan.legsAnim.SetBool("MidAir", value: false);
			thirdPersonMan.armsAnim.SetBool("MidAir", value: false);
		}
		if (!lockCam && !lookAtState)
		{
			MoveCam();
			if (justUnlockedCam)
			{
				inventoryMan.UnpauseInventory();
				justLockedCam = true;
				justUnlockedCam = false;
				playerMan.crosshair.SetActive(value: true);
			}
		}
		else if (justLockedCam)
		{
			inventoryMan.PauseInventory();
			interactMan.promptObj.SetActive(value: false);
			headbobAnim.SetBool("Running", value: false);
			headbobAnim.SetBool("Walking", value: false);
			thirdPersonMan.legsAnim.SetBool("Walking", value: false);
			thirdPersonMan.legsAnim.SetBool("Running", value: false);
			thirdPersonMan.armsAnim.SetBool("Walking", value: false);
			thirdPersonMan.armsAnim.SetBool("Running", value: false);
			thirdPersonMan.bodyAnim.SetBool("Walking", value: false);
			thirdPersonMan.bodyAnim.SetBool("Running", value: false);
			justLockedCam = false;
			justUnlockedCam = true;
			playerMan.crosshair.SetActive(value: false);
		}
		if (lookAtState)
		{
			LookAtState();
		}
	}

	private void LookAtState()
	{
		if (!objectToLookAt)
		{
			LockCursor();
			playerMan.Invoke("TurnPauseBackOn", 0.1f);
			playerMan.inventoryMan.UnpauseUseItem();
			lockMove = false;
			lockCam = false;
			lookAtState = false;
			return;
		}
		float num = 1f - Mathf.Exp(-8f * Time.deltaTime);
		float t = num * lookAtSpeed;
		float distanceToFOVLinearGraph = GetDistanceToFOVLinearGraph(Vector3.Distance(base.transform.position, objectToLookAt.position));
		playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, distanceToFOVLinearGraph, num);
		if (playerCamera.fieldOfView < 15f)
		{
			playerCamera.fieldOfView = 15f;
		}
		Vector3 forward = objectToLookAt.position - base.transform.position;
		forward.y = 0f;
		Quaternion b = Quaternion.LookRotation(forward);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, t);
		float x = Quaternion.LookRotation(objectToLookAt.position - playerCamera.transform.position).eulerAngles.x;
		Vector3 eulerAngles = playerCamera.transform.rotation.eulerAngles;
		float x2 = Mathf.LerpAngle(eulerAngles.x, x, t);
		playerCamera.transform.rotation = Quaternion.Euler(x2, eulerAngles.y, eulerAngles.z);
	}

	private float GetDistanceToFOVLinearGraph(float x)
	{
		return -10f * x + 65f;
	}

	public void Move()
	{
		Vector3 vector = base.transform.TransformDirection(Vector3.forward);
		Vector3 vector2 = base.transform.TransformDirection(Vector3.right);
		if (canSprint)
		{
			isRunning = Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind6")));
		}
		else
		{
			isRunning = false;
		}
		if (playerMan.stamina <= 0f || Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind2"))) || !canRun)
		{
			isRunning = false;
		}
		float num = 0f;
		float num2 = 0f;
		if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind0"))))
		{
			num2 += 1f;
		}
		if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind2"))))
		{
			num2 -= 1f;
		}
		if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind3"))))
		{
			num += 1f;
		}
		if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind1"))))
		{
			num -= 1f;
		}
		Vector2 vector3 = new Vector2(num, num2);
		vector3.Normalize();
		if (isRunning && vector3 != Vector2.zero && !crouching && !downed)
		{
			if (!lockVolume)
			{
				ChangeVolume(0.81f);
			}
			playerMan.isRunning = true;
			ParticleSystem.EmissionModule emission = runParticles.emission;
			emission.rateOverTime = 13f;
			if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
			{
				headbobAnim.SetBool("Running", value: true);
			}
			headbobAnim.SetBool("Walking", value: false);
			thirdPersonMan.legsAnim.SetBool("Walking", value: false);
			thirdPersonMan.legsAnim.SetBool("Running", value: true);
			thirdPersonMan.armsAnim.SetBool("Walking", value: false);
			thirdPersonMan.armsAnim.SetBool("Running", value: true);
			thirdPersonMan.bodyAnim.SetBool("Walking", value: false);
			thirdPersonMan.bodyAnim.SetBool("Running", value: true);
			if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
			{
				playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, PlayerPrefs.GetFloat("FOV", 70f) + 15f, Time.deltaTime * 8f);
			}
			else
			{
				playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, PlayerPrefs.GetFloat("FOV", 70f), Time.deltaTime * 8f);
			}
		}
		else if (vector3 != Vector2.zero)
		{
			if (!lockVolume && !crouching)
			{
				ChangeVolume(0.51f);
			}
			playerMan.isRunning = false;
			ParticleSystem.EmissionModule emission2 = runParticles.emission;
			emission2.rateOverTime = 0f;
			headbobAnim.SetBool("Running", value: false);
			if (PlayerPrefs.GetInt("CamBobbing", 1) != 0)
			{
				headbobAnim.SetBool("Walking", value: true);
			}
			thirdPersonMan.legsAnim.SetBool("Walking", value: true);
			thirdPersonMan.legsAnim.SetBool("Running", value: false);
			thirdPersonMan.armsAnim.SetBool("Walking", value: true);
			thirdPersonMan.armsAnim.SetBool("Running", value: false);
			thirdPersonMan.bodyAnim.SetBool("Walking", value: true);
			thirdPersonMan.bodyAnim.SetBool("Running", value: false);
			playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, PlayerPrefs.GetFloat("FOV", 70f), Time.deltaTime * 8f);
		}
		if (vector3 == Vector2.zero)
		{
			if (!lockVolume && !crouching)
			{
				ChangeVolume(0f);
			}
			playerMan.isRunning = false;
			ParticleSystem.EmissionModule emission3 = runParticles.emission;
			emission3.rateOverTime = 0f;
			playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, PlayerPrefs.GetFloat("FOV", 70f), Time.deltaTime * 8f);
			headbobAnim.SetBool("Running", value: false);
			headbobAnim.SetBool("Walking", value: false);
			thirdPersonMan.legsAnim.SetBool("Walking", value: false);
			thirdPersonMan.legsAnim.SetBool("Running", value: false);
			thirdPersonMan.armsAnim.SetBool("Walking", value: false);
			thirdPersonMan.armsAnim.SetBool("Running", value: false);
			thirdPersonMan.bodyAnim.SetBool("Walking", value: false);
			thirdPersonMan.bodyAnim.SetBool("Running", value: false);
		}
		RaycastHit hitInfo;
		if (Input.GetKey(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind5", "left ctrl"))))
		{
			crouching = true;
			characterAnim.SetBool("Crouching", value: true);
			thirdPersonMan.legsAnim.SetBool("Crouching", value: true);
			thirdPersonMan.armsAnim.SetBool("Running", value: false);
			thirdPersonMan.legsAnim.SetBool("Running", value: false);
			thirdPersonMan.bodyAnim.SetBool("Crouching", value: true);
			characterController.center = new Vector3(0f, -0.35f, 0f);
			characterController.height = 1.3f;
			justStoppedCrouching = true;
		}
		else if (justStoppedCrouching && !Physics.Raycast(headCheck.position, Vector3.up, out hitInfo, 1f, headHitLayer))
		{
			justStoppedCrouching = false;
			crouching = false;
			characterAnim.SetBool("Crouching", value: false);
			thirdPersonMan.legsAnim.SetBool("Crouching", value: false);
			thirdPersonMan.bodyAnim.SetBool("Crouching", value: false);
			characterController.center = Vector3.zero;
			characterController.height = 2f;
		}
		float y = vector3.y;
		float x = vector3.x;
		if (downed)
		{
			y *= downedSpeed;
			x *= downedSpeed;
		}
		else if (crouching)
		{
			if (!lockVolume)
			{
				ChangeVolume(0f);
			}
			y *= crouchSpeed;
			x *= crouchSpeed;
		}
		else if (isRunning)
		{
			y *= runSpeed;
			x *= runSpeed;
		}
		else
		{
			y *= walkSpeed;
			x *= walkSpeed;
		}
		if (!characterController.isGrounded)
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}
		float y2 = moveDirection.y;
		moveDirection = vector * y + vector2 * x;
		if (Input.GetKeyDown(ConvertStringToKeyCode(PlayerPrefs.GetString("Keybind4"))) && characterController.isGrounded && !downed)
		{
			moveDirection.y = jumpPower;
			jumpSFX.Play();
		}
		else
		{
			moveDirection.y = y2;
		}
		characterController.Move(moveDirection * Time.deltaTime * moveMultiplier);
	}

	public void MoveCam()
	{
		if (PlayerPrefs.GetInt("InvertY", 0) == 0)
		{
			rotationX += (0f - Input.GetAxis("Mouse Y")) * PlayerPrefs.GetFloat("Sensitivity") * sensitivityMultiplier;
		}
		else
		{
			rotationX += Input.GetAxis("Mouse Y") * PlayerPrefs.GetFloat("Sensitivity") * sensitivityMultiplier;
		}
		rotationX = Mathf.Clamp(rotationX, 0f - lookXLimit, lookXLimit);
		playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
		if (PlayerPrefs.GetInt("InvertX", 0) == 0)
		{
			base.transform.rotation *= Quaternion.Euler(0f, Input.GetAxis("Mouse X") * PlayerPrefs.GetFloat("Sensitivity") * sensitivityMultiplier, 0f);
		}
		else
		{
			base.transform.rotation *= Quaternion.Euler(0f, (0f - Input.GetAxis("Mouse X")) * PlayerPrefs.GetFloat("Sensitivity") * sensitivityMultiplier, 0f);
		}
	}

	public KeyCode ConvertStringToKeyCode(string keyName)
	{
		return keyName.ToLower() switch
		{
			"left ctrl" => KeyCode.LeftControl, 
			"LeftControl" => KeyCode.LeftControl, 
			"right ctrl" => KeyCode.RightControl, 
			"left shift" => KeyCode.LeftShift, 
			"LeftShift" => KeyCode.LeftShift, 
			"right shift" => KeyCode.RightShift, 
			"shift" => KeyCode.LeftShift, 
			"ctrl" => KeyCode.LeftControl, 
			_ => (KeyCode)Enum.Parse(typeof(KeyCode), keyName, ignoreCase: true), 
		};
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_ChangeVolumeCmd__Single(float volume)
	{
		ChangeVolumeRpc(volume);
	}

	protected static void InvokeUserCode_ChangeVolumeCmd__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkServer.active)
		{
			Debug.LogError("Command ChangeVolumeCmd called on client.");
		}
		else
		{
			((FPSController)obj).UserCode_ChangeVolumeCmd__Single(reader.ReadFloat());
		}
	}

	protected void UserCode_ChangeVolumeRpc__Single(float volume_)
	{
		volume = volume_;
		if (playerMan == ClientPlayer.Instance.playerMan)
		{
			storeMan.volume = volume;
		}
	}

	protected static void InvokeUserCode_ChangeVolumeRpc__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC ChangeVolumeRpc called on server.");
		}
		else
		{
			((FPSController)obj).UserCode_ChangeVolumeRpc__Single(reader.ReadFloat());
		}
	}

	static FPSController()
	{
		RemoteProcedureCalls.RegisterCommand(typeof(FPSController), "System.Void FPSController::ChangeVolumeCmd(System.Single)", InvokeUserCode_ChangeVolumeCmd__Single, requiresAuthority: false);
		RemoteProcedureCalls.RegisterRpc(typeof(FPSController), "System.Void FPSController::ChangeVolumeRpc(System.Single)", InvokeUserCode_ChangeVolumeRpc__Single);
	}
}
