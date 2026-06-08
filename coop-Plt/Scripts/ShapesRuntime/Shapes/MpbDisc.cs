using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbDisc : MetaMpb, IDashable
	{
		internal List<float> radius = MetaMpb.InitList<float>();

		internal List<float> radiusSpace = MetaMpb.InitList<float>();

		internal List<float> alignment = MetaMpb.InitList<float>();

		internal List<float> thicknessSpace = MetaMpb.InitList<float>();

		internal List<float> thickness = MetaMpb.InitList<float>();

		internal List<float> scaleMode = MetaMpb.InitList<float>();

		internal List<float> angStart = MetaMpb.InitList<float>();

		internal List<float> angEnd = MetaMpb.InitList<float>();

		internal List<float> roundCaps = MetaMpb.InitList<float>();

		internal List<Vector4> colorOuterStart = MetaMpb.InitList<Vector4>();

		internal List<Vector4> colorInnerEnd = MetaMpb.InitList<Vector4>();

		internal List<Vector4> colorOuterEnd = MetaMpb.InitList<Vector4>();

		List<float> IDashable.dashSize { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashType { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashShapeModifier { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashSpace { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashSnap { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashOffset { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashSpacing { get; } = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propRadius, radius);
			Transfer(ShapesMaterialUtils.propRadiusSpace, radiusSpace);
			Transfer(ShapesMaterialUtils.propAlignment, alignment);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
			Transfer(ShapesMaterialUtils.propAngStart, angStart);
			Transfer(ShapesMaterialUtils.propAngEnd, angEnd);
			Transfer(ShapesMaterialUtils.propRoundCaps, roundCaps);
			Transfer(ShapesMaterialUtils.propColorOuterStart, colorOuterStart);
			Transfer(ShapesMaterialUtils.propColorInnerEnd, colorInnerEnd);
			Transfer(ShapesMaterialUtils.propColorOuterEnd, colorOuterEnd);
		}
	}
}
