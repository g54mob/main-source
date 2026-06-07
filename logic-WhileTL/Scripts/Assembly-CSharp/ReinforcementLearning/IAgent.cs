namespace ReinforcementLearning
{
	public interface IAgent<StateType, ActionType>
	{
		ActionType GetAction(StateType state);

		void Update();

		void AddEpisode(Episode<StateType, ActionType> episode);
	}
}
