using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Collections;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class DragVisualizerPanelScript : DesignerPanelScript
	{
		private EnumSpinnerControl<CraftAerodynamicsModelType> _aeroModel;

		private VectorControl<Vector3> _customDirectionControl;

		private SpinnerControl _directionSpinner;

		private DragVisualizationTool _dragVisualizer;

		private NumericSpinnerControl _maxDragSpinner;

		private EnumSpinnerControl<DragVisualizationTool.DragShadingStyle> _shadingSpinner;

		private ButtonControl _visualizerEnabledButton;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			_visualizerEnabledButton = new ButtonControl(base.Widget.FindWidget("visualizer-enabled-button"));
			_visualizerEnabledButton.Button.Clicked += OnVisualizeDragButtonClicked;
			_maxDragSpinner = new NumericSpinnerControl(base.Widget.FindWidget("max-drag-spinner"));
			_maxDragSpinner.GetIncrementAmount = () => 0.05f;
			_maxDragSpinner.GetDecrementAmount = () => 0.05f;
			_maxDragSpinner.MinValue = 0f;
			_maxDragSpinner.NumericFormat = "0.####";
			_maxDragSpinner.OnValueChanged = OnMaxDragChanged;
			_aeroModel = new EnumSpinnerControl<CraftAerodynamicsModelType>(base.Widget.FindWidget("aero-model"));
			_aeroModel.OnValueChanged = OnAeroModelChanged;
			_shadingSpinner = new EnumSpinnerControl<DragVisualizationTool.DragShadingStyle>(base.Widget.FindWidget("shading-spinner"));
			_shadingSpinner.OnValueChanged = OnShadingChanged;
			_directionSpinner = new SpinnerControl(base.Widget.FindWidget("direction-spinner"));
			_directionSpinner.OnValueChanged = OnDirectionChanged;
			Jundroo.Common.Collections.CircularList<string> values = _directionSpinner.Values;
			values.Add(PartDrag.DragDirection.Forward.ToString());
			values.Add(PartDrag.DragDirection.Backward.ToString());
			values.Add(PartDrag.DragDirection.Upward.ToString());
			values.Add(PartDrag.DragDirection.Downward.ToString());
			values.Add(PartDrag.DragDirection.Leftward.ToString());
			values.Add(PartDrag.DragDirection.Rightward.ToString());
			values.Add("Custom");
			_customDirectionControl = new VectorControl<Vector3>(base.Widget.FindWidget("direction-custom-vector"));
			_customDirectionControl.AllowManualEntry = true;
			_customDirectionControl.StepValue = 0.1m;
			_customDirectionControl.Value = Vector3.forward;
			VectorControl<Vector3> customDirectionControl = _customDirectionControl;
			customDirectionControl.OnValueChanged = (Action<Vector3>)Delegate.Combine(customDirectionControl.OnValueChanged, new Action<Vector3>(OnCustomDirectionChanged));
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
			base.Designer.AircraftStructureChangedEvent += OnAircraftStructureChanged;
			_dragVisualizer = base.Designer.Tools.MovePartTool.DragVisualizationTool;
		}

		protected virtual void Start()
		{
			_maxDragSpinner.Value = _dragVisualizer.MaxDragThreshold;
			_shadingSpinner.Value = _dragVisualizer.ShadingStyle;
			_directionSpinner.Value = PartDrag.Vector3ToDragDirection(_dragVisualizer.DragDirection)?.ToString() ?? "Custom";
			_customDirectionControl.Value = _dragVisualizer.DragDirection;
		}

		private void OnAeroModelChanged(CraftAerodynamicsModelType oldValue, CraftAerodynamicsModelType newValue)
		{
			AircraftData aircraft = base.Designer.Aircraft.Aircraft;
			aircraft.AerodynamicsModelType = newValue;
			foreach (PartData part in aircraft.Assembly.Parts)
			{
				part.PartDrag.ClearDrag();
			}
			base.Designer.OnAircraftStructureChanged();
		}

		private void OnAircraftStructureChanged()
		{
			RefreshUI();
		}

		private void OnCustomDirectionChanged(Vector3 vector)
		{
			_dragVisualizer.DragDirection = vector.normalized;
		}

		private void OnDirectionChanged(string oldValue, string newValue)
		{
			Vector3 forward = Vector3.forward;
			if (newValue == "Custom")
			{
				OnCustomDirectionChanged(_customDirectionControl.Value);
			}
			else
			{
				if (!Enum.TryParse<PartDrag.DragDirection>(newValue, out var result))
				{
					Debug.LogError("Invalid drag direction: " + newValue);
					return;
				}
				forward = PartDrag.DragDirectionToVector3(result);
				_dragVisualizer.DragDirection = forward.normalized;
			}
			RefreshUI();
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			_aeroModel.Value = base.Designer.Aircraft.Aircraft.AerodynamicsModelType;
			RefreshUI();
		}

		private void OnMaxDragChanged(float oldValue, float newValue)
		{
			_dragVisualizer.MaxDragThreshold = newValue;
		}

		private void OnShadingChanged(DragVisualizationTool.DragShadingStyle oldValue, DragVisualizationTool.DragShadingStyle newValue)
		{
			_dragVisualizer.ShadingStyle = newValue;
		}

		private void OnVisualizeDragButtonClicked(Widget widget)
		{
			base.Designer.ShowDrag = !base.Designer.ShowDrag;
			RefreshUI();
		}

		private void RefreshUI()
		{
			bool showDrag = base.Designer.ShowDrag;
			bool flag = !_dragVisualizer.LegacyDragModel && false;
			_visualizerEnabledButton.ValueText.Text = (showDrag ? "Enabled" : "Disabled");
			_maxDragSpinner.Visible = showDrag && !flag;
			_shadingSpinner.Visible = showDrag && !flag;
			_directionSpinner.Visible = showDrag && !flag;
			_customDirectionControl.Visible = showDrag && !flag && _directionSpinner.Value == "Custom";
		}
	}
}
