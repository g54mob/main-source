using System.Collections.Generic;

namespace Shapes
{
	internal class MpbSphere : MetaMpb
	{
		internal readonly List<float> radius = MetaMpb.InitList<float>();

		internal readonly List<float> radiusSpace = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propRadius, radius);
			Transfer(ShapesMaterialUtils.propRadiusSpace, radiusSpace);
		}
	}
}
