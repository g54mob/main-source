using System;
using NSMedieval.Types;
using UnityEngine;

namespace NSMedieval.EnvironmentEffects
{
	[Serializable]
	public struct FootprintType
	{
		[SerializeField]
		private SoundWalkableMaterialCategory category;

		[SerializeField]
		private string left;

		[SerializeField]
		private string right;

		[SerializeField]
		private string trailDust;

		[SerializeField]
		private string wet;

		public SoundWalkableMaterialCategory Category => category;

		public string Left => left;

		public string Right => right;

		public string TrailDust => trailDust;

		public string Wet => wet;
	}
}
