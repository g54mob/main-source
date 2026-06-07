using Gh.Tk.UI.Dialogs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gh.Tk
{
	public class QuickRotateScaleController
	{
		private abstract class BaseQuickRotateScaleHandler
		{
			private float _rotateAmountThisFrame;

			private float _scaleAmountThisFrame;

			public float RotateAmountThisFrame
			{
				get
				{
					return 0f;
				}
				protected set
				{
				}
			}

			public float ScaleAmountThisFrame
			{
				get
				{
					return 0f;
				}
				protected set
				{
				}
			}

			public abstract void Start();

			public abstract void Move(InputAction mouseMove);

			public abstract void Stop();

			public abstract void Esc();

			public abstract bool IsRotating();

			public abstract bool IsScaling();
		}

		private abstract class BasePropQuickRotateScaleHandler : BaseQuickRotateScaleHandler
		{
			protected void Rotate(InputAction mouseMove, Buildable buildable)
			{
			}
		}

		private class EditBuildableTemplateUIRotateHandler : BasePropQuickRotateScaleHandler
		{
			private bool _isRotating;

			private TemplateDataDialog3DUIView _dialog;

			public override void Start()
			{
			}

			public override void Move(InputAction mouseMove)
			{
			}

			private void UpdateMode(InputAction mouseMove)
			{
			}

			public override void Stop()
			{
			}

			public override void Esc()
			{
			}

			public override bool IsRotating()
			{
				return false;
			}

			public override bool IsScaling()
			{
				return false;
			}
		}

		private class BuildPropQuickRotateScaleHandler : BasePropQuickRotateScaleHandler
		{
			private bool _isRotating;

			public override void Start()
			{
			}

			public override void Move(InputAction mouseMove)
			{
			}

			public override void Stop()
			{
			}

			public override void Esc()
			{
			}

			public override bool IsRotating()
			{
				return false;
			}

			public override bool IsScaling()
			{
				return false;
			}
		}

		private class EditPropQuickRotateScaleHandler : BasePropQuickRotateScaleHandler
		{
			private bool _isRotating;

			private bool _dontRotate;

			private BuildController _bc;

			public Buildable CurrentBuildable { get; set; }

			public override void Start()
			{
			}

			public override void Move(InputAction mouseMove)
			{
			}

			public override void Stop()
			{
			}

			private void InternalStop(bool cancel = false)
			{
			}

			public override void Esc()
			{
			}

			public override bool IsRotating()
			{
				return false;
			}

			public override bool IsScaling()
			{
				return false;
			}
		}

		private class PlaceDecorationQuickRotateScaleHandler : BaseQuickRotateScaleHandler
		{
			private bool _isRotating;

			private bool _isScaling;

			public override void Start()
			{
			}

			private Quaternion GetDesiredRotationChange(InputAction mouseMove)
			{
				return default(Quaternion);
			}

			public override void Move(InputAction mouseMove)
			{
			}

			private void UpdateMode(InputAction mouseMove)
			{
			}

			public override void Stop()
			{
			}

			public override void Esc()
			{
			}

			public override bool IsRotating()
			{
				return false;
			}

			public override bool IsScaling()
			{
				return false;
			}

			private void StopInternal()
			{
			}
		}

		private class DecorationQuickRotateScaleHandler : BaseQuickRotateScaleHandler
		{
			private bool _isRotating;

			private bool _isScaling;

			private quaternion _oldRotation;

			private float3 _oldLossyScale;

			public EntityObject EntityObject { get; set; }

			public InputAction ShiftButton { get; set; }

			public InputAction AlternateButton { get; set; }

			public override void Start()
			{
			}

			private Quaternion GetDesiredRotationChange(InputAction mouseMove)
			{
				return default(Quaternion);
			}

			public Vector3 GetDirection(bool right)
			{
				return default(Vector3);
			}

			public override void Move(InputAction mouseMove)
			{
			}

			private void UpdateMode(InputAction mouseMove)
			{
			}

			public override void Stop()
			{
			}

			public override void Esc()
			{
			}

			public override bool IsRotating()
			{
				return false;
			}

			public override bool IsScaling()
			{
				return false;
			}

			private void StopInternal()
			{
			}
		}

		private static InputController _ic;

		public static Vector2 LastMousePositionPreFreeRotate;

		public static Vector3 LastMouseCoordsPreQuickAction;

		private static BaseQuickRotateScaleHandler _currentHandler;

		private readonly EditBuildableTemplateUIRotateHandler _buildableTemplateUIRotateHandler;

		private readonly BuildPropQuickRotateScaleHandler _buildPropHandler;

		private readonly EditPropQuickRotateScaleHandler _editPropHandler;

		private readonly PlaceDecorationQuickRotateScaleHandler _placeDecorationHandler;

		private readonly DecorationQuickRotateScaleHandler _decorationQuickRotateScaleHandler;

		public static bool IsActive;

		private static bool _startedMoving;

		private InputAction _mouseMove;

		private static float _previousRotationSoundAngle;

		public static bool IsRotating => false;

		public static float RotateAmount => 0f;

		public static bool IsScaling => false;

		public static float ScaleAmount => 0f;

		private void OnInputControllerReady()
		{
		}

		private static void PlayRotationSound(float angle, GameObject gameObject)
		{
		}

		private static void PlayScaleSound(float scaleDelta, GameObject gameObject)
		{
		}

		private static void ResetSFXData()
		{
		}

		private static void OnLeftMouseUp(object sender, InputController.MouseClickEventArgs e)
		{
		}

		public static void EnableQuickMoveInput()
		{
		}

		private static void DisableQuickMoveInput()
		{
		}

		public void ForceStart()
		{
		}

		private void OnQuickEditButtonPressed()
		{
		}

		public static void Stop()
		{
		}
	}
}
