using Restory.Gameplay.InteractiveObjects;

namespace Restory.Gameplay.Shredders
{
	public class ShredInteractiveObjectRequest : IShredRequest
	{
		public IShredRequester Requester { get; }

		public InteractiveObject InteractiveObject { get; }

		public ShredInteractiveObjectRequest(IShredRequester requester, InteractiveObject interactiveObject)
		{
			Requester = requester;
			InteractiveObject = interactiveObject;
		}
	}
}
