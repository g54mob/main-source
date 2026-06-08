namespace Amazon.S3.Model.Internal
{
	internal interface IIntelligentTieringPredicateVisitor
	{
		void Visit(IntelligentTieringPrefixPredicate intelligentTieringPrefixPredicate);

		void Visit(IntelligentTieringTagPredicate intelligentTieringTagPredicate);

		void Visit(IntelligentTieringAndOperator intelligentTieringAndOperator);
	}
}
