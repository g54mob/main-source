using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbCuboid : MetaMpb
	{
		internal readonly List<Vector4> size = MetaMpb.InitList<Vector4>();

		internal readonly List<float> sizeSpace = MetaMpb.InitList<float>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propSize, size);
			Transfer(ShapesMaterialUtils.propSizeSpace, sizeSpace);
		}
	}
}
