using System.Collections.Generic;

namespace Shapes
{
	internal class MpbTorus : MetaMpb
	{
		internal List<float> radius = MetaMpb.InitList<float>();

		internal List<float> thickness = MetaMpb.InitList<float>();

		internal List<float> spaceRadius = MetaMpb.InitList<float>();

		internal List<float> spaceThickness = MetaMpb.InitList<float>();

		internal List<float> scaleMode = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propRadius, radius);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propRadiusSpace, spaceRadius);
			Transfer(ShapesMaterialUtils.propThicknessSpace, spaceThickness);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
		}
	}
}
