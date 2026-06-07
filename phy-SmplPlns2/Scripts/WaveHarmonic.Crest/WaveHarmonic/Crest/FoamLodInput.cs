using UnityEngine;
using WaveHarmonic.Crest.Utility;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Inputs/Crest Foam Input")]
	public sealed class FoamLodInput : LodInput
	{
		internal override LodInputMode DefaultMode => LodInputMode.Renderer;

		internal override Color GizmoColor => FoamLod.s_GizmoColor;

		private protected override SortedList<int, ILodInput> Inputs => FoamLod.s_Inputs;

		internal override void InferBlend()
		{
			base.InferBlend();
			if (_Mode == LodInputMode.Paint)
			{
				_Blend = LodInputBlend.Maximum;
			}
		}
	}
}
