using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI
{
	public class RotateToolPanelScript : TransformToolPanelScript
	{
		private NumericSpinnerControl _angleSnapSpinner;

		private RotateTool _rotateTool;

		public float AngleSnap
		{
			get
			{
				return _rotateTool.AngleSnap;
			}
			set
			{
				_rotateTool.AngleSnap = value;
			}
		}

		protected override TransformTool TransformTool => _rotateTool;

		public override void OnWidgetInitialized(Widget widget)
		{
			_ = Designer.Instance.DesignerScript.DesignerUI;
			_rotateTool = Designer.Instance.Tools.RotateTool;
			base.OnWidgetInitialized(widget);
			_angleSnapSpinner = new NumericSpinnerControl(base.Widget.FindWidget("rotate-tool-angle-snap"));
			_angleSnapSpinner.MinValue = 0f;
			_angleSnapSpinner.MaxValue = 90f;
			_angleSnapSpinner.StepSize = 5f;
			_angleSnapSpinner.OnValueChanged = delegate(float _, float x)
			{
				AngleSnap = x;
			};
		}

		protected override void OnShown(Widget widget)
		{
			base.OnShown(widget);
			_angleSnapSpinner.Value = _rotateTool.AngleSnap;
		}
	}
}
