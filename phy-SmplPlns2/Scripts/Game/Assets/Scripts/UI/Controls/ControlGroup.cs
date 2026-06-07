using System;
using System.Collections.Generic;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI.Controls
{
	public class ControlGroup
	{
		private IWidgetContext _context;

		private List<WidgetControl> _controls = new List<WidgetControl>();

		private List<ControlGroup> _groups = new List<ControlGroup>();

		private Widget _parent;

		public IReadOnlyList<WidgetControl> Controls => _controls;

		public HeaderScript Header { get; private set; }

		public ControlGroup(IWidgetContext context, Widget parent)
		{
			_parent = parent;
			_context = context;
		}

		public HeaderScript CreateHeader(string header)
		{
			HeaderScript componentInChildren = _context.CreateWidgetFromTemplate("control-header", _parent).GetComponentInChildren<HeaderScript>();
			componentInChildren.LabelText = header;
			return componentInChildren;
		}

		public SliderControl CreateSlider()
		{
			SliderControl sliderControl = new SliderControl(_context.CreateWidgetFromTemplate("control-slider", _parent));
			AddControl(sliderControl);
			return sliderControl;
		}

		public ControlGroup CreateSubGroup(string header)
		{
			ControlGroup controlGroup = new ControlGroup(_context, _parent);
			if (header != null)
			{
				controlGroup.Header = controlGroup.CreateHeader(header);
			}
			_groups.Add(controlGroup);
			return controlGroup;
		}

		public TextControl CreateText(string label, Func<string> valueGetter)
		{
			TextControl textControl = new TextControl(_context.CreateWidgetFromTemplate("control-text", _parent));
			textControl.LabelText = label;
			textControl.ValueTextGetter = valueGetter;
			AddControl(textControl);
			return textControl;
		}

		public void Update()
		{
			foreach (WidgetControl control in Controls)
			{
				if (control.Visible)
				{
					control.Update();
				}
			}
			foreach (ControlGroup group in _groups)
			{
				group.Update();
			}
		}

		private void AddControl(WidgetControl control)
		{
			_controls.Add(control);
		}
	}
}
