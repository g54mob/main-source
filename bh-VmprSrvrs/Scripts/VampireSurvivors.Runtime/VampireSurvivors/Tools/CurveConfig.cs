using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

namespace VampireSurvivors.Tools
{
	public class CurveConfig : MonoBehaviour
	{
		private SplineComputer _spline;

		[SerializeField]
		private float Scale;

		[SerializeField]
		private bool InvertPositiveNegative;

		[SerializeField]
		private bool Mirror;

		[SerializeField]
		private List<CurvePoint> Points;

		public void Generate()
		{
		}

		public void Clear()
		{
		}
	}
}
