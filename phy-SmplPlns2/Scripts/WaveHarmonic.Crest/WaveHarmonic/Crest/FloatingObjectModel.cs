using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum FloatingObjectModel
	{
		[Tooltip("A simple model which aligns the object with the wave normal.")]
		AlignNormal = 0,
		[Tooltip("A more advanced model which samples water at the probes positions.")]
		Probes = 1
	}
}
