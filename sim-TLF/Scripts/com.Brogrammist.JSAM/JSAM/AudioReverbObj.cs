using System;
using UnityEngine;

namespace JSAM
{
	[Serializable]
	public struct AudioReverbObj
	{
		public bool enabled;

		public AudioReverbPreset reverbPreset;

		public float dryLevel;

		public float room;

		public float roomHF;

		public float roomLF;

		public float decayTime;

		public float decayHFRatio;

		public float reflectionsLevel;

		public float reflectionsDelay;

		public float reverbLevel;

		public float reverbDelay;

		public float hFReference;

		public float lFReference;

		public float diffusion;

		public float density;
	}
}
