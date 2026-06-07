namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public interface IHeatSource
	{
		float Temperature { get; }

		float GetHeatTransferRate(PartScript part);
	}
}
