using System;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERTerrainData
	{
		public int terrainWidth;

		public int terrainHeight;

		public float originalHeight;

		public float flattenedHeight;

		public float outerHeightDifference = 0f;

		public bool critical = false;

		public float perc = 0f;

		public Vector3 hitpos;

		public Vector3 outerPos;

		public bool ignorePreserveHeights = false;

		public ERTerrainData(int m_terrainWidth, int m_terrainHeight, float m_originalHeight, float m_flattenedHeight, bool m_critical, float m_perc, float m_outerHeight, Vector3 m_hitPoint, Vector3 m_outerPoint)
		{
			terrainWidth = m_terrainWidth;
			terrainHeight = m_terrainHeight;
			originalHeight = m_originalHeight;
			outerHeightDifference = m_outerHeight;
			flattenedHeight = m_flattenedHeight;
			critical = m_critical;
			perc = m_perc;
			hitpos = m_hitPoint;
			outerPos = m_outerPoint;
		}
	}
}
