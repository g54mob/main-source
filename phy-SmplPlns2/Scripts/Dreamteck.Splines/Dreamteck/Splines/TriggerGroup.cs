using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines
{
	[Serializable]
	public class TriggerGroup
	{
		public bool enabled = true;

		public string name = "";

		public Color color = Color.white;

		public SplineTrigger[] triggers = new SplineTrigger[0];

		public void Check(double start, double end, SplineUser user = null)
		{
			for (int i = 0; i < triggers.Length; i++)
			{
				if (triggers[i] != null && triggers[i].Check(start, end))
				{
					triggers[i].Invoke(user);
				}
			}
		}

		public void Reset()
		{
			for (int i = 0; i < triggers.Length; i++)
			{
				triggers[i].Reset();
			}
		}

		public List<SplineTrigger> GetTriggers(double from, double to)
		{
			List<SplineTrigger> list = new List<SplineTrigger>();
			for (int i = 0; i < triggers.Length; i++)
			{
				if (triggers[i] != null && triggers[i].position >= from && triggers[i].position <= to)
				{
					list.Add(triggers[i]);
				}
			}
			return list;
		}

		public SplineTrigger AddTrigger(double position, SplineTrigger.Type type)
		{
			return AddTrigger(position, type, "Trigger " + (triggers.Length + 1), Color.white);
		}

		public SplineTrigger AddTrigger(double position, SplineTrigger.Type type, string name, Color color)
		{
			SplineTrigger splineTrigger = new SplineTrigger(type);
			splineTrigger.position = position;
			splineTrigger.color = color;
			splineTrigger.name = name;
			ArrayUtility.Add(ref triggers, splineTrigger);
			return splineTrigger;
		}

		public void RemoveTrigger(int index)
		{
			ArrayUtility.RemoveAt(ref triggers, index);
		}
	}
}
