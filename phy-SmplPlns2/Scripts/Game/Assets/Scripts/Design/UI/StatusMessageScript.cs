using System.Collections.Generic;
using System.Text;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class StatusMessageScript : WidgetScript
	{
		private class StatusMessage
		{
			public string Message { get; set; }

			public float Timer { get; set; }

			public StatusMessage(string message, float timer)
			{
				Message = message;
				Timer = timer;
			}
		}

		private List<StatusMessage> _messages;

		private TextMeshProUGUI _text;

		private bool _visible;

		public static int MaxMessageCount { get; set; } = 6;

		public void AppendMessage(string message, float time, bool animate)
		{
			if (_messages.Count == 0)
			{
				ShowMessage(message, time, animate);
				return;
			}
			_messages.Add(new StatusMessage(message, time));
			UpdateMessage();
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_text = GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
			_messages = new List<StatusMessage>();
		}

		public void ShowMessage(string message, float time, bool animate)
		{
			_messages.Clear();
			if (string.IsNullOrEmpty(message))
			{
				_text.text = string.Empty;
				_visible = false;
				base.Widget.Visible = false;
				return;
			}
			_messages.Add(new StatusMessage(message, time));
			_text.text = message;
			_visible = true;
			if (animate)
			{
				base.Widget.Visible = false;
				base.Widget.Show(force: true);
			}
			else
			{
				base.Widget.Visible = true;
			}
		}

		protected virtual void Update()
		{
			if (!_visible)
			{
				return;
			}
			bool flag = false;
			for (int num = _messages.Count - 1; num >= 0; num--)
			{
				_messages[num].Timer -= Time.unscaledDeltaTime;
				if (_messages[num].Timer <= 0f)
				{
					_messages.RemoveAt(num);
					flag = true;
				}
			}
			if (flag)
			{
				if (_messages.Count > 0)
				{
					UpdateMessage();
					return;
				}
				_visible = false;
				base.Widget.Hide();
			}
		}

		private void UpdateMessage()
		{
			int count = _messages.Count;
			switch (count)
			{
			case 0:
				_text.text = string.Empty;
				return;
			case 1:
				_text.text = _messages[0].Message;
				return;
			}
			if (count > MaxMessageCount)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = count - MaxMessageCount; i < count; i++)
				{
					stringBuilder.AppendLine(_messages[i].Message);
				}
				stringBuilder.AppendLine($"... and {count - MaxMessageCount} more messages.");
				_text.text = stringBuilder.ToString();
				return;
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			foreach (StatusMessage message in _messages)
			{
				stringBuilder2.AppendLine(message.Message);
			}
			_text.text = stringBuilder2.ToString();
		}
	}
}
