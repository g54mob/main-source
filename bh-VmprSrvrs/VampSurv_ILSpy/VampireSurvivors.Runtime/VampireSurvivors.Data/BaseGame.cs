namespace VampireSurvivors.Data;

public class BaseGame
{
	private static BaseGameData _baseGameData;

	public static BaseGameData Data
	{
		get
		{
			return _baseGameData;
		}
		set
		{
			_baseGameData = value;
		}
	}

	public static void ClearBuildMeta()
	{
	}
}
