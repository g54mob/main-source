namespace Amazon.S3.Model
{
	public class ReplicationRuleFilter
	{
		private string prefix;

		private Tag tag;

		private ReplicationRuleAndOperator and;

		public string Prefix
		{
			get
			{
				return prefix;
			}
			set
			{
				prefix = value;
			}
		}

		public Tag Tag
		{
			get
			{
				return tag;
			}
			set
			{
				tag = value;
			}
		}

		public ReplicationRuleAndOperator And
		{
			get
			{
				return and;
			}
			set
			{
				and = value;
			}
		}

		internal bool IsSetPrefix()
		{
			return !string.IsNullOrEmpty(prefix);
		}

		internal bool IsSetTag()
		{
			return tag != null;
		}

		internal bool IsSetAnd()
		{
			return and != null;
		}
	}
}
