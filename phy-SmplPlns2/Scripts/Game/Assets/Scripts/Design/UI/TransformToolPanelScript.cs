using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Design.UI
{
	public class TransformToolPanelScript : WidgetScript
	{
		public const string ModeConnectedParts = "Connected";

		public const string ModeSelectedPart = "Selected";

		public const string SpaceLocal = "Local";

		public const string SpaceWorld = "World";

		private SpinnerControl _selectionSpinner;

		private SpinnerControl _spaceSpinner;

		public bool InConnectedMode
		{
			get
			{
				return TransformTool.InConnectedMode;
			}
			private set
			{
				TransformTool.InConnectedMode = value;
			}
		}

		public bool UseLocalSpace
		{
			get
			{
				return TransformTool.UseLocalSpace;
			}
			private set
			{
				TransformTool.UseLocalSpace = value;
			}
		}

		protected virtual TransformTool TransformTool { get; }

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_ = Designer.Instance.DesignerScript.DesignerUI;
			base.Widget.Shown += OnShown;
			_selectionSpinner = new SpinnerControl(base.Widget.FindWidget("selection-spinner"));
			_selectionSpinner.Values.Add("Selected");
			_selectionSpinner.Values.Add("Connected");
			_selectionSpinner.OnValueChanged = delegate
			{
				InConnectedMode = _selectionSpinner.Value == "Connected";
			};
			_spaceSpinner = new SpinnerControl(base.Widget.FindWidget("space-spinner"));
			_spaceSpinner.Values.Add("Local");
			_spaceSpinner.Values.Add("World");
			_spaceSpinner.OnValueChanged = delegate
			{
				UseLocalSpace = _spaceSpinner.Value == "Local";
			};
		}

		protected virtual void OnShown(Widget widget)
		{
			_selectionSpinner.Value = (InConnectedMode ? "Connected" : "Selected");
			_spaceSpinner.Value = (UseLocalSpace ? "Local" : "World");
		}

		protected virtual void Update()
		{
			if (Game.Inputs.DesignerSinglePartModifier.GetButtonDownIfEnabled())
			{
				InConnectedMode = !InConnectedMode;
				_selectionSpinner.Value = (InConnectedMode ? "Connected" : "Selected");
			}
			else if (Game.Inputs.DesignerSinglePartModifier.GetButtonUpIfEnabled())
			{
				InConnectedMode = !InConnectedMode;
				_selectionSpinner.Value = (InConnectedMode ? "Connected" : "Selected");
			}
		}
	}
}
