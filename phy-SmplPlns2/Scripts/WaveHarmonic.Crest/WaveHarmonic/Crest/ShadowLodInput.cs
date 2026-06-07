using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Shadow Input")]
	public sealed class ShadowLodInput : LodInput
	{
		internal override Color GizmoColor => ShadowLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => ShadowLod.s_Inputs;

		internal override LodInputMode DefaultMode => LodInputMode.Renderer;
	}
}
