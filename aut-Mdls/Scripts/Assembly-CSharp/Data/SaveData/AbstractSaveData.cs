using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Data.SaveData
{
	[Serializable]
	public abstract class AbstractSaveData : ISaveVersion
	{
		public const string VerionPropertyName = "v";

		[JsonProperty("v")]
		[HideInInspector]
		public int Version;

		protected AbstractSaveData(int currentVersion)
		{
			Version = currentVersion;
		}
	}
}
