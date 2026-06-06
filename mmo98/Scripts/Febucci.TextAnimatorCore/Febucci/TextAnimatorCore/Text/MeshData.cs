using System;
using System.Text;
using Febucci.Numbers;

namespace Febucci.TextAnimatorCore.Text
{
	public struct MeshData : IEquatable<MeshData>
	{
		public Vector3[] positions;

		public Color32[] colors;

		public MeshData(bool initialize = true)
		{
			if (initialize)
			{
				positions = new Vector3[4];
				colors = new Color32[4]
				{
					Color32.White,
					Color32.White,
					Color32.White,
					Color32.White
				};
			}
			else
			{
				positions = null;
				colors = null;
			}
		}

		public bool Equals(MeshData other)
		{
			if (positions == null || other.positions == null)
			{
				return false;
			}
			if (colors == null || other.colors == null)
			{
				return false;
			}
			for (int i = 0; i < 4; i++)
			{
				if (!positions[i].ApproximatesTo(other.positions[i]))
				{
					return false;
				}
			}
			for (int j = 0; j < 4; j++)
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
			if (positions == null || colors == null)
			{
				return "MeshData(uninitialized)";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("MeshData: ");
			for (int i = 0; i < 4; i++)
			{
				stringBuilder.Append($"[{i}] Pos:{positions[i]} Col:{colors[i]} ");
			}
			return stringBuilder.ToString();
		}
	}
}
