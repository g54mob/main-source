using System.Collections.Generic;

namespace Shapes
{
	internal class MpbCone : MetaMpb
	{
		internal List<float> radius = MetaMpb.InitList<float>();

		internal List<float> length = MetaMpb.InitList<float>();

		internal List<float> sizeSpace = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propRadius, radius);
			Transfer(ShapesMaterialUtils.propLength, length);
			Transfer(ShapesMaterialUtils.propSizeSpace, sizeSpace);
		}
	}
}
