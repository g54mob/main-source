using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using Newtonsoft.Json.Linq;
using OneUseScripts;
using ScriptHelpers;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace Utility.DataLogging
{
	public class LineageVersionUpdater
	{
		public static Version toSpeciesData = new Version(0, 6, 0, 10);

		private static LogLikeConfig configPre06a10 = new LogLikeConfig(new LogLikeFormat[11]
		{
			new LogLikeFormat(30, 2),
			new LogLikeFormat(30, 3),
			new LogLikeFormat(35, 5),
			new LogLikeFormat(38, 2),
			new LogLikeFormat(48, 3),
			new LogLikeFormat(32, 4),
			new LogLikeFormat(42, 2),
			new LogLikeFormat(56, 2),
			new LogLikeFormat(42, 2),
			new LogLikeFormat(49, 4),
			new LogLikeFormat(91)
		}, Timescale.Minutes);

		private static DataLoggerBucket<SaveableStructArray<SpeciesInfo>> older06a10Datas = new DataLoggerBucket<SaveableStructArray<SpeciesInfo>>(configPre06a10.formats, isSerial: true).InsertZero(SaveableStructArray<SpeciesInfo>.Empty());

		public static float pre06a10MaxEnergy => older06a10Datas.GetAllData().Max((SaveableStructArray<SpeciesInfo> p) => p.array.Sum((SpeciesInfo s) => s.energy));

		public static int nRecords => older06a10Datas.nData;

		public static void LoadOlder06a10Data(JToken speciesData)
		{
			SerializationHelper.DeserializeObject(older06a10Datas, speciesData);
		}

		public static void ImportFromPre06a10(List<Species> recordedSpecies)
		{
			Dictionary<long, (int, int)> dictionary = new Dictionary<long, (int, int)>();
			List<long> list = new List<long>();
			List<long> list2 = new List<long>();
			SaveableStructArray<SpeciesInfo>[] allData = older06a10Datas.GetAllData();
			for (int i = 0; i < allData.Length; i++)
			{
				foreach (SpeciesInfo item3 in allData[i])
				{
					if (item3.count < 1 || list.Contains(item3.species))
					{
						list2.Add(item3.species);
						continue;
					}
					if (!dictionary.ContainsKey(item3.species))
					{
						dictionary.Add(item3.species, (i, 0));
					}
					list.Add(item3.species);
					list2.Add(item3.species);
				}
				List<long> list3 = list.Except(list2).ToList();
				list2.Clear();
				foreach (long item4 in list3)
				{
					dictionary[item4] = (dictionary[item4].Item1, i - 1);
					list.Remove(item4);
				}
			}
			foreach (long item5 in list)
			{
				dictionary[item5] = (dictionary[item5].Item1, allData.Length - 1);
			}
			int[] pushCountersNewFormat = older06a10Datas.GetPushCountersNewFormat();
			LogLikeConfig serialSpeciesConfig = DataLogger.SerialSpeciesConfig;
			foreach (Species species in recordedSpecies)
			{
				if (!dictionary.ContainsKey(species.speciesID))
				{
					continue;
				}
				(int, int) tuple = dictionary[species.speciesID];
				int item = tuple.Item1;
				int item2 = tuple.Item2;
				int[] array = configPre06a10.OldLogTimesOfConfig(item, item2);
				var (num, array2) = serialSpeciesConfig.IndexAndLogTimesOfSpan(array[0], array[^1], includeFedPoints: true);
				if (array2.Length < 1)
				{
					continue;
				}
				LogLikeSpeciesDataArray speciesData = species.speciesData;
				int num2 = num + array2.Length - 1;
				int num3 = 0;
				for (int j = 0; j < array2.Length; j++)
				{
					int num4 = array2[j];
					int num5 = int.MaxValue;
					for (int k = num3; k < array.Length && num5 > Mathf.Abs(num4 - array[k]); k++)
					{
						num5 = Mathf.Abs(num4 - array[k]);
						num3 = k;
					}
					SpeciesInfo speciesInfo = older06a10Datas[item + num3].FirstOrDefault((SpeciesInfo s) => s.species == species.speciesID);
					speciesData.SetPointAtGlobalIndex(num + j, new SpeciesDataPoint
					{
						count = (ushort)speciesInfo.count,
						energy = speciesInfo.energy,
						avgPos = Vector2.zero,
						posCor = 0f,
						posStdDev = Vector2.zero
					});
				}
				configPre06a10.SecondsSinceFirstLog(item + num3, pushCountersNewFormat);
				_ = TimeKeeper.simulatedTime;
				_ = species.timeCreation;
				int num6 = 0;
				bool flag = false;
				for (int num7 = 0; num7 < serialSpeciesConfig.formats.Length; num7++)
				{
					LogLikeFormat logLikeFormat = serialSpeciesConfig.formats[num7];
					int num8 = logLikeFormat.size + logLikeFormat.feedRatio;
					if (!flag && num <= num6 + num8)
					{
						speciesData.indexOfDisappearance = (short)(Mathf.Min(logLikeFormat.size, num - num6) - 1);
						speciesData.scaleOfDisappearance = (byte)num7;
						flag = true;
					}
					if (num2 <= num6 + num8)
					{
						speciesData.indexOfApparition = (short)Mathf.Min(logLikeFormat.size - 1, num2 - num6);
						speciesData.scaleOfApparition = (byte)num7;
						break;
					}
					num6 += num8;
				}
				species.speciesData.RefreshPresentsFromIndices();
			}
		}
	}
}
