namespace CTS.Core
{
	public interface IConstruct
	{
		void Construct();
	}
	public interface IConstruct<in TArg1>
	{
		void Construct(TArg1 arg1);
	}
	public interface IConstruct<in TArg1, in TArg2>
	{
		void Construct(TArg1 arg1, TArg2 arg2);
	}
	public interface IConstruct<in TArg1, in TArg2, in TArg3>
	{
		void Construct(TArg1 arg1, TArg2 arg2, TArg3 arg3);
	}
	public interface IConstruct<in TArg1, in TArg2, in TArg3, in TArg4>
	{
		void Construct(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
	}
}
