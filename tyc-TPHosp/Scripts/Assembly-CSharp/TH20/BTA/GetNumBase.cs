using BehaviorDesigner.Runtime.Tasks;
using JetBrains.Annotations;

namespace TH20.BTA
{
	public abstract class GetNumBase : ExpiringLevelAction
	{
		public enum Operation
		{
			LessThan = 0,
			LessThanOrEqualTo = 1,
			EqualTo = 2,
			NotEqualTo = 3,
			GreaterThanOrEqualTo = 4,
			GreaterThan = 5
		}

		[UsedImplicitly]
		[Tooltip("The operation to perform")]
		public Operation operation;

		[UsedImplicitly]
		[Tooltip("Wait until comparison is true")]
		public bool _waitForSuccess;

		[UsedImplicitly]
		[Tooltip("Value to compare against")]
		public int _value;

		protected bool CompareValues(int value)
		{
			return operation switch
			{
				Operation.LessThan => value < _value, 
				Operation.LessThanOrEqualTo => value <= _value, 
				Operation.EqualTo => value == _value, 
				Operation.NotEqualTo => value != _value, 
				Operation.GreaterThanOrEqualTo => value >= _value, 
				Operation.GreaterThan => value > _value, 
				_ => false, 
			};
		}
	}
}
