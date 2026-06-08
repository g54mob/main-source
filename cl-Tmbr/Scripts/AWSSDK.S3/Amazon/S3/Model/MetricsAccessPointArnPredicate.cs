using Amazon.S3.Model.Internal;

namespace Amazon.S3.Model
{
	public class MetricsAccessPointArnPredicate : MetricsFilterPredicate
	{
		private string _accessPointArn;

		public string AccessPointArn
		{
			get
			{
				return _accessPointArn;
			}
			set
			{
				_accessPointArn = value;
			}
		}

		public MetricsAccessPointArnPredicate(string accessPointArn)
		{
			_accessPointArn = accessPointArn;
		}

		internal bool IsSetAccessPointArn()
		{
			return _accessPointArn != null;
		}

		internal override void Accept(IMetricsPredicateVisitor metricsPredicateVisitor)
		{
			metricsPredicateVisitor.visit(this);
		}
	}
}
