using System.Collections.Generic;
using SettingScripts;
using SimulationScripts.BibiteScripts;

namespace Utility.InformationWrapers
{
	public static class NodeTypeSelection
	{
		public static List<SettingChoice<NEATBrain.NodeType>> nodeTypeChoices = new List<SettingChoice<NEATBrain.NodeType>>
		{
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Linear, "Linear", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Linear).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Abs, "Abs", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Abs).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.ReLu, "ReLU", NodeInformations.InfoOfFunction(NEATBrain.NodeType.ReLu).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Mult, "Multiplicative", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Mult).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Sigmoid, "Sigmoid", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Sigmoid).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.TanH, "TanH", NodeInformations.InfoOfFunction(NEATBrain.NodeType.TanH).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Sine, "Sinus", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Sine).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Gaussian, "Gaussian", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Gaussian).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Differential, "Differential", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Differential).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Inhibitory, "Inhibitory", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Inhibitory).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Integrator, "Integrator", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Integrator).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.Latch, "Latch", NodeInformations.InfoOfFunction(NEATBrain.NodeType.Latch).tooltipText),
			new SettingChoice<NEATBrain.NodeType>(NEATBrain.NodeType.SoftLatch, "Soft Latch", NodeInformations.InfoOfFunction(NEATBrain.NodeType.SoftLatch).tooltipText)
		};
	}
}
