using System.Collections.Generic;

namespace AwesomeTechnologies.BillboardSystem
{
	public class VegetationPackageBillboardInstances
	{
		public List<BillboardInstance> BillboardInstanceList = new List<BillboardInstance>();

		public VegetationPackageBillboardInstances(int vegetationItemCount)
		{
			for (int i = 0; i <= vegetationItemCount - 1; i++)
			{
				BillboardInstance item = new BillboardInstance();
				BillboardInstanceList.Add(item);
			}
		}

		public void ClearCache()
		{
			for (int i = 0; i <= BillboardInstanceList.Count - 1; i++)
			{
				BillboardInstanceList[i].ClearCache();
			}
		}

		public void Dispose()
		{
			for (int i = 0; i <= BillboardInstanceList.Count - 1; i++)
			{
				BillboardInstanceList[i].Dispose();
			}
			BillboardInstanceList.Clear();
		}
	}
}
