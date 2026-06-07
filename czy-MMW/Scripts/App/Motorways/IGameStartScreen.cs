namespace Motorways
{
	public interface IGameStartScreen
	{
		void PrepareForNewGame(CityDefinition newCity, MapDefinition newMapDefinition, MotorwaysGame game, MapChallenge newMapChallenge = null, bool startPaused = false);
	}
}
