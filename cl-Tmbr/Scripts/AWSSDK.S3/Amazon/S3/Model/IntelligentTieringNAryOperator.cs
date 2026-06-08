using System.Collections.Generic;

namespace Amazon.S3.Model
{
	public abstract class IntelligentTieringNAryOperator : IntelligentTieringFilterPredicate
	{
		private readonly List<IntelligentTieringFilterPredicate> operands;

		public List<IntelligentTieringFilterPredicate> Operands => operands;

		protected IntelligentTieringNAryOperator(List<IntelligentTieringFilterPredicate> operands)
		{
			this.operands = operands;
		}
	}
}
