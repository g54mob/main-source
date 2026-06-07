using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;
using NWH.VehiclePhysics2.Powertrain;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public class WirelessPowertrainNode : IPowertrainNode
	{
		public bool IsConnectedToEngine { get; set; } = true;

		public bool IsEngine => false;

		public PartScript Part { get; private set; }

		public WirelessPowertrainNode(PartScript part)
		{
			Part = part;
		}

		public PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection)
		{
			PowertrainNode node = new PowertrainNode(this, inputConnection);
			node.InitializePowertrain = delegate(IPowertrain powertrain, PowertrainComponent inputComponent)
			{
				WirelessPowertrainComponent wirelessPowertrainComponent = new WirelessPowertrainComponent();
				foreach (PowertrainNode child in node.Children)
				{
					PowertrainComponent powertrainComponent = child.InitializePowertrain(powertrain, wirelessPowertrainComponent);
					if (powertrainComponent != null)
					{
						wirelessPowertrainComponent.Outputs.Add(powertrainComponent);
					}
				}
				return wirelessPowertrainComponent;
			};
			return node;
		}
	}
}
