using Assets.Scripts.Craft.Parts.Modifiers.Powertrain.Tree;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	public abstract class PowertrainModifierScript : PartModifierScript, IPowertrainNode
	{
		public bool IsConnectedToEngine { get; set; }

		public virtual bool IsEngine => false;

		public PartScript Part => base.PartScript;

		public abstract PowertrainNode CreatePowertrainNode(PowertrainNodeConnection inputConnection);
	}
}
