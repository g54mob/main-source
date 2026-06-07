using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbTriangle : MetaMpb, IDashableMpb
	{
		internal readonly List<Vector4> a = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> b = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> c = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> colorB = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> colorC = MetaMpb.InitList<Vector4>();

		internal readonly List<float> hollow = MetaMpb.InitList<float>();

		internal readonly List<float> roundness = MetaMpb.InitList<float>();

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
			Transfer(ShapesMaterialUtils.propA, a);
			Transfer(ShapesMaterialUtils.propB, b);
			Transfer(ShapesMaterialUtils.propC, c);
			Transfer(ShapesMaterialUtils.propColorB, colorB);
			Transfer(ShapesMaterialUtils.propColorC, colorC);
			Transfer(ShapesMaterialUtils.propBorder, hollow);
			Transfer(ShapesMaterialUtils.propRoundness, roundness);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
		}
	}
}
