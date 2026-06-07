using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Albedo Input")]
	public sealed class AlbedoLodInput : LodInput
	{
		internal override LodInputMode DefaultMode => LodInputMode.Renderer;

		internal override Color GizmoColor => AlbedoLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => AlbedoLod.s_Inputs;
	}
}
