using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Flow Input")]
	public sealed class FlowLodInput : LodInput
	{
		private protected override bool FollowHorizontalMotion => true;

		internal override LodInputMode DefaultMode => LodInputMode.Renderer;

		internal override Color GizmoColor => FlowLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => FlowLod.s_Inputs;
	}
}
