using Ludiq;

namespace Bolt
{
	public interface IGraphEventListener
	{
		void StartListening(GraphStack stack);

		void StopListening(GraphStack stack);

		bool IsListening(GraphPointer pointer);
	}
}
