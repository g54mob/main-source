namespace Brewery.Minigames
{
	public class ControlPanelPreset
	{
		public string stepName;

		public ControlDefinition[] controlDefs;

		public bool[] meterActive;

		public float[] meterStartValues;

		public float[] meterDriftRates;

		public float[] meterIdealCenters;

		public float[] meterIdealWidths;

		public float meterIdealJitter;

		public float overclockDriftMultiplier;

		public float heatToPressure;

		public float pressureToFoam;

		public float foamToPurity;

		public int maxTickScore;

		public int sustainedPerfectBonus;

		public int eventSolveBonus;

		public ControlPanelEventDef[] possibleEvents;

		public FuseTargetPattern[] fuseTargetPatterns;

		public static ControlPanelPreset GetPresetForStep(int stepIndex)
		{
			return null;
		}

		private static ControlPanelPreset CreateConvertPreset()
		{
			return null;
		}

		private static ControlPanelPreset CreateSterilizePreset()
		{
			return null;
		}

		private static ControlPanelPreset CreateCoolPreset()
		{
			return null;
		}

		private static ControlPanelPreset CreatePitchYeastPreset()
		{
			return null;
		}
	}
}
