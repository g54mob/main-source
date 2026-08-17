using System.Text.RegularExpressions;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Menu.Shop;
using Assets.Scripts.UI.Localization;

public static class EnumUtility
{
	public static string EnumToReadable(string s)
	{
		return Regex.Replace(s, "((?<=\\p{Ll})\\p{Lu})|((?!\\A)\\p{Lu}(?>\\p{Ll}))", " $0");
	}

	public static string EnumToReadable(EStat eStat)
	{
		return LocalizationUtility.GetStatName(eStat);
	}

	public static bool HasFlagsAny(EEnemyFlag value, EEnemyFlag flags)
	{
		//IL_000d: Expected O, but got I4
		object obj = flags & value;
		bool flag = obj == null;
		return !flag;
	}

	public static bool HasFlagsAll(EEnemyFlag value, EEnemyFlag flags)
	{
		//IL_000d: Expected O, but got I4
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		object obj = value & flags;
		object obj2 = obj - flags;
		return obj2 == null;
	}
}
