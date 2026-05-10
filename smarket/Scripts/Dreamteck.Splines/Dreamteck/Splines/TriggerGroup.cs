using System;
using System.Collections.Generic;
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

		public List<SplineTrigger> GetTriggers(double from, double to)
		{
			return null;
		}

		public SplineTrigger AddTrigger(double position, SplineTrigger.Type type)
		{
			return null;
		}

		public SplineTrigger AddTrigger(double position, SplineTrigger.Type type, string name, Color color)
		{
			return null;
		}

		public void RemoveTrigger(int index)
		{
		}
	}
}
