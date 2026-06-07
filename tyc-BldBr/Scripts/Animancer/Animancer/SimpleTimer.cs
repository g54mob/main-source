using System;
using System.Diagnostics;
using UnityEngine;

namespace Animancer
{
	public struct SimpleTimer : IDisposable
	{
		public static readonly Stopwatch Stopwatch = Stopwatch.StartNew();

		public string name;

		public double startTime;

		public double total;

		private const string Format = "0.000";

		public static double CurrentTime => Stopwatch.Elapsed.TotalSeconds;

		public bool IsStarted => startTime != 0.0;

		public SimpleTimer(string name)
		{
			this.name = name;
			startTime = 0.0;
			total = 0.0;
		}

		public static SimpleTimer Start(string name = null)
		{
			return new SimpleTimer
			{
				name = name,
				startTime = CurrentTime
			};
		}

		public bool Start()
		{
			if (startTime != 0.0)
			{
				return false;
			}
			startTime = CurrentTime;
			return true;
		}

		public bool Stop()
		{
			if (startTime == 0.0)
			{
				return false;
			}
			double currentTime = CurrentTime;
			total += currentTime - startTime;
			startTime = 0.0;
			return true;
		}

		public override string ToString()
		{
			Stop();
			if (!string.IsNullOrEmpty(name))
			{
				return name + ": " + total.ToString("0.000");
			}
			return total.ToString("0.000");
		}

		public void Dispose()
		{
			UnityEngine.Debug.Log(ToString());
		}
	}
}
