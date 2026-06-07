using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Flight.UI
{
	public class RadioMessageScript : WidgetScript
	{
		private float _duration;

		private string _messageText;

		private string _source;

		private TextWidget _text;

		private float _time;

		public bool IsComplete { get; private set; }

		public bool IsStarted { get; private set; }

		public void InitializeMessage(string message, string source, Sprite profileImage, float duration)
		{
			_source = source;
			_messageText = message;
			_duration = duration;
			base.Widget.Visible = false;
			ImageWidget imageWidget = base.Widget.FindWidget<ImageWidget>("profile-image");
			if (profileImage != null)
			{
				imageWidget.Image.sprite = profileImage;
			}
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_text = widget.FindWidget<TextWidget>("message");
		}

		public void Show()
		{
			IsStarted = true;
			base.Widget.Show();
		}

		protected virtual void Update()
		{
			if (!IsComplete)
			{
				_time += Mathf.Min(Time.deltaTime, 0.025f);
				int num = (int)Mathf.Lerp(0f, _messageText.Length, _time / _duration);
				_text.Text = "<b>" + _source + ":</b> " + _messageText.Substring(0, num);
				IsComplete = num == _messageText.Length;
			}
		}
	}
}
