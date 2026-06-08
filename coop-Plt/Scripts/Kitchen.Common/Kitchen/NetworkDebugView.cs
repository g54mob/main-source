using System;
using System.Collections.Generic;
using System.Text;
using Kitchen.NetworkSupport;
using LiveSplit;
using Platforms;
using TMPro;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class NetworkDebugView : MonoBehaviour
	{
		public enum Mode
		{
			Off = 0,
			Debug = 1,
			Default = 2,
			FPS = 3,
			Achievements = 4
		}

		private struct DebugViewData : IViewData.ICheckForChanges<DebugViewData>
		{
			public string ChannelNames;

			public bool LiveSplitEnabled;

			public bool LiveSplitConnected;

			public bool IsChangedFrom(DebugViewData check)
			{
				if (!(ChannelNames != check.ChannelNames) && LiveSplitEnabled == check.LiveSplitEnabled)
				{
					return LiveSplitConnected != check.LiveSplitConnected;
				}
				return true;
			}

			public static DebugViewData New()
			{
				return new DebugViewData
				{
					LiveSplitEnabled = Preferences.Get<bool>(Pref.LiveSplitEnabled),
					LiveSplitConnected = global::LiveSplit.LiveSplit.IsConnected
				};
			}
		}

		public TextMeshPro Text;

		public Camera Camera;

		private float LastUpdateTime;

		public static Mode DisplayMode = (PlatformSettings.IsEditor ? Mode.FPS : (PlatformSettings.IsDebugBuild ? Mode.Debug : Mode.Default));

		private DebugViewData Data;

		private void Update()
		{
			if (DisplayMode != Mode.Off && !(Time.realtimeSinceStartup < LastUpdateTime + 0.1f))
			{
				LastUpdateTime = Time.realtimeSinceStartup;
				DebugViewData data = DebugViewData.New();
				if (data.IsChangedFrom(Data) || DisplayMode != Mode.Default)
				{
					Data = data;
					Redraw();
				}
			}
		}

		private void Redraw()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (DisplayMode == Mode.Achievements)
			{
				stringBuilder.AppendLine(GetAchievementLog());
			}
			if (DisplayMode == Mode.Debug)
			{
				stringBuilder.AppendLine(GetEventLog());
			}
			if (DisplayMode == Mode.Debug || DisplayMode == Mode.FPS)
			{
				try
				{
					RouterManager existingSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystem<RouterManager>();
					stringBuilder.AppendLine(UpdateUsingWorld(existingSystem));
				}
				catch (Exception arg)
				{
					stringBuilder.AppendLine($"Failed to get world ({arg})");
				}
			}
			if (DisplayMode == Mode.FPS || DisplayMode == Mode.Debug)
			{
				stringBuilder.AppendLine(GetFPSString());
			}
			if (Data.LiveSplitEnabled)
			{
				if (Data.LiveSplitConnected)
				{
					stringBuilder.AppendLine("LiveSplit ready");
				}
				else
				{
					stringBuilder.AppendLine($"<color=#ff0000>LiveSplit not connected (check the server component is running on port {16834}. Disable LiveSplit to prevent stuttering)</color>");
				}
			}
			Text.text = stringBuilder.ToString();
		}

		private string UpdateUsingWorld(RouterManager manager)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (manager == null)
			{
				return "Manager doesn't exist";
			}
			foreach (IViewRouter router in manager.Routers)
			{
				if (!(router is NetworkRouter networkRouter))
				{
					continue;
				}
				foreach (INetworkTransport transport in networkRouter.Transports)
				{
					stringBuilder.AppendLine(GetDetailsOf(transport));
					stringBuilder.AppendLine();
				}
			}
			return stringBuilder.ToString();
		}

		private string GetDetailsOf(INetworkTransport transport)
		{
			return transport.GetDebugInfo();
		}

		private string GetEventLog()
		{
			IEnumerable<LoggedEvent<string>> values = EventLog.Default.Tail(20);
			return string.Join("\n", values);
		}

		private string GetAchievementLog()
		{
			IEnumerable<LoggedEvent<string>> values = EventLog.Achievements.Tail(20);
			return string.Join("\n", values);
		}

		private string GetFPSString()
		{
			string arg = $"{Camera.pixelWidth}x{Camera.pixelHeight}";
			return $"FPS {1f / Time.unscaledDeltaTime:F2}, FrameTimeFPS {1f / TimerSystems.FrameTime:F2} - {arg}";
		}
	}
}
