using System.Collections.Generic;

namespace Shapes
{
	internal class MpbCone : MetaMpb
	{
		internal readonly List<float> length = MetaMpb.InitList<float>();

		internal readonly List<float> radius = MetaMpb.InitList<float>();

		internal readonly List<float> sizeSpace = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propLength, length);
			Transfer(ShapesMaterialUtils.propRadius, radius);
			Transfer(ShapesMaterialUtils.propSizeSpace, sizeSpace);
		}
	}
}
