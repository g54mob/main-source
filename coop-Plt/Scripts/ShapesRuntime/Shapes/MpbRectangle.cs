using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbRectangle : MetaMpb
	{
		internal List<Vector4> rect = MetaMpb.InitList<Vector4>();

		internal List<Vector4> cornerRadii = MetaMpb.InitList<Vector4>();

		internal List<float> thickness = MetaMpb.InitList<float>();

		internal List<float> scaleMode = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propRect, rect);
			Transfer(ShapesMaterialUtils.propCornerRadii, cornerRadii);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
		}
	}
}
