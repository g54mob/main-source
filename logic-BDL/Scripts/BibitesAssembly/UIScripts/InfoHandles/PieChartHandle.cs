using System.Collections.Generic;
using UnityEngine;

namespace UIScripts.InfoHandles
{
	public class PieChartHandle : MonoBehaviour
	{
		public GameObject WedgePrefab;

		private List<WedgeHandle> wedges = new List<WedgeHandle>();

		public void InitChart(WedgeInfo[] wedgeInfos)
		{
			_ = wedgeInfos.Length;
			foreach (WedgeInfo info in wedgeInfos)
			{
				WedgeHandle component = Object.Instantiate(WedgePrefab, base.transform).GetComponent<WedgeHandle>();
				component.InitWedge(info);
				wedges.Add(component);
			}
		}

		public void UpdateValues(float[] values)
		{
			int num = values.Length;
			if (num == wedges.Count)
			{
				float num2 = 0f;
				for (int i = 0; i < num; i++)
				{
					num2 += values[i];
				}
				float num3 = 1f;
				for (int j = 0; j < num; j++)
				{
					wedges[j].UpdateValue(num3);
					num3 -= values[j] / num2;
				}
			}
		}
	}
}
