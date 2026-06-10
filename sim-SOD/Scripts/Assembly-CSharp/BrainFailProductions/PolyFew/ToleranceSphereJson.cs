using System;
using UnityEngine;

namespace BrainFailProductions.PolyFew
{
	[Serializable]
	public class ToleranceSphereJson
	{
		public Vector3 worldPosition;

		public float diameter;

		public Color color;

		public float preservationStrength;

		public bool isHidden;

		public ToleranceSphereJson(Vector3 worldPosition, float diameter, Color color, float preservationStrength, bool isHidden = false)
		{
		}

		public ToleranceSphereJson(ToleranceSphere toleranceSphere)
		{
		}

		public void SetProperties(Vector3 worldPosition, float diameter, Color color, float preservationStrength, bool isHidden = false)
		{
		}

		public void DumpFromToleranceSphere(ToleranceSphere toleranceSphere)
		{
		}

		public void DumpToToleranceSphere(ref ToleranceSphere toleranceSphere)
		{
		}
	}
}
