using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbTexture : MetaMpb
	{
		internal Texture texture;

		internal readonly List<Vector4> rect = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> uvs = MetaMpb.InitList<Vector4>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propRect, rect);
			Transfer(ShapesMaterialUtils.propUvs, uvs);
			Transfer(ShapesMaterialUtils.propMainTex, ref texture);
		}
	}
}
