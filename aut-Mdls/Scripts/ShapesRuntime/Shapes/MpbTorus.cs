using System.Collections.Generic;

namespace Shapes
{
	internal class MpbTorus : MetaMpb
	{
		internal readonly List<float> angleEnd = MetaMpb.InitList<float>();

		internal readonly List<float> angleStart = MetaMpb.InitList<float>();

		internal readonly List<float> radius = MetaMpb.InitList<float>();

		internal readonly List<float> radiusSpace = MetaMpb.InitList<float>();

		internal readonly List<float> scaleMode = MetaMpb.InitList<float>();

		internal readonly List<float> thickness = MetaMpb.InitList<float>();

		internal readonly List<float> thicknessSpace = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propAngEnd, angleEnd);
			Transfer(ShapesMaterialUtils.propAngStart, angleStart);
			Transfer(ShapesMaterialUtils.propRadius, radius);
			Transfer(ShapesMaterialUtils.propRadiusSpace, radiusSpace);
			Transfer(ShapesMaterialUtils.propScaleMode, scaleMode);
			Transfer(ShapesMaterialUtils.propThickness, thickness);
			Transfer(ShapesMaterialUtils.propThicknessSpace, thicknessSpace);
		}
	}
}
