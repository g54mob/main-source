using System;
using UnityEngine;

namespace Motorways
{
	[Serializable]
	public class NewsAndNotificationObject
	{
		[Serializable]
		public struct DateTimeEditable
		{
			public int Day;

			public int Month;

			public int Year;
		}

		[Serializable]
		public enum RuntimeVariant
		{
			DefaultEditor = 0,
			Steam = 1,
			Humble = 2,
			Arcade = 3,
			AppStore = 4,
			WeGame = 5,
			Demo = 6,
			Eshop = 7
		}

		public string ContentIndicatorID;

		public StringId HeaderID;

		public StringId BodyID;

		public string WebLink;

		public DateTimeEditable StartDateTimeEditable;

		public DateTimeEditable EndDateTimeEditable;

		public RuntimePlatform AvailablePlatform;

		public RuntimeVariant AvailableVariant;

		public NewsAndNotificationObject(string contentIndicatorID, StringId headerID, StringId bodyID, string weblink, DateTimeEditable startDateTimeEditable, DateTimeEditable endDateTimeEditable, RuntimeVariant availableVariant)
		{
			ContentIndicatorID = contentIndicatorID;
			HeaderID = headerID;
			BodyID = bodyID;
			WebLink = weblink;
			StartDateTimeEditable = startDateTimeEditable;
			EndDateTimeEditable = endDateTimeEditable;
			AvailableVariant = availableVariant;
		}

		public DateTime StartDateTime()
		{
			return new DateTime(StartDateTimeEditable.Year, StartDateTimeEditable.Month, StartDateTimeEditable.Day);
		}

		public DateTime EndDateTime()
		{
			return new DateTime(EndDateTimeEditable.Year, EndDateTimeEditable.Month, EndDateTimeEditable.Day);
		}

		public static RuntimeVariant EnvironmentToVariant(IEnvironment environment)
		{
			if (environment is WindowsSteamEnvironment)
			{
				return RuntimeVariant.Steam;
			}
			if (environment is WindowsHumbleEnvironment)
			{
				return RuntimeVariant.Steam;
			}
			if (environment is macOSSteamEnvironment)
			{
				return RuntimeVariant.Steam;
			}
			if (environment is macOSHumbleEnvironment)
			{
				return RuntimeVariant.Steam;
			}
			if (environment is iOSAppStoreEnvironment)
			{
				return RuntimeVariant.Arcade;
			}
			if (environment is iOSRetailDemoEnvironment)
			{
				return RuntimeVariant.Arcade;
			}
			if (environment is tvOSAppStoreEnvironment)
			{
				return RuntimeVariant.Arcade;
			}
			if (environment is tvOSRetailDemoEnvironment)
			{
				return RuntimeVariant.Arcade;
			}
			if (environment is macOSAppStoreEnvironment)
			{
				return RuntimeVariant.Arcade;
			}
			return RuntimeVariant.DefaultEditor;
		}
	}
}
