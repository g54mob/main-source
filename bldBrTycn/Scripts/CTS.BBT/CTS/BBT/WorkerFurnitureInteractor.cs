using UnityEngine;

namespace CTS.BBT
{
	public abstract class WorkerFurnitureInteractor : FurnitureInteractor, IContextActor
	{
		[field: SerializeField]
		public ContextActorData ContextActorData { get; private set; }
	}
}
