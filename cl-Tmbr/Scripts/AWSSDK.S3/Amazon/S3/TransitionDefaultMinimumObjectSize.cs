using Amazon.Runtime;

namespace Amazon.S3
{
	public class TransitionDefaultMinimumObjectSize : ConstantClass
	{
		public static readonly TransitionDefaultMinimumObjectSize AllStorageClasses128K = new TransitionDefaultMinimumObjectSize("all_storage_classes_128K");

		public static readonly TransitionDefaultMinimumObjectSize VariesByStorageClass = new TransitionDefaultMinimumObjectSize("varies_by_storage_class");

		public TransitionDefaultMinimumObjectSize(string value)
			: base(value)
		{
		}

		public static TransitionDefaultMinimumObjectSize FindValue(string value)
		{
			return ConstantClass.FindValue<TransitionDefaultMinimumObjectSize>(value);
		}

		public static implicit operator TransitionDefaultMinimumObjectSize(string value)
		{
			return FindValue(value);
		}
	}
}
