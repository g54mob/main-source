namespace SickDev.CommandSystem
{
	internal static class Parsers
	{
		private const string nullObject = "null";

		[Parser(typeof(string))]
		private static string ParseString(string value)
		{
			return value.Equals("null") ? null : value;
		}

		[Parser(typeof(bool))]
		private static bool ParseBool(string value)
		{
			bool result = false;
			if (bool.TryParse(value, out result))
			{
				return result;
			}
			if (int.TryParse(value, out var result2))
			{
				switch (result2)
				{
				case 1:
					return true;
				case 0:
					return false;
				default:
					throw new InvalidArgumentFormatException<bool>(value);
				}
			}
			if (value.Equals("yes") || value.Equals("y") || value.Equals("t"))
			{
				return true;
			}
			if (value.Equals("no") || value.Equals("n") || value.Equals("f"))
			{
				return false;
			}
			throw new InvalidArgumentFormatException<bool>(value);
		}

		[Parser(typeof(bool?))]
		private static bool? ParseNullableBool(string value)
		{
			try
			{
				return value.Equals("null") ? ((bool?)null) : new bool?(ParseBool(value));
			}
			catch (CommandSystemException ex)
			{
				throw ex;
			}
		}

		[Parser(typeof(int))]
		private static int ParseInt(string value)
		{
			try
			{
				return int.Parse(value.Trim());
			}
			catch
			{
				throw new InvalidArgumentFormatException<int>(value);
			}
		}

		[Parser(typeof(int?))]
		private static int? ParseNullableInt(string value)
		{
			try
			{
				return value.Equals("null") ? ((int?)null) : new int?(ParseInt(value));
			}
			catch (CommandSystemException ex)
			{
				throw ex;
			}
		}

		[Parser(typeof(float))]
		private static float ParseFloat(string value)
		{
			try
			{
				return float.Parse(value.Trim());
			}
			catch
			{
				throw new InvalidArgumentFormatException<float>(value);
			}
		}

		[Parser(typeof(float?))]
		private static float? ParseNullableFloat(string value)
		{
			try
			{
				return value.Equals("null") ? ((float?)null) : new float?(ParseFloat(value));
			}
			catch (CommandSystemException ex)
			{
				throw ex;
			}
		}

		[Parser(typeof(char))]
		private static char ParseChar(string value)
		{
			try
			{
				return char.Parse(value);
			}
			catch
			{
				throw new InvalidArgumentFormatException<char>(value);
			}
		}

		[Parser(typeof(char?))]
		private static char? ParseNullableChar(string value)
		{
			try
			{
				return value.Equals("null") ? ((char?)null) : new char?(ParseChar(value));
			}
			catch (CommandSystemException ex)
			{
				throw ex;
			}
		}
	}
}
