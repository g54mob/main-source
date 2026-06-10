using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Factions
{
	[Serializable]
	public class FactionRelations : NSEipix.Base.Model
	{
		[SerializeField]
		private List<FactionRelation> factionRelations;

		public List<FactionRelation> Relations => factionRelations;

		public override string GetID()
		{
			return "FactionRelations";
		}
	}
}
