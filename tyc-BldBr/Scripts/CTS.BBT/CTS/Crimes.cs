using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public static class Crimes
	{
		private static readonly HashSet<Crime> _crimeList = new HashSet<Crime>();

		public static int Count => _crimeList.Count;

		public static int ConstantCount
		{
			get
			{
				int num = 0;
				foreach (Crime crime in _crimeList)
				{
					if (!crime.IsTemporary)
					{
						num++;
					}
				}
				return num;
			}
		}

		public static HashSetEnumerator<Crime> Enumerate => new HashSetEnumerator<Crime>(_crimeList);

		public static void Copy(List<Crime> list)
		{
			foreach (Crime crime in _crimeList)
			{
				list.Add(crime);
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			_crimeList.Clear();
		}

		public static void AddCrime(Crime crime)
		{
			RemoveCrime(crime);
			_crimeList.Add(crime);
		}

		public static void RemoveCrime(Crime crime)
		{
			_crimeList.Remove(crime);
		}

		public static List<Crime> FindCrimesForParent(Transform parent)
		{
			List<Crime> list = new List<Crime>();
			foreach (Crime crime in _crimeList)
			{
				if (crime.transform.parent == parent)
				{
					list.Add(crime);
				}
			}
			return list;
		}
	}
}
