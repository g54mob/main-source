using System.Collections.Generic;
using System.Linq;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/clan-list")]
	public class ClanList : MonoBehaviour
	{
		public enum Filter
		{
			Any = 0,
			OfficialGroups = 1,
			PublicGroups = 2,
			NonOfficialGroups = 3,
			PrivateGroups = 4,
			Followed = 5
		}

		[SerializeField]
		private Filter filter;

		[SerializeField]
		private Transform content;

		[SerializeField]
		private GameObject recordTemplate;

		private Dictionary<ClanData, ClanProfile> records = new Dictionary<ClanData, ClanProfile>();

		public Filter ActiveFilter
		{
			get
			{
				return filter;
			}
			set
			{
				filter = value;
				UpdateDisplay();
			}
		}

		private void OnEnable()
		{
			if (App.Initialized)
			{
				UpdateDisplay();
			}
			else
			{
				App.evtSteamInitialized.AddListener(DelayUpdate);
			}
		}

		private void OnDisable()
		{
			Clear();
		}

		private void DelayUpdate()
		{
			UpdateDisplay();
			App.evtSteamInitialized.RemoveListener(DelayUpdate);
		}

		private void Remove(ClanData clan)
		{
			if (records.ContainsKey(clan))
			{
				ClanProfile clanProfile = records[clan];
				records.Remove(clan);
				Object.Destroy(clanProfile.gameObject);
			}
		}

		private void Add(ClanData clan)
		{
			if (!records.ContainsKey(clan))
			{
				AddNewRecord(clan);
				SortRecords();
			}
			else
			{
				records[clan].Clan = clan;
			}
		}

		private void AddNewRecord(ClanData clan)
		{
			ClanProfile component = Object.Instantiate(recordTemplate, content).GetComponent<ClanProfile>();
			component.Clan = clan;
			records.Add(clan, component);
		}

		private void SortRecords()
		{
			List<ClanData> list = records.Keys.ToList();
			list.Sort((ClanData a, ClanData b) => a.Name.CompareTo(b.Name));
			foreach (ClanData item in list)
			{
				records[item].transform.SetAsLastSibling();
			}
		}

		public void Clear()
		{
			if (content.childCount <= 0)
			{
				return;
			}
			try
			{
				foreach (GameObject item in content)
				{
					try
					{
						Object.Destroy(item);
					}
					catch
					{
					}
				}
			}
			catch
			{
			}
		}

		public void UpdateDisplay()
		{
			Clear();
			List<ClanData> filtered = new List<ClanData>();
			List<ClanData> clans = new List<ClanData>(Clans.Client.GetClans());
			List<ClanData> followed = new List<ClanData>();
			Friends.Client.GetFollowed(delegate(CSteamID[] r)
			{
				if (r != null && r.Length != 0)
				{
					IEnumerable<CSteamID> enumerable = r.Where((CSteamID p) => p.GetEAccountType() == EAccountType.k_EAccountTypeClan);
					if (enumerable.Count() > 0)
					{
						foreach (CSteamID item in enumerable)
						{
							clans.Add(item);
							followed.Add(item);
						}
					}
				}
				if (filter == Filter.Followed)
				{
					foreach (ClanData item2 in followed)
					{
						if (!records.ContainsKey(item2))
						{
							AddNewRecord(item2);
						}
					}
				}
				else
				{
					foreach (ClanData item3 in clans)
					{
						if (MatchFilter(item3))
						{
							filtered.Add(item3);
						}
					}
					foreach (ClanData item4 in filtered)
					{
						if (!records.ContainsKey(item4))
						{
							AddNewRecord(item4);
						}
					}
				}
				SortRecords();
			});
		}

		public bool MatchFilter(ClanData clan)
		{
			switch (filter)
			{
			case Filter.Any:
				return true;
			case Filter.NonOfficialGroups:
				return !clan.IsOfficialGameGroup;
			case Filter.OfficialGroups:
				return clan.IsOfficialGameGroup;
			case Filter.PrivateGroups:
				if (!clan.IsPublic)
				{
					return !clan.IsOfficialGameGroup;
				}
				return false;
			case Filter.PublicGroups:
				return clan.IsPublic;
			default:
				return false;
			}
		}
	}
}
