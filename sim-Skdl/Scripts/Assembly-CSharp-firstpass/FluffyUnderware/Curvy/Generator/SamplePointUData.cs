using System;
using JetBrains.Annotations;

namespace FluffyUnderware.Curvy.Generator
{
	public struct SamplePointUData : IEquatable<SamplePointUData>
	{
		public int Vertex;

		public bool UVEdge;

		public bool HardEdge;

		public float FirstU;

		public float SecondU;

		[UsedImplicitly]
		[Obsolete("Use other constructors")]
		public SamplePointUData(int vertexIndex, bool uvEdge, float firstU, float secondU)
		{
			Vertex = 0;
			UVEdge = false;
			HardEdge = false;
			FirstU = 0f;
			SecondU = 0f;
		}

		public SamplePointUData(int vertexIndex, bool uvEdge, bool hardEdge, float firstU, float secondU)
		{
			Vertex = 0;
			UVEdge = false;
			HardEdge = false;
			FirstU = 0f;
			SecondU = 0f;
		}

		public SamplePointUData(int vertexIndex, ControlPointOption controlPointsOption)
		{
			Vertex = 0;
			UVEdge = false;
			HardEdge = false;
			FirstU = 0f;
			SecondU = 0f;
		}

		public override string ToString()
		{
			return null;
		}

		public bool Equals(SamplePointUData other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(SamplePointUData left, SamplePointUData right)
		{
			return false;
		}

		public static bool operator !=(SamplePointUData left, SamplePointUData right)
		{
			return false;
		}
	}
}
