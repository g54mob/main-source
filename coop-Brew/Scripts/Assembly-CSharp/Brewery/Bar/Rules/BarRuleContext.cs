using InteractionSystem;
using MyStuff.Environment;

namespace Brewery.Bar.Rules
{
	public struct BarRuleContext
	{
		public TimeOfDayManager TimeManager;

		public LightSwitchInteractable[] BarLights;

		public LightSwitchInteractable[] OutsideBarLights;

		public ACController InsideAC;

		public HeaterController OutsideHeater;

		public WindowCleanableController[] Windows;

		public SpeakerController Speaker;

		public BarStateManager BarState;

		public TableCleanableController[] Tables;

		public int NPCsAtBarCount => 0;

		public int NPCsOnOutsideSpotsCount => 0;

		public int InsideNPCsCount => 0;

		public bool HasNPCsAtBar => false;

		public bool HasOutsideNPCs => false;

		public bool HasInsideNPCs => false;

		public bool IsDaytime => false;

		public bool IsNighttime => false;

		public bool AnyLightsOn => false;

		public bool AllLightsOn => false;

		public int LightsOnCount => 0;

		public int TotalLightsCount => 0;

		public bool AnyOutsideLightsOn => false;

		public bool AllOutsideLightsOn => false;

		public bool HasInsideAC => false;

		public bool IsACRunning => false;

		public bool IsACHeating => false;

		public bool IsACCooling => false;

		public ACMode ACCurrentMode => default(ACMode);

		public float ACTimeRemaining => 0f;

		public bool HasOutsideHeater => false;

		public bool IsHeaterOn => false;

		public float HeaterTimeRemaining => 0f;

		public bool HasWindows => false;

		public int WindowCount => 0;

		public int TotalWindowSpots => 0;

		public int TotalWindowCapacity => 0;

		public float WindowDirtinessRatio => 0f;

		public bool AllWindowsClean => false;

		public bool AnyWindowDirty => false;

		public bool HasTables => false;

		public int TableCount => 0;

		public int TotalTableBottles => 0;

		public int TotalTableCapacity => 0;

		public float TableDirtinessRatio => 0f;

		public bool AllTablesClean => false;

		public bool AnyTableDirty => false;

		public bool HasSpeaker => false;

		public bool IsSpeakerOn => false;

		public float SpeakerTimeRemaining => 0f;
	}
}
