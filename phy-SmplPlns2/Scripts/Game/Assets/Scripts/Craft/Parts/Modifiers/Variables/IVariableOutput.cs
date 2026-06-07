namespace Assets.Scripts.Craft.Parts.Modifiers.Variables
{
	public interface IVariableOutput
	{
		PartModifierData PartModifier { get; }

		void UpdateOutputs();
	}
}
