using System;

public class Character
{
	public enum Class
	{
		Warrior = 0,
		Rogue = 1,
		Wizard = 2,
		Bard = 3
	}

	public static readonly Random RANDY = new Random();

	public Class type;

	public int shirt;

	public int hair;

	public Character()
		: this(CreateTablesHelpers.GetRandomValue(GetClasses()))
	{
	}

	public Character(Class type)
		: this(type, RANDY.Next(3) + 1, RANDY.Next(0, (type == Class.Warrior) ? 5 : 3) + 1)
	{
	}

	public Character(Class type, string username)
	{
		int num = StringToInt(username);
		this.type = type;
		shirt = num % 3 + 1;
		hair = ((type == Class.Warrior) ? (num % 5) : (num % 3)) + 1;
	}

	public Character(string username)
	{
		int num = StringToInt(username);
		type = GetClasses()[num % 4];
		shirt = num % 3 + 1;
		hair = ((type == Class.Warrior) ? (num % 5) : (num % 3)) + 1;
	}

	public Character(Class type, int shirt, int hair)
	{
		this.type = type;
		this.shirt = shirt;
		this.hair = hair;
	}

	private static int StringToInt(string username)
	{
		int num = 0;
		foreach (char c in username)
		{
			num += c;
		}
		return num;
	}

	public static Class[] GetClasses()
	{
		return (Class[])Enum.GetValues(typeof(Class));
	}

	public static string GetClassString(Class playerClass)
	{
		return playerClass switch
		{
			Class.Warrior => "Warrior", 
			Class.Bard => "Bard", 
			Class.Rogue => "Rogue", 
			Class.Wizard => "Wizard", 
			_ => null, 
		};
	}
}
