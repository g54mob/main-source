using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HospitalPlotPrerequisitePlotBought : HospitalPlotPrerequisite
	{
		[InspectorTooltip("Valid if any of these plots are bought")]
		[SerializeField]
		private SharedInstance<HospitalPlotDefinition>[] _plot;

		public bool Valid(Level level)
		{
			SharedInstance<HospitalPlotDefinition>[] plot = _plot;
			foreach (SharedInstance<HospitalPlotDefinition> sharedInstance in plot)
			{
				HospitalPlot hospitalPlot = level.WorldState.GetHospitalPlot(sharedInstance.Instance);
				if (hospitalPlot != null && hospitalPlot.Bought)
				{
					return true;
				}
			}
			return false;
		}

		public string Description()
		{
			string text = ScriptLocalization.HospitalPlot.BuyPlot_CS.Replace(" ", "") + " ";
			int num = _plot.Length;
			string text2 = ((num > 1) ? (" " + ScriptLocalization.HospitalPlot.BuyPlotSeparator_CS.Replace(" ", "") + " ") : string.Empty);
			for (int i = 0; i < num; i++)
			{
				SharedInstance<HospitalPlotDefinition> sharedInstance = _plot[i];
				text += sharedInstance.Instance.NameLocalised.Translation;
				if (num != 1 && i != num - 1)
				{
					text += text2;
				}
			}
			return text;
		}
	}
}
