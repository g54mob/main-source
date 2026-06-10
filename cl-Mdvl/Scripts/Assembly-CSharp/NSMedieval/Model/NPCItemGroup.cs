using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class NPCItemGroup
	{
		[SerializeField]
		private string groupName;

		[SerializeField]
		private List<string> equipment;

		[SerializeField]
		private float isNoneChance = 0.25f;

		[SerializeField]
		private FloatRange hitPointsRange = new FloatRange(0.3f, 1f);

		public string GroupName => groupName;

		public FloatRange HitPointsRange => hitPointsRange;

		public List<string> Equipment => equipment;

		public bool IsNoneRandom(System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			if (isNoneChance <= 0f)
			{
				return false;
			}
			if (isNoneChance >= 1f)
			{
				return true;
			}
			return rnd.Range(0f, 1f) <= isNoneChance;
		}
	}
}
