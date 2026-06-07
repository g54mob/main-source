using System;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class TriggerGroup
	{
		public bool enabled;

		public string name;

		public Color color;

		public SplineTrigger[] triggers;

		public void Check(double start, double end, SplineUser user = null)
		{
		}

		public void Reset()
		{
		}
	}
}
