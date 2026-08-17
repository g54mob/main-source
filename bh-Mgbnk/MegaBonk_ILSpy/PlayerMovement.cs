using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive;
using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.MapGeneration;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.Movement;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

public class PlayerMovement : MonoBehaviour
{
	public enum CrouchState
	{
		None,
		Crouching,
		Sliding
	}

	public Transform playerCam;

	public Transform orientation;

	public Transform feet;

	public Transform head;

	public LayerMask whatIsGround;

	public LayerMask whatIsGroundOnly;

	private Rigidbody rb;

	private float currentMoveSpeed;

	private float currentMaxSpeed;

	private float counterMovement = 0.25f;

	private float defaultCounterMovement = 0.25f;

	private float threshold = 0.01f;

	private int readyToCounterX;

	private int readyToCounterY;

	private float slowDownSpeed = 0.01f;

	private float pushMultiplier = 1f;

	private float pushResetSpeed = 1f;

	private float resetPushCounter;

	private float resetPushCounterValue = 25f;

	private float maxSlopeAngle = 45f;

	private float slideAngle = 30f;

	private float minBreakFallAngle = 12f;

	private float maxBreakFallAngle = 85f;

	private int surfaceDelay = 5;

	private int groundCancel;

	private int surfCancel;

	private int climbCancel;

	private Vector3 ladderNormal;

	private Transform ladder;

	private float ladderSpeed = 11f;

	private bool onLadderLastFrame;

	private float ladderRefreshTime = 0.1f;

	private Vector3 ladderWishDir;

	private Vector3 ladderWallVec;

	public bool onRamp;

	public bool onLadder;

	private bool pushed;

	public bool grounded;

	private bool isUnderwater;

	private bool onGround;

	private bool surfing;

	private bool cancellingGrounded;

	private bool cancellingSurf;

	private Vector3 playerScale;

	private Vector3 crouchScale;

	private float slideCounterMovement = 0.1f;

	public const float crouchRatio = 1f;

	private float playerHeight;

	private float slideThresholdSpeed = 8f;

	private bool readyToCrouch = true;

	private bool readyToSlide;

	private bool justLanded;

	private bool justUncrouched;

	private bool readyToJump = true;

	private int aerialJumps = 1;

	private float x;

	private float y;

	private float mouseDeltaX;

	private float mouseDeltaY;

	private bool jumping;

	private bool crouching;

	private CrouchState _003CcrouchState_003Ek__BackingField;

	private Vector3 normalVector;

	private CapsuleCollider playerCollider;

	private float _003CplayerRadius_003Ek__BackingField;

	private float fallSpeed;

	private Vector3 lastVelocity;

	private int ladderRefreshCount;

	private int ladderRefreshCountMax = 5;

	private int resetJumpCounter = 12;

	private int jumpCounterResetTime = 12;

	private int crouchCooldownCounter;

	private int crouchCooldownCounterMax = 20;

	private int slideCooldownCounter;

	private int slideCooldownCounterMax = 25;

	private int justLandedCounter;

	private int justLandedCounterMax = 15;

	private int justUncrouchedCounter;

	private int justUncrouchedCounterMax = 5;

	private Vector3 headHeight;

	private Vector3 crouchHeadHeight;

	private Vector3 feetHeight;

	public static Action<PlayerMovement> A_Jumped;

	public static Action<PlayerMovement> A_Crouched;

	public static Action<PlayerMovement> A_MovementState;

	public static PlayerMovement Instance;

	public PlayerMovementValues movementValues;

	private ECharacter currentCharacter;

	private EMovementState lastMovementState;

	public InputState inputState;

	private bool frozen;

	public bool isDashing;

	private float leftGroundAtTime;

	private Rail rail;

	private float railSpeed;

	private float progress;

	private float railDirectionMultiplier;

	private float canJumpOffRailTime;

	private float canJumpOffRailAtTime;

	private Vector3 railOffsetPosition;

	private Vector3 railOffsetPositionStart;

	private float railOffsetPositionTimer;

	private float railLerpTime = 0.15f;

	public static Action<bool> A_ToggleGrind;

	public PlayerSfxs playerSfx;

	public static Action A_StartedWallClimb;

	private float minWallClimbSpeed = 10f;

	private float wallClimbCooldown = 0.4f;

	private float canWallClimbAtTime;

	private float wallrunAttachAngle = 60f;

	private Vector3 _003CwallNormal_003Ek__BackingField;

	private Vector3 _003ClastGroundedPosition_003Ek__BackingField;

	private bool isNoclipping;

	private FrictionModifier.EFrictionSurface surface;

	private GameObject groundedObject;

	private float unstuckForce = 2000f;

	private float stuckTimer;

	private float stuckTimerMax = 1f;

	private float lastFallSpeed;

	private float lastTouchedWallTime;

	public static Action<Vector3> CameraBob;

	public static Action<float> A_Landed;

	public static Action<Vector3, float> A_LandedSmoke;

	public static Action<float> Shake;

	private bool wallClimbing;

	public static Action<bool> A_Grounded;

	public static Action<PlayerMovement> A_SlideStart;

	public static Action<PlayerMovement> A_Wallrun;

	private float jumpAnimationCooldownSlide = 0.4f;

	private int usedJumps;

	private float jumpedTime;

	private float landedAtTime;

	private float landingJumpCooldownPegeMode = 0.15f;

	private int climbCancelTicks = 5;

	private float avgVelocity;

	private Vector3 standingFeetOffset;

	private Vector3 crouchingFeetOffset;

	private float lastTouchedTornadoTime;

	private bool _003CisTouchingTornado_003Ek__BackingField;

	public CrouchState crouchState
	{
		get
		{
			return _003CcrouchState_003Ek__BackingField;
		}
		private set
		{
			_003CcrouchState_003Ek__BackingField = value;
		}
	}

	public float playerRadius
	{
		get
		{
			return _003CplayerRadius_003Ek__BackingField;
		}
		private set
		{
			_003CplayerRadius_003Ek__BackingField = value;
		}
	}

