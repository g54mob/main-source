using System.Collections.Generic;
using UnityEngine;

namespace Shapes
{
	internal class MpbTexture : MetaMpb
	{
		internal readonly List<Texture> textures = MetaMpb.InitList<Texture>();

		internal readonly List<Vector4> rect = MetaMpb.InitList<Vector4>();

		internal readonly List<Vector4> uvs = MetaMpb.InitList<Vector4>();

		protected override void TransferShapeProperties()
		{
			Transfer(ShapesMaterialUtils.propRect, rect);
			Transfer(ShapesMaterialUtils.propUvs, uvs);
			Transfer(ShapesMaterialUtils.propMainTex, textures);
		}
	}
}
