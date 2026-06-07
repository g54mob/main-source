using System;
using System.Collections.Generic;

namespace ModApi.Ui.Inspector
{
	public class LogModel : ItemModel
	{
		private List<string> _logs = new List<string>();

		public IReadOnlyList<string> Logs => _logs;

		public int MaxLogs { get; set; } = 100;

		public event EventHandler<EventArgs> Changed;

		public void AddMessage(string message, bool raiseChangedEvent = true)
		{
			_logs.Add(message);
			while (_logs.Count > MaxLogs)
			{
				_logs.RemoveAt(0);
			}
			if (raiseChangedEvent)
			{
				this.Changed?.Invoke(this, new EventArgs());
			}
		}

		public void Clear()
		{
			_logs.Clear();
			this.Changed?.Invoke(this, new EventArgs());
		}

		public override void Update()
		{
			base.Update();
		}
	}
}
