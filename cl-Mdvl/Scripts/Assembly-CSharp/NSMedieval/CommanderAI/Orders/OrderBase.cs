using NSMedieval.State;

namespace NSMedieval.CommanderAI.Orders
{
	public abstract class OrderBase
	{
		public override string ToString()
		{
			return "OrderBase";
		}

		public abstract bool Equals(OrderBase order);

		public virtual void OnAssigned(EnemyBehaviour unit)
		{
		}
	}
}
