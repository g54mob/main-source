using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Scattering Input")]
	public sealed class ScatteringLodInput : LodInput
	{
		internal override Color GizmoColor => ScatteringLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => ScatteringLod.s_Inputs;

		internal override LodInputMode DefaultMode => LodInputMode.Renderer;

		private protected override bool FollowHorizontalMotion => true;

		internal override void InferBlend()
		{
			base.InferBlend();
			_Blend = LodInputBlend.Alpha;
		}
	}
}
