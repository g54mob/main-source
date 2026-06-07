using System;
using UnityEngine;

namespace HeathenEngineering.SteamworksIntegration
{
	[Serializable]
	public struct MetadataTempalate
	{
		[Tooltip("The key or field name to be used. names will not be duplicated, if you add another field of the same name it will overwrite, not duplicate")]
		public string key;

		[Tooltip("The value of the field to be applied, empty values are ignored")]
		public string value;
	}
}
