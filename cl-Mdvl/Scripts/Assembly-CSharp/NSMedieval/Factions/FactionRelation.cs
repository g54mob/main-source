using System;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.Factions
{
	[Serializable]
	public struct FactionRelation
	{
		[SerializeField]
		private string factionA;

		[SerializeField]
		private string factionB;

		[SerializeField]
		private FloatRange friendlinessRange;

		public FactionRelationInstance CreateFactionInstance()
		{
			return new FactionRelationInstance(factionA, factionB, friendlinessRange.Random());
		}
	}
}
