using Amazon.S3.Model.Internal;

namespace Amazon.S3.Model
{
	public sealed class IntelligentTieringPrefixPredicate : IntelligentTieringFilterPredicate
	{
		private readonly string prefix;

		public string Prefix => prefix;

		public IntelligentTieringPrefixPredicate(string prefix)
		{
			this.prefix = prefix;
		}

		internal override void Accept(IIntelligentTieringPredicateVisitor intelligentTieringPredicateVisitor)
		{
			intelligentTieringPredicateVisitor.Visit(this);
		}
	}
}
