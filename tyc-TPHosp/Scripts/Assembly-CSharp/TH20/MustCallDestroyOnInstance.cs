namespace TH20
{
	public class MustCallDestroyOnInstance : MustCallDestroy
	{
		private bool _isInstance;

		private static bool ConstructingInstance { get; set; }

		protected MustCallDestroyOnInstance()
		{
			_isInstance = ConstructingInstance;
		}

		public static T CreateInstance<T>()
		{
			ConstructingInstance = true;
			T result = UnitySerialisationUtils.CreateInstance<T>();
			ConstructingInstance = false;
			return result;
		}

		public static T CreateInstance<T>(T obj)
		{
			ConstructingInstance = true;
			T result = UnitySerialisationUtils.CreateInstance(obj);
			ConstructingInstance = false;
			return result;
		}

		public override void Destroy()
		{
			base.Destroy();
		}

		protected override bool ActuallyNeedsDestroyCalled()
		{
			return _isInstance;
		}
	}
}
