using System;
using UnityEngine;

namespace BrainFailProductions.PolyFew
{
	[Serializable]
	public class ToleranceSphere : ScriptableObject
	{
		public Vector3 worldPosition;

		public float diameter;

		public Color color;

		public float preservationStrength;

		public bool isHidden;

		public ToleranceSphere(Vector3 worldPosition, float diameter, Color color, float preservationStrength, bool isHidden = false)
		{
		}

		public void SetProperties(ToleranceSphereJson tSphereJson)
		{
		}

		public void SetProperties(Vector3 worldPosition, float diameter, Color color, float preservationStrength, bool isHidden = false)
		{
		}
	}
}
