using System;

namespace FluffyUnderware.Curvy.Generator
{
	public struct ControlPointOption : IEquatable<ControlPointOption>
	{
		public float TF;

		public float Distance;

		public bool Include;

		public int MaterialID;

		public bool HardEdge;

		public float MaxStepDistance;

		public bool UVEdge;

		public bool UVShift;

		public float FirstU;

		public float SecondU;

		public ControlPointOption(float tf, float dist, bool includeAnyways, int materialID, bool hardEdge, float maxStepDistance, bool uvEdge, bool uvShift, float firstU, float secondU)
		{
			TF = 0f;
			Distance = 0f;
			Include = false;
			MaterialID = 0;
			HardEdge = false;
			MaxStepDistance = 0f;
			UVEdge = false;
			UVShift = false;
			FirstU = 0f;
			SecondU = 0f;
		}

		public bool Equals(ControlPointOption other)
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

		public static bool operator ==(ControlPointOption left, ControlPointOption right)
		{
			return false;
		}

		public static bool operator !=(ControlPointOption left, ControlPointOption right)
		{
			return false;
		}
	}
}
