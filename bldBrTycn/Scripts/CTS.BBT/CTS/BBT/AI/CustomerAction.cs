namespace CTS.BBT.AI
{
	public abstract class CustomerAction : AgentAction<Customer>
	{
		protected CustomerAction()
		{
			base.Name = GetType().Name.Remove(0, 14);
		}
	}
}
