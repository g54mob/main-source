namespace FractureField
{
	public interface IInitable
	{
		int InitPriority { get; }

		bool InitInStart { get; }

		bool InitCompleted { get; set; }

		void Init();
	}
}
