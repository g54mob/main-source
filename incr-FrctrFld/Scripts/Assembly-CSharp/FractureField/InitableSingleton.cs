namespace FractureField
{
	public abstract class InitableSingleton<T> : InitableMonoBehaviour where T : InitableSingleton<T>
	{
		private static T instance;

		public static T Instance
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		private void CheckDuplicate()
		{
		}
	}
}
