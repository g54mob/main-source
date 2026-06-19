using System.Reflection;
using SharpConfig;
using UnityConsole;

namespace TH20
{
	public static class DebugVars
	{
		public static DebugVarBool AllowStaffBreaks = new DebugVarBool(initialValue: true);

		public static DebugVarBool AllowNeedsFailure = new DebugVarBool(initialValue: true);

		public static DebugVarBool AllowParticleFX = new DebugVarBool(initialValue: true);

		public static DebugVarBool ShowDebugInfo = new DebugVarBool(initialValue: false);

		public static DebugVarBool ShowHospitalEntrances = new DebugVarBool(initialValue: false);

		public static DebugVarInt StaffRankOverride = new DebugVarInt(-1);

		public static DebugVarBool ShowPathfindingDebug = new DebugVarBool(initialValue: false);

		public static DebugVarBool ShowNavMeshUpdateDebug = new DebugVarBool(initialValue: false);

		public static DebugVarBool ShowRoomNavMeshDebug = new DebugVarBool(initialValue: false);

		public static DebugVarBool ShowWorkSchedule = new DebugVarBool(initialValue: false);

		public static DebugVarBool ShowWorkLifeBalance = new DebugVarBool(initialValue: false);

		public static DebugVarBool ShowPatientArrivalInfo = new DebugVarBool(initialValue: false);

		public static DebugVarBool ShowReputationTrackerInfo = new DebugVarBool(initialValue: false);

		public static DebugVarBool ShowNavPathInfo = new DebugVarBool(initialValue: false);

		public static DebugVarBool SkipFrontEnd = new DebugVarBool(initialValue: false);

		public static DebugVarBool SkipFrontEndToSandbox = new DebugVarBool(initialValue: false);

		public static DebugVarBool AllowYearlyReview = new DebugVarBool(initialValue: true);

		public static DebugVarBool BreakOnError = new DebugVarBool(initialValue: false);

		public static DebugVarBool ShowInteractionPoints = new DebugVarBool(initialValue: false);

		public static DebugVarBool AllowRoomRotation = new DebugVarBool(initialValue: true);

		public static DebugVarBool AllowTerrainModification = new DebugVarBool(initialValue: false);

		public static DebugVarBool EnableMonoBeasts = new DebugVarBool(initialValue: true);

		public static DebugVarBool ShowStatusIcons = new DebugVarBool(initialValue: true);

		public static DebugVarBool EnableHandsOnDemo = new DebugVarBool(initialValue: false);

		public static DebugVarBool DisableOldSaveVersionCheck = new DebugVarBool(initialValue: false);

		public static DebugVarBool EnableKeyBindings = new DebugVarBool(initialValue: true);

		public static DebugVarBool ShowCameraBounds = new DebugVarBool(initialValue: false);

		public static DebugVarBool EnableAwardsScreen = new DebugVarBool(initialValue: true);

		public static DebugVarBool EnableCorridorItemSell = new DebugVarBool(initialValue: true);

		public static DebugVarBool EnableCorridorItemSelection = new DebugVarBool(initialValue: true);

		public static DebugVarBool EnableAutoSaveMetagameOnChange = new DebugVarBool(initialValue: true);

		public static DebugVarBool DisableTutorialMessages = new DebugVarBool(initialValue: false);

		public static DebugVarBool FastLoadingScreenAnimation = new DebugVarBool(initialValue: false);

		public static DebugVarBool DisableBankruptcyFailure = new DebugVarBool(initialValue: false);

		public static DebugVarBool UseBehaviourTreePool = new DebugVarBool(initialValue: true);

		public static DebugVarBool ShowBehaviourTreePool = new DebugVarBool(initialValue: false);

		public static DebugVarBool PeriodicallyCloseAllFullScreenOrPauseTimeMenus = new DebugVarBool(initialValue: false);

		public static DebugVarBool DisableCursor = new DebugVarBool(initialValue: false);

		public static DebugVarBool DisableTopDownCameras = new DebugVarBool(initialValue: false);

		public static DebugVarBool EnableBehaviourTreeTickSlicing = new DebugVarBool(initialValue: true);

		public static DebugVarBool EnableSandboxMode = new DebugVarBool(initialValue: false);

		private static bool _initialised;

		public static void Initialise()
		{
			if (_initialised)
			{
				return;
			}
			FieldInfo[] fields = typeof(DebugVars).GetFields();
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.GetValue(null) is DebugVarBase debugVarBase)
				{
					debugVarBase.Name = fieldInfo.Name;
					ConsoleCommandsDatabase.RegisterCommand(debugVarBase.Name, "Sets " + debugVarBase.Name, $"{debugVarBase.Name} value", debugVarBase.SetValue);
					if (debugVarBase is DebugVarBool debugVarBool)
					{
						ConsoleCommandsDatabase.RegisterCommand("Toggle" + debugVarBool.Name, "Toggles " + debugVarBool.Name, $"{debugVarBool.Name}", debugVarBool.ToggleValue);
					}
				}
			}
			_initialised = true;
		}

		public static void SetValuesFromConfigFile(Configuration config)
		{
			foreach (DebugVarBase allVar in DebugVarBase.AllVars)
			{
				if (allVar.Name != null)
				{
					if (allVar is DebugVarBool debugVarBool && config["DebugVars"].Contains(allVar.Name))
					{
						debugVarBool.Value = config["DebugVars"][allVar.Name].BoolValue;
					}
					if (allVar is DebugVarInt debugVarInt && config["DebugVars"].Contains(allVar.Name))
					{
						debugVarInt.Value = config["DebugVars"][allVar.Name].IntValue;
					}
				}
			}
		}

		public static void SetValuesFromCommandLine()
		{
		}
	}
}
