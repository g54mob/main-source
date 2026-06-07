using System;
using MalbersAnimations.Events;

namespace MalbersAnimations
{
	[Serializable]
	public class InteractionEvents
	{
		public GameObjectEvent OnInteractWithGO = new GameObjectEvent();

		public IntEvent OnInteractWith = new IntEvent();
	}
}
