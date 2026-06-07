using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI.Stats
{
	public class BarChart : SerializedMonoBehaviour
	{
		public UIGrid Grid;

		public BarItem Prefab;

		public void Init(List<BarData> data)
		{
			(from Transform child in Grid.transform
				select child.gameObject).ToList().ForEach(Object.DestroyImmediate);
			if (data != null)
			{
				foreach (BarData datum in data)
				{
					BarItem barItem = Object.Instantiate(Prefab);
					barItem.transform.position = Grid.transform.position;
					barItem.transform.parent = Grid.transform;
					barItem.transform.localScale = Prefab.transform.localScale;
					barItem.Init(datum);
				}
			}
			Grid.repositionNow = true;
		}
	}
}
