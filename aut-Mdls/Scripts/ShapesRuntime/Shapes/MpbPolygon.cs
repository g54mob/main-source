using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbPolygon : MetaMpb, IFillableMpb
	{
		List<Vector4> IFillableMpb.fillColorEnd { get; } = MetaMpb.InitList<Vector4>();

		List<Vector4> IFillableMpb.fillEnd { get; } = MetaMpb.InitList<Vector4>();

		List<float> IFillableMpb.fillSpace { get; } = MetaMpb.InitList<float>();

		List<Vector4> IFillableMpb.fillStart { get; } = MetaMpb.InitList<Vector4>();

		List<float> IFillableMpb.fillType { get; } = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
		}
	}
}
