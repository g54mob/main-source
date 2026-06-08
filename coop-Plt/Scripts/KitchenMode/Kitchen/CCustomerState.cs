using Unity.Entities;

namespace Kitchen
{
	public struct CCustomerState : IComponentData
	{
		public enum State
		{
			Normal = 0,
			Queue = 1,
			AtTable = 2
		}

		public State CurrentState;

		public static implicit operator State(CCustomerState x)
		{
			return x.CurrentState;
		}

		public static implicit operator CCustomerState(State x)
		{
			return new CCustomerState
			{
				CurrentState = x
			};
		}
	}
}
