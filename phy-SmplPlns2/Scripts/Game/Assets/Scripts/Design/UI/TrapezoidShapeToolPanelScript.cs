using System;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI
{
	public class TrapezoidShapeToolPanelScript : WidgetScript
	{
		private SpinnerControl<TrapezoidShapeTool.EditMode> _modeSpinner;

		private NumericSpinnerControl _snappingSpinner;

		private TrapezoidShapeTool _tool;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_tool = Designer.Instance.Tools.TrapezoidShapeTool;
			widget.Shown += OnShown;
			_modeSpinner = new SpinnerControl<TrapezoidShapeTool.EditMode>(base.Widget.FindWidget("trapezoid-mode-spinner"));
			_modeSpinner.Values.AddRange((TrapezoidShapeTool.EditMode[])Enum.GetValues(typeof(TrapezoidShapeTool.EditMode)));
			_modeSpinner.OnValueChanged = delegate(TrapezoidShapeTool.EditMode from, TrapezoidShapeTool.EditMode to)
			{
				_tool.Mode = to;
			};
			_snappingSpinner = new NumericSpinnerControl(base.Widget.FindWidget("trapezoid-tool-snap"))
			{
				MinValue = 0f,
				MaxValue = 90f,
				StepSize = 5f,
				OnValueChanged = delegate(float _, float x)
				{
					_tool.SnapDistance = x;
				},
				GetIncrementAmount = () => UserInterfaceUtility.GetNextSnapStep(_snappingSpinner.Value),
				GetDecrementAmount = () => UserInterfaceUtility.GetPrevSnapStep(_snappingSpinner.Value)
			};
		}

		private void OnShown(Widget widget)
		{
			_modeSpinner.Value = _tool.Mode;
			_snappingSpinner.Value = _tool.SnapDistance;
		}
	}
}
