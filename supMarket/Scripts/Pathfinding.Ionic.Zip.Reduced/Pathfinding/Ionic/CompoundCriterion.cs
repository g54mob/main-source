using Pathfinding.Ionic.Zip;

namespace Pathfinding.Ionic
{
	internal class CompoundCriterion : SelectionCriterion
	{
		internal LogicalConjunction Conjunction;

		internal SelectionCriterion Left;

		private SelectionCriterion _Right;

		internal SelectionCriterion Right
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		internal override bool Evaluate(string filename)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		internal override bool Evaluate(ZipEntry entry)
		{
			return false;
		}
	}
}
