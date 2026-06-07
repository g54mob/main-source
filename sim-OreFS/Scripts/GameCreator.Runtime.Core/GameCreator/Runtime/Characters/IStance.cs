namespace GameCreator.Runtime.Characters
{
	public interface IStance
	{
		int Id { get; }

		Character Character { get; set; }

		void OnEnable(Character character);

		void OnDisable(Character character);

		void OnUpdate();
	}
}
