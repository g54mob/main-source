using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Absorption Input")]
	public sealed class AbsorptionLodInput : LodInput
	{
		internal override LodInputMode DefaultMode => LodInputMode.Renderer;

		private protected override bool FollowHorizontalMotion => true;

		internal override Color GizmoColor => AbsorptionLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => AbsorptionLod.s_Inputs;

		internal override void InferBlend()
		{
			base.InferBlend();
			_Blend = LodInputBlend.Alpha;
		}
	}
}
