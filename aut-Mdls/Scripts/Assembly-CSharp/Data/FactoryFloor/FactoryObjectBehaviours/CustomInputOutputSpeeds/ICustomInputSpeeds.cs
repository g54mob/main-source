namespace Data.FactoryFloor.FactoryObjectBehaviours.CustomInputOutputSpeeds
{
	public interface ICustomInputSpeeds
	{
		bool IsConfigSet();

		int[] GetInputFrequencies();
	}
}
