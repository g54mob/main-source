using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public interface IPowertrainNode
	{
		bool IsConnectedToEngine { get; set; }

		bool IsEngine { get; }

		PartScript Part { get; }

		PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection);
	}
}
