using System;
using System.Collections.Generic;
using Os.Utils;
using Placemaker.Modules;
using UnityEngine;

namespace Placemaker
{
	[Serializable]
	public class ModuleMesh
	{
		public Material material;

		public List<SbyteFloat3> verts;

		public List<SbyteFloat3> normals;

		public List<SbyteFloat3> tangents;

		public List<ByteFloat> concavity;

		public List<ByteFloat2> uvs;

		public List<OutlineUv> outlineUvs;

		public List<byte> tris;

		public MaterialType materialType;

		public byte corner;
	}
}
