namespace Polarith.AI.Criteria
{
	public abstract class CriteriaBehaviour : IBehaviour
	{
		public const int CentralOrder = 1000;

		public const int LastOrder = 2000;

		protected bool enabled;

		private int order;

		public bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				enabled = value;
			}
		}

		public int Order
		{
			get
			{
				return order;
			}
			set
			{
				order = value;
			}
		}

		public abstract void Behave();
	}
}
