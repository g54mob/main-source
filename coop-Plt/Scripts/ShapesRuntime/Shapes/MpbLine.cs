using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbLine : MetaMpb, IDashable
	{
		internal List<Vector4> colorEnd = MetaMpb.InitList<Vector4>();

		internal List<Vector4> pointStart = MetaMpb.InitList<Vector4>();

		internal List<Vector4> pointEnd = MetaMpb.InitList<Vector4>();

		internal List<float> thickness = MetaMpb.InitList<float>();

		internal List<float> alignment = MetaMpb.InitList<float>();

		internal List<float> thicknessSpace = MetaMpb.InitList<float>();

		internal List<float> scaleMode = MetaMpb.InitList<float>();

		List<float> IDashable.dashSize { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashType { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashShapeModifier { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashSpace { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashSnap { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashOffset { get; } = MetaMpb.InitList<float>();

		List<float> IDashable.dashSpacing { get; } = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propColorEnd, colorEnd);
			Transfer(ShapesMaterialUtils.propPointStart, pointStart);
			Transfer(ShapesMaterialUtils.propPointEnd, pointEnd);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propAlignment, alignment);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
		}
	}
}
