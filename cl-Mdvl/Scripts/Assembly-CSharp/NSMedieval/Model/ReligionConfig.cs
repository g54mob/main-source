using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.RoomDetection;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class ReligionConfig : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private float from;

		[SerializeField]
		private float to;

		[SerializeField]
		private string[] shrines;

		[SerializeField]
		private string[] roomTypes;

		[SerializeField]
		private RoomEffectors[] believerEffectors;

		[SerializeField]
		private RoomEffectors[] nonBelieverEffectors;

		[NonSerialized]
		private Dictionary<string, RoomEffectors> believerEffectorsCache;

		[NonSerialized]
		private Dictionary<string, RoomEffectors> nonBelieverEffectorsCache;

		public float From => from;

		public float To => to;

		public string[] Shrines => shrines;

		public string[] RoomTypes => roomTypes;

		public override string GetID()
		{
			return id;
		}

		public List<string> GetBelieverEffectors(RoomImpressivenessSettings.Setting impressiveness)
		{
			if (believerEffectors == null || impressiveness == null)
			{
				return null;
			}
			RoomEffectors.CheckCreateCache(ref believerEffectors, ref believerEffectorsCache);
			if (!believerEffectorsCache.ContainsKey(impressiveness.Name))
			{
				return null;
			}
			return believerEffectorsCache[impressiveness.Name].Effectors;
		}

		public List<string> GetNonBelieverEffectors(RoomImpressivenessSettings.Setting impressiveness)
		{
			if (nonBelieverEffectors == null || impressiveness == null)
			{
				return null;
			}
			RoomEffectors.CheckCreateCache(ref nonBelieverEffectors, ref nonBelieverEffectorsCache);
			if (!nonBelieverEffectorsCache.ContainsKey(impressiveness.Name))
			{
				return null;
			}
			return nonBelieverEffectorsCache[impressiveness.Name].Effectors;
		}
	}
}
