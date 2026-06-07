using Pathfinding.Ionic.Zip;

namespace Pathfinding.Ionic
{
	internal class TypeCriterion : SelectionCriterion
	{
		private char ObjectType;

		internal ComparisonOperator Operator;

		internal string AttributeString
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override string ToString()
		{
			return null;
		}

		internal override bool Evaluate(string filename)
		{
			return false;
		}

		internal override bool Evaluate(ZipEntry entry)
		{
			return false;
		}
	}
}
