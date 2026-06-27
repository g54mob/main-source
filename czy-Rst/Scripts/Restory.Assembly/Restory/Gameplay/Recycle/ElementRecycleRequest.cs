using Restory.Gameplay.Elements;

namespace Restory.Gameplay.Recycle
{
	public class ElementRecycleRequest : IRecycleRequest
	{
		public IRecycleRequester Requester { get; }

		public ElementBase Element { get; }

		public ElementRecycleRequest(IRecycleRequester requester, ElementBase element)
		{
			Requester = requester;
			Element = element;
		}
	}
}
