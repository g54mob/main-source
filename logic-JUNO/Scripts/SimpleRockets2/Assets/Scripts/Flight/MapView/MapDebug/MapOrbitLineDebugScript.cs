using System;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.MapDebug
{
	public class MapOrbitLineDebugScript : MonoBehaviour
	{
		private MapOrbitLine _mapOrbitLine;

		public static void RunStaticTests(IOrbitNode orbitNode)
		{
			for (double num = Math.PI * -2.0; num <= Math.PI * 2.0; num += Math.PI / 200.0)
			{
				DebugGraph.Log("ma_from_nu", OrbitMath.GetMeanAnomalyFromTrueAnomaly(0.7, num));
				DebugGraph.Log("nu_from_ma", OrbitMath.GetTrueAnomalyFromMeanAnomaly(0.7, num));
				DebugGraph.Log("nu_from_ea", OrbitMath.GetTrueAnomalyFromEccentricAnomaly(0.7, num));
				DebugGraph.Log("ea_from_nu", OrbitMath.GetEccentricAnomalyFromTrueAnomaly(0.7, num));
			}
		}

		public void Awake()
		{
			_mapOrbitLine = GetComponent<MapOrbitLine>();
			if (_mapOrbitLine == null)
			{
				Debug.LogError("MapOrbitLineDebugScript must be attached to a GameObject with a MapOrbitLine");
			}
		}
	}
}
