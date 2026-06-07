using System;
using System.Collections.Generic;
using System.Linq;
using DV.JObjectExtstensions;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Integration;
using DV.UserManagement.Storage;
using Newtonsoft.Json.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Data upgrade/LicensesUpgrade (v5 -> v6)")]
public class Upgrade_V5_to_V6_Licenses : ASaveSnapshotUpgrader
{
	[Flags]
	private enum JobLicenses
	{
		Basic = 0,
		Hazmat1 = 1,
		Hazmat2 = 2,
		Hazmat3 = 4,
		Military1 = 8,
		Military2 = 0x10,
		Military3 = 0x20,
		FreightHaul = 0x200,
		Shunting = 0x400,
		LogisticalHaul = 0x800,
		TrainLength1 = 0x4000,
		TrainLength2 = 0x8000
	}

	private static readonly JobLicenses[] JobValues = (JobLicenses[])Enum.GetValues(typeof(JobLicenses));

	public override int InputVersion => 5;

	private static HashSet<string> ImportFromArray(JObject source, string prefix, IEnumerable<string> keys)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string key in keys)
		{
			bool? flag = source.GetBool(prefix + key);
			if (flag.HasValue && flag.Value)
			{
				hashSet.Add(key);
				source.Remove(prefix + key);
			}
		}
		return hashSet;
	}

	private static HashSet<string> ExtractItemsFromStorages(JObject data, params string[] storageNames)
	{
		HashSet<string> hashSet = new HashSet<string>();
		foreach (string propertyName in storageNames)
		{
			if (data.ContainsKey(propertyName))
			{
				hashSet.UnionWith(from item in JArray.Parse(data[propertyName].Value<string>()).ToList()
					where item.Type == JTokenType.Object
					select item["itemPrefabName"].Value<string>());
			}
		}
		return hashSet;
	}

	public override JObject Upgrade(UserManager manager, string path, List<(int, byte[])> customChunks, IStorageProvider storage, GameSession session, JObject data)
	{
		HashSet<string> hashSet = ImportFromArray(data, "License_", new string[8] { "TrainDriver", "DE2", "DE6", "SH282", "ManualService", "ConcurrentJobs1", "ConcurrentJobs2", "MultipleUnit" });
		data["Licenses_General"] = JArray.FromObject(hashSet);
		HashSet<string> hashSet2 = ImportFromArray(data, "Garage_", new string[2] { "Bob", "Caboose" });
		data["Garages"] = JArray.FromObject(hashSet2);
		int? num = data.GetInt("Job_Licenses");
		int num2 = (num.HasValue ? num.Value : 0);
		HashSet<string> hashSet3 = new HashSet<string>();
		JobLicenses[] jobValues = JobValues;
		for (int i = 0; i < jobValues.Length; i++)
		{
			JobLicenses jobLicenses = jobValues[i];
			if (jobLicenses != JobLicenses.Basic && ((uint)num2 & (uint)jobLicenses) == (uint)jobLicenses)
			{
				hashSet3.Add(jobLicenses.ToString());
			}
		}
		data["Licenses_Jobs"] = JArray.FromObject(hashSet3);
		if (num.HasValue)
		{
			data.Remove("Job_Licenses");
		}
		HashSet<string> hashSet4 = ExtractItemsFromStorages(data, "Storage_Inventory", "Storage_LostAndFound", "Storage_World", "Storage_Belt");
		data["Unlocked_items"] = JArray.FromObject(hashSet4);
		if (session.GameMode == "Career" && data["Game_mode"].Value<string>() == "Career")
		{
			JObject jObject = session.Owner.ReadProgressionState();
			if (jObject["Unlocked_general_licenses"] != null)
			{
				hashSet.UnionWith(jObject["Unlocked_general_licenses"].ToObject<string[]>());
			}
			if (jObject["Unlocked_job_licenses"] != null)
			{
				hashSet3.UnionWith(jObject["Unlocked_job_licenses"].ToObject<string[]>());
			}
			if (jObject["Unlocked_garages"] != null)
			{
				hashSet2.UnionWith(jObject["Unlocked_garages"].ToObject<string[]>());
			}
			if (jObject["Unlocked_items"] != null)
			{
				hashSet4.UnionWith(jObject["Unlocked_items"].ToObject<string[]>());
			}
			jObject["Unlocked_general_licenses"] = new JArray(hashSet);
			jObject["Unlocked_job_licenses"] = new JArray(hashSet3);
			jObject["Unlocked_garages"] = new JArray(hashSet2);
			jObject["Unlocked_items"] = new JArray(hashSet4);
			session.Owner.SaveProgressionState(jObject);
		}
		return data;
	}
}
