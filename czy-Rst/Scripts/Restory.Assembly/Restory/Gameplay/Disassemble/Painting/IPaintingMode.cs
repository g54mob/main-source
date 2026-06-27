namespace Restory.Gameplay.Disassemble.Painting
{
	public interface IPaintingMode
	{
		void Enter();

		void OnUpdate(float deltaTime);

		void PressExecuteButton();

		void ReleaseExecuteButton();

		void Redo();

		void Undo();

		void Exit();
	}
}
