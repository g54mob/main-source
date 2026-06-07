namespace Lightbug.CharacterControllerPro.Implementation
{
	public interface IUpdatable
	{
		void PreUpdateBehaviour(float dt);

		void UpdateBehaviour(float dt);

		void PostUpdateBehaviour(float dt);
	}
}
