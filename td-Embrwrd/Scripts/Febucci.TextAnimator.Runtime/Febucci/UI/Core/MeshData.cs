using System;
using UnityEngine;

namespace Febucci.UI.Core
{
	public struct MeshData : IEquatable<MeshData>
	{
		public Vector3[] positions;

		public Color32[] colors;

		public bool Equals(MeshData other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
