using System;

public struct CellConstructionStruct : IEquatable<CellConstructionStruct>
{
	public ERotationAngle RotationType { get; private set; }

	public EWallType WallType { get; private set; }

	public CellConstructionStruct(ERotationAngle rotationType, EWallType wallType)
	{
		RotationType = rotationType;
		WallType = wallType;
	}

	public bool Equals(CellConstructionStruct other)
	{
		if (other.RotationType == RotationType)
		{
			return other.WallType == WallType;
		}
		return false;
	}
}
