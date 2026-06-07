using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Dynamic Waves Input")]
	public sealed class DynamicWavesLodInput : LodInput
	{
		internal override LodInputMode DefaultMode => LodInputMode.Renderer;

		internal override Color GizmoColor => DynamicWavesLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => DynamicWavesLod.s_Inputs;
	}
}
