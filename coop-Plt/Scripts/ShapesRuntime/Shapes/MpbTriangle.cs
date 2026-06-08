using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbTriangle : MetaMpb
	{
		internal List<Vector4> a = MetaMpb.InitList<Vector4>();

		internal List<Vector4> b = MetaMpb.InitList<Vector4>();

		internal List<Vector4> c = MetaMpb.InitList<Vector4>();

		internal List<Vector4> colorB = MetaMpb.InitList<Vector4>();

		internal List<Vector4> colorC = MetaMpb.InitList<Vector4>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propA, a);
			Transfer(ShapesMaterialUtils.propB, b);
			Transfer(ShapesMaterialUtils.propC, c);
			Transfer(ShapesMaterialUtils.propColorB, colorB);
			Transfer(ShapesMaterialUtils.propColorC, colorC);
		}
	}
}
