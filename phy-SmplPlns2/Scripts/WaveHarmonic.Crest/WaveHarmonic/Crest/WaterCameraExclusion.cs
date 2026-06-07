using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	[Flags]
	public enum WaterCameraExclusion
	{
		[Tooltip("No exclusion rules applied.")]
		Nothing = 0,
		[Tooltip("Exclude hidden cameras.\n\nDoes not affect reflection cameras, as they are typically always hidden. Use the Reflection flag for them.")]
		Hidden = 2,
		[Tooltip("Exclude reflection cameras.")]
		Reflection = 4,
		[Tooltip("Exclude cameras not tagged as MainCamera.")]
		NonMainCamera = 8,
		[Tooltip("Apply all exclusion rules.")]
		Everything = -1
	}
}
