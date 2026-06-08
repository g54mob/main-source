using System.Globalization;

namespace Timberborn.Persistence
{
	public static class CommonNumberSerializer
	{
		public static string SerializeInt(int value)
		{
			return value switch
			{
				0 => "0", 
				1 => "1", 
				2 => "2", 
				3 => "3", 
				4 => "4", 
				5 => "5", 
				6 => "6", 
				7 => "7", 
				8 => "8", 
				9 => "9", 
				10 => "10", 
				11 => "11", 
				12 => "12", 
				13 => "13", 
				14 => "14", 
				15 => "15", 
				16 => "16", 
				_ => value.ToString(CultureInfo.InvariantCulture), 
			};
		}

		public static string SerializeFloat(float value)
		{
			if (value <= 7f)
			{
				if (value <= 3f)
				{
					if (value <= 1f)
					{
						if (value == 0f)
						{
							return "0";
						}
						if (value == 1f)
						{
							return "1";
						}
					}
					else
					{
						if (value == 2f)
						{
							return "2";
						}
						if (value == 3f)
						{
							return "3";
						}
					}
				}
				else if (value <= 5f)
				{
					if (value == 4f)
					{
						return "4";
					}
					if (value == 5f)
					{
						return "5";
					}
				}
				else
				{
					if (value == 6f)
					{
						return "6";
					}
					if (value == 7f)
					{
						return "7";
					}
				}
			}
			else if (value <= 11f)
			{
				if (value <= 9f)
				{
					if (value == 8f)
					{
						return "8";
					}
					if (value == 9f)
					{
						return "9";
					}
				}
				else
				{
					if (value == 10f)
					{
						return "10";
					}
					if (value == 11f)
					{
						return "11";
					}
				}
			}
			else if (value <= 13f)
			{
				if (value == 12f)
				{
					return "12";
				}
				if (value == 13f)
				{
					return "13";
				}
			}
			else
			{
				if (value == 14f)
				{
					return "14";
				}
				if (value == 15f)
				{
					return "15";
				}
				if (value == 16f)
				{
					return "16";
				}
			}
			return value.ToString(CultureInfo.InvariantCulture);
		}
	}
}
