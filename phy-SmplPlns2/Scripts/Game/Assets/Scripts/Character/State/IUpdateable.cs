namespace Assets.Scripts.Character.State
{
	public interface IUpdateable
	{
		void PostUpdateBehaviour(float dt);

		void PreUpdateBehaviour(float dt);

		void UpdateBehaviour(float dt);
	}
}
