using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbDisc : MetaMpb, IDashableMpb
	{
		internal readonly List<float> alignment = MetaMpb.InitList<float>();

		internal readonly List<float> angleEnd = MetaMpb.InitList<float>();

		internal readonly List<float> angleStart = MetaMpb.InitList<float>();

		internal readonly List<Vector4> colorInnerEnd = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> colorOuterEnd = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> colorOuterStart = MetaMpb.InitList<Vector4>();

		internal readonly List<float> radius = MetaMpb.InitList<float>();

		internal readonly List<float> radiusSpace = MetaMpb.InitList<float>();

		internal readonly List<float> roundCaps = MetaMpb.InitList<float>();

		internal readonly List<float> scaleMode = MetaMpb.InitList<float>();

		internal readonly List<float> thickness = MetaMpb.InitList<float>();

		internal readonly List<float> thicknessSpace = MetaMpb.InitList<float>();

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
			Transfer(ShapesMaterialUtils.propAngEnd, angleEnd);
			Transfer(ShapesMaterialUtils.propAngStart, angleStart);
			Transfer(ShapesMaterialUtils.propColorInnerEnd, colorInnerEnd);
			Transfer(ShapesMaterialUtils.propColorOuterEnd, colorOuterEnd);
			Transfer(ShapesMaterialUtils.propColorOuterStart, colorOuterStart);
			Transfer(ShapesMaterialUtils.propRadius, radius);
			Transfer(ShapesMaterialUtils.propRadiusSpace, radiusSpace);
			Transfer(ShapesMaterialUtils.propRoundCaps, roundCaps);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
		}
	}
}
