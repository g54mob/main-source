namespace Aggro.Core
{
	public abstract class GameDataObject<T> : GameDataObjectBase where T : GameDataObject<T>
	{
		private static T _data;

		public static T data
		{
			get
			{
				if ((object)_data == null)
				{
					_data = GameDataCache.Get<T>();
				}
				return _data;
			}
		}
	}
}
