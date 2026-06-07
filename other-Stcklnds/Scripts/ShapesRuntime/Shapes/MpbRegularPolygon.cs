using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbRegularPolygon : MetaMpb, IFillableMpb, IDashableMpb
	{
		internal readonly List<float> alignment = MetaMpb.InitList<float>();

		internal readonly List<float> angle = MetaMpb.InitList<float>();

		internal readonly List<float> hollow = MetaMpb.InitList<float>();

		internal readonly List<float> radius = MetaMpb.InitList<float>();

		internal readonly List<float> radiusSpace = MetaMpb.InitList<float>();

		internal readonly List<float> roundness = MetaMpb.InitList<float>();

		internal readonly List<float> scaleMode = MetaMpb.InitList<float>();

		internal readonly List<float> sides = MetaMpb.InitList<float>();

		internal readonly List<float> thickness = MetaMpb.InitList<float>();

		internal readonly List<float> thicknessSpace = MetaMpb.InitList<float>();

		List<Vector4> IFillableMpb.fillColorEnd { get; } = MetaMpb.InitList<Vector4>();

		List<Vector4> IFillableMpb.fillEnd { get; } = MetaMpb.InitList<Vector4>();

		List<float> IFillableMpb.fillSpace { get; } = MetaMpb.InitList<float>();

		List<Vector4> IFillableMpb.fillStart { get; } = MetaMpb.InitList<Vector4>();

		List<float> IFillableMpb.fillType { get; } = MetaMpb.InitList<float>();

		List<float> IDashableMpb.dashOffset { get; } = MetaMpb.InitList<float>();

		List<float> IDashableMpb.dashShapeModifier { get; } = MetaMpb.InitList<float>();

		List<float> IDashableMpb.dashSize { get; } = MetaMpb.InitList<float>();

		List<float> IDashableMpb.dashSnap { get; } = MetaMpb.InitList<float>();

		List<float> IDashableMpb.dashSpace { get; } = MetaMpb.InitList<float>();

		List<float> IDashableMpb.dashSpacing { get; } = MetaMpb.InitList<float>();

		List<float> IDashableMpb.dashType { get; } = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propAlignment, alignment);
			Transfer(ShapesMaterialUtils.propAng, angle);
			Transfer(ShapesMaterialUtils.propBorder, hollow);
			Transfer(ShapesMaterialUtils.propRadius, radius);
			Transfer(ShapesMaterialUtils.propRadiusSpace, radiusSpace);
			Transfer(ShapesMaterialUtils.propRoundness, roundness);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
			Transfer(ShapesMaterialUtils.propSides, sides);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
		}
	}
}
