using System;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class NameRepository : DynamicJsonRepository<NameRepository, Names>
	{
		private Names Names
		{
			get
			{
				string currentLanguageName = MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageName();
				return GetByID(currentLanguageName) ?? GetByID("English");
			}
		}

		public string GetFirstName(Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new Random();
			}
			return GetFirstName((BodyType)rnd.Next(0, EnumValues.BodyTypes.Length), rnd);
		}

		public string GetFirstName(BodyType bodyType, Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new Random();
			}
			if (bodyType.Equals(BodyType.Male))
			{
				return Names.FirstNamesMale[rnd.Next(0, Names.FirstNamesMale.Count)];
			}
			return Names.FirstNamesFemale[rnd.Next(0, Names.FirstNamesFemale.Count)];
		}

		public string GetLastName(Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new Random();
			}
			return Names.LastNames[rnd.Next(0, Names.LastNames.Count)];
		}

		protected override string JsonFile()
		{
			return "Worker/Name.json";
		}
	}
}
