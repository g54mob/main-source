namespace PajamaLlama.Flotsam.Narrative
{
	public interface IScenarioPersistentData
	{
		ScenarioBase Restore(PrototypeScenario fallbackScenario);
	}
}
