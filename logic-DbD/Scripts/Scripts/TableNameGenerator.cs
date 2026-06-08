public class TableNameGenerator
{
	public static int resultId;

	public static string GetName()
	{
		resultId++;
		Save.SaveGame();
		return "result_" + resultId;
	}

	public static void ClearName()
	{
		resultId = 0;
	}
}
