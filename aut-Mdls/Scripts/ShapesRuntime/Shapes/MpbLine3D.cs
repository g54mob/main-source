using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbLine3D : MetaMpb, IDashableMpb
	{
		internal readonly List<Vector4> colorEnd = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> pointEnd = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> pointStart = MetaMpb.InitList<Vector4>();

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
			Transfer(ShapesMaterialUtils.propColorEnd, colorEnd);
			Transfer(ShapesMaterialUtils.propPointEnd, pointEnd);
			Transfer(ShapesMaterialUtils.propPointStart, pointStart);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
		}
	}
}
