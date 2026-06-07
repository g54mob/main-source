using System;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Math;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design
{
	public class RotatePartPanelScript : DesignerSubPanelScript
	{
		private XmlElement _content;

		private TextMeshProUGUI _messageText;

		private Slider _sensitivitySlider;

		private TextMeshProUGUI _sensitivityText;

		private SpinnerScript _spinnerMode;

		private SpinnerScript _spinnerOrientation;

		private SpinnerScript _spinnerSnap;

		private SpinnerScript _spinnerX;

		private SpinnerScript _spinnerY;

		private SpinnerScript _spinnerZ;

		private RotatePartTool _tool;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			designerUi.Designer.SelectedPartChanged += OnSelectedPartChanged;
			_tool = base.DesignerUi.Designer.RotatePartTool;
			_tool.ToolAdjustmentOccurred += OnGizmoAdjusted;
			_spinnerSnap.SetNumericValue(15f);
			OnSnapChanged();
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_sensitivitySlider = base.xmlLayout.GetElementById<Slider>("sensitivity-slider");
			_sensitivityText = base.xmlLayout.GetElementById<TextMeshProUGUI>("sensitivity-text");
			_messageText = base.xmlLayout.GetElementById<TextMeshProUGUI>("message-text");
			_content = base.xmlLayout.GetElementById("content");
			_spinnerSnap = base.xmlLayout.GetElementById<SpinnerScript>("spinner-snap");
			_spinnerX = base.xmlLayout.GetElementById<SpinnerScript>("spinner-x");
			_spinnerY = base.xmlLayout.GetElementById<SpinnerScript>("spinner-y");
			_spinnerZ = base.xmlLayout.GetElementById<SpinnerScript>("spinner-z");
			_spinnerMode = base.xmlLayout.GetElementById<SpinnerScript>("spinner-mode");
			_spinnerOrientation = base.xmlLayout.GetElementById<SpinnerScript>("spinner-orientation");
		}

		public override void OnOpened()
		{
			base.OnOpened();
			RefreshPanel();
		}

		private void OnAngleChanged()
		{
			IPartScript selectedPart = Game.Instance.Designer.SelectedPart;
			if (selectedPart != null)
			{
				_tool.SetWorldRotation(Quaternion.Euler(_spinnerX.NumericValue, _spinnerY.NumericValue, _spinnerZ.NumericValue));
				selectedPart.CraftScript.SetStructureChanged();
			}
		}

		private void OnGizmoAdjusted(MovementTool source)
		{
			RefreshPanel();
		}

		private void OnModeChanged(string value)
		{
			_tool.Movement = (MovementTool.MovementType)Enum.Parse(typeof(MovementTool.MovementType), value, ignoreCase: true);
			RefreshPanel();
		}

		private void OnOrientationChanged(string value)
		{
			_tool.LocalOrientation = value == "Local";
			RefreshPanel();
		}

		private void OnSelectedPartChanged(IPartScript oldPart, IPartScript newPart)
		{
			if (base.IsOpen)
			{
				RefreshPanel();
			}
		}

		private void OnSelfConnectedButtonClicked()
		{
			_tool.Movement = Utilities.NextEnum(_tool.Movement);
			RefreshPanel();
		}

		private void OnSensitivityChanged(float value)
		{
			_tool.Gizmo.Sensitivity = value;
			RefreshPanel();
		}

		private void OnSnapChanged()
		{
			float numericValue = _spinnerSnap.NumericValue;
			numericValue = ((numericValue < 0f) ? 90f : ((numericValue > 90f) ? 0f : numericValue));
			_tool.Gizmo.AngleSnap = numericValue;
			_spinnerSnap.SetNumericValue(numericValue);
			numericValue = ((numericValue < 0.1f) ? 0.1f : numericValue);
			_spinnerX.StepSize = numericValue;
			_spinnerY.StepSize = numericValue;
			_spinnerZ.StepSize = numericValue;
		}

		private void RefreshPanel()
		{
			bool flag = false;
			IPartScript selectedPart = Game.Instance.Designer.SelectedPart;
			if (selectedPart == null)
			{
				_messageText.gameObject.SetActive(value: true);
				_messageText.text = "No part selected";
			}
			else if (selectedPart.Data.SymmetryId.HasValue)
			{
				_messageText.gameObject.SetActive(value: true);
				_messageText.text = "Symmetry active";
				flag = true;
			}
			else
			{
				_messageText.gameObject.SetActive(value: false);
				flag = true;
			}
			if (flag)
			{
				_content.gameObject.SetActive(value: true);
				Vector3 eulerAngles = selectedPart.Transform.rotation.eulerAngles;
				_spinnerX.SetNumericValue(eulerAngles.x);
				_spinnerY.SetNumericValue(eulerAngles.y);
				_spinnerZ.SetNumericValue(eulerAngles.z);
				_spinnerSnap.SetNumericValue(_tool.Gizmo.AngleSnap);
				_spinnerOrientation.Value = (_tool.LocalOrientation ? "Local" : "World");
				_spinnerMode.Value = _tool.Movement.ToString();
				_sensitivitySlider.value = _tool.Gizmo.Sensitivity;
				_sensitivityText.text = Units.GetPercentageString(_tool.Gizmo.Sensitivity);
			}
			else
			{
				_content.gameObject.SetActive(value: false);
			}
		}
	}
}
