using ModApi.Ui.Inspector;
using UI.Xml;

namespace Assets.Scripts.Ui.Inspector
{
	public abstract class ButtonElement : ItemElement
	{
		private ButtonModel _model;

		private ButtonModel.ButtonStyle _style;

		public abstract XmlElement Button { get; }

		public ButtonElement(XmlElement xmlElement, ButtonModel model, GroupModel group)
			: base(xmlElement, model, group)
		{
			_model = model;
		}

		public override void Update()
		{
			base.Update();
			if (_style != _model.Style)
			{
				_style = _model.Style;
				if (_style == ButtonModel.ButtonStyle.Default)
				{
					Button.RemoveClass("btn-warning");
					Button.RemoveClass("btn-primary");
				}
				else if (_style == ButtonModel.ButtonStyle.Primary)
				{
					Button.RemoveClass("btn-warning");
					Button.AddClass("btn-primary");
				}
				else if (_style == ButtonModel.ButtonStyle.Warning)
				{
					Button.AddClass("btn-warning");
					Button.RemoveClass("btn-primary");
				}
			}
		}
	}
}
