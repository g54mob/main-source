using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class TMPAdjustTimeOfDay : MonoBehaviour
	{
		public List<Material> defaultMaterials;

		public AnimationCurve dayTimeCurve;

		public static List<Material> AdjustingMaterials { get; private set; }

		public void Start()
		{
		}

		private void Update()
		{
		}

		public void UpdateColour()
		{
		}
	}
}
