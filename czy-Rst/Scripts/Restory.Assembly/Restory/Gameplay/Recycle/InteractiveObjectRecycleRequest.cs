using Restory.Gameplay.InteractiveObjects;

namespace Restory.Gameplay.Recycle
{
	public class InteractiveObjectRecycleRequest : IRecycleRequest
	{
		public IRecycleRequester Requester { get; }

		public InteractiveObject InteractiveObject { get; }

		public InteractiveObjectRecycleRequest(IRecycleRequester requester, InteractiveObject interactiveObject)
		{
			Requester = requester;
			InteractiveObject = interactiveObject;
		}
	}
}
