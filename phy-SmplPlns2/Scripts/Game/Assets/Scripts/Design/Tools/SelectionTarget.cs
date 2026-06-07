using System;
using Assets.Scripts.Craft.Parts.Modifiers;

namespace Assets.Scripts.Design.Tools
{
	public readonly struct SelectionTarget : IEquatable<SelectionTarget>
	{
		public readonly JFuselageData Fuselage;

		public readonly int Index;

		public readonly bool IsSlice;

		public SelectionTarget(JFuselageData fuselage, int index, bool isSlice)
		{
			Fuselage = fuselage;
			Index = index;
			IsSlice = isSlice;
		}

		public static bool operator !=(SelectionTarget left, SelectionTarget right)
		{
			return !(left == right);
		}

		public static bool operator ==(SelectionTarget left, SelectionTarget right)
		{
			return left.Equals(right);
		}

		public static SelectionTarget ForSection(JFuselageData fuselage, int sectionIndex)
		{
			return new SelectionTarget(fuselage, sectionIndex, isSlice: false);
		}

		public static SelectionTarget ForSlice(JFuselageData fuselage, int sliceIndex)
		{
			return new SelectionTarget(fuselage, sliceIndex, isSlice: true);
		}

		public bool Equals(SelectionTarget other)
		{
			if (Fuselage == other.Fuselage && Index == other.Index)
			{
				return IsSlice == other.IsSlice;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is SelectionTarget other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Fuselage, Index, IsSlice);
		}

		public bool Matches(SelectionTarget other)
		{
			if (Equals(other))
			{
				return true;
			}
			if (!IsSlice || !other.IsSlice)
			{
				return false;
			}
			if (Fuselage.SyncSlice(Index) && Fuselage.TryGetNeighbour(Index, out var neighbourFuselage, out var neighbourSliceIndex) && neighbourFuselage == other.Fuselage && neighbourSliceIndex == other.Index && neighbourFuselage.SyncSlice(neighbourSliceIndex) && Fuselage.ShapeMatches(neighbourFuselage, Index, neighbourSliceIndex))
			{
				return true;
			}
			return false;
		}
	}
}
