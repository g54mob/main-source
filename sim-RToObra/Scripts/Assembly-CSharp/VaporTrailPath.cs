using System;
using System.Collections.Generic;
using UnityEngine;

public class VaporTrailPath : MonoBehaviour
{
	[Serializable]
	public class Stop
	{
		public string crewId;

		public int pointIndex;

		public int originalPointIndex;

		public bool inceptiveHost;

		public Stop()
		{
		}

		public Stop(string crewId_, int pointIndex_)
		{
			if (crewId_.StartsWith("*"))
			{
				inceptiveHost = true;
				crewId = crewId_.Substring(1);
			}
			else
			{
				crewId = crewId_;
			}
			pointIndex = pointIndex_;
			originalPointIndex = pointIndex_;
		}
	}

	public List<Vector3> points = new List<Vector3>();

	public List<Stop> stops = new List<Stop>();
}
