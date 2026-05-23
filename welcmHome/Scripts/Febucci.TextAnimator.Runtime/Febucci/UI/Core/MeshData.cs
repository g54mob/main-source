using System;
using System.Text;
using UnityEngine;

namespace Febucci.UI.Core
{
	public struct MeshData : IEquatable<MeshData>
	{
		public Vector3[] positions;

		public Color32[] colors;

		public bool Equals(MeshData other)
		{
			for (int i = 0; i < positions.Length; i++)
			{
				if (positions[i] != other.positions[i])
				{
					return false;
				}
			}
			for (int j = 0; j < colors.Length; j++)
			{
				if (!colors[j].Equals(other.colors[j]))
				{
					return false;
				}
			}
			return true;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < positions.Length; i++)
			{
				stringBuilder.Append(positions[i].ToString());
				stringBuilder.Append(" ");
				stringBuilder.Append(colors[i].ToString());
				stringBuilder.Append(" - ");
			}
			return stringBuilder.ToString();
		}
	}
}
