using System.Collections.Generic;

namespace Shapes
{
	internal class MpbPolyline : MetaMpb
	{
		internal List<float> thickness = MetaMpb.InitList<float>();

		internal List<float> thicknessSpace = MetaMpb.InitList<float>();

		internal List<float> alignment = MetaMpb.InitList<float>();

		internal List<float> scaleMode = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
			Transfer(ShapesMaterialUtils.propAlignment, alignment);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
		}
	}
}
