namespace Amazon.S3.Model
{
	public class IntelligentTieringFilter
	{
		private IntelligentTieringFilterPredicate intelligentTieringFilterPredicate;

		public IntelligentTieringFilterPredicate IntelligentTieringFilterPredicate
		{
			get
			{
				return intelligentTieringFilterPredicate;
			}
			set
			{
				intelligentTieringFilterPredicate = value;
			}
		}
	}
}
