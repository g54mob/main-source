namespace LibTessDotNet
{
	public class NullPool : IPool
	{
		public override T Get<T>()
		{
			T val = new T();
			val.Init(this);
			return val;
		}

		public override void Register<T>(ITypePool typePool)
		{
		}

		public override void Return<T>(T obj)
		{
		}
	}
}
