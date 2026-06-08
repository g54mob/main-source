namespace KitchenData
{
	public abstract class DataView
	{
		protected GameData Data;

		public virtual void Initialise(GameData data)
		{
			Data = data;
		}

		public virtual void Dispose()
		{
		}
	}
}
