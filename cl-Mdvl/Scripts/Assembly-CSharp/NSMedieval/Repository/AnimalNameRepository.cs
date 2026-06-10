using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Repository
{
	public class AnimalNameRepository : DynamicJsonRepository<AnimalNameRepository, AnimalName>
	{
		private AnimalName Names
		{
			get
			{
				string currentLanguageName = MonoSingleton<LocalizationController>.Instance.GetCurrentLanguageName();
				return GetByID(currentLanguageName) ?? GetByID("English");
			}
		}

		public string GetName()
		{
			return GetName((BodyType)Random.Range(0, EnumValues.BodyTypes.Length));
		}

		public string GetName(BodyType bodyType)
		{
			if (bodyType.Equals(BodyType.Male))
			{
				return Names.NamesMale[Random.Range(0, Names.NamesMale.Count)];
			}
			return Names.NamesFemale[Random.Range(0, Names.NamesFemale.Count)];
		}

		protected override string JsonFile()
		{
			return "Animal/AnimalName.json";
		}
	}
}
