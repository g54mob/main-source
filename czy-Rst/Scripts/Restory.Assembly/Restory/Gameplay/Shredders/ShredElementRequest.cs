using Restory.Gameplay.Elements;

namespace Restory.Gameplay.Shredders
{
	public class ShredElementRequest : IShredRequest
	{
		public IShredRequester Requester { get; }

		public ElementBase Element { get; }

		public ShredElementRequest(IShredRequester requester, ElementBase element)
		{
			Requester = requester;
			Element = element;
		}
	}
}
