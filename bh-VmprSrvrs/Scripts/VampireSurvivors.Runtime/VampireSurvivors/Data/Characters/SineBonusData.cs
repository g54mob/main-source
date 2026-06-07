using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Characters
{
	[Serializable]
	public class SineBonusData
	{
		[Title("Min")]
		public float min { get; set; }

		[Title("Max")]
		public float max { get; set; }

		[Title("Duration")]
		public float duration { get; set; }
	}
}
