using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class SpeciesGeneticDesc : BaseGeneticDesc
	{
		[NonSerialized]
		public Dictionary<long, Vector2> nodeAnchors = new Dictionary<long, Vector2>();

		public SpeciesGeneticDesc(BibiteBody bibite)
		{
		}

		public override JObject SaveState()
		{
			JObject jObject = base.SaveState();
			if (nodeAnchors.Count > 0)
			{
				jObject["nodeAnchors"] = JToken.FromObject(nodeAnchors);
			}
			return jObject;
		}

		public override void LoadState(JObject state)
		{
			base.LoadState(state);
			if (state["nodeAnchors"] != null)
			{
				nodeAnchors = state["nodeAnchors"].ToObject<Dictionary<long, Vector2>>();
			}
		}
	}
}
