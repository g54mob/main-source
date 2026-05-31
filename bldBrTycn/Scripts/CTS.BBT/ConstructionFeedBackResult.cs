using System;

public struct ConstructionFeedBackResult : IEquatable<ConstructionFeedBackResult>
{
	public EConstructionResult ConstructionResult;

	public object param;

	public bool Equals(ConstructionFeedBackResult other)
	{
		if (ConstructionResult != other.ConstructionResult)
		{
			return false;
		}
		if (param == null)
		{
			return other.param == null;
		}
		return param.Equals(other.param);
	}

	public override bool Equals(object obj)
	{
		if (obj is ConstructionFeedBackResult other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int constructionResult = (int)ConstructionResult;
		return constructionResult.GetHashCode() + ((param != null) ? param.GetHashCode() : 0);
	}
}
