using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class SelectedObject : ScriptableObject
	{
		public ERModularRoad roadScr;

		public ERCrossingPrefabs prefabScr;

		public List<int> markers;

		public void Init(ERModularRoad rScr, ERCrossingPrefabs pScr, int marker)
		{
			if (rScr != null)
			{
				roadScr = rScr;
				markers = new List<int>();
				markers.Add(marker);
				prefabScr = pScr;
			}
			else
			{
				prefabScr = pScr;
				roadScr = rScr;
				markers = null;
			}
		}

		public static SelectedObject CreateInstance(ERModularRoad rScr, ERCrossingPrefabs pScr, int marker)
		{
			SelectedObject selectedObject = ScriptableObject.CreateInstance<SelectedObject>();
			selectedObject.Init(rScr, pScr, marker);
			return selectedObject;
		}
	}
}
