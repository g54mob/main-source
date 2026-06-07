namespace Gh.Tk
{
	public class GameObjectXMatchInfo : IPersistable
	{
		[PersistenceObjectReference]
		public GameObjectX GameObjectX { get; private set; }

		[PersistenceObjectReference]
		public AccessPoint AccessPoint { get; internal set; }

		internal float Rating { get; set; }

		private GameObjectXMatchInfo()
		{
		}

		public GameObjectXMatchInfo(GameObjectX obj)
		{
		}
	}
}
