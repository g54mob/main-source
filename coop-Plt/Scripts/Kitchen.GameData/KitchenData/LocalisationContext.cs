using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	public class LocalisationContext
	{
		public int CurrentSourceID;

		public string CurrentSourceName;

		public Locale CurrentLocale;

		public List<Locale> Locales;

		public List<LocalisationRow> Rows;

		public GameDataConstructor Constructor;

		public HashSet<LocalisationRow> ImportedRows = new HashSet<LocalisationRow>();

		public void BeginTrackingScope()
		{
			ImportedRows.Clear();
		}

		public void EndTrackingScope()
		{
			List<LocalisationRow> list = new List<LocalisationRow>(Rows);
			list.RemoveAll((LocalisationRow e) => ImportedRows.Contains(e));
			if (list.Count > 0)
			{
				Debug.LogError($"Localisation import had {list.Count} missing key(s)");
				for (int num = 0; num < list.Count; num++)
				{
					LocalisationRow localisationRow = list[num];
					Debug.LogError($" -> [{num}/{list.Count}] {localisationRow.SourceID}/{localisationRow.Key}: {localisationRow.English}");
				}
			}
			else
			{
				Debug.LogWarning("All keys imported");
			}
		}

		public LocalisationContext(List<LocalisationRow> rows, GameDataConstructor constructor, List<Locale> locales)
		{
			Rows = rows;
			Constructor = constructor;
			Locales = locales;
		}

		public void Add(string key, string value)
		{
			foreach (LocalisationRow row in Rows)
			{
				if (row.SourceID == CurrentSourceID && !(key != row.Key))
				{
					row.Set(CurrentLocale, value);
					return;
				}
			}
			LocalisationRow localisationRow = LocalisationRow.CreateEmpty(CurrentSourceID, CurrentSourceName, key);
			localisationRow.Set(CurrentLocale, value);
			Rows.Add(localisationRow);
		}

		public string Get(string key)
		{
			foreach (LocalisationRow row in Rows)
			{
				if (row.SourceID == CurrentSourceID && !(key != row.Key))
				{
					ImportedRows.Add(row);
					return row.Get(CurrentLocale);
				}
			}
			return "";
		}

		public void GetAll(Dictionary<string, string> result)
		{
			foreach (LocalisationRow row in Rows)
			{
				if (row.SourceID == CurrentSourceID)
				{
					if (result.ContainsKey(row.Key))
					{
						Debug.LogWarning($"Found duplicate key for {row.Key} ({CurrentSourceName} - {CurrentSourceID})");
						continue;
					}
					ImportedRows.Add(row);
					result.Add(row.Key, row.Get(CurrentLocale));
				}
			}
		}

		public int GetMaxSubKeys(string key_start)
		{
			int num = -1;
			foreach (LocalisationRow row in Rows)
			{
				if (row.SourceID == CurrentSourceID && row.Key.StartsWith(key_start))
				{
					num = Mathf.Max(int.Parse(row.Key.Split('/')[1]), num);
				}
			}
			return num + 1;
		}
	}
}
