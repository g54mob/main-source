using System;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class NudgePartPanelScript : DesignerSubPanelScript
	{
		private XmlElement _content;

		private TextMeshProUGUI _messageText;

		private SpinnerScript _spinnerGridSize;

		private SpinnerScript _spinnerMode;

		private SpinnerScript _spinnerOrientation;

		private SpinnerScript _spinnerX;

		private SpinnerScript _spinnerY;

		private SpinnerScript _spinnerZ;

		private NudgePartTool _tool;

		public override void Initialize(DesignerUiScript designerUi)
		{
			base.Initialize(designerUi);
			designerUi.Designer.SelectedPartChanged += OnSelectedPartChanged;
			_tool = base.DesignerUi.Designer.NudgePartTool;
			_tool.ToolAdjustmentOccurred += OnGizmoAdjusted;
			_spinnerGridSize.SetNumericValue(_tool.GridSize);
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
			_messageText = base.xmlLayout.GetElementById<TextMeshProUGUI>("message-text");
			_content = base.xmlLayout.GetElementById("content");
			_spinnerGridSize = base.xmlLayout.GetElementById<SpinnerScript>("spinner-grid-size");
			_spinnerX = base.xmlLayout.GetElementById<SpinnerScript>("spinner-x");
			_spinnerY = base.xmlLayout.GetElementById<SpinnerScript>("spinner-y");
			_spinnerZ = base.xmlLayout.GetElementById<SpinnerScript>("spinner-z");
			_spinnerMode = base.xmlLayout.GetElementById<SpinnerScript>("spinner-mode");
			_spinnerOrientation = base.xmlLayout.GetElementById<SpinnerScript>("spinner-orientation");
		}

		public override void OnOpened()
		{
			base.OnOpened();
			OnGridSizeChanged();
			RefreshPanel();
		}

		private void OnGizmoAdjusted(MovementTool source)
		{
			RefreshPanel();
		}

		private void OnGridSizeChanged()
		{
			float num = _tool.GridSize;
			_spinnerGridSize.SetNumericValue(num);
			if (num < 0.01f)
			{
				num = 0.01f;
			}
			_spinnerX.StepSize = num;
			_spinnerY.StepSize = num;
			_spinnerZ.StepSize = num;
		}

		private void OnGridSizeSpinnerChanged()
		{
			_tool.GridSize = _spinnerGridSize.NumericValue;
			OnGridSizeChanged();
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

		private void OnPositionSpinnerChanged()
		{
			IPartScript selectedPart = Game.Instance.Designer.SelectedPart;
			if (selectedPart != null)
			{
				_tool.SetWorldPosition(new Vector3(_spinnerX.NumericValue, _spinnerY.NumericValue, _spinnerZ.NumericValue));
				selectedPart.CraftScript.SetStructureChanged();
			}
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
				Vector3 position = selectedPart.Transform.position;
				_spinnerX.SetNumericValue(position.x);
				_spinnerY.SetNumericValue(position.y);
				_spinnerZ.SetNumericValue(position.z);
				_spinnerGridSize.SetNumericValue(_tool.GridSize);
				_spinnerOrientation.Value = (_tool.LocalOrientation ? "Local" : "World");
				_spinnerMode.Value = _tool.Movement.ToString();
			}
			else
			{
				_content.gameObject.SetActive(value: false);
			}
		}
	}
}
