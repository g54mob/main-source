using System.Text;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Parts.Fuselage
{
	public struct Point
	{
		public const int OffsetOfPosition = 0;

		public float2 Position;

		public float2 Tangent;

		public float2 TangentB;

		public float Fraction;

		public bool Sharp;

		public int2 MeshIndices;

		public readonly float2 InTangent => Tangent;

		public readonly float2 OutTangent
		{
			get
			{
				if (!Sharp)
				{
					return Tangent;
				}
				return TangentB;
			}
		}

		public Point(float2 position, float frac, float2 tangent, float2 tangentB, bool sharp = false)
		{
			Position = position;
			Fraction = frac;
			Tangent = tangent;
			TangentB = tangentB;
			Sharp = sharp;
			MeshIndices = -1;
		}

		public Point(float2 position, float frac, float2 tangent)
		{
			Position = position;
			Fraction = frac;
			Tangent = tangent;
			TangentB = tangent;
			Sharp = false;
			MeshIndices = -1;
		}

		public Point(float2 position, float frac, float2 tangent, float2 tangentB)
		{
			Position = position;
			Fraction = frac;
			Sharp = true;
			Tangent = tangent;
			TangentB = tangentB;
			MeshIndices = -1;
		}

		public static string Dump(Point[] points)
		{
			StringBuilder stringBuilder = new StringBuilder("x,y,f,t1x,t1y,t2x,t2y\n");
			for (int i = 0; i < points.Length; i++)
			{
				Point point = points[i];
				stringBuilder.AppendLine($"{point.Position.x:F10}, {point.Position.y:F10}, {point.Fraction:F10}, {point.Tangent.x:F10}, {point.Tangent.y:F10}, {point.TangentB.x:F10}, {point.TangentB.y:F10}");
			}
			return stringBuilder.ToString();
		}
	}
}
