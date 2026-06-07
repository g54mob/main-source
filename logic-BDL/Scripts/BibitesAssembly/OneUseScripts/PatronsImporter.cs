using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace OneUseScripts
{
	public class PatronsImporter
	{
		public static List<PatreonHistoryInfo> patreonHistoryInfos = new List<PatreonHistoryInfo>
		{
			new PatreonHistoryInfo("Léo, The Creator", int.MaxValue, "leo"),
			new PatreonHistoryInfo("Borgpol", 100000, "borgpolisi"),
			new PatreonHistoryInfo("Aentek", 100000, "aentekus"),
			new PatreonHistoryInfo("MayZ", 100000, "mayzi")
		};

		public static void LoadPatronsInfo()
		{
			TextAsset textAsset = Resources.Load<TextAsset>("Patrons/patreon_supporters");
			if (textAsset == null)
			{
				return;
			}
			List<string> list = textAsset.text.Replace("\r", "").Split("\n"[0]).ToList();
			for (int i = 1; i < list.Count; i++)
			{
				try
				{
					string[] array = list[i].Split(","[0]);
					if (array.Length > 3)
					{
						string[] array2 = new string[3]
						{
							array[0],
							null,
							null
						};
						for (int j = 1; j < array.Length - 2; j++)
						{
							ref string reference = ref array2[0];
							reference = reference + "," + array[j];
						}
						array2[0] = array2[0].Replace("\"", "").Replace(" ", "");
						array2[1] = array[^2].Replace(" ", "");
						array2[2] = array[^1].Replace(" ", "");
						array = array2;
					}
					if (!string.IsNullOrEmpty(array[0]) && !string.IsNullOrEmpty(array[1]) && !string.IsNullOrEmpty(array[2]))
					{
						patreonHistoryInfos.Add(new PatreonHistoryInfo(array[0], int.Parse(array[1]), array[2]));
					}
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
					throw;
				}
			}
			patreonHistoryInfos = patreonHistoryInfos.OrderByDescending((PatreonHistoryInfo s) => s.totalPledge).ToList();
			SpeciesNameGenerator.latinNames = patreonHistoryInfos.Select((PatreonHistoryInfo p) => p.latinized).ToList();
		}
	}
}
