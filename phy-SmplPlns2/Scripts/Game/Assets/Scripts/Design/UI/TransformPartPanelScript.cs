using Assets.Scripts.Craft.Parts;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class TransformPartPanelScript : DesignerPanelScript
	{
		private const string NudgeNumericFormat = "n4";

		private Vector3 _lastSelectionPosition = Vector3.zero;

		private Vector3 _lastSelectionRotation = Vector3.zero;

		private NumericSpinnerControl _nudgeControlX;

		private NumericSpinnerControl _nudgeControlY;

		private NumericSpinnerControl _nudgeControlZ;

		private RotationControlScript _rotateControlX;

		private RotationControlScript _rotateControlY;

		private RotationControlScript _rotateControlZ;

		private SpinnerControl _selectionSpinner;

		private NumericSpinnerControl _spinnerAmountNudge;

		private NumericSpinnerControl _spinnerAmountRotation;

		public bool InConnectedMode => _selectionSpinner.Value == "Connected Parts";

		public float NudgeAmount
		{
			get
			{
				return Game.Instance.Settings.Gameplay.Designer.NudgeDistance.Value;
			}
			set
			{
				Game.Instance.Settings.Gameplay.Designer.NudgeDistance.Value = value;
			}
		}

		public float RotateAmount
		{
			get
			{
				return Game.Instance.Settings.Gameplay.Designer.RotateAmount.Value;
			}
			set
			{
				Game.Instance.Settings.Gameplay.Designer.RotateAmount.Value = value;
				UpdateRotationSlidersSteps();
			}
		}

		private Transform SelectedTransform => base.Designer?.SelectedPart?.transform;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			_selectionSpinner = new SpinnerControl(base.Widget.FindWidget("spinner-selection"));
			_selectionSpinner.Values.Add("Selected Part");
			_selectionSpinner.Values.Add("Connected Parts");
			_selectionSpinner.Value = "Selected Part";
			_selectionSpinner.OnValueChanged = delegate
			{
				designerUI.DesignerScript.Designer.Tools.MovePartTool.InConnectedMode = InConnectedMode;
			};
			_rotateControlX = CreateRotationControl("x");
			_rotateControlY = CreateRotationControl("y");
			_rotateControlZ = CreateRotationControl("z");
			_nudgeControlX = CreateNudgeControl("spinner-nudge-x");
			_nudgeControlY = CreateNudgeControl("spinner-nudge-y");
			_nudgeControlZ = CreateNudgeControl("spinner-nudge-z");
			_spinnerAmountRotation = new NumericSpinnerControl(base.Widget.FindWidget("spinner-rotation-amount"));
			_spinnerAmountRotation.NumericFormat = "n4";
			_spinnerAmountRotation.MinValue = 0.001f;
			_spinnerAmountRotation.MaxValue = 180f;
			_spinnerAmountRotation.StepSize = 5f;
			_spinnerAmountRotation.OnValueChanged = delegate(float _, float x)
			{
				RotateAmount = x;
			};
			_spinnerAmountRotation.GetIncrementAmount = () => RotateAmount;
			_spinnerAmountRotation.GetDecrementAmount = () => RotateAmount / 2f;
			_spinnerAmountNudge = new NumericSpinnerControl(base.Widget.FindWidget("spinner-nudge-amount"));
			_spinnerAmountNudge.NumericFormat = "n3";
			_spinnerAmountNudge.MinValue = 0.0001f;
			_spinnerAmountNudge.MaxValue = 10f;
			_spinnerAmountNudge.StepSize = 0.5f;
			_spinnerAmountNudge.OnValueChanged = delegate(float _, float x)
			{
				NudgeAmount = x;
			};
			_spinnerAmountNudge.GetIncrementAmount = () => NudgeAmount;
			_spinnerAmountNudge.GetDecrementAmount = () => NudgeAmount / 2f;
			base.Designer.SelectedPartChangedEvent += OnSelectedPartChangedEvent;
			base.Flyout.Opened += OnPanelStateChanged;
			base.Flyout.Closed += OnPanelStateChanged;
		}

		public void UpdatePartRotation()
		{
			SetRotation(_rotateControlX.Value, _rotateControlY.Value, _rotateControlZ.Value);
			_lastSelectionRotation = GetSelectionRotation();
		}

		public void UpdateRotationGUI()
		{
			Vector3 selectionRotation = GetSelectionRotation();
			_rotateControlX.Value = Utilities.LimitAngle180(selectionRotation.x);
			_rotateControlY.Value = Utilities.LimitAngle180(selectionRotation.y);
			_rotateControlZ.Value = Utilities.LimitAngle180(selectionRotation.z);
			_lastSelectionRotation = selectionRotation;
		}

		protected virtual void Update()
		{
			if (GetSelectionPosition() != _lastSelectionPosition)
			{
				UpdatePositionsGUI();
			}
			if (GetSelectionRotation() != _lastSelectionRotation)
			{
				UpdateRotationGUI();
			}
		}

		private NumericSpinnerControl CreateNudgeControl(string widgetId)
		{
			return new NumericSpinnerControl(base.Widget.FindWidget(widgetId))
			{
				GetIncrementAmount = () => NudgeAmount,
				GetDecrementAmount = () => NudgeAmount,
				NumericFormat = "n4",
				OnValueChanged = delegate
				{
					UpdateSelectionPosition();
				}
			};
		}

		private RotationControlScript CreateRotationControl(string axis)
		{
			return new RotationControlScript(base.Widget.FindWidget("spinner-rotation-" + axis), base.Widget.FindWidget<SliderWidget>("slider-rotation-" + axis), this);
		}

		private Vector3 GetSelectionPosition()
		{
			if (SelectedTransform == null)
			{
				return Vector3.zero;
			}
			return SelectedTransform.position;
		}

		private Vector3 GetSelectionRotation()
		{
			if (SelectedTransform == null)
			{
				return Vector3.zero;
			}
			return SelectedTransform.eulerAngles;
		}

		private void OnPanelStateChanged(IFlyout flyout)
		{
			if (base.Flyout.IsOpen)
			{
				UpdateRotationGUI();
				UpdatePositionsGUI();
				UpdateRotationSlidersSteps();
				_spinnerAmountNudge.Value = NudgeAmount;
				_spinnerAmountRotation.Value = RotateAmount;
			}
		}

		private void OnSelectedPartChangedEvent(PartScript newPart)
		{
			OnPanelStateChanged(null);
		}

		private void OnZeroRotationButtonClicked(Widget widget)
		{
			if (!(base.Designer.SelectedPart == null))
			{
				Vector3 eulerAngles = SelectedTransform.eulerAngles;
				Vector3 zero = Vector3.zero;
				if (!Utilities.CompareFloats(zero.x, eulerAngles.x, 1E-08f) || !Utilities.CompareFloats(zero.y, eulerAngles.y, 1E-08f) || !Utilities.CompareFloats(zero.z, eulerAngles.z, 1E-08f))
				{
					base.Designer.Tools.MovePartTool.RotatePart(base.Designer.SelectedPart, Quaternion.identity, singlePart: true, rotationIsTarget: true, disconnectParts: false, "Zero Rotations");
					UpdateRotationGUI();
				}
			}
		}

		private void SetRotation(float x, float y, float z)
		{
			if (!(base.Designer.SelectedPart == null))
			{
				base.Designer.Tools.MovePartTool.RotatePart(base.Designer.SelectedPart, Quaternion.Euler(x, y, z), !InConnectedMode, rotationIsTarget: true, disconnectParts: false);
			}
		}

		private void UpdatePositionsGUI(bool forceAll = false)
		{
			Vector3 selectionPosition = GetSelectionPosition();
			_nudgeControlX.Value = selectionPosition.x;
			_nudgeControlY.Value = selectionPosition.y;
			_nudgeControlZ.Value = selectionPosition.z;
			_lastSelectionPosition = GetSelectionPosition();
		}

		private void UpdateRotationSlidersSteps()
		{
			float[] obj = new float[16]
			{
				0.5f, 1f, 2f, 3f, 4f, 5f, 6f, 9f, 10f, 12f,
				15f, 18f, 20f, 30f, 36f, 45f
			};
			float num = float.MaxValue;
			float[] array = obj;
			foreach (float num2 in array)
			{
				float num3 = Mathf.Abs(RotateAmount - num2);
				if (num3 < num)
				{
					num = num3;
				}
			}
			int numberOfSteps = (int)(180f / RotateAmount * 2f + 1f);
			_rotateControlX.Slider.NumberOfSteps = numberOfSteps;
			_rotateControlY.Slider.NumberOfSteps = numberOfSteps;
			_rotateControlZ.Slider.NumberOfSteps = numberOfSteps;
		}

		private void UpdateSelectionPosition()
		{
			if (base.Designer.SelectedPart != null)
			{
				Vector3 vector = new Vector3(_nudgeControlX.Value, _nudgeControlY.Value, _nudgeControlZ.Value);
				base.Designer.Tools.MovePartTool.SetPartPosition(base.Designer.SelectedPart, vector, !InConnectedMode, disconnectParts: false);
				_lastSelectionPosition = vector;
			}
		}
	}
}
