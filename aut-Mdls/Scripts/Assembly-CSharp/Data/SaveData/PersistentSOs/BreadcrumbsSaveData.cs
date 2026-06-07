using System;
using System.Collections.Generic;
using Data.Breadcrumbs;
using Newtonsoft.Json;

namespace Data.SaveData.PersistentSOs
{
	[Serializable]
	public class BreadcrumbsSaveData : AbstractSaveData
	{
		public struct BreadcrumbSaveData
		{
			[JsonProperty("s")]
			public List<int> StateIndexes;

			[JsonProperty("t")]
			public List<string> Tags;

			[JsonProperty("i")]
			public string Id;
		}

		public const int CurrentVersion = 0;

		public List<BreadcrumbSaveData> Breadcrumbs = new List<BreadcrumbSaveData>();

		public BreadcrumbsSaveData()
			: base(0)
		{
		}

		public BreadcrumbsSaveData(IEnumerable<Breadcrumb> breadcrumbs, BreadcrumbStateSO[] persistentBreadcrumbStates)
			: base(0)
		{
			foreach (Breadcrumb breadcrumb in breadcrumbs)
			{
				BreadcrumbSaveData item = new BreadcrumbSaveData
				{
					Id = breadcrumb.Id,
					Tags = new List<string>(breadcrumb.Tags)
				};
				for (int i = 0; i < persistentBreadcrumbStates.Length; i++)
				{
					if (breadcrumb.GetState(persistentBreadcrumbStates[i]))
					{
						if (item.StateIndexes == null)
						{
							item.StateIndexes = new List<int> { i };
						}
						else
						{
							item.StateIndexes.Add(i);
						}
					}
				}
				Breadcrumbs.Add(item);
			}
		}
	}
}
