using System.Collections.Generic;
using Amazon.S3.Model.Internal;

namespace Amazon.S3.Model
{
	public sealed class IntelligentTieringAndOperator : IntelligentTieringNAryOperator
	{
		public IntelligentTieringAndOperator(List<IntelligentTieringFilterPredicate> operands)
			: base(operands)
		{
		}

		internal override void Accept(IIntelligentTieringPredicateVisitor intelligentTieringPredicateVisitor)
		{
			intelligentTieringPredicateVisitor.Visit(this);
		}
	}
}
