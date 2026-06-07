using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	[DefaultExecutionOrder(-1)]
	public class NameGeneratorManager : MonoSingleton<NameGeneratorManager>
	{
		[Space(10f)]
		[Header("ScriptableObjects")]
		[SerializeField]
		private NamesScriptable _femaleNames;

		[SerializeField]
		private NamesScriptable _maleNames;

		[SerializeField]
		private NamesScriptable _unisexNames;

		[Space(10f)]
		[Header("Debug View")]
		[SerializeField]
		private string _returnedValue;

		[Space(10f)]
		[SerializeField]
		private List<string> _femaleFirstNames;

		[SerializeField]
		private List<string> _femaleLastNames;

		[SerializeField]
		private List<string> _maleFirstNames;

		[SerializeField]
		private List<string> _maleLastNames;

		[SerializeField]
		private List<string> _unisexFirstNames;

		[SerializeField]
		private List<string> _unisexLastNames;

		[field: SerializeField]
		public NamesDataSO NameDataSO { get; private set; }

		protected override void SingletonAwake()
		{
			CleanArrays();
		}

		protected override void OnSingletonDestroy()
		{
		}

		private void CleanArrays()
		{
			CleanArray(_femaleNames.dataArray, _femaleFirstNames, _femaleLastNames);
			CleanArray(_maleNames.dataArray, _maleFirstNames, _maleLastNames);
			CleanArray(_unisexNames.dataArray, _unisexFirstNames, _unisexLastNames);
		}

		private static void CleanArray(IEnumerable<NamesData> data, ICollection<string> firstNameList, ICollection<string> lastNameList)
		{
			firstNameList.Clear();
			lastNameList.Clear();
			foreach (NamesData datum in data)
			{
				if (!string.IsNullOrEmpty(datum.Firstname))
				{
					firstNameList.Add(datum.Firstname);
					lastNameList.Add(datum.Lastname);
				}
			}
		}

		public string GetFirstName(int gender)
		{
			return GetFirstName((EGender)gender);
		}

		public string GetFirstName(EGender gender)
		{
			return gender switch
			{
				EGender.Female => GetFirstName(_femaleNames, _femaleFirstNames, _femaleLastNames), 
				EGender.Male => GetFirstName(_maleNames, _maleFirstNames, _maleLastNames), 
				EGender.NonBinary => GetFirstName(_unisexNames, _unisexFirstNames, _unisexLastNames), 
				_ => "Code", 
			};
		}

		private string GetFirstName(NamesScriptable data, IList<string> firstNamesList, ICollection<string> lastNamesList)
		{
			if (firstNamesList.Count <= 0)
			{
				return "Code";
			}
			string random = firstNamesList.GetRandom();
			firstNamesList.Remove(random);
			if (firstNamesList.Count <= 0)
			{
				CleanArray(data.dataArray, firstNamesList, lastNamesList);
			}
			return random;
		}

		public string GetLastName(int gender)
		{
			return GetLastName((EGender)gender);
		}

		public string GetLastName(EGender gender)
		{
			return gender switch
			{
				EGender.Female => GetLastName(_femaleNames, _femaleFirstNames, _femaleLastNames), 
				EGender.Male => GetLastName(_maleNames, _maleFirstNames, _maleLastNames), 
				EGender.NonBinary => GetLastName(_unisexNames, _unisexFirstNames, _unisexLastNames), 
				_ => "Joker", 
			};
		}

		private string GetLastName(NamesScriptable data, ICollection<string> firstNamesList, IList<string> lastNamesList)
		{
			if (lastNamesList.Count <= 0)
			{
				return "Joker";
			}
			string random = lastNamesList.GetRandom();
			lastNamesList.Remove(random);
			if (lastNamesList.Count <= 0)
			{
				CleanArray(data.dataArray, firstNamesList, lastNamesList);
			}
			return random;
		}

		public string GetFullname(EGender gender)
		{
			_returnedValue = GetFirstName(gender) + " " + GetLastName(gender);
			return _returnedValue;
		}

		public void AddFirstName(EGender gender, string firstName)
		{
			switch (gender)
			{
			case EGender.Female:
				_femaleFirstNames.Add(firstName);
				break;
			case EGender.Male:
				_maleFirstNames.Add(firstName);
				break;
			case EGender.NonBinary:
				_unisexFirstNames.Add(firstName);
				break;
			}
		}

		public void AddLastName(EGender gender, string lastName)
		{
			switch (gender)
			{
			case EGender.Female:
				_femaleLastNames.Add(lastName);
				break;
			case EGender.Male:
				_maleLastNames.Add(lastName);
				break;
			case EGender.NonBinary:
				_unisexLastNames.Add(lastName);
				break;
			}
		}
	}
}
