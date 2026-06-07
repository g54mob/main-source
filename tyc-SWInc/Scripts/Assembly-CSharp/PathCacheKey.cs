using System.Collections.Generic;

public struct PathCacheKey
{
	public readonly IRoomConnector X;

	public readonly IRoomConnector Y;

	public readonly byte XFlag;

	public readonly byte YFlag;

	public PathCacheKey(IRoomConnector x, IRoomConnector y, byte xFlag, byte yFlag)
	{
		X = x;
		Y = y;
		XFlag = xFlag;
		YFlag = yFlag;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is PathCacheKey))
		{
			return false;
		}
		PathCacheKey pathCacheKey = (PathCacheKey)obj;
		if (X.Equals(pathCacheKey.X) && Y.Equals(pathCacheKey.Y) && XFlag == pathCacheKey.XFlag)
		{
			return YFlag == pathCacheKey.YFlag;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((1089753330 * -1521134295 + EqualityComparer<IRoomConnector>.Default.GetHashCode(X)) * -1521134295 + EqualityComparer<IRoomConnector>.Default.GetHashCode(Y)) * -1521134295 + XFlag.GetHashCode()) * -1521134295 + YFlag.GetHashCode();
	}
}
