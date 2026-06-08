using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbRect : MetaMpb, IFillableMpb, IDashableMpb
	{
		internal readonly List<Vector4> cornerRadii = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> rect = MetaMpb.InitList<Vector4>();

		internal readonly List<float> scaleMode = MetaMpb.InitList<float>();

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
			Transfer(ShapesMaterialUtils.propCornerRadii, cornerRadii);
			Transfer(ShapesMaterialUtils.propRect, rect);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
		}
	}
}
