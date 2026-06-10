using System.Collections.Generic;
using System.Linq;
using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Stockpiles
{
	public class ResourceGroupsRepository : DynamicJsonRepository<ResourceGroupsRepository, ResourceGroupsModel>
	{
		private Dictionary<string, HashSet<string>> subGroupsByParent;

		protected override string JsonFile()
		{
			return "Stockpile/ResourceGroups.json";
		}

		private void TryInit()
		{
			if (subGroupsByParent != null)
			{
				return;
			}
			subGroupsByParent = new Dictionary<string, HashSet<string>>();
			List<ResourceGroups> allResourceGroups = Repository<ResourceGroupsRepository, ResourceGroupsModel>.Instance.GetByID("all_resource_groups").ResourceGroups;
			int level = 0;
			while (true)
			{
				IEnumerable<ResourceGroups> enumerable = allResourceGroups.Where((ResourceGroups rg) => rg.Depth == level);
				foreach (ResourceGroups item in enumerable)
				{
					FillGroupConnections(item.GetID(), item.GetID(), ref allResourceGroups);
				}
				if (enumerable.Any())
				{
					level++;
					continue;
				}
				break;
			}
		}

		private void FillGroupConnections(string currentGroupName, string mainGroupName, ref List<ResourceGroups> allResourceGroups)
		{
			ResourceGroups resourceGroups = allResourceGroups.FirstOrDefault((ResourceGroups rg) => currentGroupName.Equals(rg.GetID()));
			if (!subGroupsByParent.ContainsKey(mainGroupName))
			{
				subGroupsByParent.Add(mainGroupName, new HashSet<string>());
			}
			if (!subGroupsByParent[mainGroupName].Contains(resourceGroups.GetID()))
			{
				subGroupsByParent[mainGroupName].Add(resourceGroups.GetID());
			}
			foreach (string subGroupID in resourceGroups.SubGroupIDs)
			{
				FillGroupConnections(subGroupID, mainGroupName, ref allResourceGroups);
			}
		}

		public bool CheckGroup(string subGroupName, string mainGroupName)
		{
			TryInit();
			if (!subGroupsByParent.TryGetValue(mainGroupName, out var value))
			{
				return false;
			}
			return value.Contains(subGroupName);
		}
	}
}
