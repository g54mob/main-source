using System;
using System.Collections.Generic;
using System.ComponentModel;
using MLAPI.Collections;
using MLAPI.Configuration;
using UnityEngine;

namespace MLAPI.Profiling
{
	public static class NetworkProfiler
	{
		private static int tickHistory = 1024;

		private static int EventIdCounter = 0;

		private static ProfilerTick CurrentTick;

		public static FixedQueue<ProfilerTick> Ticks { get; private set; }

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use IsRunning instead", false)]
		public static bool isRunning => IsRunning;

		public static bool IsRunning { get; private set; }

		public static void Start(int historyLength)
		{
			if (!IsRunning)
			{
				EventIdCounter = 0;
				Ticks = new FixedQueue<ProfilerTick>(historyLength);
				tickHistory = historyLength;
				CurrentTick = null;
				IsRunning = true;
			}
		}

		public static void Stop()
		{
			Ticks = null;
			CurrentTick = null;
			IsRunning = false;
		}

		public static int Stop(ref ProfilerTick[] tickBuffer)
		{
			if (!IsRunning)
			{
				return 0;
			}
			int num = ((Ticks.Count > tickBuffer.Length) ? tickBuffer.Length : Ticks.Count);
			for (int i = 0; i < num; i++)
			{
				tickBuffer[i] = Ticks[i];
			}
			Ticks = null;
			CurrentTick = null;
			IsRunning = false;
			return num;
		}

		public static int Stop(ref List<ProfilerTick> tickBuffer)
		{
			if (!IsRunning)
			{
				return 0;
			}
			int num = ((Ticks.Count > tickBuffer.Count) ? tickBuffer.Count : Ticks.Count);
			for (int i = 0; i < num; i++)
			{
				tickBuffer[i] = Ticks[i];
			}
			Ticks = null;
			CurrentTick = null;
			IsRunning = false;
			return num;
		}

		internal static void StartTick(TickType type)
		{
			if (IsRunning)
			{
				if (Ticks.Count == tickHistory)
				{
					Ticks.Dequeue();
				}
				ProfilerTick profilerTick = new ProfilerTick
				{
					Type = type,
					Frame = Time.frameCount,
					EventId = EventIdCounter
				};
				EventIdCounter++;
				Ticks.Enqueue(profilerTick);
				CurrentTick = profilerTick;
			}
		}

		internal static void EndTick()
		{
			if (IsRunning && CurrentTick != null)
			{
				CurrentTick = null;
			}
		}

		internal static void StartEvent(TickType eventType, uint bytes, string channelName, byte messageType)
		{
			if (IsRunning && CurrentTick != null)
			{
				string messageType2 = ((messageType < MLAPIConstants.MESSAGE_NAMES.Length) ? MLAPIConstants.MESSAGE_NAMES[messageType] : "INVALID_MESSAGE_TYPE");
				CurrentTick.StartEvent(eventType, bytes, channelName, messageType2);
			}
		}

		internal static void StartEvent(TickType eventType, uint bytes, string channelName, string messageName)
		{
			if (IsRunning && CurrentTick != null)
			{
				CurrentTick.StartEvent(eventType, bytes, channelName, messageName);
			}
		}

		internal static void EndEvent()
		{
			if (IsRunning && CurrentTick != null)
			{
				CurrentTick.EndEvent();
			}
		}
	}
}
