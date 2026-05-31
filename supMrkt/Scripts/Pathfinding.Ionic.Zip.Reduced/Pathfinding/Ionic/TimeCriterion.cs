using System;
using Pathfinding.Ionic.Zip;

namespace Pathfinding.Ionic
{
	internal class TimeCriterion : SelectionCriterion
	{
		internal ComparisonOperator Operator;

		internal WhichTime Which;

		internal DateTime Time;

		public override string ToString()
		{
			return null;
		}

		internal override bool Evaluate(string filename)
		{
			return false;
		}

		private bool _Evaluate(DateTime x)
		{
			return false;
		}

		internal override bool Evaluate(ZipEntry entry)
		{
			return false;
		}
	}
}
