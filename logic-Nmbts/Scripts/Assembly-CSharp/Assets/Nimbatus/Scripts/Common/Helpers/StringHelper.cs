using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.Common.Helpers
{
	public static class StringHelper
	{
		public static string GenerateRandomWeaponName(Random randomGenerator, Emitter emitter, Ammunition ammo)
		{
			string translation = LocalizationManager.GetTermTranslation("DroneWorkshop/RandomWeaponName");
			string value = GenerateRandomName(randomGenerator.Next(4, 7), randomGenerator);
			string value2 = randomGenerator.Next(0, 10000).ToString();
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string>
			{
				{
					"AmmoName",
					ammo.Name.GetTranslation()
				},
				{
					"WeaponName",
					emitter.Name.GetTranslation()
				},
				{ "RandomName", value },
				{ "RandomNumber", value2 }
			});
			return translation;
		}

		public static string GenerateStarterWeaponName(Random randomGenerator, Emitter emitter, Ammunition ammo)
		{
			string translation = LocalizationManager.GetTermTranslation("DroneWorkshop/StartingWeaponName");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string>
			{
				{
					"AmmoName",
					ammo.Name.GetTranslation()
				},
				{
					"WeaponName",
					emitter.Name.GetTranslation()
				}
			});
			return translation;
		}

		public static string GenerateRandomLocationName(Random randomGenerator)
		{
			return GenerateRandomName(randomGenerator.Next(4, 7), randomGenerator);
		}

		public static string GenerateRandomName(int minLength, Random randomGenerator)
		{
			minLength = randomGenerator.Next(minLength, minLength + 2);
			string[] array = new string[21]
			{
				"b", "c", "d", "f", "g", "h", "j", "k", "l", "m",
				"n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w",
				"x"
			};
			string[] array2 = new string[7] { "a", "e", "i", "o", "u", "ae", "y" };
			string text = "";
			text += array[randomGenerator.Next(array.Length)];
			text += array2[randomGenerator.Next(array2.Length)];
			int num;
			for (num = 2; num < minLength; num++)
			{
				text += array[randomGenerator.Next(array.Length)];
				num++;
				text += array2[randomGenerator.Next(array2.Length)];
			}
			return text.First().ToString().ToUpper() + text.Substring(1);
		}

		public static string ToTimeString(this float myFloat)
		{
			char paddingChar = '0';
			TimeSpan timeSpan = TimeSpan.FromSeconds(myFloat);
			string text = (timeSpan.Days * 24 * 60 + timeSpan.Hours * 60 + timeSpan.Minutes).ToString("F0", CultureInfo.InvariantCulture).PadLeft(2, paddingChar);
			string text2 = timeSpan.Seconds.ToString("F0", CultureInfo.InvariantCulture).PadLeft(2, paddingChar);
			string text3 = timeSpan.Milliseconds.ToString("F0", CultureInfo.InvariantCulture).PadLeft(3, paddingChar);
			return text + ":" + text2 + "." + text3;
		}
	}
}
