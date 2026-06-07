using Assets.Scripts.GuiNew;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.Flight.UI
{
	public class FadingMessageScript : WidgetScript, IFadingMessage
	{
		private MessageManager.Message _message;

		private TextWidget _text;

		public bool CanFloat => _message.CanFloat;

		public bool IsDead { get; private set; }

		public string MessageText => _message.Text;

		public void Destroy(bool immediate)
		{
			IsDead = true;
			if (immediate)
			{
				base.Widget.Visible = false;
				base.Widget.Destroy();
			}
			else
			{
				base.Widget.Hide(delegate
				{
					base.Widget.Destroy();
				});
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_text = widget.FindWidget<TextWidget>("message");
		}

		public void ShowMessage(MessageManager.Message message)
		{
			_message = message;
			_text.Text = message.Text;
			if (message.Highlighted)
			{
				base.Widget.AddClass("highlighted");
			}
			base.Widget.Show();
		}

		void IFadingMessage.Update(float deltaTime)
		{
			if (_message != null && _message.Time > 0f)
			{
				_message.Time -= deltaTime;
			}
			else
			{
				IsDead = true;
			}
		}
	}
}
