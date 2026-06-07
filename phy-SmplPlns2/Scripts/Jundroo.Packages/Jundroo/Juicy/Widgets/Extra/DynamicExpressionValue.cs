using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets.Serialization;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class DynamicExpressionValue : IDynamicValue
	{
		private AttributeSet _attributeSet;

		private DynamicExpressionText _dynamicText;

		private string _value;

		public string Name { get; }

		public Widget Widget { get; }

		public DynamicExpressionValue(Widget widget, AttributeSet attributeSet, string name, string value)
		{
			Widget = widget;
			Name = name;
			_value = value;
			_attributeSet = attributeSet;
			_dynamicText = new DynamicExpressionText(widget.Context.ExpressionSource);
			_dynamicText.WarningLogSource = "'" + widget.GetType().Name + "' id '" + widget.Id + "'";
			_dynamicText.MatchInputs(value);
		}

		public void UpdateValue(object dataModel)
		{
			_dynamicText.Update();
			if (_dynamicText.ParseText(_value))
			{
				_attributeSet.ApplyAttribute(Widget, Name, _dynamicText.Text);
			}
		}
	}
}
