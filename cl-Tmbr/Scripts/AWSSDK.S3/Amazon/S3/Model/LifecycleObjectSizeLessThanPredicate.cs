using Amazon.S3.Model.Internal;

namespace Amazon.S3.Model
{
	public class LifecycleObjectSizeLessThanPredicate : LifecycleFilterPredicate
	{
		private long? _objectSizeLessThan;

		public long? ObjectSizeLessThan
		{
			get
			{
				return _objectSizeLessThan;
			}
			set
			{
				_objectSizeLessThan = value;
			}
		}

		internal bool IsSetObjectSizeLessThan()
		{
			return _objectSizeLessThan.HasValue;
		}

		internal override void Accept(ILifecyclePredicateVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
