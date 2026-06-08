using System.Collections.Generic;

public class Level9 : Level
{
	public const int LEVEL_NUMBER = 9;

	protected static ICollection<string> everyone = new HashSet<string>();

	public static void Create(bool hasLoad)
	{
	}

	private static void AddSuspect(List<Suspect> suspects, int number, string first, string last, string job)
	{
		suspects.Add(new Suspect(number, first, last, job));
		CreateTablesHelpers.AddName(everyone, (first, last));
	}

	public static ICollection<string> GetAllPossibleSuspects()
	{
		return everyone;
	}
}
