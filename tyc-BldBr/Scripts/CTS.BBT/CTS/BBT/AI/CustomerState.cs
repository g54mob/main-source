using CTS.Core;

namespace CTS.BBT.AI
{
	public abstract class CustomerState : State<Customer>
	{
		public abstract void SpreadUpdate();

		public abstract void Update();
	}
}
