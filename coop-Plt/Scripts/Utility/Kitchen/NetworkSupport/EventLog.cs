using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Kitchen.NetworkSupport
{
	public class EventLog
	{
		private static EventLog _Default;

		public static EventLog Achievements = new EventLog("ACH");

		public static EventLog Files = new EventLog("FILE");

		public static EventLog Controllers = new EventLog("CONT");

		public static EventLog Networking = new EventLog("NETW");

		public static EventLog Platform = new EventLog("PLAT");

		public static EventLog Session = new EventLog("SESS");

		public string Tag;

		public List<LoggedEvent<string>> Events = new List<LoggedEvent<string>>();

		public Stopwatch Timer;

		public static EventLog Default
		{
			get
			{
				if (_Default == null)
				{
					_Default = new AggregateEventLog(Files, Controllers, Networking, Platform);
				}
				return _Default;
			}
		}

		public event Action<LoggedEvent<string>> OnReport = delegate
		{
		};

		private static void ClearLogs()
		{
			UnityEngine.Debug.LogWarning("EventLog - Clearing logs");
			Networking.Reset();
			Files.Reset();
			Default.Reset();
			Controllers.Reset();
		}

		public EventLog(string tag)
		{
			Tag = tag;
			Timer = new Stopwatch();
			Timer.Start();
		}

		public void Reset()
		{
			Timer.Reset();
			Events.Clear();
		}

		public void Report<T>(T e, Exception ex) where T : Enum
		{
			Report(e, ex.Message);
		}

		public void Report<T>(T e) where T : Enum
		{
			Report(e, "");
		}

		public void Report<T>(T e, string detail) where T : Enum
		{
			PerformReport(e, detail, Color.white);
		}

		public void Report<T>(T e, int detail) where T : Enum
		{
			PerformReport(e, $"{detail} ({detail:X})", Color.white);
		}

		public void ReportHigh<T>(T e, string detail) where T : Enum
		{
			PerformReport(e, detail, new Color(1f, 0.2f, 0.47f));
		}

		public void ReportMedium<T>(T e, string detail) where T : Enum
		{
			PerformReport(e, detail, new Color(1f, 0.62f, 0.3f));
		}

		public void ReportPositive<T>(T e, string detail) where T : Enum
		{
			PerformReport(e, detail, new Color(0.42f, 1f, 0.6f));
		}

		protected void PerformReport<T>(T e, string detail, Color c) where T : Enum
		{
			LoggedEvent<string> evt = new LoggedEvent<string>(Tag, c, (float)Timer.ElapsedMilliseconds / 1000f, e.ToString(), detail);
			PerformReport(evt);
		}

		protected void PerformReport(LoggedEvent<string> evt, bool silent = false)
		{
			if (!silent)
			{
				UnityEngine.Debug.LogWarning(evt.ToString());
			}
			Events.Add(evt);
			this.OnReport(evt);
		}

		public virtual IEnumerable<LoggedEvent<string>> Tail(int n)
		{
			int count = n;
			if (count <= 0)
			{
				yield break;
			}
			int i = Events.Count - 1;
			while (i >= 0)
			{
				yield return Events[i];
				count--;
				if (count >= 0)
				{
					i--;
					continue;
				}
				break;
			}
		}
	}
}
