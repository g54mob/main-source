namespace Polarith.AI.Move
{
	public interface IPercept<T>
	{
		bool Active { get; set; }

		void Receive(T data);
	}
}
