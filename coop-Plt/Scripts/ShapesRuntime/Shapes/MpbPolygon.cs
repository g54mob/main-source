using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbPolygon : MetaMpb, IFillable
	{
		List<float> IFillable.fillType { get; } = MetaMpb.InitList<float>();

		List<float> IFillable.fillSpace { get; } = MetaMpb.InitList<float>();

		List<Vector4> IFillable.fillStart { get; } = MetaMpb.InitList<Vector4>();

		List<Vector4> IFillable.fillEnd { get; } = MetaMpb.InitList<Vector4>();

		List<Vector4> IFillable.fillColorEnd { get; } = MetaMpb.InitList<Vector4>();

		protected override void TransferShapeProperties()
		{
		}
	}
}
