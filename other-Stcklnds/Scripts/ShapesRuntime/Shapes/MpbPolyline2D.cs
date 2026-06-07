using System.Collections.Generic;

namespace Shapes
{
	internal class MpbPolyline2D : MetaMpb
	{
		internal readonly List<float> alignment = MetaMpb.InitList<float>();

		internal readonly List<float> scaleMode = MetaMpb.InitList<float>();

		internal readonly List<float> thickness = MetaMpb.InitList<float>();

		internal readonly List<float> thicknessSpace = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propAlignment, alignment);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
		}
	}
}
