using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Manager;
using NSMedieval.Managers.Selection;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Structs;
using NSMedieval.Tutorial;
using NSMedieval.UI;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval
{
	public class RtsCamera : MonoSingleton<RtsCamera>, IObserver
	{
		public delegate void CameraUpdate();

		private const float ZoomedInMoveCorrection = 0.16f;

		private const float UpdateSensitivity = 0.01f;

		private CameraSettings settings;

		private Vector3 desiredPosition;

		private Vector3 currentPosition;

		private Vector3 moveVector;

		private readonly Vector3 followTargetOffset = new Vector3(0f, 1.5f, 0f);

		private float desiredHeight;

		private float desiredRotation;

		private float desiredTilt;

		private float currentHeight;

		private float currentRotation;

		private float currentTilt;

		private float movementCorrection;

		private float tiltPercent;

		private float minTilt;

		private float camSensitivity;

		private Vector3 initialPosition;

		[SerializeField]
		private Vector3 minBounds;

		[SerializeField]
		private Vector3 maxBounds;

		[SerializeField]
		private LayerMask cameraTerrainPhysicsLayerMask;

		[SerializeField]
		private LayerMask targetTerainPhysicsLayerMask;

		[SerializeField]
		private bool zoomOnFollow = true;

		[SerializeField]
		private float zoomFollowTilt = 30f;

		[SerializeField]
		private float zooomFollowHeight = 18f;

		private Transform targetToFollow;

		private bool wasFollowing;

		private bool blockCameraMovement;

		[SerializeField]
		private bool jumping;

		[Header("Move to next Layer")]
		[SerializeField]
		private GridHolder raycastShape;

		[SerializeField]
		private int moveToNextLayerThresholdT1 = 9;

		[SerializeField]
		private int moveToNextLayerThresholdT2 = 6;

		[Header("Room-based culling")]
		[SerializeField]
		[Tooltip("Beyond this distance from the camera, all rooms will be called, regardless of the rest of the culling rules")]
		private float maxRoomContentRenderDistance;

		private int hitsT1;

		private int hitsT2;

		private int desiredLayer;

		private int currentLayer;

		private int lockedLayerIndex = 15;

		private bool lockedToLayer;

		private float previousHeight;

		private float lerpSpeed = 1f;

		private IDisposable _disposableImplementation;

		public Transform TargetToFollow => targetToFollow;

		public float MaxRoomContentRenderDistance => maxRoomContentRenderDistance;

		public bool Jumping => jumping;

		public int LockedLayerIndex => lockedLayerIndex;

		public bool LockedToLayer => lockedToLayer;

		public float DesiredHeight => desiredHeight;

		public float DesiredRotation => desiredRotation;

		public float CurrentRotation => currentRotation;

		public float AimHeight
		{
			get
			{
				int num = Mathf.RoundToInt(GetHeightAt(currentPosition.x, currentPosition.z, targetTerainPhysicsLayerMask));
				switch (num % World.MapBlockHeight)
				{
				case 1:
					num--;
					return num;
				case 2:
					num++;
					return num;
				default:
					return num;
				}
			}
		}

		public Vector3 CurrentPosition => currentPosition;

		public Vector3 DesiredPosition => desiredPosition;

		public bool FastCameraMove { get; set; }

		public Vector3 MovementAxis { get; private set; } = Vector3.zero;

		private float RotationAxis { get; set; }

		private float ZoomAxis { get; set; }

		private float TiltAxis { get; set; }

		public CameraSettings Settings => settings;

		public float MovementCorrection => movementCorrection;

		public Vector3 InitialPosition
		{
			set
			{
				initialPosition = value;
			}
		}

		public float CurrentHeightNormalized
		{
			get
			{
				if (!base.isActiveAndEnabled || settings.HeightRange == null)
				{
					return 0f;
				}
				return (currentHeight - settings.HeightRange.Min) / (settings.HeightRange.Max - settings.HeightRange.Min);
			}
		}

		public event CameraUpdate CameraUpdateEvent;

		public event Action LockedLayerChangedEvent;

		public event Action LockedLayerUpEvent;

		public event Action LockedLayerDownEvent;

		public event Action CameraJumpToEvent;

		public event Action<float> CameraPositionEvent;

		public event Action<float> CameraRotationEvent;

		public event Action<float> CameraHeightEvent;

		public void OnLockedLayerUpEvent()
		{
			this.LockedLayerUpEvent?.Invoke();
		}

		public void OnLockedLayerDownEvent()
		{
			this.LockedLayerDownEvent?.Invoke();
		}

		public void OnLockedLayerChangedEvent(int value)
		{
			lockedLayerIndex = value;
			this.LockedLayerChangedEvent?.Invoke();
			GlobalSaveController.CurrentVillageData.LockedLayerIndex = value;
		}

		public void OnCameraLayerLockedEvent(bool value)
		{
			lockedToLayer = value;
			int num = (int)desiredPosition.y / World.MapBlockHeight;
			lockedLayerIndex = num;
			GlobalSaveController.CurrentVillageData.CameraLockedToLayer = value;
		}

		public void BlockCameraMovement(bool block)
		{
			blockCameraMovement = block;
		}

		public void SetCameraBounds(Vector3 min, Vector3 max)
		{
			minBounds = min;
			maxBounds = max;
		}

		public void CancelFollow()
		{
			targetToFollow = null;
		}

		public void JumpToAndFollow(Transform target)
		{
			if (zoomOnFollow)
			{
				desiredHeight = zooomFollowHeight;
				desiredTilt = zoomFollowTilt;
				tiltPercent = Mathf.InverseLerp(minTilt, settings.MaxTilt, desiredTilt);
			}
			targetToFollow = target;
			if (lockedToLayer)
			{
				lockedToLayer = false;
				this.CameraJumpToEvent?.Invoke();
			}
		}

		public void ChangeFollowTarget(Transform target)
		{
			if (!(targetToFollow == null))
			{
				targetToFollow = target;
			}
		}

		public void JumpTo(Vector3 position, bool snap = false)
		{
			jumping = true;
			desiredPosition = position;
			if (snap)
			{
				currentPosition = position;
			}
			if (lockedToLayer)
			{
				lockedToLayer = false;
				this.CameraJumpToEvent?.Invoke();
			}
		}

		public CameraData GetCameraData()
		{
			if (movementCorrection == 0f)
			{
				return null;
			}
			return new CameraData(currentPosition, currentHeight, currentRotation, currentTilt);
		}

		public void OnCameraReset()
		{
			ResetToDefaultValues();
		}

		public void AddToPosition(float dx, float dy, float dz)
		{
			if (TutorialManager.IsTutorialActive)
			{
				float num = Mathf.Abs(moveVector.magnitude - new Vector3(dx, dy, dz).magnitude);
				if (num > 0.1f)
				{
					this.CameraPositionEvent?.Invoke(num);
				}
			}
			moveVector.x += dx;
			moveVector.y += dy;
			moveVector.z += dz;
		}

		public void UpdateTilt(float tiltChangeAmount)
		{
			if (tiltChangeAmount != 0f)
			{
				desiredTilt += tiltChangeAmount;
				tiltPercent = Mathf.InverseLerp(minTilt, settings.MaxTilt, desiredTilt);
			}
		}

		public void SetCameraJump(Vector3 desiredPosition, float desiredHeight, float desiredRotation, float desiredTilt)
		{
			this.desiredPosition = desiredPosition;
			this.desiredHeight = desiredHeight;
			this.desiredRotation = desiredRotation;
			this.desiredTilt = desiredTilt;
			tiltPercent = Mathf.InverseLerp(minTilt, settings.MaxTilt, this.desiredTilt);
		}

		public void SetCameraDirect(Vector3 desiredPosition, float desiredHeight, float desiredRotation, float desiredTilt)
		{
			currentPosition = desiredPosition;
			currentHeight = desiredHeight;
			currentRotation = desiredRotation;
			currentTilt = desiredTilt;
			SetCameraJump(desiredPosition, desiredHeight, desiredRotation, desiredTilt);
		}

		public void SetDesiredHeight(float value)
		{
			if (TutorialManager.IsTutorialActive)
			{
				float num = Mathf.Abs(desiredHeight - value);
				if (num > 0.1f)
				{
					this.CameraHeightEvent?.Invoke(num);
				}
			}
			desiredHeight = value;
		}

		public void SetDesiredRotation(float value)
		{
			if (TutorialManager.IsTutorialActive)
			{
				float num = Mathf.Abs(desiredRotation - value);
				if (num > 0.1f)
				{
					this.CameraRotationEvent?.Invoke(num);
				}
			}
			desiredRotation = value;
		}

		public void SetMovementAxis(Vector3 newValue)
		{
			MovementAxis = newValue;
		}

		private void SetInitialPosition()
		{
			desiredPosition = initialPosition;
		}

		private void OnCameraChange(CameraType cameraType)
		{
			switch (cameraType)
			{
			case CameraType.PhotoMode:
				settings = Repository<PhotoCameraSettingsData, CameraSettings>.Instance.GetData<CameraSettings>();
				break;
			case CameraType.StructurePresetMode:
				settings = Repository<StructurePresetCameraSettingsData, CameraSettings>.Instance.GetData<CameraSettings>();
				break;
			default:
				settings = Repository<GameplayCameraSettingsData, CameraSettings>.Instance.GetData<CameraSettings>();
				break;
			}
		}

		private void UpdateLayerMask()
		{
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraOffsetByBuildings)
			{
				targetTerainPhysicsLayerMask = (int)targetTerainPhysicsLayerMask | 0x1000000;
			}
			else
			{
				targetTerainPhysicsLayerMask = (int)targetTerainPhysicsLayerMask & -16777217;
			}
		}

		private void InitializeCamera()
		{
			OnCameraChange(CameraType.Gameplay);
			camSensitivity = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraSensitivity;
			lockedToLayer = GlobalSaveController.CurrentVillageData.CameraLockedToLayer;
			lockedLayerIndex = GlobalSaveController.CurrentVillageData.LockedLayerIndex;
			if (GlobalSaveController.CurrentVillageData.FirstEnter)
			{
				ResetToDefaultValues();
				SetInitialPosition();
			}
			else
			{
				CameraData cameraData = GlobalSaveController.CurrentVillageData.CameraData;
				if (cameraData != null)
				{
					desiredPosition = cameraData.Position;
					desiredHeight = cameraData.Height;
					desiredRotation = cameraData.Rotation;
					desiredTilt = cameraData.Tilt;
				}
				else
				{
					ResetToDefaultValues();
					SetInitialPosition();
				}
				if (GlobalSaveController.CurrentVillageData.IsSecondMap)
				{
					KeyValuePair<HumanoidInstance, WorkerView> keyValuePair = MonoSingleton<WorkerManager>.Instance.AllWorkers.PickRandom();
					if (keyValuePair.Value != null)
					{
						JumpToAndFollow(null);
						JumpTo(keyValuePair.Value.transform.position, snap: true);
					}
				}
			}
			currentHeight = desiredHeight;
			currentRotation = desiredRotation;
			currentTilt = desiredTilt;
			currentPosition = desiredPosition;
			previousHeight = desiredPosition.y;
			CalculateMovementCorrection();
			MonoSingleton<CameraVisuals>.Instance.SetupCameraVisuals();
			UpdateLayerMask();
		}

		private void CalculateMovementCorrection()
		{
			movementCorrection = Mathf.Lerp(0.16f, 1f, Mathf.InverseLerp(settings.HeightRange.Min, settings.HeightRange.Max, currentHeight));
		}

		private void ResetToDefaultValues()
		{
			desiredHeight = settings.DefaultHeight;
			desiredRotation = settings.DefaultRotation;
			desiredTilt = settings.DefaultTilt;
			tiltPercent = Mathf.InverseLerp(settings.DefaultMinTilt, settings.MaxTilt, desiredTilt);
			MonoSingleton<CameraVisuals>.Instance.ResetVisuals();
		}

		private float GetHeightAt(float x, float z, LayerMask mask)
		{
			float maxDistance = maxBounds.y - minBounds.y + 1f;
			if (Physics.Raycast(new Vector3(x, maxBounds.y, z), new Vector3(0f, -1f, 0f), out var hitInfo, maxDistance, mask))
			{
				return hitInfo.point.y;
			}
			return 0f;
		}

		private void UpdateKeyboardInput(float deltaTime)
		{
			float num = (FastCameraMove ? (settings.KeyboardFastMoveSpeed * camSensitivity) : (settings.KeyboardMoveSpeed * camSensitivity));
			Vector3 vector = MovementAxis.normalized * (num * movementCorrection * deltaTime);
			AddToPosition(vector.x, vector.y, vector.z);
			desiredRotation += RotationAxis * settings.KeyboardRotateSpeed * camSensitivity * deltaTime;
			desiredHeight += ZoomAxis * settings.KeyboardZoomSpeed * camSensitivity * deltaTime;
			UpdateTilt(TiltAxis * settings.KeyboardTiltSpeed * camSensitivity * deltaTime);
			if (Input.GetMouseButtonDown(1))
			{
				MonoSingleton<CameraVisuals>.Instance.OnRightClickShowVisuals();
			}
			if (Input.GetMouseButtonUp(1))
			{
				MonoSingleton<CameraVisuals>.Instance.OnHideTranslateVisuals();
			}
			if (Input.GetMouseButtonDown(2))
			{
				MonoSingleton<CameraVisuals>.Instance.OnMiddleClickShowVisuals();
			}
			if (Input.GetMouseButtonUp(2))
			{
				MonoSingleton<CameraVisuals>.Instance.OnHideRotateVisuals();
			}
			if (Input.GetMouseButton(1))
			{
				CancelFollow();
			}
		}

		private void UpdateEdgeMovingInput(float deltaTime)
		{
			if (MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.ScreenEdgeMouseScroll && MonoSingleton<InputManager>.Instance.InputEnabled)
			{
				if (Input.mousePosition.y > (float)Screen.height - settings.ScreenEdgeBorderUp * (float)Screen.height)
				{
					AddToPosition(0f, 0f, settings.MouseMoveSpeed * camSensitivity * deltaTime);
				}
				else if (Input.mousePosition.y < settings.ScreenEdgeBorderDown * (float)Screen.height)
				{
					AddToPosition(0f, 0f, (0f - settings.MouseMoveSpeed) * camSensitivity * deltaTime);
				}
				if (Input.mousePosition.x > (float)Screen.width - settings.ScreenEdgeBorderRight * (float)Screen.width)
				{
					AddToPosition(settings.MouseMoveSpeed * camSensitivity * deltaTime, 0f, 0f);
				}
				else if (Input.mousePosition.x < settings.ScreenEdgeBorderLeft * (float)Screen.width)
				{
					AddToPosition((0f - settings.MouseMoveSpeed) * camSensitivity * deltaTime, 0f, 0f);
				}
			}
		}

		private void CalculateDesiredPosition()
		{
			moveVector.y = 0f;
			desiredPosition += Quaternion.Euler(0f, desiredRotation, 0f) * moveVector * camSensitivity;
			LayerMask mask = targetTerainPhysicsLayerMask;
			if (!MonoSingleton<SelectionManager>.Instance.Selecting && !MonoSingleton<BuildingPlacementManager>.Instance.MouseDown)
			{
				desiredPosition.y = GetHeightAt(desiredPosition.x, desiredPosition.z, mask);
			}
			DesiredPositionForCoyoteCamera();
			if (!MonoSingleton<SelectionManager>.Instance.Selecting && !MonoSingleton<BuildingPlacementManager>.Instance.MouseDown)
			{
				desiredPosition.y += settings.LookAtHeightOffset;
			}
		}

		public bool ShouldCameraMoveToTargetLayer()
		{
			LayerMask mask = targetTerainPhysicsLayerMask;
			hitsT1 = 0;
			hitsT2 = 0;
			int num = Mathf.RoundToInt(currentPosition.x);
			int num2 = Mathf.RoundToInt(currentPosition.z);
			int num3 = Mathf.RoundToInt(GetHeightAt(num, num2, mask));
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (raycastShape.grid[i].values[j] != Elements.off)
					{
						int num4 = i - 2;
						int num5 = j - 2;
						int num6 = Mathf.RoundToInt(GetHeightAt(num + num4, num2 + num5, mask));
						desiredLayer = num3;
						if (num6 == desiredLayer)
						{
							hitsT2++;
						}
						currentLayer = Mathf.FloorToInt(currentPosition.y);
						if (num6 != currentLayer)
						{
							hitsT1++;
						}
					}
				}
			}
			if (hitsT1 >= moveToNextLayerThresholdT1 && hitsT2 >= moveToNextLayerThresholdT2)
			{
				return true;
			}
			return false;
		}

		private void DesiredPositionForCoyoteCamera()
		{
			if (jumping)
			{
				if (MathF.Abs(desiredPosition.magnitude - currentPosition.magnitude) >= 0.2f)
				{
					return;
				}
				jumping = false;
				previousHeight = Mathf.RoundToInt(currentPosition.y);
			}
			if (lockedToLayer)
			{
				desiredPosition.y = lockedLayerIndex * World.MapBlockHeight;
				if (MonoSingleton<SelectionManager>.Instance.Selecting || MonoSingleton<BuildingPlacementManager>.Instance.MouseDown)
				{
					desiredPosition.y += settings.LookAtHeightOffset;
				}
			}
			else
			{
				if (MonoSingleton<SelectionManager>.Instance.Selecting || MonoSingleton<BuildingPlacementManager>.Instance.MouseDown)
				{
					return;
				}
				desiredPosition.y = Mathf.RoundToInt(desiredPosition.y);
				switch ((int)desiredPosition.y % World.MapBlockHeight)
				{
				case 1:
					desiredPosition.y -= 1f;
					break;
				case 2:
					desiredPosition.y += 1f;
					break;
				}
				if (Mathf.Abs(Mathf.RoundToInt(desiredPosition.y) - Mathf.RoundToInt(previousHeight)) >= World.MapBlockHeight && !MonoSingleton<CameraVisuals>.Instance.Lerping)
				{
					desiredPosition.y = previousHeight;
				}
				else
				{
					desiredPosition.y = (previousHeight = Mathf.FloorToInt(currentPosition.y));
				}
				LayerMask mask = targetTerainPhysicsLayerMask;
				if (wasFollowing && targetToFollow == null)
				{
					wasFollowing = false;
					previousHeight = (desiredPosition.y = GetHeightAt(desiredPosition.x, desiredPosition.z, mask));
				}
				if (MonoSingleton<CameraVisuals>.Instance.Lerping)
				{
					if (ShouldCameraMoveToTargetLayer())
					{
						desiredPosition.y = GetHeightAt(desiredPosition.x, desiredPosition.z, mask);
					}
					lerpSpeed = MonoSingleton<CameraVisuals>.Instance.LerpSpeed;
				}
			}
		}

		private void ClampDesiredValues()
		{
			desiredHeight = Mathf.Clamp(desiredHeight, settings.HeightRange.Min, settings.HeightRange.Max);
			desiredPosition = new Vector3(Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x), Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y), Mathf.Clamp(desiredPosition.z, minBounds.z, maxBounds.z));
			minTilt = Mathf.Lerp(settings.MinTiltRange.Min, settings.MinTiltRange.Max, Mathf.InverseLerp(settings.HeightRange.Min, settings.HeightRange.Max, desiredHeight));
			desiredTilt = Mathf.Lerp(minTilt, settings.MaxTilt, tiltPercent);
		}

		private void UpdateCameraValues(float deltaTime)
		{
			CalculateDesiredPosition();
			ClampDesiredValues();
			if (targetToFollow == null && !MonoSingleton<InputManager>.Instance.InputEnabled && !TutorialManager.IsTutorialActive)
			{
				desiredPosition = currentPosition;
				desiredRotation = currentRotation;
				desiredHeight = currentHeight;
				desiredTilt = currentTilt;
			}
			if (targetToFollow != null && !CameraControlInput())
			{
				wasFollowing = true;
				desiredPosition = targetToFollow.position + followTargetOffset;
			}
			if (settings.Smoothing)
			{
				if (Mathf.Abs(currentRotation - desiredRotation) >= 0.01f)
				{
					currentRotation = Mathf.LerpAngle(currentRotation, desiredRotation, 1f - Mathf.Exp((0f - settings.RotationDampening) * deltaTime));
				}
				if (Mathf.Abs(currentHeight - desiredHeight) >= 0.01f)
				{
					currentHeight = Mathf.Lerp(currentHeight, desiredHeight, 1f - Mathf.Exp((0f - settings.ZoomDampening) * deltaTime));
				}
				if (Mathf.Abs(currentTilt - desiredTilt) >= 0.01f)
				{
					currentTilt = Mathf.LerpAngle(currentTilt, desiredTilt, 1f - Mathf.Exp((0f - settings.TiltDampening) * deltaTime));
				}
				if (settings.MoveSmoothing)
				{
					float num = 0.01f;
					float num2 = Mathf.Sin(settings.MoveDampening * num * MathF.PI) / 2f;
					currentPosition.x = Mathf.Lerp(currentPosition.x, desiredPosition.x, num2);
					currentPosition.y = Mathf.Lerp(currentPosition.y, desiredPosition.y, num2 * lerpSpeed);
					currentPosition.z = Mathf.Lerp(currentPosition.z, desiredPosition.z, num2);
				}
				else
				{
					currentPosition = desiredPosition;
				}
			}
			else
			{
				currentRotation = desiredRotation;
				currentHeight = desiredHeight;
				currentTilt = desiredTilt;
				currentPosition = desiredPosition;
			}
			moveVector = Vector3.zero;
		}

		private void UpdateCameraTransform()
		{
			Quaternion quaternion = Quaternion.Euler(currentTilt, currentRotation, 0f);
			Vector3 position = quaternion * new Vector3(0f, 0f, 0f - currentHeight) + currentPosition;
			float num = GetHeightAt(position.x, position.z, cameraTerrainPhysicsLayerMask) + 1f;
			if (num > position.y)
			{
				position.y = num;
			}
			Transform obj = base.transform;
			obj.rotation = quaternion;
			obj.position = position;
			CalculateMovementCorrection();
		}

		private bool CameraControlInput()
		{
			if (RotationAxis == 0f && ZoomAxis == 0f)
			{
				return TiltAxis != 0f;
			}
			return true;
		}

		private void Start()
		{
			MonoSingleton<SceneController>.Instance.SceneSetup += OnSceneSetup;
			MonoSingleton<OptionsController>.Instance.SetCameraOffsetByBuildingsEvent += UpdateLayerMask;
		}

		private void OnSceneSetup()
		{
			InitializeCamera();
			MonoSingleton<SceneController>.Instance.UnscaledTick += OnUnscaledTick;
			MonoSingleton<GlobalSaveController>.Instance.OnGlobalSaveUpdate += OnGlobalSaveUpdate;
			MonoSingleton<CameraManager>.Instance.CameraTypeChangedAction += OnCameraChange;
		}

		private void OnUnscaledTick(float unscaledDeltaTime)
		{
			if (!blockCameraMovement)
			{
				UpdateKeyboardInput(unscaledDeltaTime);
				UpdateEdgeMovingInput(unscaledDeltaTime);
				UpdateCameraValues(unscaledDeltaTime);
				UpdateCameraTransform();
				this.CameraUpdateEvent?.Invoke();
			}
		}

		private void OnGlobalSaveUpdate()
		{
			camSensitivity = MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.CameraSensitivity;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
				MonoSingleton<SceneController>.Instance.UnscaledTick -= OnUnscaledTick;
			}
			if (MonoSingleton<OptionsController>.IsInstantiated())
			{
				MonoSingleton<OptionsController>.Instance.SetCameraOffsetByBuildingsEvent -= UpdateLayerMask;
			}
			if (MonoSingleton<GlobalSaveController>.IsInstantiated())
			{
				MonoSingleton<GlobalSaveController>.Instance.OnGlobalSaveUpdate -= OnGlobalSaveUpdate;
			}
			if (MonoSingleton<CameraManager>.IsInstantiated())
			{
				MonoSingleton<CameraManager>.Instance.CameraTypeChangedAction -= OnCameraChange;
			}
			this.CameraUpdateEvent = null;
			this.LockedLayerChangedEvent = null;
			this.LockedLayerUpEvent = null;
			this.LockedLayerDownEvent = null;
			this.CameraJumpToEvent = null;
		}
	}
}
