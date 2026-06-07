namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface ICarEngineWheel
	{
		float Rpm { get; }

		void SetEngineTorque(float engineTorque);
	}
}
