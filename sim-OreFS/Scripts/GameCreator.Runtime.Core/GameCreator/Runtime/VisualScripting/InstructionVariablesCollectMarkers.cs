using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Collect Markers")]
	[Description("Collects all Markers that within a certain radius of a position")]
	[Image(typeof(IconMarker), ColorTheme.Type.Teal, typeof(OverlayListVariable))]
	[Category("Variables/Collect Markers")]
	public class InstructionVariablesCollectMarkers : TInstructionVariablesCollect
	{
		[NonSerialized]
		private List<ISpatialHash> m_Results = new List<ISpatialHash>();

		protected override string TitleTarget => "Markers";

		protected override List<GameObject> Collect(Vector3 origin, float maxRadius, float minDistance)
		{
			List<GameObject> list = new List<GameObject>();
			SpatialHashMarkers.Find(origin, maxRadius, m_Results);
			foreach (ISpatialHash result in m_Results)
			{
				if (!(Vector3.Distance(result.Position, origin) <= minDistance))
				{
					Marker marker = result as Marker;
					if (!(marker == null))
					{
						list.Add(marker.gameObject);
					}
				}
			}
			return list;
		}
	}
}