	public unsafe Vector3 wallNormal
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003CwallNormal_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+240]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003CwallNormal_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public unsafe Vector3 lastGroundedPosition
	{
		get
		{
			//IL_000f: Expected F4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected F4, but got I
			//IL_001f: Expected native int or pointer, but got O
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003ClastGroundedPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+24C]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_000f: Expected O, but got F4
			_003ClastGroundedPosition_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public bool isTouchingTornado
	{
		get
		{
			return _003CisTouchingTornado_003Ek__BackingField;
		}
		private set
		{
			_003CisTouchingTornado_003Ek__BackingField = value;
		}
	}

	private void UpdateTickRate(int tickRate)
	{
		float num = (float)tickRate * 0.02f;
		float num2 = num * 10f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int num3 = default(int);
		jumpCounterResetTime = num3;
		float num4 = num * 5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		pushResetSpeed = num;
		float num5 = num * 20f;
		int num6 = default(int);
		surfaceDelay = num6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int num7 = default(int);
		crouchCooldownCounterMax = num7;
		float num8 = num * 25f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		float num9 = num * 15f;
		int num10 = default(int);
		slideCooldownCounterMax = num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int num11 = default(int);
		justLandedCounterMax = num11;
	}

	private void Awake()
	{
		//IL_0380: Expected I, but got O
		//IL_0391: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_01ab: Expected I, but got O
		//IL_040e: Expected O, but got I4
		//IL_0424: Expected I, but got O
		//IL_028d: Expected I, but got O
		//IL_0452: Expected O, but got I4
		//IL_0468: Expected I, but got O
		//IL_0496: Expected O, but got I4
		//IL_04ac: Expected I, but got O
		//IL_04da: Expected O, but got I4
		//IL_04f0: Expected I, but got O
		Action<Water> b = OnWaterEnter;
		Delegate obj = Delegate.Combine(Water.A_PlayerEnterWater, b);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			Water.A_PlayerEnterWater = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Water> action = default(Action<Water>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Water>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0536;
			}
			Water.A_PlayerEnterWater = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_03c3;
			}
		}
		Action<Water> b2 = OnWaterExit;
		Delegate obj6 = Delegate.Combine(Water.A_PlayerExitWater, b2);
		if ((object)obj6 == null)
		{
			Water.A_PlayerExitWater = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Water> action2 = default(Action<Water>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_03ce;
			}
			Water.A_PlayerExitWater = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_03de;
			}
		}
		num = (nint)Lava.A_PlayerEnterWater;
		Action action3 = OnLavaEnter;
		Delegate obj8 = Delegate.Combine(Lava.A_PlayerEnterWater, action3);
		if ((object)obj8 == null)
		{
			Lava.A_PlayerEnterWater = null;
		}
		else
		{
			bool flag4 = (object)obj8.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag4)
			{
				obj9 = obj8;
			}
			bool flag5 = (object)obj9 == null;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_04fe;
			}
			Lava.A_PlayerEnterWater = (Action)obj9;
			bool flag6 = (object)obj8.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag6)
			{
				obj10 = obj8;
			}
			bool flag7 = (object)obj10 == null;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0516;
			}
		}
		num = (nint)Lava.A_PlayerExitWater;
		Action action4 = OnLavaExit;
		Delegate obj11 = Delegate.Combine(Lava.A_PlayerExitWater, action4);
		if ((object)obj11 == null)
		{
			Lava.A_PlayerExitWater = null;
			return;
		}
		bool flag8 = (object)obj11.GetType() != typeof(Action);
		Delegate obj12 = null;
		if (!flag8)
		{
			obj12 = obj11;
		}
		bool flag9 = (object)obj12 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num5 = (nint)typeof(Action);
		if (flag9)
		{
			goto IL_0526;
		}
		Lava.A_PlayerExitWater = (Action)obj12;
		bool flag10 = (object)obj11.GetType() != typeof(Action);
		Delegate obj13 = null;
		if (!flag10)
		{
			obj13 = obj11;
		}
		bool flag11 = (object)obj13 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num6 = (nint)typeof(Action);
		if (!flag11)
		{
			return;
		}
		goto IL_0536;
		IL_03de:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ce;
		IL_04fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03de;
		IL_03ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03c3;
		IL_0526:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0516;
		IL_0536:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0526;
		IL_03c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0516:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04fe;
	}

	private void OnDestroy()
	{
		//IL_0380: Expected I, but got O
		//IL_0391: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_012a: Expected I, but got O
		//IL_013b: Expected O, but got I4
		//IL_017e: Expected I, but got O
		//IL_018f: Expected O, but got I4
		//IL_01ab: Expected I, but got O
		//IL_040e: Expected O, but got I4
		//IL_0424: Expected I, but got O
		//IL_028d: Expected I, but got O
		//IL_0452: Expected O, but got I4
		//IL_0468: Expected I, but got O
		//IL_0496: Expected O, but got I4
		//IL_04ac: Expected I, but got O
		//IL_04da: Expected O, but got I4
		//IL_04f0: Expected I, but got O
		Action<Water> value = OnWaterEnter;
		Delegate obj = Delegate.Remove(Water.A_PlayerEnterWater, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			Water.A_PlayerEnterWater = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Water> action = default(Action<Water>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Water>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0536;
			}
			Water.A_PlayerEnterWater = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_03c3;
			}
		}
		Action<Water> value2 = OnWaterExit;
		Delegate obj6 = Delegate.Remove(Water.A_PlayerExitWater, value2);
		if ((object)obj6 == null)
		{
			Water.A_PlayerExitWater = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Water> action2 = default(Action<Water>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_03ce;
			}
			Water.A_PlayerExitWater = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<Water>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_03de;
			}
		}
		num = (nint)Lava.A_PlayerEnterWater;
		Action action3 = OnLavaEnter;
		Delegate obj8 = Delegate.Remove(Lava.A_PlayerEnterWater, action3);
		if ((object)obj8 == null)
		{
			Lava.A_PlayerEnterWater = null;
		}
		else
		{
			bool flag4 = (object)obj8.GetType() != typeof(Action);
			Delegate obj9 = null;
			if (!flag4)
			{
				obj9 = obj8;
			}
			bool flag5 = (object)obj9 == null;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num3 = (nint)typeof(Action);
			if (flag5)
			{
				goto IL_04fe;
			}
			Lava.A_PlayerEnterWater = (Action)obj9;
			bool flag6 = (object)obj8.GetType() != typeof(Action);
			Delegate obj10 = null;
			if (!flag6)
			{
				obj10 = obj8;
			}
			bool flag7 = (object)obj10 == null;
			obj2 = action3;
			obj3 = 0;
			obj4 = obj8;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0516;
			}
		}
		num = (nint)Lava.A_PlayerExitWater;
		Action action4 = OnLavaExit;
		Delegate obj11 = Delegate.Remove(Lava.A_PlayerExitWater, action4);
		if ((object)obj11 == null)
		{
			Lava.A_PlayerExitWater = null;
			return;
		}
		bool flag8 = (object)obj11.GetType() != typeof(Action);
		Delegate obj12 = null;
		if (!flag8)
		{
			obj12 = obj11;
		}
		bool flag9 = (object)obj12 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num5 = (nint)typeof(Action);
		if (flag9)
		{
			goto IL_0526;
		}
		Lava.A_PlayerExitWater = (Action)obj12;
		bool flag10 = (object)obj11.GetType() != typeof(Action);
		Delegate obj13 = null;
		if (!flag10)
		{
			obj13 = obj11;
		}
		bool flag11 = (object)obj13 == null;
		obj2 = action4;
		obj3 = 0;
		obj4 = obj11;
		nint num6 = (nint)typeof(Action);
		if (!flag11)
		{
			return;
		}
		goto IL_0536;
		IL_03de:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ce;
		IL_04fe:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_03de;
		IL_03ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03c3;
		IL_0526:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0516;
		IL_0536:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0526;
		IL_03c3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0516:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04fe;
	}

	private unsafe void OnLavaEnter()
	{
		//IL_002d: Invalid comparison between I4 and F4
		//IL_008b: Expected O, but got Ref
		isUnderwater = true;
		if (0f > rb.velocity.y)
		{
			Vector3 velocity = rb.velocity;
			Vector3 velocity2 = rb.velocity;
			Vector3 velocity3 = rb.velocity;
			float num = default(float);
			rb.velocity = (Vector3)(&num);
		}
	}

	private void OnLavaExit()
	{
		isUnderwater = false;
	}

	private unsafe void OnWaterEnter(Water water)
	{
		//IL_002d: Invalid comparison between I4 and F4
		//IL_008b: Expected O, but got Ref
		isUnderwater = true;
		if (0f > rb.velocity.y)
		{
			Vector3 velocity = rb.velocity;
			Vector3 velocity2 = rb.velocity;
			Vector3 velocity3 = rb.velocity;
			float num = default(float);
			rb.velocity = (Vector3)(&num);
		}
	}

	private void OnWaterExit(Water water)
	{
		isUnderwater = false;
	}

	private bool IsInitialized()
	{
		return Instance != null;
	}

	private void Initialize()
	{
		//IL_018a: Expected O, but got F4
		//IL_022f: Expected O, but got I4
		if (Instance == null)
		{
			Instance = this;
			PlayerMovementValues playerMovementValues = new PlayerMovementValues();
			movementValues = playerMovementValues;
			float fixedDeltaTime = Time.fixedDeltaTime;
			float num = 1f / fixedDeltaTime;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
			object obj = default(object);
			float num2 = (float)obj * 0.02f;
			float num3 = num2 * 10f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
			int num4 = default(int);
			jumpCounterResetTime = num4;
			float num5 = num2 * 5f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
			pushResetSpeed = num2;
			float num6 = num2 * 20f;
			int num7 = default(int);
			surfaceDelay = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
			int num8 = default(int);
			crouchCooldownCounterMax = num8;
			float num9 = num2 * 25f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
			float num10 = num2 * 15f;
			int num11 = default(int);
			slideCooldownCounterMax = num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
			int num12 = default(int);
			justLandedCounterMax = num12;
			Rigidbody component = GetComponent<Rigidbody>();
			rb = component;
			Transform transform = base.transform;
			Vector3 localScale = transform.localScale;
			playerScale = (Vector3)localScale.x;
			_ = localScale.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+EC]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+F0]");
			_ = 0;
			crouchScale = playerScale;
			CapsuleCollider component2 = GetComponent<CapsuleCollider>();
			playerCollider = component2;
			float height = playerCollider.height;
			playerHeight = height;
			float radius = playerCollider.radius;
			_003CplayerRadius_003Ek__BackingField = radius;
			rb.sleepThreshold = 0f;
			inputState = (InputState)0;
			_ = 0;
			Vector3 position = head.position;
			Vector3 position2 = rb.position;
			float num13 = position.z - position2.z;
			Vector3 vector = default(Vector3);
			headHeight = vector;
			crouchHeadHeight = vector;
			Vector3 position3 = rb.position;
			Vector3 position4 = feet.position;
			float num14 = position3.z - position4.z;
			feetHeight = vector;
			Vector3 position5 = rb.position;
			Vector3 position6 = feet.position;
			float num15 = position5.z - position6.z;
			standingFeetOffset = vector;
			crouchingFeetOffset = vector;
		}
	}

	public unsafe void ResetState(ECharacter character, Vector3 dir)
	{
		//IL_003b: Expected O, but got Ref
		//IL_0050: Expected O, but got Ref
		//IL_0078: Expected O, but got Ref
		//IL_0130: Expected O, but got I4
		//IL_013c: Expected F4, but got O
		//IL_019f: Expected O, but got Ref
		//IL_01b7: Expected O, but got Ref
		Initialize();
		surface = FrictionModifier.EFrictionSurface.Normal;
		isUnderwater = false;
		currentCharacter = character;
		Vector3 vector = default(Vector3);
		rb.velocity = (Vector3)(&vector);
		rb.angularVelocity = (Vector3)(&vector);
		_003CcrouchState_003Ek__BackingField = CrouchState.None;
		Transform transform = base.transform;
		transform.localScale = (Vector3)(&vector);
		resetJumpCounter = jumpCounterResetTime;
		resetPushCounter = resetPushCounterValue;
		slideCooldownCounter = slideCooldownCounterMax;
		crouchCooldownCounter = crouchCooldownCounterMax;
		justLandedCounter = justLandedCounterMax;
		justUncrouchedCounter = justUncrouchedCounterMax;
		climbCancel = climbCancelTicks;
		fallSpeed = 0f;
		justUncrouched = false;
		pushMultiplier = 1f;
		onLadder = false;
		readyToCrouch = true;
		justLanded = false;
		onLadderLastFrame = false;
		_ = 0;
		_ = 0;
		inputState = (InputState)0;
		x = (float)inputState;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1D0]");
		jumping = false;
		inputState = inputState;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1D0]");
		_ = 0;
		bool flag = default(bool);
		crouching = flag;
		float num = default(float);
		y = num;
		movementValues.CreateMovement(rb, character);
		Quaternion quaternion2 = Quaternion.LookRotation((Vector3)(&vector));
		float num2 = default(float);
		orientation.rotation = (Quaternion)(&num2);
	}

	public void SetBetterInput(InputState input)
	{
		//IL_000f: Expected O, but got F4
		inputState = (InputState)input.moveHorizontal;
		_ = input.jumping;
		x = input.moveHorizontal;
		y = input.moveVertical;
		jumping = input.jumping;
		crouching = input.crouching;
	}

	public void Freeze(bool b)
	{
		frozen = b;
		rb.isKinematic = b;
	}

	public unsafe void MovementTick()
	{
		//IL_0008: Expected O, but got Ref
		//IL_004c: Expected O, but got Ref
		//IL_0095: Expected O, but got Ref
		//IL_0120: Expected O, but got F4
		//IL_018c: Expected O, but got Ref
		//IL_037f: Invalid comparison between F4 and I4
		//IL_050d: Expected O, but got Ref
		//IL_0259: Expected I, but got O
		//IL_02d7: Expected O, but got F4
		//IL_0349: Expected O, but got Ref
		//IL_07ea: Invalid comparison between F4 and I4
		//IL_0840: Invalid comparison between I4 and F4
		//IL_041e: Expected I, but got O
		//IL_1429: Invalid comparison between F4 and I4
		//IL_0493: Expected O, but got Ref
		//IL_08da: Invalid comparison between I4 and F4
		//IL_0865: Expected O, but got F4
		//IL_0872: Invalid comparison between O and F4
		//IL_0898: Expected F4, but got I4
		//IL_0942: Expected F4, but got I4
		//IL_0a4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a50: Expected F4, but got Unknown
		//IL_146f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1474: Expected F4, but got Unknown
		//IL_13c8: Expected I, but got O
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Expected O, but got Unknown
		//IL_06c5: Invalid comparison between F4 and O
		//IL_0c7a: Expected O, but got Ref
		//IL_09e3: Expected F4, but got I4
		//IL_0cab: Expected O, but got Ref
		//IL_07b7: Expected O, but got Ref
		//IL_10a3: Expected O, but got Ref
		//IL_0cf9: Invalid comparison between F4 and I4
		//IL_111e: Expected O, but got Ref
		//IL_1492: Expected F4, but got I
		//IL_0d61: Expected O, but got F4
		//IL_0d74: Expected O, but got F4
		//IL_0d87: Expected O, but got F4
		//IL_0ee2: Expected O, but got F4
		//IL_0ef4: Expected O, but got F4
		//IL_0f06: Expected O, but got F4
		//IL_0e7a: Expected O, but got Ref
		//IL_0ff6: Expected O, but got Ref
		//IL_159b: Expected O, but got I4
		//IL_15a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a9: Expected I4, but got Unknown
		//IL_150c: Expected I, but got O
		//IL_1229: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (MyTime.paused)
		{
			return;
		}
		Vector3 vector2;
		Vector2 vector3 = default(Vector2);
		if (!frozen)
		{
			Transform transform = orientation.transform;
			Vector3 euler = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1C8]");
			float num = 0f * ((float)Math.PI / 180f);
			_ = 0;
			_ = 0;
			Quaternion quaternion2 = Quaternion.Internal_FromEulerRad(euler);
			Quaternion localRotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 105));
			_ = quaternion2.x;
			transform.localRotation = localRotation;
			if (!isNoclipping)
			{
				UpdateCooldowns();
				CheckInput();
				fallSpeed = rb.velocity.y;
				Vector3 velocity = rb.velocity;
				lastVelocity = (Vector3)velocity.x;
				_ = velocity.z;
				float moveSpeed = movementValues.GetMoveSpeed(surface, grounded);
				float num2 = moveSpeed * pushMultiplier;
				currentMoveSpeed = num2;
				Vector3 velocity2 = rb.velocity;
				Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				_ = velocity2.x;
				_ = velocity2.z;
				vector2 = orientation.InverseTransformVector(vector);
				if (isDashing)
				{
					return;
				}
				bool flag = IsGrinding();
				if (!flag)
				{
					if (isUnderwater != flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1D2]");
						float num3 = (((nint)0 == (flag ? 1 : 0)) ? 0.85f : 1.9125f);
						nint num4 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1168 @ rax_v123 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num5 = 0;
						float mass = rb.mass;
						float num6 = (float)Vector3.upVector * mass;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1169 @ rdx_v77 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
						float num7 = 0f * mass;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1169 @ rdx_v77 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						float num8 = 0f * mass;
						object obj3 = Physics.gravity.y ^ -0f;
						float num9 = num6 * (float)obj3;
						float num10 = num7 * (float)obj3;
						float num11 = num8 * (float)obj3;
						float num12 = num9 * num3;
						float num13 = num10 * num3;
						float num14 = num11 * num3;
						Vector3 force = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
						rb.AddForce(force);
					}
					float drag = rb.drag;
					if (drag > 0f)
					{
						rb.drag = 0f;
					}
					if (!grounded)
					{
						bool isKinematic = rb.isKinematic;
						if (!isKinematic && isUnderwater == isKinematic)
						{
							PlayerMovementValues playerMovementValues = movementValues;
							nint num15 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rax_v118 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num16 = 0;
							float num17 = playerMovementValues._003CextraGravity_003Ek__BackingField * (float)Vector3.downVector;
							float num18 = playerMovementValues._003CextraGravity_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v75 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
							float num19 = num18 * 0f;
							float num20 = playerMovementValues._003CextraGravity_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v486 @ rdx_v75 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
							float num21 = num20 * 0f;
							Vector3 force2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
							rb.AddForce(force2);
						}
					}
					float num22 = y;
					CounterMovement(x, y, vector3);
					if (_003CcrouchState_003Ek__BackingField != CrouchState.None)
					{
						Vector3 velocity3 = rb.velocity;
						object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
						_ = velocity3.x;
						_ = velocity3.z;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
						if (slideThresholdSpeed > velocity3.x)
						{
							if (_003CcrouchState_003Ek__BackingField == CrouchState.Sliding)
							{
								readyToSlide = false;
								slideCooldownCounter = 0;
							}
							_003CcrouchState_003Ek__BackingField = CrouchState.Crouching;
						}
					}
					RampMovement(vector3);
					if (jumping)
					{
						Jump();
					}
					if (!onLadder && onLadderLastFrame)
					{
						onLadder = true;
					}
					if (!onLadder || !(ladder != null))
					{
						goto IL_1398;
					}
					if (IsTouchingGround())
					{
						Transform transform2 = feet.transform;
						Vector3 position = transform2.position;
						Vector3 position2 = ladder.position;
						if (position.y > position2.y)
						{
							float num23 = rb.velocity.y;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
							object obj5 = num23 & 0;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
							{
								onLadderLastFrame = true;
								goto IL_1398;
							}
						}
					}
					LadderMovementTick(x, y);
					onLadderLastFrame = false;
					return;
				}
				RailMovement();
				return;
			}
			NoclipMovement();
			return;
		}
		x = 0f;
		jumping = false;
		return;
		IL_0933:
		_ = 0;
		float num24 = 0f;
		float num26;
		float num25 = num26;
		goto IL_1440;
		IL_141e:
		if (y > 0f && vector2.z > num26)
		{
			goto IL_0933;
		}
		num24 = y;
		_ = y;
		bool flag2 = !(0f > y);
		num25 = num26;
		if (!flag2)
		{
			num26 ^= -0f;
			bool flag3 = !(num26 > vector2.z);
			num25 = num26;
			if (!flag3)
			{
				goto IL_0933;
			}
		}
		goto IL_1440;
		IL_0889:
		_ = 0;
		float num27 = 0f;
		goto IL_141e;
		IL_1398:
		if (_003CcrouchState_003Ek__BackingField == CrouchState.Sliding && grounded && readyToJump && -0f > rb.velocity.y)
		{
			nint num28 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rax_v98 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num29 = 0;
			float num30 = (float)Vector3.downVector * 50f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1779 @ rcx_v88 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
			float num31 = 0f * 50f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1779 @ rcx_v88 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
			float num32 = 0f * 50f;
			float mass2 = rb.mass;
			float num33 = mass2 * num30;
			float num22 = mass2 * num31;
			float num34 = mass2 * num32;
			Vector3 force3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
			rb.AddForce(force3);
		}
		num26 = currentMaxSpeed;
		if (x > 0f && vector2.x > currentMaxSpeed)
		{
			goto IL_0889;
		}
		num27 = x;
		_ = x;
		if (0f > x)
		{
			object obj6 = num26 ^ -0f;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)vector2.x))
			{
				goto IL_0889;
			}
		}
		goto IL_141e;
		IL_1440:
		float num35;
		float num36;
		if (grounded)
		{
			if (_003CcrouchState_003Ek__BackingField == CrouchState.Sliding)
			{
				if (IsHoldingAgainstVerticalVel(vector3))
				{
					num35 = 0.15f;
					num36 = 0.25f;
				}
				else
				{
					num35 = 0.15f;
					num36 = 0f;
				}
			}
			else
			{
				num35 = 1f;
				num36 = 1f;
			}
		}
		else if (IsHoldingAgainstVerticalVel(vector3))
		{
			float num37 = vector2.z * 0.025f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			num25 = num37 & 0;
			bool flag4 = !(0.5f < num25);
			float num38 = 0.5f;
			if (!flag4)
			{
				num38 = num25;
			}
			float num39 = num38;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			num36 = num39 & 0;
			num35 = 0.45f;
		}
		else
		{
			num35 = 0.45f;
			num36 = 0.45f;
		}
		Vector3 forward = orientation.forward;
		float num40 = num24 * forward.x;
		float num41 = num24 * forward.y;
		float num42 = num24 * forward.z;
		float num43 = num40 * currentMoveSpeed;
		float num44 = num41 * currentMoveSpeed;
		float num45 = num42 * currentMoveSpeed;
		float num46 = num43 * 0.02f;
		float num47 = num44 * 0.02f;
		float num48 = num45 * 0.02f;
		float num49 = num46 * num36;
		float num50 = num47 * num36;
		float num51 = num48 * num36;
		Vector3 right = orientation.right;
		float num52 = currentMoveSpeed;
		float num53 = num27 * right.x;
		float num54 = num53 * currentMoveSpeed;
		float num55 = num54 * 0.02f;
		float num56 = num27 * right.y;
		float num57 = num27 * right.z;
		float num58 = num56 * currentMoveSpeed;
		float num59 = num57 * currentMoveSpeed;
		float num60 = num58 * 0.02f;
		float num61 = num59 * 0.02f;
		float num62 = num60 * num35;
		float num63 = num55 * num35;
		float num64 = num61 * num35;
		Vector3 force4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		rb.AddForce(force4);
		Vector3 force5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		rb.AddForce(force5);
		if (!grounded)
		{
			num52 = GetAirDeceleration();
			if (num52 > 0f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				bool flag5 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001803401A4h\"");
				float num77;
				float num78;
				if (!flag5)
				{
					Vector3 forward2 = orientation.forward;
					object obj7 = forward2.x ^ -0f;
					object obj8 = forward2.y ^ -0f;
					object obj9 = forward2.z ^ -0f;
					float num65 = (float)obj7 * vector2.z;
					float num66 = (float)obj8 * vector2.z;
					float num67 = (float)obj9 * vector2.z;
					float num68 = num65 * currentMoveSpeed;
					float num69 = num66 * currentMoveSpeed;
					float num70 = num67 * currentMoveSpeed;
					float num71 = num68 * 0.02f;
					float num72 = num69 * 0.02f;
					float num73 = num70 * 0.02f;
					float airDeceleration = GetAirDeceleration();
					float num74 = num71 * airDeceleration;
					float num75 = num72 * airDeceleration;
					float num76 = airDeceleration * num73;
					Vector3 force6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
					rb.AddForce(force6);
					num77 = -0f;
					num78 = 0.02f;
				}
				else
				{
					num77 = -0f;
					num78 = 0.02f;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
				num52 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+7F]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180340285h\"");
				if (!flag6)
				{
					Vector3 right2 = orientation.right;
					object obj10 = right2.x ^ num77;
					object obj11 = right2.y ^ num77;
					object obj12 = right2.z ^ num77;
					float num79 = (float)obj10 * vector2.x;
					float num80 = (float)obj11 * vector2.x;
					float num81 = (float)obj12 * vector2.x;
					float num82 = num79 * currentMoveSpeed;
					float num83 = num80 * currentMoveSpeed;
					float num84 = num81 * currentMoveSpeed;
					float num85 = num82 * num78;
					float num86 = num83 * num78;
					float num87 = num84 * num78;
					float airDeceleration2 = GetAirDeceleration();
					num25 = airDeceleration2 * num85;
					float num22 = airDeceleration2 * num86;
					num52 = airDeceleration2 * num87;
					Vector3 force7 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
					rb.AddForce(force7);
				}
			}
		}
		EMovementState movementState = GetMovementState();
		if (movementState != lastMovementState)
		{
			EMovementState movementState2 = GetMovementState();
			lastMovementState = movementState2;
			Action<PlayerMovement> a_MovementState = A_MovementState;
			if (A_MovementState != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1966 @ rax_v87 (System.Action`1<PlayerMovement>)+18] (should have been resolved before IL gen)");
			}
		}
		Vector3 velocity4 = rb.velocity;
		object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		_ = velocity4.x;
		_ = velocity4.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		float num88 = velocity4.x + avgVelocity;
		float num89 = num88 * 0.5f;
		avgVelocity = num89;
		VerifyPosition();
		Vector3 velocity5 = rb.velocity;
		object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
		_ = velocity5.x;
		_ = velocity5.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		if (!(velocity5.x > 0.5f) && !IsTouchingGround() && !rb.isKinematic && rb.useGravity)
		{
			if ((stuckTimer += MyTime.fixedDeltaTime) > stuckTimerMax)
			{
				stuckTimer = 0f;
				nint num90 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rax_v79 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num91 = 0;
				_ = Vector3.upVector;
				float num92 = (float)Vector3.upVector * unstuckForce;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-75]");
				float num93 = 0f * unstuckForce;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2362 @ rcx_v67 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float num94 = 0f * unstuckForce;
				float mass3 = rb.mass;
				float num95 = mass3 * num92;
				float num96 = mass3 * num93;
				float num97 = mass3 * num94;
				Vector3 force8 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				rb.AddForce(force8);
			}
		}
		else
		{
			stuckTimer = 0f;
		}
		if (-25f > lastFallSpeed && fallSpeed > -5f)
		{
			bool flag7 = _003CcrouchState_003Ek__BackingField == CrouchState.None;
			bool flag8 = !flag7;
			object obj15 = flag8 & onRamp;
			bool flag9 = (byte)(obj15 ^ 1) != 0;
			float num98 = MyTime.time - lastTouchedWallTime;
			bool flag10 = !(0.1f > num98);
			bool flag11 = false;
			if (!flag10)
			{
				flag11 = flag9;
			}
			if (flag11)
			{
				MyPlayer instance = MyPlayer.Instance;
				PlayerInventory inventory = instance.inventory;
				PlayerHealth playerHealth = inventory.playerHealth;
				float num99 = MyTime.time - playerHealth.fallDamageTakenAtTime;
				if (num99 > 0.15f)
				{
					MyStats.AddValue(EMyStat.wallhugs, 1f);
				}
			}
		}
		lastFallSpeed = fallSpeed;
	}

	private float GetAirDeceleration()
	{
		//IL_0063: Expected F4, but got I4
		if (GameManager.Instance != null)
		{
			GameManager instance = GameManager.Instance;
			if (instance._003CisCrypt_003Ek__BackingField)
			{
				return 0f;
			}
		}
		PlayerMovementValues playerMovementValues = movementValues;
		return playerMovementValues._003CairDeceleration_003Ek__BackingField;
	}

	public void StartRail(Rail rail)
	{
		//IL_0095: Expected O, but got I4
		//IL_00a7: Expected F4, but got I4
		//IL_036b: Expected I, but got O
		//IL_0122: Expected F8, but got I4
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0228: Invalid comparison between O and F4
		//IL_023a: Expected F4, but got I4
		//IL_0255: Expected F4, but got I8
		this.rail = rail;
		float fixedDeltaTime = Time.fixedDeltaTime;
		float num = fixedDeltaTime + MyTime.time;
		canJumpOffRailTime = num;
		float num2 = currentMaxSpeed * 1.5f;
		Vector3 velocity = rb.velocity;
		float num3 = velocity.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		if (!(velocity.x > num2))
		{
			num3 = num2;
		}
		railSpeed = num3;
		Transform transform = base.transform;
		Vector3 position = transform.position;
		object obj = 0;
		float num4 = 3.4028235E+38f;
		float t = 0f;
		bool flag;
		do
		{
			float num5 = (float)obj / 100f;
			float3 float5 = rail.splineContainer.EvaluatePosition(num5);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
			nint num6 = (nint)typeof(Math);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
			double num7;
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
				num7 = 0.0;
			}
			else
			{
				num7 = Math.Sqrt(0.0);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
			if ((double)num4 > num7)
			{
				num4 = (float)num7;
				t = num5;
			}
			obj++;
			flag = (nint)obj <= 100;
			float num8 = float5.x;
		}
		while (flag);
		progress = t;
		float3 float6 = rail.splineContainer.EvaluateTangent(t);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
		Vector3 velocity2 = rb.velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v22+4]");
		object obj2 = 0 * velocity2.y;
		object obj4 = default(object);
		object obj3 = obj4 * velocity2.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v22+8]");
		object obj5 = 0 * velocity2.z;
		object obj6 = obj2 + obj3;
		object obj7 = obj6 + obj5;
		bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0f);
		float num9 = 1f;
		if (!flag2)
		{
			num9 = 4.2949673E+09f;
		}
		railDirectionMultiplier = num9;
		Vector3 position2 = rb.position;
		Vector3 railPosition = GetRailPosition();
		float num10 = position2.z - railPosition.z;
		railOffsetPositionTimer = 0f;
		Vector3 vector = default(Vector3);
		railOffsetPosition = vector;
		railOffsetPositionStart = railOffsetPosition;
		rb.isKinematic = true;
		playerSfx.StartGrind();
		Action<bool> a_ToggleGrind = A_ToggleGrind;
		if (A_ToggleGrind != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v538 @ rax_v31 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	public unsafe void StopRail()
	{
		//IL_0094: Invalid comparison between I4 and F4
		//IL_0135: Expected O, but got Ref
		//IL_01b2: Expected I, but got O
		//IL_022b: Expected O, but got Ref
		if (!(this.rail != null))
		{
			return;
		}
		rb.isKinematic = false;
		this.rail.Cooldown(playerCollider);
		StopGrounded();
		float num = progress;
		if (progress < 1f)
		{
			if (!(0f < num))
			{
				num = 0.01f;
			}
		}
		else
		{
			num = 0.99f;
		}
		Rail rail = this.rail;
		float3 float5 = rail.splineContainer.EvaluateTangent(num);
		float num2 = railDirectionMultiplier * float5.y;
		float num3 = railDirectionMultiplier * float5.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		float num4 = default(float);
		rb.velocity = (Vector3)(&num4);
		Vector3 velocity = rb.velocity;
		nint num5 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rax_v19 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rdx_v12 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num7 = 0f * 5f;
		float num8 = num7 + velocity.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rdx_v12 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		float num9 = 0f * 5f;
		float num10 = num9 + velocity.y;
		rb.velocity = (Vector3)(&num4);
		this.rail = null;
		playerSfx.StopGrind();
		Action<bool> a_ToggleGrind = A_ToggleGrind;
		if (A_ToggleGrind != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v129 @ rax_v24 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private unsafe void RailMovement()
	{
		//IL_0070: Invalid comparison between I4 and F4
		//IL_00bb: Expected F4, but got I4
		//IL_00e8: Invalid comparison between I4 and F4
		//IL_00cb: Invalid comparison between F4 and I4
		//IL_0107: Invalid comparison between I4 and F4
		//IL_01d8: Expected O, but got Ref
		//IL_0279: Invalid comparison between I4 and F4
		//IL_0188: Expected F4, but got I4
		//IL_0323: Expected I, but got O
		//IL_0348: Invalid comparison between I4 and F4
		//IL_01c4: Expected F4, but got I4
		//IL_02b9: Expected O, but got I
		Rail rail = this.rail;
		float num = rail.splineContainer.CalculateLength();
		float fixedDeltaTime = Time.fixedDeltaTime;
		float num2 = railSpeed / num;
		float num3 = num2 * railDirectionMultiplier;
		float num4 = fixedDeltaTime * num3;
		float num5 = num4 + progress;
		if (!(0f > num5))
		{
			if (num5 > 1f)
			{
				num5 = 1f;
			}
		}
		else
		{
			num5 = 0f;
		}
		progress = num5;
		if ((!(num5 < 1f) && railDirectionMultiplier > 0f) || (!(0f < num5) && 0f > railDirectionMultiplier))
		{
			StopRail();
			return;
		}
		if (1f > railOffsetPositionTimer)
		{
			float num6 = MyTime.fixedDeltaTime / railLerpTime;
			float num7 = num6 + railOffsetPositionTimer;
			if (!(0f > num7))
			{
				if (num7 > 1f)
				{
					num7 = 1f;
				}
			}
			else
			{
				num7 = 0f;
			}
			railOffsetPositionTimer = num7;
			nint num8 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ rax_v20 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num9 = 0;
			float num10 = railOffsetPositionTimer;
			if (!(0f > railOffsetPositionTimer))
			{
				if (num10 > 1f)
				{
					num10 = 1f;
				}
			}
			else
			{
				num10 = 0f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ rcx_v15 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+210]");
			object obj = num11 - 0;
			float num12 = (float)obj * num10;
			float num13 = num12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+210]");
			float num14 = num13 + 0f;
			Vector3 vector = default(Vector3);
			railOffsetPosition = vector;
		}
		Vector3 railPosition = GetRailPosition();
		float num15 = default(float);
		rb.MovePosition((Vector3)(&num15));
		if (MyTime.time > canJumpOffRailTime && jumping)
		{
			Jump();
		}
	}

	private unsafe Vector3 GetRailPosition()
	{
		//IL_0106: Expected I, but got O
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_0149: Expected O, but got I
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_01a3: Expected native int or pointer, but got O
		//IL_01b0: Expected native int or pointer, but got O
		//IL_01bd: Expected native int or pointer, but got O
		Rail rail = this.rail;
		if ((object)this.rail != null && (object)rail.splineContainer != null)
		{
			float3 float5 = rail.splineContainer.EvaluatePosition(progress);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
			Rail rail2 = this.rail;
			if ((object)this.rail != null && (object)rail2.splineContainer != null)
			{
				float3 float6 = rail2.splineContainer.EvaluateUpVector(progress);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+1A8]");
				object obj = 0 * Vector3.upVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+1A8]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rcx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				object obj2 = num3 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+1A8]");
				object obj4 = default(object);
				object obj3 = 0 * obj4;
				object obj5 = default(object);
				float num4 = (float)obj + (float)obj5;
				float num5 = (float)obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v6+8]");
				float z = num5 + 0f;
				float num6 = (float)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v6+4]");
				float num7 = num6 + 0f;
				Vector3 vector = default(Vector3);
				((Vector3*)(nint)vector)->x = num4;
				((Vector3*)(nint)vector)->z = z;
				((Vector3*)(nint)vector)->y = num7;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public bool CanStartGrind()
	{
		bool flag = rail != null;
		return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
	}

	public bool IsGrinding()
	{
		return rail != null;
	}

	public unsafe Vector3 GetGrindNormal()
	{
		//IL_007f: Expected F4, but got O
		//IL_007a: Expected native int or pointer, but got O
		//IL_0094: Expected F4, but got I
		//IL_008f: Expected native int or pointer, but got O
		Rail rail = this.rail;
		if ((object)this.rail != null && (object)rail.splineContainer != null)
		{
			float3 float5 = rail.splineContainer.EvaluateUpVector(progress);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
			Vector3 vector = default(Vector3);
			object obj = default(object);
			((Vector3*)(nint)vector)->x = (float)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v5+8]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe Vector3 GetGrindDirection()
	{
		//IL_007f: Expected F4, but got O
		//IL_007a: Expected native int or pointer, but got O
		//IL_0094: Expected F4, but got I
		//IL_008f: Expected native int or pointer, but got O
		Rail rail = this.rail;
		if ((object)this.rail != null && (object)rail.splineContainer != null)
		{
			float3 float5 = rail.splineContainer.EvaluateTangent(progress);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
			Vector3 vector = default(Vector3);
			object obj = default(object);
			((Vector3*)(nint)vector)->x = (float)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v4+8]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	private float FindClosestPointOnSpline(SplineContainer spline, Vector3 position)
	{
		//IL_0036: Expected F4, but got I4
		//IL_003f: Expected O, but got I4
		//IL_0167: Expected I, but got O
		//IL_00ff: Expected F8, but got I4
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		float result = 0f;
		object obj = 0;
		float num = 3.4028235E+38f;
		object obj2 = default(object);
		bool flag;
		do
		{
			float num2 = (float)obj / 100f;
			float3 float5 = spline.EvaluatePosition(num2);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
			nint num3 = (nint)typeof(Math);
			float num4 = position.x - (float)obj2;
			float num5 = position.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v6+4]");
			float num6 = num5 - 0f;
			float num7 = position.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rax_v6+8]");
			float num8 = num7 - 0f;
			float num9 = num6 * num6;
			float num10 = num4 * num4;
			float num11 = num8 * num8;
			float num12 = num9 + num10;
			float num13 = num12 + num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v5 (Il2CppClass<System.Math>)+E4]");
			double num14;
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
				num14 = 0.0;
			}
			else
			{
				num14 = Math.Sqrt(num13);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
			if ((double)num > num14)
			{
				result = num2;
				num = (float)num14;
			}
			obj++;
			flag = (nint)obj <= 100;
			float num15 = float5.x;
		}
		while (flag);
		return result;
	}

	private unsafe void WallClimbing()
	{
		//IL_014d: Expected O, but got Ref
		if (climbCancel >= climbCancelTicks)
		{
			Action a_StartedWallClimb = A_StartedWallClimb;
			if (A_StartedWallClimb != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v42.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		climbCancel = 0;
		Vector3 velocity = rb.velocity;
		float num = minWallClimbSpeed;
		float num2 = currentMaxSpeed * 1.5f;
		if (minWallClimbSpeed < num2)
		{
			num = num2;
		}
		if (num > velocity.y)
		{
			Vector3 velocity2 = rb.velocity;
			float num3 = currentMaxSpeed * 1.5f;
			if (minWallClimbSpeed < num3)
			{
				goto IL_0180;
			}
			Vector3 velocity3 = rb.velocity;
			object obj = default(object);
			rb.velocity = (Vector3)(&obj);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1D3]");
		if ((nint)0 == 0)
		{
			goto IL_0180;
		}
		return;
		IL_0180:
		float num4 = MyTime.time + wallClimbCooldown;
		canWallClimbAtTime = num4;
	}

	private unsafe bool CanWallClimb(Vector3 normal, Collision other)
	{
		//IL_0168: Expected I4, but got O
		//IL_007b: Expected O, but got F4
		//IL_010d: Expected O, but got Ref
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_0130: Invalid comparison between O and F4
		if (canWallClimbAtTime > MyTime.time)
		{
			goto IL_0154;
		}
		if (other != null)
		{
			GameObject gameObject = other.gameObject;
			if ((object)gameObject != null)
			{
				if (!gameObject.CompareTag("Ignore"))
				{
					_003CwallNormal_003Ek__BackingField = (Vector3)normal.x;
					_ = normal.z;
					MyPlayer instance = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null && instance.inventory != null)
					{
						MyPlayer instance2 = MyPlayer.Instance;
						if ((object)MyPlayer.Instance == null || instance2.inventory == null)
						{
							goto IL_015a;
						}
						if (instance2.inventory.HasPassive(EPassive.WallClimb))
						{
							object obj = default(object);
							float num = RelativeToLook((Vector3)(&obj));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
							object obj2 = num & 0;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)wallrunAttachAngle))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1D3]");
								return false;
							}
						}
					}
				}
				goto IL_0154;
			}
		}
		goto IL_015a;
		IL_0154:
		return false;
		IL_015a:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void StopWallClimbing()
	{
		float num = MyTime.time + wallClimbCooldown;
		canWallClimbAtTime = num;
	}

	public bool IsWallClimbing()
	{
		//IL_0011: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected I4, but got Unknown
		object obj = climbCancel - climbCancelTicks;
		int num = climbCancel ^ climbCancelTicks;
		int num2 = climbCancel ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 != flag;
	}

	private unsafe bool CheckIfPlayerWantsToWallClimb(Vector3 normal)
	{
		//IL_000a: Expected O, but got Ref
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_002d: Invalid comparison between O and F4
		object obj = default(object);
		float num = RelativeToLook((Vector3)(&obj));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj2 = num & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)wallrunAttachAngle))
		{
			return false;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1D3]");
		return false;
	}

	private float RelativeToLook(Vector3 normal)
	{
		//IL_035c: Expected I, but got O
		//IL_0480: Invalid comparison between F4 and I4
		//IL_02e8: Expected I, but got O
		//IL_0239: Expected F8, but got I4
		//IL_02fb: Expected I, but got O
		//IL_0314: Expected F4, but got O
		//IL_0324: Expected F8, but got I
		//IL_0334: Expected F4, but got I
		Transform transform = orientation.transform;
		Vector3 forward = transform.forward;
		float num = y * forward.x;
		float num2 = y * forward.y;
		float num3 = y * forward.z;
		Transform transform2 = orientation.transform;
		Vector3 right = transform2.right;
		float num4 = x * right.x;
		float num5 = x * right.y;
		float num6 = x * right.z;
		float num7 = num4 + num;
		float num8 = num5 + num2;
		float num9 = num6 + num3;
		Vector3 velocity = rb.velocity;
		Vector3 velocity2 = rb.velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		float num10 = default(float);
		bool flag = !(num10 > 0.1f);
		double num11 = num8;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			bool flag2 = !(num10 > 3f);
			num11 = num8;
			if (!flag2)
			{
				nint num12 = (nint)typeof(Math);
				float num13 = velocity.x * velocity.x;
				float num14 = velocity2.z * velocity2.z;
				float num15 = num13 + num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm2\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ rcx_v16 (Il2CppClass<System.Math>)+E4]");
				double num16;
				if ((nint)0 <= (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm2\"");
					num16 = 0.0;
				}
				else
				{
					num16 = Math.Sqrt(num15);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
				double num17;
				float num18;
				float num19;
				if (num16 > 9.999999747378752E-06)
				{
					num17 = 0.0 / num16;
					num18 = velocity.x / (float)num16;
					num19 = velocity2.z / (float)num16;
				}
				else
				{
					nint num20 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v447 @ rax_v22 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num21 = 0;
					num18 = (float)Vector3.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
					num17 = 0.0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v19 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					num19 = 0f;
				}
				float num22 = num18 * 0.2f;
				double num23 = num17 * 0.20000000298023224;
				float num24 = num19 * 0.2f;
				float num25 = num22 + num7;
				double num26 = num23 + (double)num8;
				float num27 = num24 + num9;
				num11 = num26;
				num7 = num25;
				num9 = num27;
			}
		}
		nint num28 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rax_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		float num30 = normal.x * num9;
		float num31 = normal.z * num7;
		float num32 = normal.z * (float)num11;
		float num33 = num30 - num31;
		float num34 = normal.x * (float)num11;
		float num35 = normal.y * num7;
		float num36 = normal.y * num9;
		float num37 = num35 - num34;
		float num38 = num33;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		float num39 = num38 * 0f;
		float num40 = num32 - num36;
		float num41 = num37;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num42 = num41 * 0f;
		float num43 = num40 * (float)Vector3.upVector;
		float num44 = num39 + num43;
		float num45 = num44 + num42;
		float num46 = ((num45 < 0f) ? (-1f) : 1f);
		return num46 * 0.2f;
	}

	private unsafe Vector3 InputVectorRelativeToLook()
	{
		//IL_0169: Expected native int or pointer, but got O
		//IL_0176: Expected native int or pointer, but got O
		//IL_0183: Expected native int or pointer, but got O
		if ((object)orientation != null)
		{
			Transform transform = orientation.transform;
			if ((object)transform != null)
			{
				Vector3 forward = transform.forward;
				float num = y * forward.x;
				float num2 = y * forward.y;
				float num3 = y * forward.z;
				if ((object)orientation != null)
				{
					Transform transform2 = orientation.transform;
					if ((object)transform2 != null)
					{
						Vector3 right = transform2.right;
						float num4 = x * right.x;
						float num5 = x * right.y;
						float num6 = x * right.z;
						float num7 = num4 + num;
						float num8 = num5 + num2;
						float z = num6 + num3;
						Vector3 vector = default(Vector3);
						((Vector3*)(nint)vector)->x = num7;
						((Vector3*)(nint)vector)->y = num8;
						((Vector3*)(nint)vector)->z = z;
						return vector;
					}
				}
			}
		}
		return (Vector3)new NullReferenceException();
	}

	private float GetWallClimbSpeed()
	{
		float num = currentMaxSpeed * 1.5f;
		float result = minWallClimbSpeed;
		if (minWallClimbSpeed < num)
		{
			result = num;
		}
		return result;
	}

	private unsafe void VerifyPosition()
	{
		//IL_0022: Expected I, but got O
		//IL_0037: Expected O, but got Ref
		//IL_00bf: Expected O, but got F4
		//IL_004c: Expected O, but got Ref
		//IL_0150: Expected O, but got Ref
		//IL_0150: Expected O, but got Ref
		if (!grounded)
		{
			Vector3 position = rb.position;
			nint num = (nint)typeof(MapInfo);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rax_v12 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v13 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+4]");
			float num3 = 0f - 10f;
			if (num3 > position.y)
			{
				Vector3 vector = default(Vector3);
				rb.MovePosition((Vector3)(&vector));
				rb.velocity = (Vector3)(&vector);
				object obj = default(object);
				CheckLanding((Vector3)(&obj), (Vector3)(&vector));
			}
		}
		else if (groundedObject != null && !groundedObject.CompareTag("Ignore"))
		{
			Vector3 position2 = rb.position;
			_003ClastGroundedPosition_003Ek__BackingField = (Vector3)position2.x;
			_ = position2.z;
		}
	}

	public unsafe void TeleportPlayerBackToBounds(Vector3 pos)
	{
		//IL_0014: Expected O, but got Ref
		//IL_0029: Expected O, but got Ref
		//IL_0048: Expected O, but got Ref
		//IL_0048: Expected O, but got Ref
		float num = default(float);
		rb.MovePosition((Vector3)(&num));
		rb.velocity = (Vector3)(&num);
		object obj = default(object);
		Vector3 vector = default(Vector3);
		CheckLanding((Vector3)(&obj), (Vector3)(&vector));
		ResetAerialJumps();
	}

	public unsafe void TeleportPlayer(Vector3 pos)
	{
		//IL_0014: Expected O, but got Ref
		//IL_0028: Expected O, but got Ref
		float num = default(float);
		rb.MovePosition((Vector3)(&num));
		rb.velocity = (Vector3)(&num);
	}

	private void Update()
	{
	}

	private unsafe void NoclipMovement()
	{
		//IL_0088: Expected O, but got Ref
		//IL_00ab: Expected O, but got Ref
		Transform transform = PlayerCamera.Instance.transform;
		Vector3 forward = transform.forward;
		if (!jumping)
		{
		}
		Transform transform2 = PlayerCamera.Instance.transform;
		Vector3 right = transform2.right;
		float num = default(float);
		rb.velocity = (Vector3)(&num);
		Vector3 velocity = rb.velocity;
		rb.velocity = (Vector3)(&num);
	}

	public unsafe Vector2 GetLocalVelocity()
	{
		//IL_005c: Expected O, but got Ref
		if ((object)rb != null)
		{
			Vector3 velocity = rb.velocity;
			if ((object)orientation != null)
			{
				object obj = default(object);
				Vector3 vector = orientation.InverseTransformVector((Vector3)(&obj));
				Vector2 result = default(Vector2);
				return result;
			}
		}
		return (Vector2)new NullReferenceException();
	}

	public unsafe static Vector3 AirAccelerate(Vector3 velocity, Vector3 wishdir, float wishspeed, float accel, float airCap, float deltaTime, float gainMultiplier = 1f)
	{
		//IL_0110: Invalid comparison between I4 and F4
		//IL_019d: Expected I, but got O
		//IL_01bb: Expected F4, but got O
		//IL_01b6: Expected native int or pointer, but got O
		//IL_01d0: Expected F4, but got I
		//IL_01cb: Expected native int or pointer, but got O
		//IL_016b: Expected native int or pointer, but got O
		//IL_0178: Expected native int or pointer, but got O
		//IL_0185: Expected native int or pointer, but got O
		float num = default(float);
		bool flag = wishspeed > num;
		float num2 = num;
		if (!flag)
		{
			num2 = wishspeed;
		}
		float num3 = wishdir.x * velocity.x;
		float num4 = velocity.y * wishdir.y;
		float num5 = velocity.z * wishdir.z;
		float num6 = num4 + num3;
		float num7 = num6 + num5;
		float num8 = num2 - num7;
		object obj = default(object);
		float num9 = num8 * (float)obj;
		Vector3 vector = default(Vector3);
		if (0f < num9)
		{
			object obj2 = default(object);
			float num10 = wishspeed * (float)obj2;
			object obj3 = default(object);
			float num11 = num10 * (float)obj3;
			if (num9 > num11)
			{
				num9 = num11;
			}
			float num12 = num9 * wishdir.x;
			float num13 = num9 * wishdir.y;
			float z = num9 * wishdir.z;
			((Vector3*)(nint)vector)->x = num12;
			((Vector3*)(nint)vector)->y = num13;
			((Vector3*)(nint)vector)->z = z;
			return vector;
		}
		nint num14 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v2 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num15 = 0;
		((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public unsafe Vector3 GetWishDir()
	{
		//IL_0129: Expected F4, but got O
		//IL_0124: Expected native int or pointer, but got O
		//IL_013e: Expected F4, but got I
		//IL_0139: Expected native int or pointer, but got O
		if ((object)orientation != null)
		{
			Vector3 forward = orientation.forward;
			float num = y * forward.x;
			float num2 = y * forward.y;
			float num3 = y * forward.z;
			if ((object)orientation != null)
			{
				Vector3 right = orientation.right;
				float num4 = x * right.x;
				float num5 = x * right.z;
				float num6 = x * right.y;
				float num7 = num4 + num;
				float num8 = num5 + num3;
				float num9 = num6 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				Vector3 vector = default(Vector3);
				object obj = default(object);
				((Vector3*)(nint)vector)->x = (float)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rax_v5+8]");
				((Vector3*)(nint)vector)->z = 0f;
				return vector;
			}
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe Vector2 VelRelativeToLook()
	{
		//IL_005c: Expected O, but got Ref
		if ((object)rb != null)
		{
			Vector3 velocity = rb.velocity;
			if ((object)orientation != null)
			{
				object obj = default(object);
				Vector3 vector = orientation.InverseTransformVector((Vector3)(&obj));
				Vector2 result = default(Vector2);
				return result;
			}
		}
		return (Vector2)new NullReferenceException();
	}

	private unsafe void OnCollisionEnter(Collision other)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected I4, but got Unknown
		//IL_0262: Invalid comparison between F4 and O
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_0237: Expected O, but got Ref
		//IL_0237: Expected O, but got Ref
		//IL_02ca: Invalid comparison between O and F4
		//IL_02ea: Invalid comparison between F4 and I4
		GameObject gameObject = other.gameObject;
		int layer = gameObject.layer;
		ContactPoint[] contacts = other.contacts;
		object obj = contacts + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		int num = layer & 0x1F;
		int num2 = 1 << num;
		object obj2 = default(object);
		int num3 = obj2 | num2;
		object obj3 = default(object);
		if ((nint)obj3 != num3)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		float num4 = maxSlopeAngle;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector))
		{
			return;
		}
		GameObject gameObject2 = other.gameObject;
		FrictionModifier component = gameObject2.GetComponent<FrictionModifier>();
		FrictionModifier.EFrictionSurface eFrictionSurface = ((!(component == null)) ? component.frictionSurface : FrictionModifier.EFrictionSurface.Normal);
		surface = eFrictionSurface;
		bool flag = grounded;
		object obj4 = default(object);
		Vector3 vector = (Vector3)obj4;
		Vector3 vector2 = Vector3.upVector;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
			float num5 = (float)Vector3.upVector - 1f;
			bool flag3 = num5 == 0f;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			bool flag6 = flag5 & flag4;
			onRamp = flag6;
			GameObject gameObject3 = other.gameObject;
			groundedObject = gameObject3;
			StartGrounded();
			normalVector = (Vector3)obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rax_v13+8]");
			_ = 0;
			if (_003CcrouchState_003Ek__BackingField > CrouchState.None && onRamp)
			{
				float speedHorizontal = GetSpeedHorizontal();
				if (speedHorizontal > slideThresholdSpeed && _003CcrouchState_003Ek__BackingField != CrouchState.Sliding)
				{
					StartSlide();
				}
			}
			justLanded = true;
			justLandedCounter = 0;
			landedAtTime = MyTime.time;
			vector = Vector3.upVector;
			vector2 = (Vector3)obj4;
		}
		ContactPoint[] contacts2 = other.contacts;
		object obj5 = contacts2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
		ContactPoint[] contacts3 = other.contacts;
		object obj6 = contacts3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
		CheckLanding((Vector3)(&vector), (Vector3)(&vector2));
		fallSpeed = 0f;
	}

	private void CheckLanding(Vector3 point, Vector3 normal)
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_001b: Invalid comparison between F4 and O
		//IL_013b: Invalid comparison between F4 and O
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected F4, but got Unknown
		//IL_009c: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+154]");
		object obj = 0 * normal.y;
		object obj2 = lastVelocity * normal.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+158]");
		object obj3 = 0 * normal.z;
		object obj4 = obj + obj2;
		float num = leftGroundAtTime + 0.55f;
		if (num > MyTime.time)
		{
			return;
		}
		object obj5 = obj3 + obj4;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-3f)) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			Action<float> a_Landed = A_Landed;
			if (A_Landed != null)
			{
				float num2 = fallSpeed;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
				float num3 = num2 & 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v168 @ rax_v11 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
			Action<Vector3> cameraBob = CameraBob;
			if (CameraBob != null)
			{
				float num3 = fallSpeed;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v188 @ rax_v14 (System.Action`1<UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
				object obj6 = 0;
			}
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)(-12f)) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			Action<Vector3, float> a_LandedSmoke = A_LandedSmoke;
			if (A_LandedSmoke != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v113 @ r8_v3 (System.Action`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private unsafe void CheckStuck()
	{
		//IL_00db: Expected O, but got Ref
		Vector3 velocity = rb.velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		if (!(velocity.x > 0.5f) && !IsTouchingGround() && !rb.isKinematic && rb.useGravity)
		{
			if ((stuckTimer += MyTime.fixedDeltaTime) > stuckTimerMax)
			{
				stuckTimer = 0f;
				float mass = rb.mass;
				float num = default(float);
				rb.AddForce((Vector3)(&num));
			}
		}
		else
		{
			stuckTimer = 0f;
		}
	}

	private void CheckFallDamageBug()
	{
		//IL_010a: Expected O, but got I4
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_0145: Expected O, but got I4
		if (-25f > lastFallSpeed && fallSpeed > -5f)
		{
			bool flag = _003CcrouchState_003Ek__BackingField == CrouchState.None;
			bool flag2 = !flag;
			object obj = flag2 & onRamp;
			float num = MyTime.time - lastTouchedWallTime;
			object obj2 = obj ^ 1;
			bool flag3 = !(0.1f > num);
			object obj3 = 0;
			if (!flag3)
			{
				obj3 = obj2;
			}
			if (obj3 != null)
			{
				MyPlayer instance = MyPlayer.Instance;
				PlayerInventory inventory = instance.inventory;
				PlayerHealth playerHealth = inventory.playerHealth;
				float num2 = MyTime.time - playerHealth.fallDamageTakenAtTime;
				if (num2 > 0.15f)
				{
					MyStats.AddValue(EMyStat.wallhugs, 1f);
				}
			}
		}
		lastFallSpeed = fallSpeed;
	}

	public bool CanTakeFallDamage(Vector3 normal)
	{
		//IL_0010: Invalid comparison between O and F4
		//IL_0032: Invalid comparison between F4 and O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		if (_003CcrouchState_003Ek__BackingField > CrouchState.None && System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)minBreakFallAngle))
		{
			float num = maxBreakFallAngle;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector))
			{
				return false;
			}
		}
		return !surfing;
	}

	private unsafe void OnCollisionStay(Collision other)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected I4, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00d2: Expected O, but got I4
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_0121: Expected O, but got I
		//IL_067e: Expected I, but got O
		//IL_068c: Expected O, but got Ref
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_0155: Invalid comparison between F4 and O
		//IL_053b: Expected O, but got Ref
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_03eb: Expected O, but got I4
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected O, but got Unknown
		//IL_017f: Expected O, but got Ref
		//IL_044e: Invalid comparison between I and F4
		//IL_028b: Expected O, but got Ref
		//IL_02ab: Expected O, but got I4
		//IL_01a6: Expected O, but got Ref
		//IL_0274: Expected O, but got I4
		//IL_0597: Expected I, but got O
		//IL_05a5: Expected O, but got Ref
		//IL_05b8: Expected O, but got Ref
		//IL_0601: Invalid comparison between O and F4
		//IL_0621: Invalid comparison between F4 and I4
		//IL_03b0: Expected O, but got I4
		//IL_01d2: Expected O, but got Ref
		//IL_01f1: Expected O, but got I
		//IL_0209: Expected O, but got I
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_02fb: Invalid comparison between O and F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = other.gameObject;
		int layer = gameObject.layer;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		int num = layer & 0x1F;
		int num2 = 1 << num;
		object obj3 = default(object);
		int num3 = obj3 | num2;
		object obj4 = default(object);
		if ((nint)obj4 != num3)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		Vector3 vector = default(Vector3);
		Vector3 vector2 = default(Vector3);
		Vector3 vector3 = default(Vector3);
		object obj14 = default(object);
		object obj16 = default(object);
		Vector3 vector4 = default(Vector3);
		object obj17 = default(object);
		Vector3 vector6 = default(Vector3);
		while (true)
		{
			int contactCount = other.contactCount;
			if ((flag2 ? 1 : 0) >= contactCount)
			{
				break;
			}
			ContactPoint[] contacts = other.contacts;
			object obj5 = contacts + 32;
			object obj6 = (flag ? 1 : 0) * 2;
			object obj7 = flag + obj6;
			object obj8 = obj7 << 4;
			object obj9 = obj8 + obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v16+4]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj10 = num4 & 0;
			nint num5 = (nint)typeof(Vector3);
			object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ rax_v19 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num6 = 0;
			_ = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rax_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
			float num7 = 90f - (float)Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj12 = num7 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12))
			{
				lastTouchedWallTime = MyTime.time;
			}
			Vector3 vector5;
			object obj18;
			if (!IsFloor((Vector3)(&vector)))
			{
				if (CanWallClimb((Vector3)(&vector2), other))
				{
					bool flag3 = IsWall((Vector3)(&vector3));
					object obj13 = obj14;
					object obj15 = obj16;
					if (!flag3)
					{
						bool flag4 = IsSurf((Vector3)(&vector4));
						bool flag5 = !flag4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v16+8]");
						obj13 = 0;
						obj15 = obj10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v16+8]");
						obj14 = 0;
						obj16 = obj10;
						vector3 = (Vector3)obj17;
						if (flag5)
						{
							goto IL_0281;
						}
					}
					WallClimbing();
					flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
					vector5 = (Vector3)obj17;
					vector = (Vector3)obj17;
					obj14 = obj13;
					obj16 = obj15;
					vector3 = (Vector3)obj17;
					vector2 = (Vector3)obj17;
					obj18 = 0;
					flag2 = flag;
					continue;
				}
				goto IL_0281;
			}
			ContactPoint[] contacts2 = other.contacts;
			object obj19 = contacts2 + 32;
			object obj20 = (flag ? 1 : 0) * 2;
			object obj21 = flag + obj20;
			object obj22 = obj21 << 4;
			object obj23 = obj22 + obj19;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ rax_v30+4]");
			if (!(0f > position.y))
			{
				nint num8 = (nint)typeof(Vector3);
				object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
				object obj25 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v16+8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ rax_v34 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num9 = 0;
				_ = Vector3.upVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ rax_v35 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
				bool flag6 = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
				float num10 = (float)Vector3.upVector - 1f;
				bool flag7 = num10 == 0f;
				bool flag8 = !flag6;
				bool flag9 = !flag7;
				bool flag10 = flag9 & flag8;
				onRamp = flag10;
				GameObject gameObject2 = other.gameObject;
				groundedObject = gameObject2;
				StartGrounded();
				normalVector = (Vector3)obj17;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v16+8]");
				_ = 0;
				if (_003CcrouchState_003Ek__BackingField > CrouchState.None)
				{
					float speedHorizontal = GetSpeedHorizontal();
					if (speedHorizontal > slideThresholdSpeed && _003CcrouchState_003Ek__BackingField != CrouchState.Sliding)
					{
						StartSlide();
					}
				}
			}
			goto IL_0500;
			IL_0500:
			flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
			vector5 = (Vector3)obj17;
			vector = (Vector3)obj17;
			flag2 = flag;
			continue;
			IL_0281:
			bool flag11 = IsSurf((Vector3)(&vector6));
			bool flag12 = !flag11;
			vector2 = (Vector3)obj17;
			obj18 = 0;
			if (!flag12)
			{
				if (_003CcrouchState_003Ek__BackingField > CrouchState.None)
				{
					float num11 = fallSpeed;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
					object obj26 = num11 & 0;
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj26) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)4f) && _003CcrouchState_003Ek__BackingField != CrouchState.Sliding)
					{
						StartSlide();
					}
				}
				flag = (byte)((flag ? 1u : 0u) + 1u) != 0;
				normalVector = (Vector3)obj17;
				surfing = true;
				cancellingSurf = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rax_v16+8]");
				_ = 0;
				surfCancel = 0;
				vector5 = (Vector3)obj17;
				vector = (Vector3)obj17;
				vector6 = (Vector3)obj17;
				vector2 = (Vector3)obj17;
				obj18 = 0;
				flag2 = flag;
				continue;
			}
			goto IL_0500;
		}
	}

	private void StartGrounded()
	{
		grounded = true;
		groundCancel = 0;
		cancellingGrounded = false;
		ResetAerialJumps();
		Action<bool> a_Grounded = A_Grounded;
		if (A_Grounded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v31 @ rax_v4 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private void UpdateCooldowns()
	{
		if (!readyToJump && ++resetJumpCounter >= jumpCounterResetTime)
		{
			readyToJump = true;
		}
		if (1f > pushMultiplier)
		{
			float num = pushResetSpeed * 0.02f;
			if ((pushMultiplier = num + pushMultiplier) > 1f)
			{
				pushMultiplier = 1f;
			}
		}
		if (pushed && !(++resetPushCounter < resetPushCounterValue))
		{
			pushed = false;
		}
		if ((onLadder || onLadderLastFrame) && ++ladderRefreshCount >= ladderRefreshCountMax)
		{
			onLadder = false;
			onLadderLastFrame = false;
		}
		if (!readyToSlide && ++slideCooldownCounter >= slideCooldownCounterMax)
		{
			readyToSlide = true;
		}
		if (!readyToCrouch && ++crouchCooldownCounter >= crouchCooldownCounterMax)
		{
			readyToCrouch = true;
		}
		if (justLanded && ++justLandedCounter >= justLandedCounterMax)
		{
			justLanded = false;
		}
		if (justUncrouched && ++justUncrouchedCounter >= justUncrouchedCounterMax)
		{
			justUncrouched = false;
		}
		if (_003CisTouchingTornado_003Ek__BackingField)
		{
			float num2 = lastTouchedTornadoTime + 3f;
			if (!(MyTime.time < num2))
			{
				_003CisTouchingTornado_003Ek__BackingField = false;
			}
		}
		if (cancellingGrounded)
		{
			if (++groundCancel > surfaceDelay)
			{
				StopGrounded();
			}
		}
		else
		{
			cancellingGrounded = true;
		}
		if (climbCancel < climbCancelTicks)
		{
			int num3 = climbCancel + 1;
			climbCancel = num3;
		}
		if (cancellingSurf)
		{
			if (++surfCancel > surfaceDelay)
			{
				surfing = false;
			}
		}
		else
		{
			cancellingSurf = true;
			surfCancel = 1;
		}
	}

	private void CheckInput()
	{
		//IL_0296: Invalid comparison between O and F4
		if (!crouching)
		{
			goto IL_0190;
		}
		if (_003CcrouchState_003Ek__BackingField != CrouchState.None)
		{
			if (!crouching)
			{
				goto IL_0190;
			}
		}
		else
		{
			bool flag = UseLimitedMovement();
			if (!flag && _003CcrouchState_003Ek__BackingField == CrouchState.None && readyToCrouch != flag)
			{
				readyToCrouch = flag;
				crouchCooldownCounter = 0;
				_003CcrouchState_003Ek__BackingField = CrouchState.Crouching;
				Action<PlayerMovement> a_Crouched = A_Crouched;
				if (A_Crouched != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v327 @ rax_v10 (System.Action`1<PlayerMovement>)+18] (should have been resolved before IL gen)");
				}
				Vector3 velocity = rb.velocity;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
				if (!(velocity.x > slideThresholdSpeed))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
					if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)slideAngle))
					{
						goto IL_020f;
					}
				}
				if (grounded || surfing)
				{
					StartSlide();
				}
			}
		}
		goto IL_020f;
		IL_0190:
		if (_003CcrouchState_003Ek__BackingField != CrouchState.None && CanStopCrouching())
		{
			if (_003CcrouchState_003Ek__BackingField == CrouchState.Sliding)
			{
				readyToSlide = false;
				slideCooldownCounter = 0;
			}
			_003CcrouchState_003Ek__BackingField = CrouchState.None;
			justUncrouched = true;
			justUncrouchedCounter = 0;
		}
		goto IL_020f;
		IL_020f:
		float num = (currentMaxSpeed = movementValues.GetMaxSpeed());
		if (_003CcrouchState_003Ek__BackingField == CrouchState.Crouching)
		{
			float num2 = num * 0.5f;
			currentMaxSpeed = num2;
		}
	}

	private void StartCrouch()
	{
		//IL_0157: Invalid comparison between O and F4
		bool flag = UseLimitedMovement();
		if (flag || _003CcrouchState_003Ek__BackingField != CrouchState.None || readyToCrouch == flag)
		{
			return;
		}
		readyToCrouch = flag;
		_003CcrouchState_003Ek__BackingField = CrouchState.Crouching;
		crouchCooldownCounter = 0;
		Action<PlayerMovement> a_Crouched = A_Crouched;
		if (A_Crouched != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v198 @ rax_v5 (System.Action`1<PlayerMovement>)+18] (should have been resolved before IL gen)");
		}
		Vector3 velocity = rb.velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		if (!(velocity.x > slideThresholdSpeed))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
			if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)slideAngle))
			{
				return;
			}
		}
		if (grounded || surfing)
		{
			StartSlide();
		}
	}

	private void StopCrouch()
	{
		if (CanStopCrouching())
		{
			if (_003CcrouchState_003Ek__BackingField == CrouchState.Sliding)
			{
				readyToSlide = false;
				slideCooldownCounter = 0;
			}
			_003CcrouchState_003Ek__BackingField = CrouchState.None;
			justUncrouched = true;
			justUncrouchedCounter = 0;
		}
	}

	private unsafe bool CanStopCrouching()
	{
		//IL_0008: Expected O, but got Ref
		//IL_006f: Expected O, but got I
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_004b: Expected O, but got I
		//IL_02f6: Expected I, but got O
		//IL_0304: Expected O, but got Ref
		//IL_0318: Expected O, but got Ref
		//IL_00eb: Expected O, but got Ref
		//IL_013c: Expected O, but got I4
		//IL_0145: Expected O, but got I4
		//IL_02c2: Expected I4, but got O
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_01a1: Expected O, but got Ref
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_0212: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		Vector3 position;
		object obj3;
		if (_003CcrouchState_003Ek__BackingField != CrouchState.None)
		{
			position = rb.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1A0]");
			obj3 = 0;
		}
		else
		{
			position = rb.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+194]");
			obj3 = 0;
		}
		object obj4 = obj3 + position.z;
		nint num = (nint)typeof(Vector3);
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
		_ = 0;
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_ = Vector3.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v10 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rax_v12+8]");
		_ = 0;
		Bounds bounds = playerCollider.bounds;
		object obj7 = bounds.m_Extents + bounds.m_Extents;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+190]");
		float num3 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+19C]");
		float maxDistance = num3 - 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num4 = (float)obj7 * 0.5f;
		Ray ray = (Ray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		float radius = num4 * 0.9f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-39]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-29]");
		_ = 0;
		int layerMask = default(int);
		RaycastHit[] array = Physics.SphereCastAll(ray, radius, maxDistance, layerMask);
		object obj8 = 0;
		object obj9 = 0;
		while (true)
		{
			if ((nint)obj8 < array.Length)
			{
				if ((nint)obj9 >= array.Length)
				{
					break;
				}
				object obj10 = obj9 * 44;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rcx_v13+20+v119 @ rax_v17 (UnityEngine.RaycastHit[])]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rcx_v13+30+v119 @ rax_v17 (UnityEngine.RaycastHit[])]");
				_ = 0;
				RaycastHit raycastHit = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v412 @ rcx_v13+3C+v119 @ rax_v17 (UnityEngine.RaycastHit[])]");
				_ = 0;
				Transform transform = ((RaycastHit*)raycastHit)->transform;
				Transform root = transform.root;
				GameObject gameObject = root.gameObject;
				if (!gameObject.CompareTag("Water"))
				{
					RaycastHit raycastHit2 = (RaycastHit)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					Transform transform2 = ((RaycastHit*)raycastHit2)->transform;
					if (!transform2.CompareTag("MainCamera"))
					{
						return false;
					}
				}
				obj9++;
				obj8 = obj9;
				continue;
			}
			return true;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	public bool IsCrouching()
	{
		bool flag = _003CcrouchState_003Ek__BackingField < CrouchState.None;
		bool flag2 = _003CcrouchState_003Ek__BackingField == CrouchState.None;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private bool UseLimitedMovement()
	{
		//IL_00c4: Expected I4, but got O
		//IL_00a2: Expected O, but got I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager.config;
			if (saveManager.config != null)
			{
				CFGameSettings cfGameSettings = config.cfGameSettings;
				if (config.cfGameSettings != null)
				{
					object obj = cfGameSettings.pege_mode - 1;
					return obj == null;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void StartSlide()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0053: Invalid comparison between I4 and F4
		//IL_009e: Expected F4, but got I4
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Expected F4, but got Unknown
		//IL_00c0: Invalid comparison between F4 and I4
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected O, but got Unknown
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected O, but got Unknown
		//IL_0564: Expected I, but got O
		//IL_05b9: Expected F4, but got I
		//IL_0137: Expected O, but got F4
		//IL_0140: Invalid comparison between F4 and O
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected F4, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_0166: Expected O, but got F4
		//IL_016f: Invalid comparison between F4 and O
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_03ac: Expected O, but got I
		//IL_03c9: Expected O, but got I
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Expected O, but got Unknown
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Expected O, but got Unknown
		//IL_01ef: Expected F4, but got O
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		bool flag = UseLimitedMovement();
		if (flag || readyToSlide == flag)
		{
			return;
		}
		float num = fallSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num & 0;
		float num2 = (float)obj - 10f;
		if (!(0f > num2))
		{
			if (num2 > 2.1474836E+09f)
			{
				num2 = 2.1474836E+09f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = num2 * 1000f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		float num4 = num3 & 0;
		if (rb.velocity.y > 0f)
		{
			num4 *= 0.5f;
		}
		object obj3 = default(object);
		object obj2 = obj3 - 96;
		object obj4 = obj3 - 80;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+138]");
		_ = 0;
		nint num5 = (nint)typeof(Vector3);
		_ = normalVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		_ = Vector3.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rax_v10 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		bool flag2 = !justLanded;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		float num7 = 0f;
		float num8;
		float num9;
		if (!flag2)
		{
			Vector3 upVector = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			num8 = upVector & 0;
			bool flag3 = 2f > num8;
			num9 = 2f;
			if (flag3)
			{
				goto IL_0464;
			}
		}
		object obj5 = x & num7;
		float num10;
		float z;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
		{
			object obj6 = y & num7;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
			{
				Vector3 velocity = rb.velocity;
				_ = 0;
				object obj7 = obj3 - 96;
				object obj8 = obj3 - 80;
				z = velocity.z;
				_ = velocity.x;
				_ = velocity.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				object obj9 = default(object);
				num10 = (float)obj9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v495 @ rax_v27+8]");
				_ = 0;
				goto IL_04f8;
			}
		}
		Vector3 right = orientation.right;
		float num11 = x * right.x;
		float num12 = x * right.y;
		float num13 = x * right.z;
		Vector3 forward = orientation.forward;
		object obj10 = obj3 - 96;
		float num14 = y * forward.x;
		object obj11 = obj3 - 80;
		float num15 = y * forward.z;
		float num16 = y * forward.y;
		float num17 = num14 + num11;
		num7 = num15 + num13;
		float num18 = num16 + num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Vector3 velocity2 = rb.velocity;
		_ = 0;
		object obj12 = obj3 - 96;
		object obj13 = obj3 - 80;
		num10 = velocity2.x;
		z = velocity2.z;
		_ = velocity2.x;
		_ = velocity2.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj15 = default(object);
		object obj16 = default(object);
		object obj14 = obj15 + obj16;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v23+4]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v25+4]");
		object obj17 = num19 + 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rax_v23+8]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ rax_v25+8]");
		object obj18 = num20 + 0;
		goto IL_04f8;
		IL_04f8:
		object obj19 = obj3 - 96;
		object obj20 = obj3 - 80;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		PlayerMovementValues playerMovementValues = movementValues;
		float num21 = num4 + playerMovementValues._003CslideForce_003Ek__BackingField;
		object obj21 = default(object);
		num8 = num21 * (float)obj21;
		float num22 = num21;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v19+4]");
		num9 = num22 * 0f;
		float num23 = num21;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rax_v19+8]");
		float num24 = num23 * 0f;
		Vector3 force = (Vector3)(obj3 - 96);
		rb.AddForce(force);
		goto IL_0464;
		IL_0464:
		_003CcrouchState_003Ek__BackingField = CrouchState.Sliding;
		readyToSlide = false;
		Action<PlayerMovement> a_SlideStart = A_SlideStart;
		if (A_SlideStart != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v456 @ rax_v15 (System.Action`1<PlayerMovement>)+18] (should have been resolved before IL gen)");
		}
	}

	private void StopSlide()
	{
		readyToSlide = false;
		slideCooldownCounter = 0;
	}

	public bool IsSliding()
	{
		//IL_0010: Expected O, but got I4
		object obj = _003CcrouchState_003Ek__BackingField - 2;
		return obj == null;
	}

	public bool IsSlidingAnimation()
	{
		//IL_0020: Expected O, but got I4
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected I4, but got Unknown
		if (_003CcrouchState_003Ek__BackingField > CrouchState.None)
		{
			float num = jumpedTime + jumpAnimationCooldownSlide;
			if (MyTime.time > num)
			{
				object obj = resetJumpCounter - 4;
				int num2 = resetJumpCounter ^ 4;
				int num3 = resetJumpCounter ^ obj;
				int num4 = num2 & num3;
				bool flag = num4 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
		}
		return false;
	}

	private void UpdateCrouchState()
	{
		if (_003CcrouchState_003Ek__BackingField == CrouchState.None)
		{
			return;
		}
		Vector3 velocity = rb.velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		if (slideThresholdSpeed > velocity.x)
		{
			if (_003CcrouchState_003Ek__BackingField == CrouchState.Sliding)
			{
				readyToSlide = false;
				slideCooldownCounter = 0;
			}
			_003CcrouchState_003Ek__BackingField = CrouchState.Crouching;
		}
	}

	private unsafe void WaterMovement()
	{
		//IL_0046: Expected O, but got Ref
		//IL_0088: Expected O, but got Ref
		//IL_00ca: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1D2]");
		if ((nint)0 != 0)
		{
		}
		float mass = rb.mass;
		Vector3 gravity = Physics.gravity;
		float num = default(float);
		rb.AddForce((Vector3)(&num));
		Transform transform = playerCam.transform;
		Vector3 forward = transform.forward;
		rb.AddForce((Vector3)(&num));
		Transform transform2 = orientation.transform;
		Vector3 right = transform2.right;
		rb.AddForce((Vector3)(&num));
	}

	private bool IsUnderwater()
	{
		return isUnderwater;
	}

	private unsafe void RampMovement(Vector2 mag)
	{
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_026b: Invalid comparison between F4 and O
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_02a2: Invalid comparison between F4 and O
		//IL_012b: Invalid comparison between F4 and I4
		//IL_015c: Invalid comparison between I4 and F4
		//IL_0208: Expected O, but got Ref
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_01a2: Invalid comparison between F4 and O
		//IL_01c7: Expected O, but got Ref
		if (grounded && onRamp && !surfing && !crouching && !jumping && resetJumpCounter >= jumpCounterResetTime)
		{
			float num = x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj = num & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				float num2 = y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
				object obj2 = num2 & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) && !pushed && HasFooting())
				{
					rb.useGravity = false;
					Vector3 velocity = rb.velocity;
					Vector3 velocity2;
					object obj4 = default(object);
					Rigidbody rigidbody;
					if (!(velocity.y > 0f))
					{
						if (0f < rb.velocity.y)
						{
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331210");
						float num3 = velocity.y;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
						object obj3 = num3 & 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
						{
							return;
						}
						velocity2 = (Vector3)(&obj4);
						rigidbody = rb;
					}
					else
					{
						Vector3 velocity3 = rb.velocity;
						Vector3 velocity4 = rb.velocity;
						velocity2 = (Vector3)(&obj4);
						rigidbody = rb;
					}
					rigidbody.velocity = velocity2;
					return;
				}
			}
		}
		rb.useGravity = true;
	}

	private bool TryLadderMovement()
	{
		//IL_01a3: Expected I4, but got O
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_014b: Invalid comparison between F4 and O
		if (!onLadder || !(ladder != null))
		{
			goto IL_01c2;
		}
		if (!IsTouchingGround())
		{
			goto IL_0172;
		}
		if ((object)feet != null)
		{
			Transform transform = feet.transform;
			if ((object)transform != null)
			{
				Vector3 position = transform.position;
				if ((object)ladder != null)
				{
					Vector3 position2 = ladder.position;
					if (position.y > position2.y)
					{
						if ((object)rb == null)
						{
							goto IL_0195;
						}
						float num = rb.velocity.y;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
						object obj = num & 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
						{
							onLadderLastFrame = true;
							goto IL_01c2;
						}
					}
					goto IL_0172;
				}
			}
		}
		goto IL_0195;
		IL_0172:
		LadderMovementTick(x, y);
		onLadderLastFrame = false;
		return true;
		IL_0195:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_01c2:
		return false;
	}

	public void RefreshLadder(Transform ladder)
	{
		//IL_002c: Expected O, but got F4
		//IL_0135: Invalid comparison between F4 and O
		onLadder = true;
		Vector3 forward = ladder.forward;
		ladderNormal = (Vector3)forward.x;
		_ = forward.z;
		this.ladder = ladder;
		Vector3 right = orientation.right;
		float num = x * right.z;
		Vector3 forward2 = orientation.forward;
		float num2 = y * forward2.z;
		float num3 = num2 + num;
		Vector3 vector = default(Vector3);
		ladderWishDir = vector;
		Vector3 position = feet.position;
		if (ladder.position.y > position.y && grounded)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
			Vector3 vector2 = ladderWishDir;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)50f) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector2))
			{
				goto IL_0178;
			}
		}
		if (resetJumpCounter >= 2)
		{
			ladderRefreshCount = 0;
			return;
		}
		goto IL_0178;
		IL_0178:
		onLadder = false;
		onLadderLastFrame = false;
	}

	private void StopLadder()
	{
		onLadder = false;
		onLadderLastFrame = false;
	}

	private unsafe void LadderMovementTick(float x, float y)
	{
		//IL_00a5: Expected O, but got Ref
		//IL_00bb: Expected O, but got Ref
		//IL_00bb: Expected O, but got Ref
		//IL_00ce: Expected O, but got F4
		//IL_0125: Expected O, but got Ref
		//IL_0159: Invalid comparison between F4 and O
		float num = x * orientation.right.z;
		float num2 = y * orientation.forward.z;
		float num3 = num2 + num;
		Vector3 vector = default(Vector3);
		ladderWishDir = vector;
		Vector3 right = ladder.right;
		float num4 = default(float);
		Quaternion quaternion2 = Quaternion.AngleAxis(90f, (Vector3)(&num4));
		object obj = default(object);
		Vector3 vector2 = (Quaternion)(&obj) * (Vector3)(&num4);
		ladderWallVec = (Vector3)vector2.x;
		_ = vector2.z;
		float num5 = ((_003CcrouchState_003Ek__BackingField <= CrouchState.None) ? 1f : 0.5f);
		float num6 = ladderSpeed * (float)ladderWallVec;
		float num7 = ladderSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+D4]");
		float num8 = num7 * 0f;
		float num9 = num6 * num5;
		float num10 = num8 * num5;
		rb.velocity = (Vector3)(&num4);
		if (grounded)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
			Vector3 vector3 = ladderWishDir;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)50f) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector3))
			{
				onLadder = false;
			}
		}
	}

	public unsafe void JumpPad(JumpPad pad)
	{
		//IL_00ab: Invalid comparison between I4 and F4
		//IL_0096: Expected O, but got Ref
		pushed = true;
		resetPushCounter = 0f;
		rb.useGravity = true;
		Vector3 velocity = rb.velocity;
		if (pad.direction != null)
		{
			Vector3 forward = pad.direction.forward;
		}
		while (0f < velocity.y)
		{
		}
		float num = default(float);
		rb.velocity = (Vector3)(&num);
	}

	public unsafe void RocketJump(Vector3 pushForce)
	{
		//IL_003c: Expected O, but got Ref
		float num = rb.velocity.z + pushForce.z;
		object obj = default(object);
		rb.velocity = (Vector3)(&obj);
		pushed = true;
		resetPushCounter = 0f;
		rb.useGravity = true;
		pushMultiplier = 0f;
		Action<float> shake = Shake;
		if (Shake != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v140 @ rax_v8 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
	}

	public unsafe void PushPlayer(Vector3 pushForce)
	{
		//IL_003c: Expected O, but got Ref
		float num = rb.velocity.z + pushForce.z;
		object obj = default(object);
		rb.velocity = (Vector3)(&obj);
		pushed = true;
		resetPushCounter = 0f;
		rb.useGravity = true;
		pushMultiplier = 0f;
		Action<float> shake = Shake;
		if (Shake != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v140 @ rax_v8 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
	}

	public void PushPlayerButKeepMovement()
	{
		pushed = true;
		resetPushCounter = 0f;
		rb.useGravity = true;
	}

	public unsafe void BouncePlayer(Vector3 pushForce)
	{
		//IL_0015: Expected O, but got Ref
		//IL_0051: Expected O, but got Ref
		Vector3 vector = default(Vector3);
		rb.velocity = (Vector3)(&vector);
		float num = rb.velocity.z + pushForce.z;
		rb.velocity = (Vector3)(&vector);
		rb.useGravity = true;
		Action<float> shake = Shake;
		if (Shake != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ rax_v13 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
	}

	public bool RecentlyJumped()
	{
		//IL_0010: Expected O, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected I4, but got Unknown
		object obj = resetJumpCounter - 4;
		int num = resetJumpCounter ^ 4;
		int num2 = resetJumpCounter ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 != flag;
	}

	public unsafe bool IsTouchingGround()
	{
		//IL_00c0: Expected I4, but got O
		//IL_005e: Expected O, but got Ref
		//IL_00a9: Expected O, but got Ref
		float num = playerHeight * 0.5f;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			float num2 = _003CplayerRadius_003Ek__BackingField + num;
			Vector3 position = transform.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			float maxDistance = num2 + 0.1f;
			float num3 = default(float);
			int layerMask = default(int);
			if (Physics.SphereCast((Ray)(&num3), _003CplayerRadius_003Ek__BackingField, out var _, maxDistance, layerMask))
			{
				return true;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			int layerMask2 = default(int);
			return Physics.Raycast((Ray)(&num3), num2, layerMask2);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe bool HasFooting()
	{
		//IL_0046: Expected I4, but got O
		//IL_002f: Expected O, but got Ref
		//IL_002f: Expected O, but got Ref
		if ((object)feet != null)
		{
			Vector3 position = feet.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			object obj = default(object);
			object obj2 = default(object);
			int layerMask = default(int);
			return Physics.Raycast((Vector3)(&obj), (Vector3)(&obj2), 1f, layerMask);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool AreFeetTouchingFloor()
	{
		//IL_0046: Expected I4, but got O
		//IL_002f: Expected O, but got Ref
		//IL_002f: Expected O, but got Ref
		if ((object)feet != null)
		{
			Vector3 position = feet.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			object obj = default(object);
			object obj2 = default(object);
			int layerMask = default(int);
			return Physics.Raycast((Vector3)(&obj), (Vector3)(&obj2), 0.1f, layerMask);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void SetKinematic(bool b)
	{
		//IL_002d: Expected O, but got Ref
		if (b)
		{
			object obj = default(object);
			rb.velocity = (Vector3)(&obj);
		}
		bool useGravity = (byte)((b ? 1u : 0u) ^ 1u) != 0;
		rb.useGravity = useGravity;
	}

	private bool IsBreakingFall(Vector3 normal)
	{
		//IL_0010: Invalid comparison between O and F4
		//IL_0032: Invalid comparison between F4 and O
		//IL_0053: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		if (_003CcrouchState_003Ek__BackingField > CrouchState.None && System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)minBreakFallAngle))
		{
			float num = maxBreakFallAngle;
			bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector);
			float num2 = maxBreakFallAngle - (float)Vector3.upVector;
			bool flag2 = num2 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		return false;
	}

	private bool CanJump(bool ignoreAerialJumps = false)
	{
		if (UseLimitedMovement())
		{
			float num = landingJumpCooldownPegeMode + landedAtTime;
			if (num > MyTime.time)
			{
				goto IL_00d5;
			}
		}
		if (readyToJump && ((!ignoreAerialJumps && aerialJumps > 0) || grounded || IsGrinding() || climbCancel < climbCancelTicks || onLadder))
		{
			return true;
		}
		goto IL_00d5;
		IL_00d5:
		return false;
	}

	private void ResetAerialJumps()
	{
		//IL_0066: Expected I4, but got F8
		usedJumps = 0;
		if (PlayerStats.HasStats())
		{
			float stat = PlayerStats.GetStat(EStat.ExtraJumps);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
			double num = Math.Floor(0.0);
			aerialJumps = (int)num;
		}
		else
		{
			aerialJumps = 0;
		}
	}

	public bool CanBhopJump()
	{
		return CanJump(ignoreAerialJumps: true);
	}

	public unsafe void Jump()
	{
		//IL_0008: Expected O, but got Ref
		//IL_057f: Expected O, but got Ref
		//IL_05ac: Expected O, but got I4
		//IL_0643: Expected O, but got Ref
		//IL_0665: Expected O, but got I4
		//IL_0198: Invalid comparison between F4 and I4
		//IL_0924: Expected O, but got Ref
		//IL_095b: Expected O, but got F4
		//IL_0975: Invalid comparison between O and F4
		//IL_037e: Invalid comparison between I4 and F4
		//IL_0a2c: Expected O, but got F4
		//IL_0a39: Invalid comparison between O and F4
		//IL_0997: Invalid comparison between F4 and I4
		//IL_09af: Expected O, but got I4
		//IL_06cd: Expected O, but got Ref
		//IL_0706: Unknown result type (might be due to invalid IL or missing references)
		//IL_070b: Expected F4, but got Unknown
		//IL_0ec9: Expected I, but got O
		//IL_0c5b: Expected I, but got O
		//IL_09e9: Invalid comparison between I4 and F4
		//IL_0a01: Expected O, but got I4
		//IL_0411: Expected O, but got Ref
		//IL_03d6: Expected O, but got Ref
		//IL_01cc: Expected O, but got Ref
		//IL_0a5b: Invalid comparison between F4 and I4
		//IL_0a73: Expected O, but got I4
		//IL_0867: Expected O, but got Ref
		//IL_07f2: Expected O, but got I
		//IL_080a: Expected O, but got I4
		//IL_0823: Expected O, but got I4
		//IL_0768: Invalid comparison between F4 and I4
		//IL_0777: Expected O, but got I4
		//IL_0cec: Expected I, but got O
		//IL_0d12: Expected F4, but got I
		//IL_0d22: Expected F4, but got I
		//IL_0d30: Expected O, but got Ref
		//IL_0d5d: Expected O, but got Ref
		//IL_0d6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d74: Expected O, but got Unknown
		//IL_0da5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0daa: Expected O, but got Unknown
		//IL_0aad: Invalid comparison between I4 and F4
		//IL_0ac5: Expected O, but got I4
		//IL_07b1: Invalid comparison between I4 and F4
		//IL_07c0: Expected O, but got I4
		//IL_04bb: Expected O, but got Ref
		//IL_04dd: Expected O, but got I4
		//IL_0207: Expected O, but got Ref
		//IL_0215: Expected O, but got Ref
		//IL_0262: Expected O, but got I
		//IL_028c: Expected O, but got I
		//IL_0fed: Expected O, but got Ref
		//IL_0ffb: Expected O, but got Ref
		//IL_0f5a: Expected O, but got Ref
		//IL_0bb1: Expected O, but got I4
		//IL_0e33: Expected I, but got O
		//IL_02de: Expected O, but got I4
		//IL_030e: Expected O, but got Ref
		//IL_0330: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!CanJump())
		{
			return;
		}
		rb.useGravity = true;
		int num = usedJumps + 1;
		usedJumps = num;
		bool flag = !grounded;
		readyToJump = false;
		resetJumpCounter = 0;
		if ((flag || surfing) && rail == null && climbCancel >= climbCancelTicks)
		{
			int num2 = aerialJumps - 1;
			aerialJumps = num2;
		}
		float num3 = ((!isUnderwater) ? 1f : 1.4f);
		float stat = PlayerStats.GetStat(EStat.JumpHeight);
		float mass = rb.mass;
		float num4 = mass * stat;
		float num5 = num4 * num3;
		float num28;
		object obj16;
		float num34;
		float num29;
		if (!onLadder)
		{
			if (!onRamp || IsGrinding())
			{
				if (rail != null)
				{
					StopRail();
				}
				if (0f > rb.velocity.y)
				{
					_ = rb.velocity.x;
					_ = 0;
					Vector3 velocity = rb.velocity;
					Vector3 velocity2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					_ = velocity.z;
					rb.velocity = velocity2;
				}
				nint num6 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rax_v53 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num7 = 0;
				float num8 = num5 * (float)Vector3.upVector;
				float num9 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdx_v42 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				float num10 = num9 * 0f;
				float num11 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rdx_v42 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float num12 = num11 * 0f;
				float num13 = num8 * 1.5f;
				float num14 = num10 * 1.5f;
				float num15 = num12 * 1.5f;
				Vector3 force = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				rb.AddForce(force, ForceMode.Impulse);
				goto IL_042f;
			}
			if (num5 > 0f)
			{
				nint num16 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rax_v63 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num17 = 0;
				float num18 = num5 * (float)Vector3.upVector;
				float num19 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdx_v48 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				float num20 = num19 * 0f;
				float num21 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rdx_v48 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float num22 = num21 * 0f;
				float num23 = num18 * 1.5f;
				float num24 = num20 * 1.5f;
				float num25 = num22 * 1.5f;
				Vector3 force2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				rb.AddForce(force2, ForceMode.Impulse);
				nint num26 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1029 @ rax_v66 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num27 = 0;
				_ = Vector3.rightVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+134]");
				num28 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+138]");
				num29 = 0f;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1030 @ rcx_v60 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
				float num30 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+134]");
				float num31 = num30 * 0f;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1030 @ rcx_v60 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
				object obj5 = 0 * normalVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
				float num32 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+138]");
				float num33 = num32 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-25]");
				object obj6 = 0 * normalVector;
				num34 = num33 - num31;
				float num35 = (float)Vector3.rightVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+138]");
				float num36 = num35 * 0f;
				float num37 = (float)Vector3.rightVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+134]");
				float num38 = num37 * 0f;
				float num39 = (float)obj5 - num36;
				float num40 = num38 - (float)obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				Vector3 velocity3 = rb.velocity;
				object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				mass = velocity3.x;
				_ = velocity3.x;
				_ = velocity3.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v67+4]");
				nint num41 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rax_v70+4]");
				object obj9 = num41 * 0;
				object obj11 = default(object);
				object obj12 = default(object);
				object obj10 = obj11 * obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v67+8]");
				nint num42 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rax_v70+8]");
				object obj13 = num42 * 0;
				object obj14 = obj9 + obj10;
				object obj15 = obj14 + obj13;
				if ((nint)obj15 <= 0)
				{
					bool flag2 = 0 <= (nint)obj15;
					obj16 = 0;
					if (!flag2)
					{
						goto IL_042f;
					}
				}
				else
				{
					nint num43 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rax_v72 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num44 = 0;
					float num45 = num5 * (float)Vector3.upVector;
					float num46 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdx_v53 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
					float num47 = num46 * 0f;
					float num48 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rdx_v53 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num49 = num48 * 0f;
					num34 = num45 * 0.25f;
					num29 = num47 * 0.25f;
					num28 = num49 * 0.25f;
					Vector3 force3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					rb.AddForce(force3, ForceMode.Impulse);
					obj16 = 0;
					mass = 0.25f;
				}
			}
		}
		else
		{
			float num50 = num5 * (float)ladderNormal;
			float num51 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+A4]");
			float num52 = num51 * 0f;
			float num53 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+A8]");
			float num54 = num53 * 0f;
			mass = num50 + num50;
			num34 = num52 + num52;
			num29 = num54 + num54;
			Vector3 force4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			rb.AddForce(force4, ForceMode.Impulse);
			onLadder = false;
			obj16 = 0;
		}
		goto IL_0c2a;
		IL_0f4c:
		Vector3 velocity4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		Rigidbody rigidbody;
		rigidbody.velocity = velocity4;
		object obj17;
		obj16 = obj17;
		goto IL_0f9d;
		IL_042f:
		float num55 = num5 * (float)normalVector;
		float num56 = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+134]");
		float num57 = num56 * 0f;
		float num58 = num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+138]");
		float num59 = num58 * 0f;
		num34 = num55 * 0.5f;
		num29 = num57 * 0.5f;
		num28 = num59 * 0.5f;
		Vector3 force5 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		rb.AddForce(force5, ForceMode.Impulse);
		obj16 = 0;
		mass = 0.5f;
		goto IL_0c2a;
		IL_0831:
		rigidbody = rb;
		Vector3 wishDir = GetWishDir();
		Vector3 velocity5 = rb.velocity;
		object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		_ = velocity5.x;
		_ = velocity5.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		num34 = velocity5.x * wishDir.x;
		num29 = velocity5.x * wishDir.y;
		mass = velocity5.x * wishDir.z;
		goto IL_0f4c;
		IL_0f9d:
		jumpedTime = MyTime.time;
		Action<PlayerMovement> a_Jumped = A_Jumped;
		if (A_Jumped != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1023 @ rax_v18 (System.Action`1<PlayerMovement>)+18] (should have been resolved before IL gen)");
		}
		return;
		IL_0c2a:
		if (climbCancel < climbCancelTicks)
		{
			StopWallClimbing();
			float num60 = num5 * (float)_003CwallNormal_003Ek__BackingField;
			float num61 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+23C]");
			float num62 = num61 * 0f;
			float num63 = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+240]");
			float num64 = num63 * 0f;
			mass = num60 * 1.5f;
			num34 = num62 * 1.5f;
			float num65 = num64 * 1.5f;
			Vector3 force6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			rb.AddForce(force6, ForceMode.Impulse);
			obj16 = 0;
		}
		float num67;
		if (currentCharacter != ECharacter.Monke)
		{
			if (currentCharacter == ECharacter.Ninja)
			{
				Vector3 velocity6 = rb.velocity;
				Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
				_ = velocity6.x;
				_ = velocity6.z;
				Vector3 vector2 = orientation.InverseTransformVector(vector);
				float num66 = threshold;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
				num67 = num66 ^ 0;
				float num68 = vector2.x;
				mass = vector2.z;
				_ = vector2.z;
				if (num67 > vector2.x)
				{
					mass = x;
					bool flag3 = x > 0f;
					obj17 = 0;
					if (flag3)
					{
						goto IL_0831;
					}
				}
				if (num68 > threshold)
				{
					bool flag4 = 0f > x;
					obj17 = 0;
					if (flag4)
					{
						goto IL_0831;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+83]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+77]");
				bool flag5 = IsHoldingAgainstVerticalVel((Vector2)0);
				bool flag6 = !flag5;
				obj17 = 0;
				num29 = num68;
				num34 = num67;
				obj16 = 0;
				if (!flag6)
				{
					goto IL_0831;
				}
			}
			goto IL_0f9d;
		}
		float maxSpeed = movementValues.GetMaxSpeed();
		Vector3 velocity7 = rb.velocity;
		Vector3 vector3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
		_ = velocity7.x;
		_ = velocity7.z;
		Vector3 vector4 = orientation.InverseTransformVector(vector3);
		object obj19 = threshold ^ -0f;
		num67 = vector4.x;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)vector4.x))
		{
			bool flag7 = x > 0f;
			float num68 = -0f;
			obj17 = 0;
			if (flag7)
			{
				goto IL_0831;
			}
		}
		if (num67 > threshold)
		{
			bool flag8 = 0f > x;
			float num68 = -0f;
			obj17 = 0;
			if (flag8)
			{
				goto IL_0831;
			}
		}
		num67 = vector4.z;
		object obj20 = threshold ^ -0f;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)vector4.z))
		{
			bool flag9 = y > 0f;
			float num68 = -0f;
			obj17 = 0;
			if (flag9)
			{
				goto IL_0831;
			}
		}
		if (num67 > threshold)
		{
			bool flag10 = 0f > y;
			float num68 = -0f;
			obj17 = 0;
			if (flag10)
			{
				goto IL_0831;
			}
		}
		float speedHorizontal = GetSpeedHorizontal();
		float num70;
		if (speedHorizontal > maxSpeed)
		{
			float speedHorizontal2 = GetSpeedHorizontal();
			float num69 = speedHorizontal2 - maxSpeed;
			num70 = 10f - num69;
		}
		else
		{
			num70 = 10f;
		}
		bool flag11 = !(5f < num70);
		float num71 = 5f;
		if (!flag11)
		{
			num71 = num70;
		}
		Vector3 wishDir2 = GetWishDir();
		_ = 0;
		object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
		object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		mass = wishDir2.x;
		num34 = wishDir2.z;
		_ = wishDir2.x;
		_ = wishDir2.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		object obj23 = default(object);
		float num72 = num71 * (float)obj23;
		float num73 = num71;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v27+4]");
		float num74 = num73 * 0f;
		float num75 = num71;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rax_v27+8]");
		float num76 = num75 * 0f;
		rigidbody = rb;
		Vector3 velocity8 = rb.velocity;
		float num77 = num72 + velocity8.x;
		float num78 = num74 + velocity8.y;
		float num79 = num76 + velocity8.z;
		num29 = -0f;
		obj17 = 0;
		goto IL_0f4c;
	}

	private float GetJumpForce()
	{
		float num = ((!isUnderwater) ? 1f : 1.4f);
		float stat = PlayerStats.GetStat(EStat.JumpHeight);
		float mass = rb.mass;
		float num2 = mass * stat;
		return num2 * num;
	}

	private void CounterMovement(float x, float y, Vector2 mag)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0e20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e25: Expected O, but got Unknown
		//IL_0e2e: Invalid comparison between F4 and O
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_004f: Invalid comparison between F4 and O
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d02: Expected O, but got Unknown
		//IL_0d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d10: Expected O, but got Unknown
		//IL_0d4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d53: Expected O, but got Unknown
		//IL_0d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d61: Expected O, but got Unknown
		//IL_0d81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d86: Expected O, but got Unknown
		//IL_0dcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd2: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Expected O, but got Unknown
		//IL_0578: Invalid comparison between O and F4
		//IL_0744: Expected O, but got I
		//IL_074e: Invalid comparison between O and F4
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Expected O, but got Unknown
		//IL_05b2: Invalid comparison between F4 and O
		//IL_0186: Expected I, but got O
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_0429: Invalid comparison between I4 and F4
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_077f: Expected O, but got Unknown
		//IL_0788: Invalid comparison between F4 and O
		//IL_046f: Expected F4, but got I4
		//IL_0c33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c38: Expected O, but got Unknown
		//IL_0c41: Invalid comparison between F4 and O
		//IL_0951: Unknown result type (might be due to invalid IL or missing references)
		//IL_0956: Expected O, but got Unknown
		//IL_0ae4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae9: Expected O, but got Unknown
		//IL_0a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Expected O, but got Unknown
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Expected O, but got Unknown
		//IL_0bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c00: Expected O, but got Unknown
		//IL_0615: Unknown result type (might be due to invalid IL or missing references)
		//IL_061a: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected O, but got Unknown
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected O, but got Unknown
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		//IL_0c94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c99: Expected O, but got Unknown
		//IL_0ca2: Invalid comparison between F4 and O
		//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Expected O, but got Unknown
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Expected O, but got Unknown
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e2: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 87;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj3 = x & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj4 = y & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				Vector3 velocity = rb.velocity;
				object obj5 = obj - 113;
				_ = velocity.x;
				_ = velocity.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
				if (1f > velocity.x && grounded && !jumping && !pushed && resetJumpCounter > 2 && HasFooting())
				{
					nint num = (nint)typeof(Vector3);
					Vector3 velocity2 = (Vector3)(obj - 113);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rax_v56 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					_ = Vector3.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v806 @ rax_v57 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					_ = 0;
					rb.velocity = velocity2;
					groundCancel = 0;
					if (!rb.isKinematic)
					{
						SetKinematic(b: true);
					}
					return;
				}
			}
		}
		if (rb.isKinematic)
		{
			rb.useGravity = true;
		}
		if (!grounded || !readyToJump || pushed)
		{
			return;
		}
		float counterMovementMultiplier = movementValues.GetCounterMovementMultiplier(surface);
		bool flag = _003CcrouchState_003Ek__BackingField == CrouchState.Sliding;
		float num3 = counterMovementMultiplier * defaultCounterMovement;
		counterMovement = num3;
		if (!flag)
		{
			if (justLandedCounter <= 2)
			{
				return;
			}
			Vector3 velocity3 = rb.velocity;
			_ = 0;
			object obj6 = obj - 113;
			_ = velocity3.x;
			_ = velocity3.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			if (velocity3.z > currentMaxSpeed)
			{
				float num4 = ((!(pushMultiplier < 1f)) ? 0.1f : 0.01f);
				slowDownSpeed = num4;
				float num5 = velocity3.z - currentMaxSpeed;
				float mass = rb.mass;
				float fixedDeltaTime = Time.fixedDeltaTime;
				float num6 = num5 / fixedDeltaTime;
				float num7 = num6 * mass;
				float num8 = slowDownSpeed * currentMoveSpeed;
				if (!(0f > num7))
				{
					if (!(num7 > num8))
					{
						num8 = num7;
					}
				}
				else
				{
					num8 = 0f;
				}
				float slowdownMultiplier = PlayerMovementValues.GetSlowdownMultiplier(surface, currentCharacter);
				float num9 = slowdownMultiplier * num8;
				Vector3 velocity4 = rb.velocity;
				object obj7 = obj - 113;
				object obj8 = obj - 97;
				_ = velocity4.x;
				_ = velocity4.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				Vector3 force = (Vector3)(obj - 113);
				object obj10 = default(object);
				object obj9 = obj10 ^ -0f;
				float num10 = (float)obj9 * num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1181 @ rax_v47+8]");
				object obj11 = 0 ^ -0f;
				float num11 = (float)obj11 * num9;
				float num12 = num9 * -0f;
				rb.AddForce(force);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj12 = mag & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)threshold))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
				object obj13 = x & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13) && readyToCounterX > 1)
				{
					Transform transform = orientation.transform;
					Vector3 right = transform.right;
					object obj14 = mag ^ -0f;
					float num13 = currentMoveSpeed * right.x;
					float num14 = currentMoveSpeed * right.y;
					float num15 = currentMoveSpeed * right.z;
					float num16 = num13 * 0.02f;
					float num17 = num14 * 0.02f;
					float num18 = num15 * 0.02f;
					float num19 = num16 * (float)obj14;
					float num20 = num17 * (float)obj14;
					float num21 = num18 * (float)obj14;
					float num22 = num19 * counterMovement;
					float num23 = num20 * counterMovement;
					float num24 = num21 * counterMovement;
					Vector3 force2 = (Vector3)(obj - 113);
					rb.AddForce(force2);
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-7D]");
			nint num25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj15 = num25 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)threshold))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
				object obj16 = y & 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16) && readyToCounterY > 1)
				{
					Transform transform2 = orientation.transform;
					Vector3 forward = transform2.forward;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-7D]");
					object obj17 = 0 ^ -0f;
					float num26 = currentMoveSpeed * forward.x;
					float num27 = currentMoveSpeed * forward.y;
					float num28 = currentMoveSpeed * forward.z;
					float num29 = num26 * 0.02f;
					float num30 = num27 * 0.02f;
					float num31 = num28 * 0.02f;
					float num32 = num29 * (float)obj17;
					float num33 = num30 * (float)obj17;
					float num34 = num31 * (float)obj17;
					float num35 = num32 * counterMovement;
					float num36 = num33 * counterMovement;
					float num37 = num34 * counterMovement;
					Vector3 force3 = (Vector3)(obj - 113);
					rb.AddForce(force3);
				}
			}
			if (IsHoldingAgainstHorizontalVel(mag))
			{
				Transform transform3 = orientation.transform;
				Vector3 right2 = transform3.right;
				object obj18 = mag ^ -0f;
				float num38 = currentMoveSpeed * right2.x;
				float num39 = currentMoveSpeed * right2.y;
				float num40 = currentMoveSpeed * right2.z;
				float num41 = num38 * 0.02f;
				float num42 = num39 * 0.02f;
				float num43 = num40 * 0.02f;
				float num44 = num41 * (float)obj18;
				float num45 = num42 * (float)obj18;
				float num46 = num43 * (float)obj18;
				float num47 = num44 * counterMovement;
				float num48 = num45 * counterMovement;
				float num49 = num46 * counterMovement;
				float num50 = num47 + num47;
				float num51 = num48 + num48;
				float num52 = num49 + num49;
				Vector3 force4 = (Vector3)(obj - 113);
				rb.AddForce(force4);
			}
			if (IsHoldingAgainstVerticalVel(mag))
			{
				Transform transform4 = orientation.transform;
				Vector3 forward2 = transform4.forward;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-7D]");
				object obj19 = 0 ^ -0f;
				float num53 = currentMoveSpeed * forward2.x;
				float num54 = currentMoveSpeed * forward2.y;
				float num55 = currentMoveSpeed * forward2.z;
				float num56 = num53 * 0.02f;
				float num57 = num54 * 0.02f;
				float num58 = num55 * 0.02f;
				float num59 = num56 * (float)obj19;
				float num60 = num57 * (float)obj19;
				float num61 = num58 * (float)obj19;
				float num62 = num59 * counterMovement;
				float num63 = num60 * counterMovement;
				float num64 = num61 * counterMovement;
				float num65 = num62 + num62;
				float num66 = num63 + num63;
				float num67 = num64 + num64;
				Vector3 force5 = (Vector3)(obj - 113);
				rb.AddForce(force5);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj20 = x & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20))
			{
				readyToCounterX = 0;
			}
			else
			{
				int num68 = readyToCounterX + 1;
				readyToCounterX = num68;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj21 = y & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.05f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj21))
			{
				readyToCounterY = 0;
				return;
			}
			int num69 = readyToCounterY + 1;
			readyToCounterY = num69;
		}
		else
		{
			Vector3 velocity5 = rb.velocity;
			object obj22 = obj - 113;
			object obj23 = obj - 97;
			_ = velocity5.x;
			_ = velocity5.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			float num70 = currentMoveSpeed * 0.02f;
			Vector3 force6 = (Vector3)(obj - 113);
			object obj25 = default(object);
			object obj24 = obj25 ^ -0f;
			float num71 = (float)obj24 * num70;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v10+8]");
			object obj26 = 0 ^ -0f;
			float num72 = (float)obj26 * num70;
			float num73 = num71 * slideCounterMovement;
			float num74 = num72 * slideCounterMovement;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v10+4]");
			object obj27 = 0 ^ -0f;
			float num75 = (float)obj27 * num70;
			float num76 = num75 * slideCounterMovement;
			rb.AddForce(force6);
		}
	}

	private bool IsHoldingAgainstHorizontalVel(Vector2 vel)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0068: Invalid comparison between O and F4
		//IL_008d: Invalid comparison between I4 and F4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_0041: Invalid comparison between F4 and I4
		float num = threshold;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
		object obj = num ^ 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vel) && x > 0f)
		{
			return true;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vel) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)threshold))
		{
			return false;
		}
		bool flag = 0f < x;
		object obj2 = 0 - x;
		bool flag2 = obj2 == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private bool IsHoldingAgainstVerticalVel(Vector2 vel)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0068: Invalid comparison between O and F4
		//IL_008d: Invalid comparison between I4 and F4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_0041: Invalid comparison between F4 and I4
		float num = threshold;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED90]");
		object obj = num ^ 0;
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) && y > 0f)
		{
			return true;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)threshold))
		{
			return false;
		}
		bool flag = 0f < y;
		object obj3 = 0 - y;
		bool flag2 = obj3 == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private bool IsFloor(Vector3 v)
	{
		//IL_001a: Invalid comparison between F4 and O
		//IL_003b: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		float num = maxSlopeAngle;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector);
		float num2 = maxSlopeAngle - (float)Vector3.upVector;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private bool IsSlideable(Vector3 v)
	{
		//IL_001a: Invalid comparison between O and F4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)slideAngle);
		object obj = Vector3.upVector - slideAngle;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private bool IsSurf(Vector3 v)
	{
		//IL_0077: Invalid comparison between F4 and O
		//IL_0016: Invalid comparison between O and F4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)89f) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector))
		{
			return false;
		}
		bool flag = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)maxSlopeAngle);
		object obj = Vector3.upVector - maxSlopeAngle;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private bool IsWall(Vector3 v)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0034: Invalid comparison between F4 and O
		//IL_0053: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		float num = 90f - (float)Vector3.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num & 0;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.1f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num2 = 0.1f - (float)obj;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private bool IsRoof(Vector3 v)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0038: Invalid comparison between F4 and O
		//IL_0057: Invalid comparison between F4 and I4
		float num = v.y - -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num & 0;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.075f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num2 = 0.075f - (float)obj;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private void UpdateCollisionChecks()
	{
		if (cancellingGrounded)
		{
			if (++groundCancel > surfaceDelay)
			{
				StopGrounded();
			}
		}
		else
		{
			cancellingGrounded = true;
		}
		if (climbCancel < climbCancelTicks)
		{
			int num = climbCancel + 1;
			climbCancel = num;
		}
		if (cancellingSurf)
		{
			if (++surfCancel > surfaceDelay)
			{
				surfing = false;
			}
		}
		else
		{
			cancellingSurf = true;
			surfCancel = 1;
		}
	}

	private void StopGrounded()
	{
		if (grounded)
		{
			leftGroundAtTime = MyTime.time;
		}
		grounded = false;
		groundedObject = null;
		Action<bool> a_Grounded = A_Grounded;
		if (A_Grounded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v75 @ rax_v5 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private void StopSurf()
	{
		surfing = false;
	}

	public unsafe Vector3 GetVelocity()
	{
		//IL_003b: Expected native int or pointer, but got O
		//IL_004d: Expected native int or pointer, but got O
		if ((object)rb != null)
		{
			Vector3 velocity = rb.velocity;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = velocity.x;
			((Vector3*)(nint)vector)->z = velocity.z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public float GetAverageVelocity()
	{
		return avgVelocity;
	}

	public float GetSpeedHorizontal()
	{
		//IL_00dc: Expected I, but got O
		//IL_00b2: Expected F4, but got I4
		Vector3 velocity = rb.velocity;
		Vector3 velocity2 = rb.velocity;
		nint num = (nint)typeof(Math);
		float num2 = velocity2.z * velocity2.z;
		float num3 = velocity.x * velocity.x;
		float num4 = num2 + num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v5 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 <= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
			return 0f;
		}
		float result = (float)Math.Sqrt(num4);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
		return result;
	}

	public float GetSpeed()
	{
		Vector3 velocity = rb.velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		return velocity.x;
	}

	public float GetFallSpeed()
	{
		return fallSpeed;
	}

	public Collider GetPlayerCollider()
	{
		return playerCollider;
	}

	public Transform GetPlayerCamTransform()
	{
		if ((object)playerCam != null)
		{
			return playerCam.transform;
		}
		return (Transform)(object)new NullReferenceException();
	}

	public Rigidbody GetRb()
	{
		return rb;
	}

	public unsafe void StopFallVelocity()
	{
		//IL_001d: Invalid comparison between I4 and F4
		//IL_0067: Expected O, but got Ref
		if (0f > rb.velocity.y)
		{
			Vector3 velocity = rb.velocity;
			Vector3 velocity2 = rb.velocity;
			float num = default(float);
			rb.velocity = (Vector3)(&num);
		}
	}

	public unsafe Vector3 GetRbFeetPosition()
	{
		//IL_01a1: Expected native int or pointer, but got O
		//IL_01ae: Expected native int or pointer, but got O
		//IL_01ed: Expected native int or pointer, but got O
		//IL_0143: Expected native int or pointer, but got O
		//IL_0150: Expected native int or pointer, but got O
		if ((object)rb != null)
		{
			Vector3 position = rb.position;
			float num = position.x;
			float num2 = position.y;
			float z = position.z;
			GameObject gameObject = base.gameObject;
			if ((object)gameObject != null)
			{
				if (!gameObject.activeInHierarchy)
				{
					Transform transform = base.transform;
					if ((object)transform == null)
					{
						goto IL_01b8;
					}
					Vector3 position2 = transform.position;
					num = position2.x;
					num2 = position2.y;
					z = position2.z;
				}
				float z2;
				Vector3 vector = default(Vector3);
				if (_003CcrouchState_003Ek__BackingField != CrouchState.None)
				{
					float num3 = num - (float)crouchingFeetOffset;
					float num4 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+2A4]");
					float num5 = num4 - 0f;
					float num6 = z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+2A8]");
					z2 = num6 - 0f;
					((Vector3*)(nint)vector)->x = num3;
					((Vector3*)(nint)vector)->y = num5;
				}
				else
				{
					float num7 = num - (float)standingFeetOffset;
					float num8 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+298]");
					float num9 = num8 - 0f;
					float num10 = z;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+29C]");
					z2 = num10 - 0f;
					((Vector3*)(nint)vector)->x = num7;
					((Vector3*)(nint)vector)->y = num9;
				}
				((Vector3*)(nint)vector)->z = z2;
				return vector;
			}
		}
		goto IL_01b8;
		IL_01b8:
		return (Vector3)new NullReferenceException();
	}

	public unsafe Vector3 GetRbHeadPosition()
	{
		//IL_00f7: Expected native int or pointer, but got O
		//IL_010c: Expected O, but got I
		//IL_0114: Expected native int or pointer, but got O
		//IL_0148: Expected native int or pointer, but got O
		//IL_0087: Expected native int or pointer, but got O
		//IL_009c: Expected O, but got I
		//IL_00a4: Expected native int or pointer, but got O
		if ((object)rb != null)
		{
			Vector3 position;
			Vector3 vector = default(Vector3);
			object obj;
			if (_003CcrouchState_003Ek__BackingField != CrouchState.None)
			{
				position = rb.position;
				float num = (float)crouchHeadHeight + position.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+19C]");
				float num2 = 0f + position.y;
				((Vector3*)(nint)vector)->x = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+1A0]");
				obj = 0;
				((Vector3*)(nint)vector)->y = num2;
			}
			else
			{
				position = rb.position;
				float num3 = (float)headHeight + position.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+190]");
				float num4 = 0f + position.y;
				((Vector3*)(nint)vector)->x = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+194]");
				obj = 0;
				((Vector3*)(nint)vector)->y = num4;
			}
			float z = (float)obj + position.z;
			((Vector3*)(nint)vector)->z = z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe Vector3 FeetPositionToRb(Vector3 feetPos, bool wasCrouching = false)
	{
		//IL_0056: Expected native int or pointer, but got O
		//IL_0063: Expected native int or pointer, but got O
		//IL_0070: Expected native int or pointer, but got O
		float num = (float)feetHeight + feetPos.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+1A8]");
		float num2 = 0f + feetPos.y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+1AC]");
		float z = 0f + feetPos.z;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = num;
		((Vector3*)(nint)vector)->y = num2;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public bool CanFloat()
	{
		//IL_00b4: Expected I4, but got O
		if (!IsTouchingGround())
		{
			if ((object)rb == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (-0.5f > rb.velocity.y && resetJumpCounter >= 4)
			{
				return !jumping;
			}
		}
		return false;
	}

	public float GetFeetOffset()
	{
		//IL_000d: Expected F4, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1A8]");
		return 0f;
	}

	public EMovementState GetMovementState()
	{
		//IL_00ff: Invalid comparison between F4 and I4
		//IL_0112: Expected O, but got I4
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected I4, but got Unknown
		if (grounded)
		{
			if (_003CcrouchState_003Ek__BackingField == CrouchState.Crouching)
			{
				return EMovementState.Crouching;
			}
			if (_003CcrouchState_003Ek__BackingField == CrouchState.Sliding)
			{
				return EMovementState.Sliding;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018033D450h\"");
			if ((object)inputState == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018033D450h\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerMovement)+1C4]");
				if ((nint)0 == 0)
				{
					float speedHorizontal = GetSpeedHorizontal();
					bool flag = 3f < speedHorizontal;
					float num = 3f - speedHorizontal;
					bool flag2 = num == 0f;
					object obj = flag | flag2;
					return (EMovementState)(obj + 1);
				}
			}
			return EMovementState.Walking;
		}
		if (_003CcrouchState_003Ek__BackingField != CrouchState.Crouching)
		{
			bool flag3 = _003CcrouchState_003Ek__BackingField == CrouchState.Sliding;
			EMovementState result = (EMovementState)24;
			if (!flag3)
			{
				result = EMovementState.Airborne;
			}
			return result;
		}
		return (EMovementState)20;
	}

	public float GetPlayerRadius()
	{
		return _003CplayerRadius_003Ek__BackingField;
	}

	public unsafe Vector3 GetNormal()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)normalVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (PlayerMovement)+138]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public bool IsHoldingMovement()
	{
		//IL_0015: Invalid comparison between F4 and I4
		//IL_0041: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018033E394h\"");
		if (x == 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018033E394h\"");
			if (y == 0f)
			{
				return false;
			}
		}
		return true;
	}

	public void TouchingTornado()
	{
		lastTouchedTornadoTime = MyTime.time;
		_003CisTouchingTornado_003Ek__BackingField = true;
	}
}
