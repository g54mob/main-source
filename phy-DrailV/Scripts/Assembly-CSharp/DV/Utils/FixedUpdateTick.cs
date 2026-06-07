namespace DV.Utils
{
	public class FixedUpdateTick : SingletonBehaviour<FixedUpdateTick>
	{
		public int Tick { get; private set; }

		public new static string AllowAutoCreate()
		{
			return "[FixedUpdateTick]";
		}

		private void FixedUpdate()
		{
			Tick++;
		}
	}
}
