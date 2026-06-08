using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbRegularPolygon : MetaMpb, IFillable
	{
		internal List<float> radius = MetaMpb.InitList<float>();

		internal List<float> radiusSpace = MetaMpb.InitList<float>();

		internal List<float> geometry = MetaMpb.InitList<float>();

		internal List<float> sides = MetaMpb.InitList<float>();

		internal List<float> angle = MetaMpb.InitList<float>();

		internal List<float> roundness = MetaMpb.InitList<float>();

		internal List<float> hollow = MetaMpb.InitList<float>();

		internal List<float> thicknessSpace = MetaMpb.InitList<float>();

		internal List<float> thickness = MetaMpb.InitList<float>();

		internal List<float> scaleMode = MetaMpb.InitList<float>();

		List<float> IFillable.fillType { get; } = MetaMpb.InitList<float>();

		List<float> IFillable.fillSpace { get; } = MetaMpb.InitList<float>();

		List<Vector4> IFillable.fillStart { get; } = MetaMpb.InitList<Vector4>();

		List<Vector4> IFillable.fillEnd { get; } = MetaMpb.InitList<Vector4>();

		List<Vector4> IFillable.fillColorEnd { get; } = MetaMpb.InitList<Vector4>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propRadius, radius);
			Transfer(ShapesMaterialUtils.propRadiusSpace, radiusSpace);
			Transfer(ShapesMaterialUtils.propAlignment, geometry);
			Transfer(ShapesMaterialUtils.propSides, sides);
			Transfer(ShapesMaterialUtils.propAng, angle);
			Transfer(ShapesMaterialUtils.propRoundness, roundness);
			Transfer(ShapesMaterialUtils.propHollow, hollow);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
		}
	}
}
