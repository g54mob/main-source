using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI.Debug;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	public DetectInteractables detectInteractables;

	private float moveHorizontal;

	private float moveVertical;

	private bool jumping;

	private bool interacting;

	private bool sliding;

	private bool aiming;

	private bool holdingJump;

	private bool holdingWallrun;

	public Vector3 cameraRotation;

	private Vector3 desiredCameraRotation;

	private float cameraSmoothingMin;

	private float cameraSmoothingMax;

	private bool hasWallrunActionBound;

	private string stringMouseX;

	private string stringMouseY;

	private int jumpBufferTicks;

	private int currentJumpBufferTick;

	private void Awake()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_020a: Expected I, but got O
		//IL_0230: Expected O, but got I4
		//IL_0246: Expected I, but got O
		//IL_0271: Expected I, but got O
		//IL_027a: Expected O, but got I4
		Action b = OnPlayerDied;
		Delegate obj = Delegate.Combine(PlayerHealth.A_Died, b);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			PlayerHealth.A_Died = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02d3;
			}
			PlayerHealth.A_Died = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b8;
			}
		}
		Action b2 = OnInputMappingChanged;
		Delegate obj6 = Delegate.Combine(KeyListener.A_MapChanged, b2);
		if ((object)obj6 == null)
		{
			KeyListener.A_MapChanged = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02c3;
		}
		KeyListener.A_MapChanged = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02d3;
		IL_02b8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b8;
		IL_02d3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02c3;
	}

	private void OnDestroy()
	{
		//IL_01a4: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_020a: Expected I, but got O
		//IL_0230: Expected O, but got I4
		//IL_0246: Expected I, but got O
		//IL_0271: Expected I, but got O
		//IL_027a: Expected O, but got I4
		Action value = OnPlayerDied;
		Delegate obj = Delegate.Remove(PlayerHealth.A_Died, value);
		nint num;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			PlayerHealth.A_Died = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action);
				obj3 = 0;
				obj4 = obj;
				goto IL_02d3;
			}
			PlayerHealth.A_Died = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_02b8;
			}
		}
		Action value2 = OnInputMappingChanged;
		Delegate obj6 = Delegate.Remove(KeyListener.A_MapChanged, value2);
		if ((object)obj6 == null)
		{
			KeyListener.A_MapChanged = null;
			return;
		}
		bool flag4 = (object)obj6.GetType() != typeof(Action);
		Delegate obj7 = null;
		if (!flag4)
		{
			obj7 = obj6;
		}
		bool flag5 = (object)obj7 == null;
		obj3 = 0;
		obj4 = obj6;
		nint num3 = (nint)typeof(Action);
		if (flag5)
		{
			goto IL_02c3;
		}
		KeyListener.A_MapChanged = (Action)obj7;
		bool flag6 = (object)obj6.GetType() != typeof(Action);
		Delegate obj8 = null;
		if (!flag6)
		{
			obj8 = obj6;
		}
		bool flag7 = (object)obj8 == null;
		num = (nint)typeof(Action);
		obj3 = 0;
		obj4 = obj6;
		if (!flag7)
		{
			return;
		}
		goto IL_02d3;
		IL_02b8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_02c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02b8;
		IL_02d3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_02c3;
	}

	private void Start()
	{
		bool flag = MyInputManager.IsActionBound(MyInputManager.Wallrun);
		hasWallrunActionBound = flag;
	}

	private unsafe void Update()
	{
		//IL_0100: Expected O, but got Ref
		MyPlayer player = GameManager.Instance.GetPlayer();
		if (!(player != null) || !(PlayerCamera.Instance != null))
		{
			return;
		}
		PlayerCamera instance = PlayerCamera.Instance;
		if (instance.cameraState == PlayerCamera.ECameraState.Player3rd && !MyTime.paused && MyTime.unpauseTick < MyTime.tick && (!(DebugConsole.Instance != null) || !DebugConsole.Instance.IsActive()))
		{
			MovementInput();
			if (Cursor.lockState != CursorLockMode.None)
			{
				ManualRotation();
				object obj = default(object);
				PlayerCamera.Instance.CameraInput((Vector3)(&obj));
			}
			else
			{
				PlayerCamera.Instance.MovePositionOnly();
			}
		}
	}

	public static bool IsConsoleOpen()
	{
		//IL_0066: Expected I4, but got O
		bool flag = DebugConsole.Instance != null;
		if (!flag)
		{
			return flag;
		}
		if ((object)DebugConsole.Instance != null)
		{
			return DebugConsole.Instance.IsActive();
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe Vector3 GetWishDir()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0071: Expected O, but got Ref
		//IL_0071: Expected O, but got Ref
		//IL_0088: Expected O, but got Ref
		//IL_0088: Expected O, but got Ref
		//IL_012f: Expected F4, but got O
		//IL_012a: Expected native int or pointer, but got O
		//IL_0144: Expected F4, but got I
		//IL_013f: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerInput)+3C]");
		float num = 0f * ((float)Math.PI / 180f);
		object obj = default(object);
		Vector3 euler = (Vector3)(obj - 120);
		_ = 0;
		_ = 0;
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		float num2 = default(float);
		Vector3 vector2 = default(Vector3);
		Vector3 vector = (Quaternion)(&num2) * (Vector3)(&vector2);
		Vector3 vector3 = (Quaternion)(&num2) * (Vector3)(&vector2);
		float num3 = moveHorizontal * vector3.x;
		float num4 = vector.y * moveVertical;
		float num5 = moveHorizontal * vector3.y;
		float num6 = moveHorizontal * vector3.z;
		float num7 = vector.z * moveVertical;
		float num8 = num5 + num4;
		float num9 = num6 + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Vector3 vector4 = default(Vector3);
		object obj2 = default(object);
		((Vector3*)(nint)vector4)->x = (float)obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rax_v13+8]");
		((Vector3*)(nint)vector4)->z = 0f;
		return vector4;
	}

	private void TestInput()
	{
	}

	private void MovementInput()
	{
		moveHorizontal = 0f;
		float axis = MyInputManager.GetAxis(MyInputManager.MoveHorizontal);
		moveHorizontal = axis;
		float axis2 = MyInputManager.GetAxis(MyInputManager.MoveVertical);
		moveVertical = axis2;
		if (ChallengesTracker.HasChallengeModifier("inverted_controls"))
		{
			float num = moveHorizontal * -1f;
			moveHorizontal = num;
			float num2 = moveVertical * -1f;
			moveVertical = num2;
		}
		if (MyInputManager.GetButtonDown(MyInputManager.Jump))
		{
			goto IL_00a3;
		}
		if (MyInputManager.GetButtonDown(MyInputManager.JumpBhop))
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.playerMovement.CanJump(true))
			{
				goto IL_00a3;
			}
		}
		goto IL_03f9;
		IL_00a3:
		jumping = true;
		currentJumpBufferTick = 0;
		goto IL_03f9;
		IL_0416:
		if (MyInputManager.GetButtonDown(MyInputManager.Interact))
		{
			interacting = true;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerInventory inventory = instance2.inventory;
		WeaponInventory weaponInventory = inventory.weaponInventory;
		if (weaponInventory.hasAimableWeapon)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			CFControlSettings cfControlSettings = config.cfControlSettings;
			if (cfControlSettings.hold_aim == 1)
			{
				aiming = false;
				if (MyInputManager.GetButton(MyInputManager.Aim))
				{
					aiming = true;
				}
			}
			else if (MyInputManager.GetButtonDown(MyInputManager.Aim))
			{
				bool flag = !aiming;
				aiming = flag;
			}
		}
		else
		{
			aiming = false;
		}
		if (!hasWallrunActionBound)
		{
			holdingWallrun = true;
			return;
		}
		bool button = MyInputManager.GetButton(MyInputManager.Wallrun);
		holdingWallrun = button;
		return;
		IL_03f9:
		bool button2 = MyInputManager.GetButton(MyInputManager.Jump);
		holdingJump = button2;
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config2 = saveManager2.config;
		CFControlSettings cfControlSettings2 = config2.cfControlSettings;
		bool flag3;
		if (cfControlSettings2.hold_crouch != 1)
		{
			if (!MyInputManager.GetButtonDown(MyInputManager.Slide))
			{
				goto IL_0416;
			}
			bool flag2 = !sliding;
			flag3 = flag2;
		}
		else
		{
			bool button3 = MyInputManager.GetButton(MyInputManager.Slide);
			bool flag4 = !button3;
			flag3 = !flag4;
		}
		sliding = flag3;
		goto IL_0416;
	}

	private void AbilityInput()
	{
	}

	public unsafe void SetSpawnDirection(Vector3 direction, float pitch = 0f)
	{
		//IL_000a: Expected O, but got Ref
		//IL_0018: Expected O, but got Ref
		//IL_002a: Expected O, but got Ref
		//IL_0038: Expected O, but got F4
		float num = default(float);
		Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num));
		Vector3 vector = Quaternion.Internal_ToEulerRad((Quaternion)(&num));
		Vector3 vector2 = Quaternion.Internal_MakePositive((Vector3)(&num));
		desiredCameraRotation = (Vector3)pitch;
		Vector3 vector3 = default(Vector3);
		cameraRotation = vector3;
		_ = 0;
		_ = vector2.y;
		_ = 0;
	}

	public bool IsHoldingJump()
	{
		return MyInputManager.GetButton(MyInputManager.Jump);
	}

	public unsafe void RotationInput()
	{
		//IL_001e: Expected O, but got Ref
		if (Cursor.lockState != CursorLockMode.None)
		{
			ManualRotation();
			object obj = default(object);
			PlayerCamera.Instance.CameraInput((Vector3)(&obj));
		}
		else
		{
			PlayerCamera.Instance.MovePositionOnly();
		}
	}

	private void AutoRotation()
	{
	}

	private void ManualRotation()
	{
		//IL_01ce: Expected F4, but got I4
		//IL_01d7: Expected F4, but got I4
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Expected O, but got Unknown
		//IL_0223: Expected F4, but got I4
		//IL_026f: Expected F4, but got I4
		//IL_059f: Expected O, but got F4
		//IL_05f9: Invalid comparison between I4 and F4
		//IL_045d: Invalid comparison between I4 and F4
		//IL_04a8: Expected F4, but got I4
		//IL_062d: Expected O, but got I
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFControlSettings cfControlSettings = config.cfControlSettings;
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config2 = saveManager2.config;
		CFControlSettings cfControlSettings2 = config2.cfControlSettings;
		float axis = Input.GetAxis(stringMouseX);
		float axis2 = Input.GetAxis(stringMouseY);
		Player player = MyInputManager.GetPlayer();
		float axis3 = player.GetAxis(MyInputManager.LookHorizontal);
		float deltaTime = Time.deltaTime;
		float num = cfControlSettings2.controller_sensitivity * axis3;
		float num2 = deltaTime * num;
		Player player2 = MyInputManager.GetPlayer();
		float axis4 = player2.GetAxis(MyInputManager.LookVertical);
		float deltaTime2 = Time.deltaTime;
		float num3 = cfControlSettings2.controller_sensitivity * axis4;
		float num4 = deltaTime2 * num3;
		SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config3 = saveManager3.config;
		CFControlSettings cfControlSettings3 = config3.cfControlSettings;
		float num5 = num2 * 50f;
		float num6 = num4 * 50f;
		float num7 = axis * cfControlSettings.sensitivity;
		float num8 = cfControlSettings.sensitivity * axis2;
		bool flag = cfControlSettings3.rotate_camera_with_arrow_keys != 1;
		float num9 = 0f;
		float num10 = 0f;
		if (!flag)
		{
			if (!Input.GetKeyInt(KeyCode.LeftArrow))
			{
				bool keyInt = Input.GetKeyInt(KeyCode.RightArrow);
				bool flag2 = !keyInt;
				num10 = 0f;
				if (!flag2)
				{
					num10 = 3f;
				}
			}
			else
			{
				num10 = -3f;
			}
			if (!Input.GetKeyInt(KeyCode.UpArrow))
			{
				bool keyInt2 = Input.GetKeyInt(KeyCode.DownArrow);
				bool flag3 = !keyInt2;
				num9 = 0f;
				if (!flag3)
				{
					num9 = -3f;
				}
			}
			else
			{
				num9 = 3f;
			}
		}
		float num11 = num5 + num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
		object obj = num8 ^ 0;
		float num12 = (float)obj + num6;
		SaveManager saveManager4 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config4 = saveManager4.config;
		CFControlSettings cfControlSettings4 = config4.cfControlSettings;
		float num13 = num11 + num10;
		if (cfControlSettings4.inverted_horizontal_axis == 1)
		{
			num13 *= -1f;
		}
		SaveManager saveManager5 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config5 = saveManager5.config;
		CFControlSettings cfControlSettings5 = config5.cfControlSettings;
		float num14 = num12 + num9;
		if (cfControlSettings5.inverted_vertical_axis == 1)
		{
			num14 *= -1f;
		}
		if (ChallengesTracker.HasChallengeModifier("inverted_controls"))
		{
			num13 *= -1f;
			num14 *= -1f;
		}
		float num15 = num14 + (float)desiredCameraRotation;
		float num16 = num13;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerInput)+48]");
		float num17 = num16 + 0f;
		bool flag4 = -40f > num15;
		float num18 = -40f;
		if (!flag4)
		{
			bool flag5 = !(num15 > 75f);
			num18 = 75f;
			if (flag5)
			{
				goto IL_0595;
			}
		}
		num15 = num18;
		goto IL_0595;
		IL_0595:
		desiredCameraRotation = (Vector3)num15;
		_ = 0;
		float cameraSmoothing = GetCameraSmoothing();
		float num19 = cameraSmoothingMax - cameraSmoothingMin;
		float num20 = 1f - cameraSmoothing;
		float num21 = num19 * num20;
		float cameraSmoothing2 = GetCameraSmoothing();
		if (0f < cameraSmoothing2)
		{
			float deltaTime3 = Time.deltaTime;
			float num22 = cameraSmoothingMin + num21;
			float num23 = deltaTime3 * num22;
			float num24 = num23 * 20f;
			if (!(0f > num24))
			{
				if (num24 > 1f)
				{
					num24 = 1f;
				}
			}
			else
			{
				num24 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerInput)+4C]");
			nint num25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerInput)+40]");
			object obj2 = num25 - 0;
			float num26 = (float)obj2 * num24;
			float num27 = num26;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerInput)+40]");
			float num28 = num27 + 0f;
			Vector3 vector = default(Vector3);
			cameraRotation = vector;
		}
		else
		{
			cameraRotation = desiredCameraRotation;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerInput)+4C]");
			_ = 0;
		}
	}

	private float GetCameraSmoothing()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFControlSettings cfControlSettings = config.cfControlSettings;
		return cfControlSettings.look_smoothing;
	}

	private void FixedUpdate()
	{
		//IL_0104: Expected I4, but got O
		//IL_0104: Expected F4, but got I
		//IL_0125: Expected O, but got I4
		GameManager instance = GameManager.Instance;
		if (!instance.isPlaying || !(MyPlayer.Instance != null))
		{
			return;
		}
		MyPlayer instance2 = MyPlayer.Instance;
		if (instance2.playerMovement != null && !MyTime.paused)
		{
			if (!MyPlayer.Instance.IsDead() && !ChallengesTracker.HasChallengeModifier("no_movement"))
			{
				MyPlayer instance3 = MyPlayer.Instance;
				PlayerMovement playerMovement = instance3.playerMovement;
				float mH = moveHorizontal;
				float mV = moveVertical;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerInput)+3C]");
				float rV = default(float);
				bool ju = default(bool);
				bool cr = default(bool);
				bool flag = default(bool);
				InputState inputState = new InputState(mH, mV, 0f, rV, ju, cr, flag, (byte)(int)cameraRotation != 0);
				playerMovement.jumping = false;
				playerMovement.inputState = (InputState)0;
				_ = 0;
				playerMovement.x = 0f;
				bool crouching = default(bool);
				playerMovement.crouching = crouching;
				float y = default(float);
				playerMovement.y = y;
			}
			MyPlayer instance4 = MyPlayer.Instance;
			instance4.playerMovement.MovementTick();
			if (interacting)
			{
				detectInteractables.TryInteract();
			}
			if (currentJumpBufferTick < jumpBufferTicks && ++currentJumpBufferTick >= jumpBufferTicks)
			{
				jumping = false;
			}
			interacting = false;
		}
	}

	private void OnPlayerDied()
	{
		//IL_0025: Expected O, but got I4
		MyPlayer instance = MyPlayer.Instance;
		PlayerMovement playerMovement = instance.playerMovement;
		playerMovement.inputState = (InputState)0;
		_ = 0;
		playerMovement.jumping = false;
		bool crouching = default(bool);
		playerMovement.crouching = crouching;
		playerMovement.x = 0f;
		playerMovement.y = 0f;
	}

	private unsafe InputState GetInputState()
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_0017: Expected native int or pointer, but got O
		//IL_0053: Expected I4, but got O
		//IL_0053: Expected F4, but got I
		//IL_004e: Expected native int or pointer, but got O
		InputState inputState = default(InputState);
		((InputState*)(nint)inputState)->moveHorizontal = 0f;
		((InputState*)(nint)inputState)->jumping = false;
		float mH = moveHorizontal;
		float mV = moveVertical;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerInput)+3C]");
		float rV = default(float);
		bool ju = default(bool);
		bool cr = default(bool);
		bool flag = default(bool);
		*(InputState*)(nint)inputState = new InputState(mH, mV, 0f, rV, ju, cr, flag, (byte)(int)cameraRotation != 0);
		return inputState;
	}

	private bool CanInput()
	{
		//IL_00bc: Expected I4, but got O
		if ((object)GameManager.Instance != null)
		{
			MyPlayer player = GameManager.Instance.GetPlayer();
			if (player != null && PlayerCamera.Instance != null)
			{
				PlayerCamera instance = PlayerCamera.Instance;
				if ((object)PlayerCamera.Instance == null)
				{
					goto IL_00ae;
				}
				if (instance.cameraState == PlayerCamera.ECameraState.Player3rd)
				{
					return true;
				}
			}
			return false;
		}
		goto IL_00ae;
		IL_00ae:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool IsMovementDisabled()
	{
		return ChallengesTracker.HasChallengeModifier("no_movement");
	}

	public bool IsAiming()
	{
		return aiming;
	}

	private void OnInputMappingChanged()
	{
		bool flag = MyInputManager.IsActionBound(MyInputManager.Wallrun);
		hasWallrunActionBound = flag;
	}

	public PlayerInput()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183171F75]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		cameraSmoothingMin = 0.25f;
		cameraSmoothingMax = 0.75f;
		stringMouseX = "Mouse X";
		stringMouseY = "Mouse Y";
		jumpBufferTicks = 4;
		base._002Ector();
	}
}
