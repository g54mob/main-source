using System;
using UnityEngine;

namespace JSAM
{
	[Serializable]
	public class SpatialSoundSettings
	{
		public float DopplerLevel;

		public AnimationCurve Spread;

		public AudioRolloffMode VolumeRolloff;

		public float MinDistance;

		public float MaxDistance;
	}
}
