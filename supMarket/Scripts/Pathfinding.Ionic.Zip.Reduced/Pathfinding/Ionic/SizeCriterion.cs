using Pathfinding.Ionic.Zip;

namespace Pathfinding.Ionic
{
	internal class SizeCriterion : SelectionCriterion
	{
		internal ComparisonOperator Operator;

		internal long Size;

		public override string ToString()
		{
			return null;
		}

		internal override bool Evaluate(string filename)
		{
			return false;
		}

		private bool _Evaluate(long Length)
		{
			return false;
		}

		internal override bool Evaluate(ZipEntry entry)
		{
			return false;
		}
	}
}
