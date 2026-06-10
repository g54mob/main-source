using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.StatsSystem
{
	[Serializable]
	public class StatsModel : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private List<Stat> stats;

		public List<Stat> Stats => stats;

		public override string GetID()
		{
			return id;
		}

		public Stat GetByType(StatType type)
		{
			foreach (Stat stat in stats)
			{
				if (stat.Type == type)
				{
					return stat;
				}
			}
			return null;
		}
	}
}
