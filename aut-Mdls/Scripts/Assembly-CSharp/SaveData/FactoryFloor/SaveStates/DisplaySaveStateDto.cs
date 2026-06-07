using System;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class DisplaySaveStateDto : BehaviourSaveStateDto
	{
		[JsonProperty("id")]
		public int StoredResourceID;

		[JsonProperty("r")]
		public bool HasResource;

		[JsonProperty("c")]
		public Color Color;

		[JsonProperty("h")]
		public string Hash;
	}
}
