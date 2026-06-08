namespace Amazon.S3.Model.Internal
{
	internal interface ILifecyclePredicateVisitor
	{
		void Visit(LifecyclePrefixPredicate lifecyclePrefixPredicate);

		void Visit(LifecycleTagPredicate lifecycleTagPredicate);

		void Visit(LifecycleObjectSizeGreaterThanPredicate lifecycleGreaterThanPredicate);

		void Visit(LifecycleObjectSizeLessThanPredicate lifecycleGreaterLessThanPredicate);

		void Visit(LifecycleAndOperator lifecycleAndOperator);
	}
}
