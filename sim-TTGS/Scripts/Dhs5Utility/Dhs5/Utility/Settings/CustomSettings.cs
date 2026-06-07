namespace Dhs5.Utility.Settings
{
	public abstract class CustomSettings<T> : BaseSettings where T : CustomSettings<T>
	{
		private static T _instance;

		public static T I
		{
			get
			{
				if (_instance == null && BaseSettings.GetInstance(typeof(T)) is T instance)
				{
					_instance = instance;
				}
				return _instance;
			}
		}
	}
}
