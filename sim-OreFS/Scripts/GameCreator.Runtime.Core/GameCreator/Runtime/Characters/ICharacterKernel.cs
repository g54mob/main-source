namespace GameCreator.Runtime.Characters
{
	public interface ICharacterKernel
	{
		IUnitPlayer Player { get; }

		IUnitMotion Motion { get; }

		IUnitDriver Driver { get; }

		IUnitFacing Facing { get; }

		IUnitAnimim Animim { get; }

		Character Character { get; }

		void OnStartup(Character character);

		void AfterStartup(Character character);

		void OnDispose(Character character);

		void OnEnable();

		void OnDisable();

		void OnUpdate();

		void OnDrawGizmos(Character character);
	}
}
