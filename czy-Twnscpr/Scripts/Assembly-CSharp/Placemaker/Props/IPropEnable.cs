namespace Placemaker.Props
{
	public interface IPropEnable
	{
		void OnFirstEnable(WorldMaster master);

		void OnEnable(WorldMaster master);

		void OnDisable(WorldMaster master);
	}
}
