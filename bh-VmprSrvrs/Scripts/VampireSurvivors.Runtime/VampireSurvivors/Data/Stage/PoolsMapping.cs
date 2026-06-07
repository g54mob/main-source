using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	[Title("Pools Mapping")]
	public class PoolsMapping
	{
		[Title("Key")]
		public int key { get; set; }

		[Title("Enemy Type")]
		public EnemyType type { get; set; }
	}
}
