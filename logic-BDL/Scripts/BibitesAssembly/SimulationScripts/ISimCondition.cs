using ScriptHelpers;

namespace SimulationScripts
{
	public interface ISimCondition : ISaveable
	{
		bool EvaluateIsMet();
	}
}
