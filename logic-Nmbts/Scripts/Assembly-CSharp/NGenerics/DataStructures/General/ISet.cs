namespace NGenerics.DataStructures.General
{
	public interface ISet
	{
		ISet Subtract(ISet other);

		ISet Intersection(ISet other);

		ISet Inverse();

		bool IsProperSubsetOf(ISet other);

		bool IsProperSupersetOf(ISet other);

		bool IsSubsetOf(ISet other);

		bool IsSupersetOf(ISet other);

		ISet Union(ISet other);
	}
}
