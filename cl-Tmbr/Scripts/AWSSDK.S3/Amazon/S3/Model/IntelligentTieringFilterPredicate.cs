using Amazon.S3.Model.Internal;

namespace Amazon.S3.Model
{
	public abstract class IntelligentTieringFilterPredicate
	{
		internal abstract void Accept(IIntelligentTieringPredicateVisitor intelligentTieringPredicateVisitor);
	}
}
