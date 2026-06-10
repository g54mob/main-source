using System;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.GameEventSystem
{
	[Serializable]
	public class DaysFromStartMultipliers : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private LocKeys[] locKeys;

		[FormerlySerializedAs("wealthMultiplierList")]
		[SerializeField]
		private InterpolatedValueList raidStrengthMultiplierList;

		public InterpolatedValueList List => raidStrengthMultiplierList;

		public LocKeys[] LocKeys => locKeys;

		public override string GetID()
		{
			return id;
		}
	}
}
