using Amazon.S3.Model.Internal;

namespace Amazon.S3.Model
{
	public class LifecycleObjectSizeGreaterThanPredicate : LifecycleFilterPredicate
	{
		private long? _objectSizeGreaterThan;

		public long? ObjectSizeGreaterThan
		{
			get
			{
				return _objectSizeGreaterThan;
			}
			set
			{
				_objectSizeGreaterThan = value;
			}
		}

		internal bool IsSetObjectSizeGreaterThan()
		{
			return _objectSizeGreaterThan.HasValue;
		}

		internal override void Accept(ILifecyclePredicateVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}
