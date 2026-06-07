namespace ReinforcementLearning.Environment
{
	internal interface IEnvironment<Presets, InternalStateType, ExternalStateType, ActionType>
	{
		ExternalStateType State { get; }

		long ActionsNumber { get; }

		void Render();

		ExternalStateType Reset();

		Episode<ExternalStateType, ActionType> Step(ActionType action);
	}
}
