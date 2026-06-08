using Amazon.S3.Model.Internal;

namespace Amazon.S3.Model
{
	public sealed class IntelligentTieringTagPredicate : IntelligentTieringFilterPredicate
	{
		private readonly Tag tag;

		public Tag Tag => tag;

		public IntelligentTieringTagPredicate(Tag tag)
		{
			this.tag = tag;
		}

		internal override void Accept(IIntelligentTieringPredicateVisitor intelligentTieiringPredicateVisitor)
		{
			intelligentTieiringPredicateVisitor.Visit(this);
		}
	}
}
