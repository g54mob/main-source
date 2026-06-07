using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	public class CarControllerInput : InitializePlayer, ICarControl
	{
		public float HorizontalChangeSpeed;

		public bool RotateCameraWithMousePressed;

		[Header("Key binding settings")]
		public bool UseBindingsFromInputManager;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public string HorizontalAxis;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public string VerticalAxis;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode PichUpKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode PichDownKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode NextGearKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode PrevGearKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode SwitchLightsKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode SwitchLeftTurnLightsKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode SwitchRightTurnLightsKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode SwitchAlarmKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode ConnectTrailerKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode ResetCarKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode RestoreCarKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode ChangeViewKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode HandBrakeKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode BoostKey;

		[HideInInspectorIf("UseBindingsFromInputManager", true)]
		public KeyCode EnterExitKey;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string SteerAxis;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string AccelerationAxis;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string BrakeReverseAxis;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string PitchAxis;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string NextGearButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string PrevGearButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string SwitchLightsButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string SwitchLeftTurnLightsButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string SwitchRightTurnLightsButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string SwitchAlarmButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string ConnectTrailerButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string ResetCarButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string RestoreCarButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string ChangeViewButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string HandBrakeButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string BoostButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string EnterExitButton;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string DpadX;

		[ShowInInspectorIf("UseBindingsFromInputManager")]
		public string DpadY;

		public string MouseX;

		public string MouseY;

		private float TargetHorizontal;

		private CarLighting CarLighting;

		private int TouchCount;

		private Touch Touch;

		private int RotateTouchId;

		public static int GamepadP1no;

		public static int GamepadP2no;

		private Vector2Int PrevDpadValue;

		private bool DpadLeftDown;

		private bool DpadRightDown;

		public float Horizontal { get; private set; }

		public float Acceleration { get; private set; }

		public float BrakeReverse { get; private set; }

		public float Pitch { get; private set; }

		public bool HandBrake { get; private set; }

		public bool Boost { get; private set; }

		public Vector2 ViewDelta { get; private set; }

		public bool ManualCameraRotation { get; private set; }

		public bool IsFirstPlayer { get; private set; }

		public event Action OnChangeViewAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private event Action OnDestroyAction
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void RegisterEvents()
		{
		}

		private void UnRegisterEvents()
		{
		}

		private void OnGasAction(float value)
		{
		}

		private void OnBrakeAction(float value)
		{
		}

		public void OnHandBrake(bool value)
		{
		}

		private void OnSteeringAction(float steerValue)
		{
		}

		private void OnExitVehicleAction()
		{
		}

		public void ForceExitFromCar(PlayerInstance playerInstance)
		{
		}

		private void OnLookAroundAction(Vector2 lookAround)
		{
		}

		private void OnResetVehicleAction()
		{
		}

		private void OnOpenMapAction()
		{
		}

		private void UpdateKeys()
		{
		}

		private void UpdateDpad()
		{
		}

		private void OnDestroy()
		{
		}

		public override bool Initialize(VehicleController car)
		{
			return false;
		}

		public override void Uninitialize()
		{
		}

		public void SetAcceleration(float value)
		{
		}

		public void SetBrakeReverse(float value)
		{
		}

		public void SetSteer(float value)
		{
		}

		public void SetPitch(float value)
		{
		}

		public void NextGear()
		{
		}

		public void PrevGear()
		{
		}

		public void SwitchLights()
		{
		}

		public void SwitchLeftTurnSignal()
		{
		}

		public void SwitchRightTurnSignal()
		{
		}

		public void SwitchAlarm()
		{
		}

		public void ConnectTrailer()
		{
		}

		public void ResetCar()
		{
		}

		public void RestoreCar()
		{
		}

		public void ChangeView()
		{
		}

		public void TryExitFromCar()
		{
		}

		public void SetViewDelta(Vector2 value)
		{
		}

		public void SetHandBrake(bool value)
		{
		}

		public void SetBoost(bool value)
		{
		}

		private bool IsPointerOverUIObject(Vector3 touchPos)
		{
			return false;
		}
	}
}
