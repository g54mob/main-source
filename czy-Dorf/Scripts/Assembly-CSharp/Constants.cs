using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Dorfromantik.UI;
using UnityEngine;

public static class Constants
{
	public static class PlayerPrefKeys
	{
		public static readonly string[] SelectedSessionQuests = new string[3] { "SelectedSessionQuest0", "SelectedSessionQuest1", "SelectedSessionQuest2" };

		public static readonly string[] ActiveSessionQuests = new string[3] { "ActiveSessionQuest0", "ActiveSessionQuest1", "ActiveSessionQuest2" };
	}

	public static class Settings
	{
		public static class Graphics
		{
			public static readonly int[] AntiAliasingMultiplierByLevel = new int[4] { 8, 4, 2, 0 };

			public static readonly int[] FrameCapByLevel = new int[4] { -1, 120, 60, 30 };

			public static readonly int[] QualityLevelByInputLevel = new int[3] { 2, 1, 0 };

			public static readonly int[] AntiAliasingLevelByQualityLevel = new int[3] { 1, 2, 3 };

			public static readonly int[] FrameCapLevelByQualityLevel = new int[3] { 2, 2, 3 };

			public static readonly int[] VsyncCountByLevel = new int[3] { 1, 2, 0 };

			public static readonly int[] VsyncLevelByQualityLevel = new int[3] { 0, 0, 1 };

			public static readonly int[] MeshQualityLevelByQualityLevel = new int[3] { 0, 0, 1 };

			public static readonly Dictionary<int, UiScalingLevelId> UiScaleByLevel = new Dictionary<int, UiScalingLevelId>
			{
				{
					0,
					UiScalingLevelId.Default
				},
				{
					1,
					UiScalingLevelId.Large
				}
			};

			public static string DynamicBackgroundEnabled = "DynamicBackgroundEnabled";

			public static string MeshQualityLevel = "MeshQualityLevel";

			public static string DisableAAWhileMovingCam = "DisableAntiAliasingWhileMovingCamera";

			public static string UiScale = "UiScale";
		}

		public static string IsSteamDeckUiInitialized = "IsSteamDeckUiInitialized";
	}

	public static class SaveLoad
	{
		public static string FullRewardDataPath => Path.Combine(persistentDataPath, "Rewards01.sav");

		public static string FullChallengeDataPath => Path.Combine(persistentDataPath, "SessionQuests01.sav");

		public static string SaveGamePathWithinPersistentDataPath(string fileName)
		{
			if (!fileName.Contains(".sav"))
			{
				fileName += ".sav";
			}
			return Path.Combine("Saves", fileName);
		}
	}

	public static class UI
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Colors
		{
			public static readonly Color Transparent = new Color(1f, 1f, 1f, 0f);

			public static readonly Color SelectedBlack = new Color(8f / 85f, 8f / 85f, 8f / 85f, 1f);

			public static readonly Color HoverWhite = new Color(1f, 1f, 1f, 0.2509804f);

			public static readonly Color HoverLightWhite = new Color(1f, 1f, 1f, 0.1254902f);

			public static readonly Color QuestFulfilled = new Color(0.686f, 0.831f, 0.435f, 1f);

			public static readonly Color QuestFailed = new Color(0.886f, 0.471f, 0.38f, 1f);

			public static readonly Color DebugMirroringPlaceholder = new Color(1f, 1f, 0f, 0.2f);

			public static readonly Color DebugSpacer = new Color(0f, 1f, 1f, 0.2f);
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct ColorModifier
		{
			public static readonly Color Black75Percent = new Color(0.25f, 0.25f, 0.25f, 1f);

			public static readonly Color Black95Percent = new Color(0.05f, 0.05f, 0.05f, 1f);
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct UiStateAlpha
		{
			public static readonly float Enabled = 1f;

			public static readonly float Disabled = 0.25f;
		}
	}

	public class MaterialParameters
	{
		public static string GroupType = "_GroupType";
	}

	public static readonly List<GroupTypeId> AllGroupTypes = new List<GroupTypeId>
	{
		GroupTypeId.Village,
		GroupTypeId.Forest,
		GroupTypeId.Agriculture,
		GroupTypeId.Water,
		GroupTypeId.TrainTracks
	};

	public static string persistentDataPath
	{
		get
		{
			if (Application.platform == RuntimePlatform.Switch)
			{
				return "Saves:/";
			}
			return Application.persistentDataPath;
		}
	}
}
