using System;
using UnityEngine;

namespace Coherence
{
	[Serializable]
	public sealed class SchemaAsset : ScriptableObject, IComparable<SchemaAsset>
	{
		public string raw;

		public string identifier;

		public SchemaDefinition SchemaDefinition;

		public int CompareTo(SchemaAsset other)
		{
			return 0;
		}
	}
}
