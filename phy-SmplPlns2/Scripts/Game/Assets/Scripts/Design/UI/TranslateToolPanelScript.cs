using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI
{
	public class TranslateToolPanelScript : TransformToolPanelScript
	{
		private NumericSpinnerControl _gridSnapSpinner;

		private TranslateTool _translateTool;

		public float NudgeAmount
		{
			get
			{
				return _translateTool.GridSize;
			}
			set
			{
				_translateTool.GridSize = value;
			}
		}

		protected override TransformTool TransformTool => _translateTool;

		public override void OnWidgetInitialized(Widget widget)
		{
			_ = Designer.Instance.DesignerScript.DesignerUI;
			_translateTool = Designer.Instance.Tools.TranslateTool;
			base.OnWidgetInitialized(widget);
			_gridSnapSpinner = new NumericSpinnerControl(base.Widget.FindWidget("grid-snap-spinner"));
			_gridSnapSpinner.MinValue = 0f;
			_gridSnapSpinner.MaxValue = 10f;
			_gridSnapSpinner.StepSize = 0.5f;
			_gridSnapSpinner.OnValueChanged = delegate(float _, float x)
			{
				NudgeAmount = x;
			};
			_gridSnapSpinner.GetIncrementAmount = () => UserInterfaceUtility.GetNextSnapStep(_gridSnapSpinner.Value);
			_gridSnapSpinner.GetDecrementAmount = () => UserInterfaceUtility.GetPrevSnapStep(_gridSnapSpinner.Value);
		}

		protected override void OnShown(Widget widget)
		{
			base.OnShown(widget);
			_gridSnapSpinner.Value = _translateTool.GridSize;
		}
	}
}
