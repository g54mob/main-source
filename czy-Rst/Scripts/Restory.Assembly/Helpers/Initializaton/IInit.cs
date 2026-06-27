namespace Helpers.Initializaton
{
	public interface IInit
	{
		void Initialize();
	}
	public interface IInit<T>
	{
		void Initialize(T arg);
	}
	public interface IInit<T0, T1>
	{
		void Initialize(T0 arg0, T1 arg1);
	}
	public interface IInit<T0, T1, T2>
	{
		void Initialize(T0 arg0, T1 arg1, T2 arg2);
	}
	public interface IInit<T0, T1, T2, T3>
	{
		void Initialize(T0 arg0, T1 arg1, T2 arg2, T3 arg3);
	}
}
