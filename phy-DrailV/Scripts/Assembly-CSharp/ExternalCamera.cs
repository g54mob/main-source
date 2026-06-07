using System;
using DV;
using DV.Common;
using DV.DopplerEffects;
using DV.HUD;
using DV.Hovering;
using DV.Interaction.Inputs;
using DV.UI.ContextMenu;
using DV.UI.LocoHUD;
using DV.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExternalCamera : MonoBehaviour
{
	private const float ALTITUDE_LIMIT = 1200f;

	private const float MAX_TERRAIN_HEIGHT = 10000f;

	private const float TRAIN_ORBIT_SCROLL_SPEED = 1f;

	private const float ORBIT_DISTANCE_SCROLL_SPEED = 0.2f;

	private const float FLYSPEED_CHANGE_MULT = 50f;

	private const float MIN_FLY_SPEED = 0.01f;

	private const float MIN_DISTANCE_ORBIT_FLYMODE = 0.5f;

	private const float VELOCITY_DRAG = 1.5f;

	private const float FLYMODE_ORBIT_EXIT_VELOCITY_MULT = 0.002f;

	private const float FLYMODE_ORBIT_ENTER_VELOCITY_MULT = 0.003f;

	private const float CAMERA_SPHERE_RADIUS = 0.3f;

	private const float TRAIN_ORBIT_INITIAL_X = 22f;

	private const float TRAIN_ORBIT_HEIGHT_MAX = 5f;

	private const float TRAIN_COUPLER_HEIGHT = 0.4f;

	private const float OFF_TRANSITION_SWITCH_TO_ROT_TIME = 0.2f;

	private bool _isOn;

	public bool invertedY;

	[NonSerialized]
	public bool lockCameraOnTrain;

	private bool _photoMode;

	private bool isTurningOff;

	private float orbitDistanceDesired = 10f;

	private float flySpeed = 20f;

	public float mouseSensitivity = 50f;

	public float clampAngle = 80f;

	private float adjustedPhotoModeSmoothtime;

	public float photoModeSmoothTime = 1f;

	public float gameModeSmoothTime = 0.2f;

	public AnimationCurve transitionCurve;

	[NonSerialized]
	public bool acceptMouseInput = true;

	[NonSerialized]
	public bool acceptKeyboardInput = true;

	[NonSerialized]
	public bool blockFOVChange;

	[NonSerialized]
	public float targetRotY;

	[NonSerialized]
	public float targetRotX;

	[NonSerialized]
	public CustomFirstPersonController fpsController;

	[NonSerialized]
	public Camera cam;

	[NonSerialized]
	public TrainCar currentHoveredTrain;

	[NonSerialized]
	public TurntableControlKeyboardInput currentHoveredTurntable;

	[NonSerialized]
	public WarehouseMachineController currentHoveredMachine;

	[NonSerialized]
	public bool locoSelect;

	private TrainCar _currentCar;

	private float fovVelocity;

	private float fovZoomSpeed = 0.6f;

	private float fovRaw;

	private float minFov = 3f;

	private float maxFov = 130f;

	private float fov = 40f;

	private float desiredFov;

	private Vector3 position;

	private Quaternion rotation;

	private Vector3 velocity;

	private Vector3 transitionPosition;

	private Vector3 flyModeOrbitPosition;

	private float transitionSmoothStep = 1f;

	private float transitionLinear = 1f;

	private float transitionTime = 0.5f;

	private LayerMask orbitTargetsLayerMask;

	private LayerMask cameraCollisionLayer;

	private int terrainMask;

	private float trainOrbitPosRawT;

	private float trainOrbitSideRawT;

	private float trainOrbitHeightRawT;

	private Vector3 trainOrbitLocalPosSmooth;

	private Vector3 trainOrbitPosSmooth;

	private Vector3 trainOrbitLocalPosRaw;

	private Vector3 trainOrbitPosVel;

	private float minOrbitDistance = 3f;

	private float maxOrbitDistance = 500f;

	private float orbitDistanceSmooth = 3f;

	private float orbitDistanceRaw = 3f;

	private float orbitDistanceVel;

	private Vector3 desiredFlyPosition;

	private Vector3 flySmoothVelocity;

	private float rotX;

	private float rotY;

	private float rotXVel;

	private float rotYVel;

	private RaycastHit[] camCollisionCache = new RaycastHit[20];

	private bool orbitCollision;

	private float lastTrainRotationY;

	private float trainRotationDelta;

	private float camRotationDelta;

	private float ignoreCollisionTimer;

	private float turnOffTransitionTime;

	private float turnOffTransitionStartTime;

	private Vector3 turnOffTransitionStartPos;

	private Quaternion turnOffTransitionStartRot;

	private bool worldJustMoved;

	private bool locoSelectOverrideRequested;

	private Coroutine coro;

	private HUDLocoMenuProvider locoMenuProvider;

	private HUDTurntableContextMenuProvider turntableProvider;

	private StreamingController streamingController;

	private bool wasPressedLastFrame;

	private float MAX_FLY_SPEED
	{
		get
		{
			if (!DevUtil.IsDevMachine())
			{
				return 100f;
			}
			return 600f;
		}
	}

	public bool IsOn
	{
		get
		{
			return _isOn;
		}
		set
		{
			if (_isOn != value)
			{
				_isOn = value;
				this.IsOnChanged?.Invoke(value);
			}
		}
	}

	public bool PhotoMode
	{
		get
		{
			return _photoMode;
		}
		set
		{
			if (_photoMode != value)
			{
				_photoMode = value;
				this.PhotoModeChanged?.Invoke(value);
			}
			if (!value)
			{
				targetRotX = rotX;
				targetRotY = rotY;
				rotXVel = 0f;
				rotYVel = 0f;
			}
		}
	}

	public bool freeOrbitPressed => InputManager.NewPlayer.GetNegativeButton(InputManager.Actions.Lean);

	public TrainCar CurrentCar
	{
		get
		{
			return _currentCar;
		}
		set
		{
			if (_currentCar != null && value != null && Vector3.Dot(_currentCar.transform.forward, value.transform.forward) < 0f)
			{
				trainOrbitSideRawT = 0f - trainOrbitSideRawT;
			}
			if (_currentCar != value)
			{
				_currentCar = value;
				SingletonBehaviour<DopplerStopRequests>.Instance.SkipFrames = 1;
				this.FollowingCarChanged?.Invoke();
				if (_currentCar != null)
				{
					lastTrainRotationY = _currentCar.transform.eulerAngles.y;
				}
			}
		}
	}

	public bool IsOrbitingPlayerCar
	{
		get
		{
			if (CurrentCar == PlayerManager.Car)
			{
				return PlayerManager.Car != null;
			}
			return false;
		}
	}

	public event Action<bool> IsOnChanged;

	public event Action<bool> PhotoModeChanged;

	public event Action FollowingCarChanged;

	private void Awake()
	{
		locoMenuProvider = SingletonBehaviour<HUDInterfacer>.Instance.GetComponent<HUDLocoMenuProvider>();
		turntableProvider = SingletonBehaviour<HUDInterfacer>.Instance.GetComponent<HUDTurntableContextMenuProvider>();
		cam = GetComponent<Camera>();
		streamingController = GetComponent<StreamingController>();
		streamingController.enabled = false;
		if (!cam)
		{
			Debug.LogError("No Camera attached to External Cam!");
			UnityEngine.Object.Destroy(base.gameObject);
		}
		terrainMask = LayerMask.GetMask("Terrain");
		orbitTargetsLayerMask = LayerMask.GetMask("Default", "Interactable", "Train_Interior", "Laser_Pointer_Target", "Teleport_Destination", "Train_Big_Collider", "Terrain");
		cameraCollisionLayer = LayerMask.GetMask("Default", "Terrain");
		desiredFov = GamePreferences.Get<float>(Preferences.FieldOfView);
		GamePreferences.RegisterToPreferenceUpdated(Preferences.PhotomodeSmoothing, OnSmoothingChanged);
		OnSmoothingChanged();
	}

	private void OnSmoothingChanged()
	{
		adjustedPhotoModeSmoothtime = photoModeSmoothTime * GamePreferences.Get<float>(Preferences.PhotomodeSmoothing);
	}

	private void OnWorldMoved(WorldMover _, Vector3 dir)
	{
		position -= dir;
		transitionPosition -= dir;
		desiredFlyPosition -= dir;
		flyModeOrbitPosition -= dir;
		base.transform.position -= dir;
		trainOrbitPosSmooth -= dir;
		worldJustMoved = true;
	}

	private void OnDestroy()
	{
		GamePreferences.UnregisterFromPreferenceUpdated(Preferences.PhotomodeSmoothing, OnSmoothingChanged);
		if (!UnloadWatcher.isUnloading)
		{
			if ((bool)SingletonBehaviour<WorldMover>.Instance)
			{
				SingletonBehaviour<WorldMover>.Instance.WorldMoved -= OnWorldMoved;
			}
			if (coro != null)
			{
				SingletonBehaviour<CoroutineManager>.Instance.StopCoroutine(coro);
			}
		}
	}

	private void LateUpdate()
	{
		if ((SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen && Time.timeScale == 0f) || !IsOn)
		{
			return;
		}
		if (isTurningOff)
		{
			Camera playerCamera = PlayerManager.PlayerCamera;
			float num = Time.time - turnOffTransitionStartTime;
			float num2 = turnOffTransitionTime - 0.2f;
			float time = NumberUtil.MapClamp(num, 0f, num2, 0f, 1f);
			float time2 = NumberUtil.MapClamp(num, num2, turnOffTransitionTime, 0f, 1f);
			time = transitionCurve.Evaluate(time);
			time2 = transitionCurve.Evaluate(time2);
			base.transform.position = Vector3.LerpUnclamped(turnOffTransitionStartPos, playerCamera.transform.position, time);
			base.transform.rotation = Quaternion.SlerpUnclamped(turnOffTransitionStartRot, playerCamera.transform.rotation, time2);
			cam.fieldOfView = Mathf.LerpUnclamped(fov, playerCamera.fieldOfView, time);
			if (!(num < turnOffTransitionTime))
			{
				blockFOVChange = false;
				isTurningOff = false;
				IsOn = false;
				CurrentCar = null;
				streamingController.enabled = false;
				if ((bool)SingletonBehaviour<WorldMover>.Instance)
				{
					SingletonBehaviour<WorldMover>.Instance.WorldMoved -= OnWorldMoved;
				}
			}
			return;
		}
		if (acceptMouseInput)
		{
			DoMouse();
		}
		if (acceptKeyboardInput)
		{
			UpdateRawValues();
		}
		DoRotation();
		if (acceptMouseInput)
		{
			DoFlyOrbit();
		}
		else
		{
			wasPressedLastFrame = false;
		}
		UpdateSmoothValues();
		ApplyValues();
		float time3 = GetTime();
		if (!CurrentCar)
		{
			Vector3 vector = velocity * time3;
			desiredFlyPosition = WorldBoundaryEnforcer.ClampPointAndAltitude(desiredFlyPosition + vector, 1200f);
			position = WorldBoundaryEnforcer.ClampPointAndAltitude(position + vector, 1200f, 0.5f);
		}
		Vector3 vector2 = Vector3.Lerp(transitionPosition, position, transitionSmoothStep);
		if (time3 != 0f && transitionTime != 0f)
		{
			transitionLinear += time3 / transitionTime;
		}
		transitionSmoothStep = Mathf.SmoothStep(0f, 1f, transitionLinear);
		base.transform.position = (CurrentCar ? vector2 : WorldBoundaryEnforcer.ClampPointAndAltitude(vector2, 1200f, 0.5f));
		base.transform.rotation = rotation;
		velocity *= 1f - 1.5f * time3;
		if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.ContextMenu))
		{
			SingletonBehaviour<ScreenspaceMouse>.Instance.RequestOverride(this, on: true);
			locoSelectOverrideRequested = true;
		}
		else if (locoSelectOverrideRequested && !InputManager.NewPlayer.GetButton(InputManager.Actions.ContextMenu))
		{
			SingletonBehaviour<ScreenspaceMouse>.Instance.RemoveRequest(this);
			locoSelectOverrideRequested = false;
		}
		bool flag = (locoMenuProvider.simpleHoverable.gameObject.activeInHierarchy && locoMenuProvider.simpleHoverable.IsHovered) || (turntableProvider.simpleHoverable.gameObject.activeInHierarchy && turntableProvider.simpleHoverable.IsHovered);
		bool flag2 = (bool)EventSystem.current && EventSystem.current.IsPointerOverGameObject() && !flag;
		bool flag3 = (locoSelect || InputManager.NewPlayer.GetButton(InputManager.Actions.ContextMenu)) && !InputManager.NewPlayer.GetButtonDown(InputManager.Actions.ContextMenu) && SingletonBehaviour<ScreenspaceMouse>.Instance.on && Cursor.visible && !InputManager.NewPlayer.GetButtonUp(InputManager.Actions.InteractionSecondary) && !InputManager.NewPlayer.GetButtonUp(InputManager.Actions.MouseLook) && !flag2;
		(NonVRHoverManager.HoverType, object) currentlyHovered = SingletonBehaviour<NonVRHoverManager>.Instance.CurrentlyHovered;
		if (!flag && flag3)
		{
			TrainCar trainCar = ((currentlyHovered.Item1 == NonVRHoverManager.HoverType.Train) ? (currentlyHovered.Item2 as TrainCar) : null);
			if (trainCar != currentHoveredTrain)
			{
				currentHoveredTrain = trainCar;
				locoMenuProvider.CarChanged(currentHoveredTrain);
			}
			TurntableControlKeyboardInput turntableControlKeyboardInput = ((currentlyHovered.Item1 == NonVRHoverManager.HoverType.Turntable) ? (currentlyHovered.Item2 as TurntableControlKeyboardInput) : null);
			if (currentHoveredTurntable != turntableControlKeyboardInput)
			{
				currentHoveredTurntable = turntableControlKeyboardInput;
				turntableProvider.TurntableChanged(currentHoveredTurntable);
			}
		}
		else if (!flag3)
		{
			if ((bool)currentHoveredTrain)
			{
				currentHoveredTrain = null;
				locoMenuProvider.CarChanged(null);
			}
			if ((bool)currentHoveredTurntable)
			{
				currentHoveredTurntable = null;
				turntableProvider.TurntableChanged(null);
			}
		}
		if ((bool)currentHoveredTrain && !flag && CurrentCar != currentHoveredTrain && InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionPrimary))
		{
			SwitchFlyToOrbital(currentHoveredTrain);
		}
		WarehouseMachineController warehouseMachineController = ((currentlyHovered.Item1 == NonVRHoverManager.HoverType.WarehouseMachine) ? (currentlyHovered.Item2 as WarehouseMachineController) : null);
		if (!SingletonBehaviour<ScreenspaceMouse>.Instance.on)
		{
			warehouseMachineController = null;
		}
		if (currentHoveredMachine != warehouseMachineController)
		{
			if ((bool)currentHoveredMachine)
			{
				currentHoveredMachine.SetHighlight(on: false);
			}
			currentHoveredMachine = warehouseMachineController;
			if ((bool)currentHoveredMachine)
			{
				currentHoveredMachine.SetHighlight(on: true);
				SingletonBehaviour<JunctionSwitcherManager>.Instance.hoverOverSwitch.Play2D();
			}
		}
		if ((bool)currentHoveredMachine && InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionPrimary))
		{
			currentHoveredMachine.ActivateExternally();
		}
		if ((bool)CurrentCar)
		{
			float y = CurrentCar.transform.eulerAngles.y;
			if (lockCameraOnTrain)
			{
				trainRotationDelta += Mathf.DeltaAngle(y, lastTrainRotationY);
			}
			lastTrainRotationY = y;
			if (InputManager.NewPlayer.GetButton(InputManager.Actions.ContextMenu) && InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InteractionSecondary))
			{
				SwitchOrbitalToFly();
			}
		}
		if (worldJustMoved)
		{
			worldJustMoved = false;
		}
	}

	public void FindPlayerCar()
	{
		if ((bool)PlayerManager.Car)
		{
			CurrentCar = PlayerManager.Car;
			velocity = Vector3.zero;
			transitionPosition = position;
			transitionSmoothStep = 0f;
			transitionLinear = 0f;
			transitionTime = 0.2f;
			trainOrbitSideRawT = 0f;
			Vector3 a = (CurrentCar.rearCoupler.IsCoupled() ? Vector3.Lerp(CurrentCar.rearCoupler.transform.position, CurrentCar.rearCoupler.coupledTo.transform.position, 0.5f) : CurrentCar.rearCoupler.transform.position);
			Vector3 b = (CurrentCar.frontCoupler.IsCoupled() ? Vector3.Lerp(CurrentCar.frontCoupler.transform.position, CurrentCar.frontCoupler.coupledTo.transform.position, 0.5f) : CurrentCar.frontCoupler.transform.position);
			trainOrbitPosRawT = VectorUtils.InverseLerp(a, b, PlayerManager.PlayerTransform.position);
			trainOrbitLocalPosSmooth = GetTrainPos(trainOrbitPosRawT, out var _);
			trainOrbitLocalPosRaw = trainOrbitLocalPosSmooth;
			trainOrbitPosSmooth = CurrentCar.transform.TransformPoint(trainOrbitLocalPosSmooth);
		}
	}

	private void DoFlyOrbit()
	{
		if ((bool)CurrentCar)
		{
			return;
		}
		if (freeOrbitPressed)
		{
			if (!wasPressedLastFrame)
			{
				wasPressedLastFrame = true;
				if (Physics.Raycast(desiredFlyPosition, rotation * Vector3.forward, out var hitInfo, 20000f, orbitTargetsLayerMask))
				{
					flyModeOrbitPosition = desiredFlyPosition + rotation * Vector3.forward * hitInfo.distance;
				}
				else
				{
					flyModeOrbitPosition = desiredFlyPosition + rotation * Vector3.forward * 20f;
				}
				float num = Vector3.Dot(base.transform.right, velocity.normalized);
				float num2 = Vector3.Dot(base.transform.up, velocity.normalized);
				float num3 = velocity.magnitude / (Vector3.Distance(flyModeOrbitPosition, desiredFlyPosition) * 2f * (float)Math.PI * 0.003f);
				rotYVel = (0f - num) * num3;
				rotXVel = num2 * num3;
				targetRotX += num2 * num3;
				targetRotY -= num * num3;
				velocity = Vector3.zero;
			}
			float value = Vector3.Distance(flyModeOrbitPosition, desiredFlyPosition);
			value = Mathf.Clamp(value, 0.5f, float.MaxValue);
			Vector3 vector = desiredFlyPosition;
			desiredFlyPosition = flyModeOrbitPosition - rotation * Vector3.forward * value;
			desiredFlyPosition = WorldBoundaryEnforcer.ClampVector(flyModeOrbitPosition, desiredFlyPosition);
			Vector3 vector2 = vector - desiredFlyPosition;
			Matrix4x4 matrix4x = Matrix4x4.TRS(desiredFlyPosition, rotation, Vector3.one);
			Vector3 vector3 = matrix4x.inverse.MultiplyVector(vector2);
			vector3.z = 0f;
			position -= matrix4x.MultiplyVector(vector3);
		}
		else if (wasPressedLastFrame && !freeOrbitPressed)
		{
			float num4 = Vector3.Distance(flyModeOrbitPosition, desiredFlyPosition) * 2f * (float)Math.PI * 0.002f;
			float num5 = (0f - rotYVel) * num4;
			float num6 = rotXVel * num4;
			velocity = base.transform.right * num5 + base.transform.up * num6;
			targetRotY = rotY;
			targetRotX = rotX;
			wasPressedLastFrame = false;
		}
	}

	private void DoMouse()
	{
		Vector2 mouseAxisInput = InputManager.GetMouseAxisInput();
		targetRotX -= mouseAxisInput.y * mouseSensitivity * fov * (float)((!invertedY) ? 1 : (-1));
		targetRotY += mouseAxisInput.x * mouseSensitivity * fov;
		targetRotX = Mathf.Clamp(targetRotX, 0f - clampAngle, clampAngle);
	}

	private void DoRotation()
	{
		if ((bool)CurrentCar)
		{
			float num = camRotationDelta;
			camRotationDelta = Mathf.LerpAngle(camRotationDelta, trainRotationDelta, Time.deltaTime);
			targetRotY += num - camRotationDelta;
		}
		if (PhotoMode)
		{
			rotX = NumberUtil.SmoothDampNoOvershoot(rotX, targetRotX, ref rotXVel, adjustedPhotoModeSmoothtime, float.MaxValue, GetTime());
			rotY = NumberUtil.SmoothDampNoOvershoot(rotY, targetRotY, ref rotYVel, adjustedPhotoModeSmoothtime, float.MaxValue, GetTime());
		}
		else
		{
			rotX = targetRotX;
			rotY = targetRotY;
		}
		rotation = Quaternion.Euler(rotX, rotY, 0f);
	}

	public void SwitchFlyToOrbital(TrainCar train)
	{
		if ((bool)train)
		{
			CurrentCar = train;
			velocity = Vector3.zero;
			flySmoothVelocity = Vector3.zero;
			position = base.transform.position;
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			(bool, Vector3, Vector3) tuple = VectorUtils.ClosestPointsOnTwoLines(CurrentCar.transform.position, CurrentCar.transform.forward, ray.origin, ray.direction);
			Vector3 a = new Plane(cam.transform.forward, cam.transform.position).ClosestPointOnPlane(tuple.Item3);
			orbitDistanceDesired = Vector3.Distance(a, tuple.Item3);
			orbitDistanceSmooth = orbitDistanceDesired;
			transitionPosition = position;
			transitionSmoothStep = 0f;
			transitionLinear = 0f;
			transitionTime = 0.7f;
			Vector3 a2 = (CurrentCar.rearCoupler.IsCoupled() ? Vector3.Lerp(CurrentCar.rearCoupler.transform.position, CurrentCar.rearCoupler.coupledTo.transform.position, 0.5f) : CurrentCar.rearCoupler.transform.position);
			Vector3 b = (CurrentCar.frontCoupler.IsCoupled() ? Vector3.Lerp(CurrentCar.frontCoupler.transform.position, CurrentCar.frontCoupler.coupledTo.transform.position, 0.5f) : CurrentCar.frontCoupler.transform.position);
			trainOrbitPosRawT = VectorUtils.InverseLerp(a2, b, tuple.Item3);
			trainOrbitSideRawT = 0f;
			trainOrbitHeightRawT = 0.5f;
			trainOrbitLocalPosSmooth = GetTrainPos(trainOrbitPosRawT, out var _);
			trainOrbitLocalPosRaw = trainOrbitLocalPosSmooth;
			trainOrbitPosSmooth = CurrentCar.transform.TransformPoint(trainOrbitLocalPosSmooth);
		}
	}

	private bool CheckSphereCol(Vector3 pos)
	{
		return Physics.CheckSphere(pos, 0.3f, cameraCollisionLayer);
	}

	private Vector3 GetTrainPos(float t, out Vector3 trainCenter, float height = 0f, float side = 0f)
	{
		Vector3 a = (CurrentCar.rearCoupler.IsCoupled() ? Vector3.Lerp(CurrentCar.rearCoupler.transform.position, CurrentCar.rearCoupler.coupledTo.transform.position, 0.5f) : CurrentCar.rearCoupler.transform.position);
		Vector3 b = (CurrentCar.frontCoupler.IsCoupled() ? Vector3.Lerp(CurrentCar.frontCoupler.transform.position, CurrentCar.frontCoupler.coupledTo.transform.position, 0.5f) : CurrentCar.frontCoupler.transform.position);
		trainCenter = Vector3.Lerp(a, b, t);
		return CurrentCar.transform.InverseTransformPoint(trainCenter) - 0.4f * Vector3.up + height * Vector3.up + Vector3.right * (side * 5f);
	}

	public void SwitchOrbitalToFly()
	{
		if ((bool)CurrentCar)
		{
			velocity = CurrentCar.rb.velocity;
			CurrentCar = null;
			desiredFlyPosition = position;
		}
	}

	private void UpdateRawValues()
	{
		int num = InputManager.GetScrollValue();
		if ((bool)SingletonBehaviour<HUDHoverManager>.Instance && SingletonBehaviour<HUDHoverManager>.Instance.CurrentHovered != null)
		{
			num = 0;
		}
		float time = GetTime();
		if (InputManager.NewPlayer.GetButton(InputManager.Actions.Run))
		{
			if ((bool)CurrentCar && num != 0)
			{
				float num2 = Mathf.Sign(Vector3.Dot(rotation * Vector3.forward, CurrentCar.transform.forward));
				float num3 = Mathf.Sign(Vector3.Dot(CurrentCar.rb.velocity, CurrentCar.transform.forward));
				MoveToNextCar((float)num * ((CurrentCar.rb.velocity.sqrMagnitude > 0.1f) ? num3 : num2) > 0f);
			}
		}
		else if (!InputManager.NewPlayer.GetButton(InputManager.Actions.ContextMenu) && !InputManager.NewPlayer.GetButton(InputManager.Actions.Crouch) && !InputManager.NewPlayer.GetButton(InputManager.Actions.MouseLook) && (bool)CurrentCar)
		{
			if (orbitCollision)
			{
				if (num > 0)
				{
					orbitDistanceDesired = orbitDistanceRaw;
					orbitDistanceDesired -= 0.2f * (float)num * orbitDistanceDesired;
				}
			}
			else
			{
				orbitDistanceDesired -= 0.2f * (float)num * orbitDistanceDesired;
			}
			orbitDistanceDesired = Mathf.Clamp(orbitDistanceDesired, minOrbitDistance, maxOrbitDistance);
		}
		if (acceptMouseInput && !blockFOVChange && (PhotoMode || InputManager.NewPlayer.GetButton(InputManager.Actions.Hotbar)))
		{
			desiredFov += desiredFov * time * fovZoomSpeed * GetAxis(InputManager.Actions.InteractionPrimary, InputManager.Actions.InteractionSecondary);
			desiredFov = Mathf.Clamp(desiredFov, minFov, maxFov);
		}
		fovRaw = desiredFov;
		Vector2 axis2D = InputManager.NewPlayer.GetAxis2D(InputManager.Actions.MoveHorizontal, InputManager.Actions.MoveVertical);
		float y = axis2D.y;
		float num4 = GetAxis(InputManager.Actions.Crouch, InputManager.Actions.Jump);
		float num5 = axis2D.x;
		if ((bool)CurrentCar)
		{
			float num6 = Vector3.Dot(rotation * Vector3.forward, CurrentCar.transform.forward);
			float num7 = Vector3.Dot(rotation * Vector3.right, CurrentCar.transform.forward);
			float num8 = y * num6 + num5 * num7;
			float num9 = num5 * num6 - y * num7;
			if (num8 != 0f)
			{
				trainOrbitPosRawT += 1f * time * num8 * (float)((!InputManager.NewPlayer.GetButton(InputManager.Actions.Run)) ? 1 : 3) * orbitDistanceSmooth / CurrentCar.Bounds.size.z;
			}
			if (num9 != 0f)
			{
				trainOrbitSideRawT += 1f * time * num9 * (float)((!InputManager.NewPlayer.GetButton(InputManager.Actions.Run)) ? 1 : 3) * orbitDistanceSmooth / 5f;
				trainOrbitSideRawT = Mathf.Clamp(trainOrbitSideRawT, -1f, 1f);
			}
			trainOrbitHeightRawT += 1f * time * num4 * (float)((!InputManager.NewPlayer.GetButton(InputManager.Actions.Run)) ? 1 : 3) * orbitDistanceSmooth;
			trainOrbitHeightRawT = Mathf.Clamp(trainOrbitHeightRawT, 0f, 5f);
		}
		else
		{
			if (freeOrbitPressed)
			{
				num5 = 0f;
				num4 = 0f;
			}
			Vector3 vector = new Vector3(num5, num4, y);
			desiredFlyPosition += rotation * vector * flySpeed * Time.unscaledDeltaTime * ((!InputManager.NewPlayer.GetButton(InputManager.Actions.Run)) ? 1 : 3);
			flySpeed += Mathf.Sqrt(flySpeed) * time * (float)num * 50f;
			flySpeed = Mathf.Clamp(flySpeed, 0.01f, MAX_FLY_SPEED);
		}
		void MoveToNextCar(bool forward)
		{
			Coupler coupler = (forward ? CurrentCar.frontCoupler : CurrentCar.rearCoupler);
			if (coupler.IsCoupled())
			{
				trainOrbitPosVel = CurrentCar.transform.TransformVector(trainOrbitPosVel);
				CurrentCar = coupler.coupledTo.train;
				trainOrbitLocalPosSmooth = CurrentCar.transform.InverseTransformPoint(trainOrbitPosSmooth);
				trainOrbitPosVel = CurrentCar.transform.InverseTransformVector(trainOrbitPosVel);
				trainOrbitPosRawT = 0.5f;
			}
		}
	}

	private void UpdateSmoothValues()
	{
		float time = GetTime();
		if ((bool)CurrentCar)
		{
			if (!orbitCollision)
			{
				orbitDistanceRaw = orbitDistanceDesired;
			}
			Vector3 trainCenter;
			Vector3 trainPos = GetTrainPos(trainOrbitPosRawT, out trainCenter, trainOrbitHeightRawT, trainOrbitSideRawT);
			trainOrbitLocalPosRaw = trainPos;
			Vector3 end = CurrentCar.transform.TransformPoint(trainOrbitLocalPosRaw);
			end = WorldBoundaryEnforcer.ClampVector(trainCenter, end);
			ClampPositionAboveTerrain(ref end, 1f);
			trainOrbitLocalPosRaw = CurrentCar.transform.InverseTransformPoint(end);
			if (time > 0f)
			{
				trainOrbitLocalPosSmooth = Vector3.SmoothDamp(trainOrbitLocalPosSmooth, trainOrbitLocalPosRaw, ref trainOrbitPosVel, PhotoMode ? adjustedPhotoModeSmoothtime : gameModeSmoothTime, float.MaxValue, time);
			}
			trainOrbitPosSmooth = CurrentCar.transform.TransformPoint(trainOrbitLocalPosSmooth);
			trainOrbitPosSmooth = WorldBoundaryEnforcer.ClampVector(trainCenter, trainOrbitPosSmooth);
		}
		else
		{
			ClampPositionAboveTerrain(ref desiredFlyPosition, 0.2f);
			if (time > 0f)
			{
				position = Vector3.SmoothDamp(position, desiredFlyPosition, ref flySmoothVelocity, PhotoMode ? adjustedPhotoModeSmoothtime : gameModeSmoothTime, float.MaxValue, time);
			}
			ClampPositionAboveTerrain(ref position, 0.2f);
		}
		if (!worldJustMoved && time > 0f)
		{
			orbitDistanceSmooth = Mathf.SmoothDamp(orbitDistanceSmooth, orbitDistanceRaw, ref orbitDistanceVel, PhotoMode ? adjustedPhotoModeSmoothtime : gameModeSmoothTime, float.MaxValue, time);
		}
		if (time > 0f)
		{
			fov = Mathf.SmoothDamp(fov, fovRaw, ref fovVelocity, PhotoMode ? adjustedPhotoModeSmoothtime : gameModeSmoothTime, float.MaxValue, time);
		}
	}

	private void ApplyValues()
	{
		if ((bool)CurrentCar)
		{
			if (trainOrbitPosRawT < 0f)
			{
				DoEndT(forward: false);
			}
			else if (trainOrbitPosRawT > 1f)
			{
				DoEndT(forward: true);
			}
			orbitCollision = false;
			Vector3 vector = position;
			position = trainOrbitPosSmooth + Quaternion.Euler(rotX, rotY, 0f) * new Vector3(0f, 0f, 0f - orbitDistanceSmooth);
			position = WorldBoundaryEnforcer.ClampVector(trainOrbitPosSmooth, position);
			Ray ray = new Ray(vector, (position - vector).normalized);
			RaycastHit hitInfo;
			bool flag = Physics.SphereCast(ray, 0.3f, out hitInfo, Vector3.Distance(position, vector), cameraCollisionLayer);
			bool flag2 = CheckSphereCol(position);
			if (!worldJustMoved && ignoreCollisionTimer <= 0f && (flag2 || flag))
			{
				ray = new Ray(trainOrbitPosSmooth, (position - trainOrbitPosSmooth).normalized);
				int num = Physics.SphereCastNonAlloc(ray, 0.3001f, camCollisionCache, orbitDistanceSmooth, cameraCollisionLayer);
				float num2 = 0f;
				RaycastUtils.ExtendOnCacheFull(ref camCollisionCache, num);
				for (int i = 0; i < num; i++)
				{
					RaycastHit raycastHit = camCollisionCache[i];
					if (raycastHit.distance > num2 && raycastHit.distance != orbitDistanceSmooth)
					{
						hitInfo = raycastHit;
						num2 = raycastHit.distance;
					}
				}
				if (num2 != orbitDistanceSmooth && num2 != 0f)
				{
					_ = ray.origin + ray.direction * hitInfo.distance;
					float distance = hitInfo.distance;
					orbitDistanceSmooth = (orbitDistanceRaw = Mathf.Clamp(distance, minOrbitDistance, maxOrbitDistance));
					orbitCollision = true;
					position = trainOrbitPosSmooth + Quaternion.Euler(rotX, rotY, 0f) * new Vector3(0f, 0f, 0f - orbitDistanceSmooth);
				}
			}
			ClampPositionAboveTerrain(ref position, 0.29000002f);
		}
		if (ignoreCollisionTimer > 0f)
		{
			ignoreCollisionTimer -= Time.unscaledDeltaTime;
		}
		cam.fieldOfView = fov;
		void DoEndT(bool forward)
		{
			Coupler coupler = (forward ? CurrentCar.frontCoupler : CurrentCar.rearCoupler);
			if (coupler.IsCoupled())
			{
				trainOrbitPosRawT = (trainOrbitPosRawT + 10f) % 1f;
				if (coupler.coupledTo.isFrontCoupler == forward)
				{
					trainOrbitPosRawT = 1f - trainOrbitPosRawT;
				}
				trainOrbitPosVel = CurrentCar.transform.TransformVector(trainOrbitPosVel);
				CurrentCar = coupler.coupledTo.train;
				trainOrbitLocalPosSmooth = CurrentCar.transform.InverseTransformPoint(trainOrbitPosSmooth);
				trainOrbitPosVel = CurrentCar.transform.InverseTransformVector(trainOrbitPosVel);
			}
			else
			{
				trainOrbitPosRawT = (forward ? 1 : 0);
			}
		}
	}

	private float GetTime()
	{
		if (!SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen || Time.timeScale != 0f)
		{
			return Time.unscaledDeltaTime;
		}
		return 0f;
	}

	private void ClampPositionAboveTerrain(ref Vector3 position, float offset = 0f)
	{
		if (!worldJustMoved)
		{
			float num = GetTerrainHeightAtPos(position);
			if ((bool)CurrentCar)
			{
				num = Mathf.Max(num, LevelInfo.WaterLevel + 0.1f);
			}
			position.y = Mathf.Clamp(position.y, num + offset, float.PositiveInfinity);
		}
	}

	public float GetTerrainHeightAtPos(Vector3 position)
	{
		position.y = 10000f;
		if (Physics.Raycast(position, Vector3.down, out var hitInfo, 10000f, terrainMask))
		{
			return 10000f - hitInfo.distance;
		}
		return 0f;
	}

	public ExternalCameraSavePositionManager.CamPose GetCamPose()
	{
		return new ExternalCameraSavePositionManager.CamPose(new Vector2(trainOrbitSideRawT, trainOrbitHeightRawT), rotX, fovRaw);
	}

	public void TurnOn(Vector3 _pos, Quaternion _rot, bool followCar)
	{
		IsOn = true;
		desiredFlyPosition = _pos;
		position = desiredFlyPosition;
		base.transform.position = position;
		rotation = _rot;
		targetRotY = rotation.eulerAngles.y;
		rotY = targetRotY;
		if (!followCar || !PlayerManager.Car)
		{
			targetRotX = Mathf.DeltaAngle(0f, rotation.eulerAngles.x);
			rotX = targetRotX;
		}
		else
		{
			CurrentCar = PlayerManager.Car;
			if (!ExternalCameraSavePositionManager.TryLoadPosition(out var camPose))
			{
				camPose = new ExternalCameraSavePositionManager.CamPose(default(Vector2), Mathf.DeltaAngle(0f, rotation.eulerAngles.x), desiredFov);
			}
			if (camPose.fov == 0f)
			{
				camPose.fov = desiredFov;
			}
			camPose.fov = Mathf.Clamp(camPose.fov, minFov, maxFov);
			trainOrbitSideRawT = camPose.offset.x;
			trainOrbitHeightRawT = camPose.offset.y;
			targetRotX = camPose.pitch;
			rotX = camPose.pitch;
			desiredFov = camPose.fov;
			trainOrbitPosRawT = 0.5f;
			trainOrbitLocalPosSmooth = GetTrainPos(trainOrbitPosRawT, out var _, trainOrbitHeightRawT, trainOrbitSideRawT);
			trainOrbitLocalPosRaw = trainOrbitLocalPosSmooth;
			trainOrbitPosSmooth = CurrentCar.transform.TransformPoint(trainOrbitLocalPosSmooth);
		}
		transitionSmoothStep = 1f;
		transitionLinear = 1f;
		transitionTime = 0f;
		velocity = Vector3.zero;
		flySmoothVelocity = Vector3.zero;
		ignoreCollisionTimer = 0.5f;
		fov = PlayerManager.PlayerCamera.fieldOfView;
		fovRaw = fov;
		fovVelocity = 0f;
		orbitDistanceSmooth = 3f;
		orbitDistanceRaw = 3f;
		if ((bool)SingletonBehaviour<WorldMover>.Instance)
		{
			SingletonBehaviour<WorldMover>.Instance.WorldMoved += OnWorldMoved;
		}
		streamingController.enabled = true;
	}

	public void TurnOff(float transitionTime)
	{
		if ((bool)CurrentCar)
		{
			SwitchOrbitalToFly();
		}
		SingletonBehaviour<ScreenspaceMouse>.Instance.RemoveRequest(this);
		if ((bool)currentHoveredTrain)
		{
			currentHoveredTrain = null;
			locoMenuProvider.CarChanged(null);
		}
		if ((bool)currentHoveredMachine)
		{
			currentHoveredMachine.SetHighlight(on: false);
			currentHoveredMachine = null;
		}
		currentHoveredTurntable = null;
		turntableProvider.TurntableChanged(null);
		blockFOVChange = true;
		isTurningOff = true;
		turnOffTransitionStartPos = base.transform.position;
		turnOffTransitionStartRot = base.transform.rotation;
		turnOffTransitionTime = transitionTime;
		turnOffTransitionStartTime = Time.time;
	}

	private float GetAxis(int negative, int positive)
	{
		if (InputManager.NewPlayer.GetButton(negative))
		{
			return -1f;
		}
		if (InputManager.NewPlayer.GetButton(positive))
		{
			return 1f;
		}
		return 0f;
	}
}
